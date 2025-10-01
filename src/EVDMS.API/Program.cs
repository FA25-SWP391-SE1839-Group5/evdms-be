using System.Text;
using System.Text.Json.Serialization;
using EVDMS.API.Middlewares;
using EVDMS.BusinessLogicLayer;
using EVDMS.Common.Settings;
using EVDMS.DataAccessLayer.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace EVDMS.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder
                .Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EVDMS API", Version = "v1" });
                c.AddSecurityDefinition(
                    "Bearer",
                    new OpenApiSecurityScheme
                    {
                        Description =
                            "JWT Authorization header using the Bearer scheme. Example: 'Bearer {token}'",
                        Name = "Authorization",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.Http,
                        Scheme = "bearer",
                        BearerFormat = "JWT",
                    }
                );
                c.AddSecurityRequirement(
                    new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer",
                                },
                            },
                            Array.Empty<string>()
                        },
                    }
                );
            });

            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options
                    .UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
                    .UseSnakeCaseNamingConvention();
                ;
            });

            builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("Jwt"));
            builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("Email"));
            builder.Services.Configure<CloudinarySettings>(
                builder.Configuration.GetSection("Cloudinary")
            );

            builder
                .Services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    var jwtSettings = builder.Configuration.GetSection("Jwt").Get<JwtSettings>();
                    if (jwtSettings == null)
                    {
                        throw new InvalidOperationException(
                            "JWT settings are not configured properly."
                        );
                    }
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtSettings.Issuer,
                        ValidAudience = jwtSettings.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(jwtSettings.Key)
                        ),
                    };
                });

            builder.Services.AddServices();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(
                    "CorsPolicy",
                    builder =>
                    {
                        builder
                            .WithOrigins("http://localhost:5173")
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowCredentials();
                    }
                );
            });

            builder.Services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var errors = context
                        .ModelState.Values.SelectMany(v => v.Errors)
                        .Select(e => e.ErrorMessage)
                        .ToArray();
                    var response = new ApiResponse<string>(string.Join("; ", errors));
                    return new BadRequestObjectResult(response);
                };
            });

            var app = builder.Build();

            app.UseMiddleware<ApiExceptionMiddleware>();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseCors("CorsPolicy");

            if (app.Environment.IsProduction())
            {
                app.UseHttpsRedirection();
            }

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
