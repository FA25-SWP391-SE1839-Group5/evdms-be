using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EVDMS.DataAccessLayer.Data.Migrations
{
    /// <inheritdoc />
    public partial class _1Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false,
                        defaultValueSql: "CURRENT_TIMESTAMP"
                    ),
                    UpdatedAt = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false,
                        defaultValueSql: "CURRENT_TIMESTAMP"
                    ),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                }
            );

            migrationBuilder.CreateTable(
                name: "Dealers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DealerName = table.Column<string>(type: "text", nullable: false),
                    Region = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false,
                        defaultValueSql: "CURRENT_TIMESTAMP"
                    ),
                    UpdatedAt = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false,
                        defaultValueSql: "CURRENT_TIMESTAMP"
                    ),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dealers", x => x.Id);
                }
            );

            migrationBuilder.CreateTable(
                name: "FeatureCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoryName = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false,
                        defaultValueSql: "CURRENT_TIMESTAMP"
                    ),
                    UpdatedAt = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false,
                        defaultValueSql: "CURRENT_TIMESTAMP"
                    ),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeatureCategories", x => x.Id);
                }
            );

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleName = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false,
                        defaultValueSql: "CURRENT_TIMESTAMP"
                    ),
                    UpdatedAt = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false,
                        defaultValueSql: "CURRENT_TIMESTAMP"
                    ),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                }
            );

            migrationBuilder.CreateTable(
                name: "SpecCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false,
                        defaultValueSql: "CURRENT_TIMESTAMP"
                    ),
                    UpdatedAt = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false,
                        defaultValueSql: "CURRENT_TIMESTAMP"
                    ),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecCategories", x => x.Id);
                }
            );

            migrationBuilder.CreateTable(
                name: "VehicleColors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ColorName = table.Column<string>(type: "text", nullable: false),
                    HexCode = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false,
                        defaultValueSql: "CURRENT_TIMESTAMP"
                    ),
                    UpdatedAt = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false,
                        defaultValueSql: "CURRENT_TIMESTAMP"
                    ),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleColors", x => x.Id);
                }
            );

            migrationBuilder.CreateTable(
                name: "VehicleModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ModelName = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Year = table.Column<short>(type: "smallint", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false,
                        defaultValueSql: "CURRENT_TIMESTAMP"
                    ),
                    UpdatedAt = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false,
                        defaultValueSql: "CURRENT_TIMESTAMP"
                    ),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleModels", x => x.Id);
                }
            );

            migrationBuilder.CreateTable(
                name: "CustomerDealers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uuid", nullable: false),
                    DealerId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false,
                        defaultValueSql: "CURRENT_TIMESTAMP"
                    ),
                    UpdatedAt = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false,
                        defaultValueSql: "CURRENT_TIMESTAMP"
                    ),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerDealers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerDealers_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict
                    );
                    table.ForeignKey(
                        name: "FK_CustomerDealers_Dealers_DealerId",
                        column: x => x.DealerId,
                        principalTable: "Dealers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "DealerContracts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DealerId = table.Column<Guid>(type: "uuid", nullable: false),
                    StartDate = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false
                    ),
                    EndDate = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false
                    ),
                    SalesTarget = table.Column<decimal>(type: "numeric", nullable: false),
                    OutstandingDebt = table.Column<decimal>(type: "numeric", nullable: false),
                    CreatedAt = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false,
                        defaultValueSql: "CURRENT_TIMESTAMP"
                    ),
                    UpdatedAt = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false,
                        defaultValueSql: "CURRENT_TIMESTAMP"
                    ),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DealerContracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DealerContracts_Dealers_DealerId",
                        column: x => x.DealerId,
                        principalTable: "Dealers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "DealerOrders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DealerId = table.Column<Guid>(type: "uuid", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false,
                        defaultValueSql: "CURRENT_TIMESTAMP"
                    ),
                    UpdatedAt = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false,
                        defaultValueSql: "CURRENT_TIMESTAMP"
                    ),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DealerOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DealerOrders_Dealers_DealerId",
                        column: x => x.DealerId,
                        principalTable: "Dealers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uuid", nullable: false),
                    DealerId = table.Column<Guid>(type: "uuid", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false,
                        defaultValueSql: "CURRENT_TIMESTAMP"
                    ),
                    UpdatedAt = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false,
                        defaultValueSql: "CURRENT_TIMESTAMP"
                    ),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict
                    );
                    table.ForeignKey(
                        name: "FK_Feedbacks_Dealers_DealerId",
                        column: x => x.DealerId,
                        principalTable: "Dealers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "Promotions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DealerId = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    DiscountPercent = table.Column<decimal>(type: "numeric", nullable: false),
                    StartDate = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false
                    ),
                    EndDate = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false
                    ),
                    CreatedAt = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false,
                        defaultValueSql: "CURRENT_TIMESTAMP"
                    ),
                    UpdatedAt = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false,
                        defaultValueSql: "CURRENT_TIMESTAMP"
                    ),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promotions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Promotions_Dealers_DealerId",
                        column: x => x.DealerId,
                        principalTable: "Dealers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "Features",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    FeatureName = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false,
                        defaultValueSql: "CURRENT_TIMESTAMP"
                    ),
                    UpdatedAt = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false,
                        defaultValueSql: "CURRENT_TIMESTAMP"
                    ),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Features", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Features_FeatureCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "FeatureCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    DealerId = table.Column<Guid>(type: "uuid", nullable: true),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false,
                        defaultValueSql: "CURRENT_TIMESTAMP"
                    ),
                    UpdatedAt = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false,
                        defaultValueSql: "CURRENT_TIMESTAMP"
                    ),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Dealers_DealerId",
                        column: x => x.DealerId,
                        principalTable: "Dealers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict
                    );
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "Specs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SpecCategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    SpecName = table.Column<string>(type: "text", nullable: false),
                    Unit = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false,
                        defaultValueSql: "CURRENT_TIMESTAMP"
                    ),
                    UpdatedAt = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false,
                        defaultValueSql: "CURRENT_TIMESTAMP"
                    ),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Specs_SpecCategories_SpecCategoryId",
                        column: x => x.SpecCategoryId,
                        principalTable: "SpecCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "VehicleVariants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ModelId = table.Column<Guid>(type: "uuid", nullable: false),
                    VariantName = table.Column<string>(type: "text", nullable: false),
                    BasePrice = table.Column<decimal>(type: "numeric", nullable: false),
                    CreatedAt = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false,
                        defaultValueSql: "CURRENT_TIMESTAMP"
                    ),
                    UpdatedAt = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false,
                        defaultValueSql: "CURRENT_TIMESTAMP"
                    ),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleVariants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleVariants_VehicleModels_ModelId",
                        column: x => x.ModelId,
                        principalTable: "VehicleModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "Quotations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DealerId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uuid", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false,
                        defaultValueSql: "CURRENT_TIMESTAMP"
                    ),
                    UpdatedAt = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false,
                        defaultValueSql: "CURRENT_TIMESTAMP"
                    ),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Quotations_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict
                    );
                    table.ForeignKey(
                        name: "FK_Quotations_Dealers_DealerId",
                        column: x => x.DealerId,
                        principalTable: "Dealers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict
                    );
                    table.ForeignKey(
                        name: "FK_Quotations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "DealerOrderItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderId = table.Column<Guid>(type: "uuid", nullable: false),
                    VariantId = table.Column<Guid>(type: "uuid", nullable: false),
                    ColorId = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false,
                        defaultValueSql: "CURRENT_TIMESTAMP"
                    ),
                    UpdatedAt = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false,
                        defaultValueSql: "CURRENT_TIMESTAMP"
                    ),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DealerOrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DealerOrderItems_DealerOrders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "DealerOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict
                    );
                    table.ForeignKey(
                        name: "FK_DealerOrderItems_VehicleColors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "VehicleColors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict
                    );
                    table.ForeignKey(
                        name: "FK_DealerOrderItems_VehicleVariants_VariantId",
                        column: x => x.VariantId,
                        principalTable: "VehicleVariants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "VariantFeatures",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    VariantId = table.Column<Guid>(type: "uuid", nullable: false),
                    FeatureId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsAvailable = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false,
                        defaultValueSql: "CURRENT_TIMESTAMP"
                    ),
                    UpdatedAt = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false,
                        defaultValueSql: "CURRENT_TIMESTAMP"
                    ),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VariantFeatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VariantFeatures_Features_FeatureId",
                        column: x => x.FeatureId,
                        principalTable: "Features",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict
                    );
                    table.ForeignKey(
                        name: "FK_VariantFeatures_VehicleVariants_VariantId",
                        column: x => x.VariantId,
                        principalTable: "VehicleVariants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "VariantSpecs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    VariantId = table.Column<Guid>(type: "uuid", nullable: false),
                    SpecId = table.Column<Guid>(type: "uuid", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false,
                        defaultValueSql: "CURRENT_TIMESTAMP"
                    ),
                    UpdatedAt = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false,
                        defaultValueSql: "CURRENT_TIMESTAMP"
                    ),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VariantSpecs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VariantSpecs_Specs_SpecId",
                        column: x => x.SpecId,
                        principalTable: "Specs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict
                    );
                    table.ForeignKey(
                        name: "FK_VariantSpecs_VehicleVariants_VariantId",
                        column: x => x.VariantId,
                        principalTable: "VehicleVariants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    VariantId = table.Column<Guid>(type: "uuid", nullable: false),
                    ColorId = table.Column<Guid>(type: "uuid", nullable: false),
                    Vin = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false,
                        defaultValueSql: "CURRENT_TIMESTAMP"
                    ),
                    UpdatedAt = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false,
                        defaultValueSql: "CURRENT_TIMESTAMP"
                    ),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicles_VehicleColors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "VehicleColors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict
                    );
                    table.ForeignKey(
                        name: "FK_Vehicles_VehicleVariants_VariantId",
                        column: x => x.VariantId,
                        principalTable: "VehicleVariants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "DealerAllocations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DealerId = table.Column<Guid>(type: "uuid", nullable: false),
                    VehicleId = table.Column<Guid>(type: "uuid", nullable: false),
                    AllocationDate = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false
                    ),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false,
                        defaultValueSql: "CURRENT_TIMESTAMP"
                    ),
                    UpdatedAt = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false,
                        defaultValueSql: "CURRENT_TIMESTAMP"
                    ),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DealerAllocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DealerAllocations_Dealers_DealerId",
                        column: x => x.DealerId,
                        principalTable: "Dealers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict
                    );
                    table.ForeignKey(
                        name: "FK_DealerAllocations_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "OemInventories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    VehicleId = table.Column<Guid>(type: "uuid", nullable: false),
                    Location = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false,
                        defaultValueSql: "CURRENT_TIMESTAMP"
                    ),
                    UpdatedAt = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false,
                        defaultValueSql: "CURRENT_TIMESTAMP"
                    ),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OemInventories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OemInventories_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "SalesOrders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    QuotationId = table.Column<Guid>(type: "uuid", nullable: false),
                    DealerId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uuid", nullable: false),
                    VehicleId = table.Column<Guid>(type: "uuid", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false,
                        defaultValueSql: "CURRENT_TIMESTAMP"
                    ),
                    UpdatedAt = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false,
                        defaultValueSql: "CURRENT_TIMESTAMP"
                    ),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesOrders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict
                    );
                    table.ForeignKey(
                        name: "FK_SalesOrders_Dealers_DealerId",
                        column: x => x.DealerId,
                        principalTable: "Dealers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict
                    );
                    table.ForeignKey(
                        name: "FK_SalesOrders_Quotations_QuotationId",
                        column: x => x.QuotationId,
                        principalTable: "Quotations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict
                    );
                    table.ForeignKey(
                        name: "FK_SalesOrders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict
                    );
                    table.ForeignKey(
                        name: "FK_SalesOrders_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "TestDrives",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uuid", nullable: false),
                    DealerId = table.Column<Guid>(type: "uuid", nullable: false),
                    VehicleId = table.Column<Guid>(type: "uuid", nullable: false),
                    ScheduledAt = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false
                    ),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false,
                        defaultValueSql: "CURRENT_TIMESTAMP"
                    ),
                    UpdatedAt = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false,
                        defaultValueSql: "CURRENT_TIMESTAMP"
                    ),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestDrives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestDrives_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict
                    );
                    table.ForeignKey(
                        name: "FK_TestDrives_Dealers_DealerId",
                        column: x => x.DealerId,
                        principalTable: "Dealers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict
                    );
                    table.ForeignKey(
                        name: "FK_TestDrives_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "SalesContracts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SalesOrderId = table.Column<Guid>(type: "uuid", nullable: false),
                    ContractDate = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false
                    ),
                    TotalAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    CreatedAt = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false,
                        defaultValueSql: "CURRENT_TIMESTAMP"
                    ),
                    UpdatedAt = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false,
                        defaultValueSql: "CURRENT_TIMESTAMP"
                    ),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesContracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesContracts_SalesOrders_SalesOrderId",
                        column: x => x.SalesOrderId,
                        principalTable: "SalesOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SalesContractId = table.Column<Guid>(type: "uuid", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    PaymentDate = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false
                    ),
                    Method = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false,
                        defaultValueSql: "CURRENT_TIMESTAMP"
                    ),
                    UpdatedAt = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false,
                        defaultValueSql: "CURRENT_TIMESTAMP"
                    ),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_SalesContracts_SalesContractId",
                        column: x => x.SalesContractId,
                        principalTable: "SalesContracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict
                    );
                }
            );

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "Email", "FullName", "Phone" },
                values: new object[,]
                {
                    {
                        new Guid("10000000-0000-0000-0000-000000000001"),
                        "123 Lê Lợi, Quận 1, TP. Hồ Chí Minh",
                        "an.nguyen@email.com",
                        "Nguyễn Văn An",
                        "0901234567",
                    },
                    {
                        new Guid("10000000-0000-0000-0000-000000000002"),
                        "456 Nguyễn Trãi, Quận 5, TP. Hồ Chí Minh",
                        "ngoc.tran@email.com",
                        "Trần Thị Bích Ngọc",
                        "0912345678",
                    },
                    {
                        new Guid("10000000-0000-0000-0000-000000000003"),
                        "789 Cách Mạng Tháng 8, Quận 10, TP. Hồ Chí Minh",
                        "tuan.le@email.com",
                        "Lê Minh Tuấn",
                        "0923456789",
                    },
                    {
                        new Guid("10000000-0000-0000-0000-000000000004"),
                        "321 Điện Biên Phủ, Quận Bình Thạnh, TP. Hồ Chí Minh",
                        "huy.pham@email.com",
                        "Phạm Quang Huy",
                        "0934567890",
                    },
                    {
                        new Guid("10000000-0000-0000-0000-000000000005"),
                        "654 Võ Văn Tần, Quận 3, TP. Hồ Chí Minh",
                        "lan.vo@email.com",
                        "Võ Thị Mai Lan",
                        "0945678901",
                    },
                }
            );

            migrationBuilder.InsertData(
                table: "FeatureCategories",
                columns: new[] { "Id", "CategoryName" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), "Safety" },
                    { new Guid("22222222-2222-2222-2222-222222222222"), "Convenience" },
                    { new Guid("33333333-3333-3333-3333-333333333333"), "Entertainment" },
                    { new Guid("44444444-4444-4444-4444-444444444444"), "Exterior" },
                    { new Guid("55555555-5555-5555-5555-555555555555"), "Seating" },
                }
            );

            migrationBuilder.InsertData(
                table: "SpecCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), "Performance" },
                    { new Guid("22222222-2222-2222-2222-222222222222"), "Energy" },
                    { new Guid("33333333-3333-3333-3333-333333333333"), "Charging" },
                    { new Guid("44444444-4444-4444-4444-444444444444"), "Practicality" },
                }
            );

            migrationBuilder.InsertData(
                table: "VehicleColors",
                columns: new[] { "Id", "ColorName", "HexCode" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), "Red", "#FF0000" },
                    { new Guid("22222222-2222-2222-2222-222222222222"), "Blue", "#0000FF" },
                    { new Guid("33333333-3333-3333-3333-333333333333"), "Green", "#00FF00" },
                    { new Guid("44444444-4444-4444-4444-444444444444"), "Black", "#000000" },
                    { new Guid("55555555-5555-5555-5555-555555555555"), "White", "#FFFFFF" },
                    { new Guid("66666666-6666-6666-6666-666666666666"), "Silver", "#C0C0C0" },
                    { new Guid("77777777-7777-7777-7777-777777777777"), "Gray", "#808080" },
                    { new Guid("88888888-8888-8888-8888-888888888888"), "Yellow", "#FFFF00" },
                    { new Guid("99999999-9999-9999-9999-999999999999"), "Brown", "#8B4513" },
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "Orange", "#FFA500" },
                    { new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "Beige", "#F5F5DC" },
                }
            );

            migrationBuilder.InsertData(
                table: "VehicleModels",
                columns: new[] { "Id", "Description", "ImageUrl", "ModelName", "Year" },
                values: new object[,]
                {
                    {
                        new Guid("11111111-1111-1111-1111-111111111111"),
                        "A distinctive battery-electric compact crossover SUV, notable for its retro-futuristic design and being built on Hyundai's Electric Global Modular Platform (E-GMP) with 800V charging capability.",
                        "https://res.cloudinary.com/dchtww9gf/image/upload/v1758450493/Hyundai_Ioniq_5_f5npjl.jpg",
                        "Hyundai Ioniq 5",
                        (short)2021,
                    },
                    {
                        new Guid("22222222-2222-2222-2222-222222222222"),
                        "A battery-electric compact crossover SUV that draws design and naming inspiration from the Mustang line, offering a mix of sporty performance and SUV practicality.",
                        "https://res.cloudinary.com/dchtww9gf/image/upload/v1758450495/Ford_Mustang_Mach-E_cdvi8o.jpg",
                        "Ford Mustang Mach-E",
                        (short)2020,
                    },
                    {
                        new Guid("33333333-3333-3333-3333-333333333333"),
                        "A battery-electric compact crossover SUV, closely related to the Hyundai Ioniq 5 as it also uses the E-GMP platform, known for its sleek, crossover-coupe styling and fast charging.",
                        "https://res.cloudinary.com/dchtww9gf/image/upload/v1758450487/Kia_EV6_boehy3.jpg",
                        "Kia EV6",
                        (short)2021,
                    },
                    {
                        new Guid("44444444-4444-4444-4444-444444444444"),
                        "A battery-electric mid-size crossover SUV built on the GM Ultium platform, offering a sporty design and multiple drivetrain configurations (FWD, RWD, AWD).",
                        "https://res.cloudinary.com/dchtww9gf/image/upload/v1758450486/Chevrolet_Blazer_EV_v6t9tq.jpg",
                        "Chevrolet Blazer EV",
                        (short)2023,
                    },
                    {
                        new Guid("55555555-5555-5555-5555-555555555555"),
                        "A battery-electric four-door luxury sedan known for its focus on maximum driving range, spacious interior packaging, and high-performance capabilities, produced by a Silicon Valley startup.",
                        "https://res.cloudinary.com/dchtww9gf/image/upload/v1758450488/Lucid_Air_nur4uz.jpg",
                        "Lucid Air",
                        (short)2021,
                    },
                    {
                        new Guid("66666666-6666-6666-6666-666666666666"),
                        "A battery-electric compact crossover SUV that serves as Nissan's first dedicated zero-emissions SUV, featuring a modern, sleek design and available dual-motor e-4ORCE all-wheel drive.",
                        "https://res.cloudinary.com/dchtww9gf/image/upload/v1758450488/Nissan_Ariya_ds6ta3.jpg",
                        "Nissan Ariya",
                        (short)2022,
                    },
                    {
                        new Guid("77777777-7777-7777-7777-777777777777"),
                        "Porsche's first all-electric production vehicle, a high-performance luxury sports sedan (and shooting brake) known for its rapid acceleration, precise handling, and 800-volt electrical architecture.",
                        "https://res.cloudinary.com/dchtww9gf/image/upload/v1758450489/Porsche_Taycan_q2esmf.jpg",
                        "Porsche Taycan",
                        (short)2019,
                    },
                    {
                        new Guid("88888888-8888-8888-8888-888888888888"),
                        "A battery-electric compact executive car with a five-door liftback body style, closely related to the gasoline-powered BMW 4 Series Gran Coupé and offering a balance of luxury and performance.",
                        "https://res.cloudinary.com/dchtww9gf/image/upload/v1758450487/BMW_i4_fackc5.jpg",
                        "BMW i4",
                        (short)2021,
                    },
                    {
                        new Guid("99999999-9999-9999-9999-999999999999"),
                        "A battery-electric compact crossover SUV that shares many components with the Model 3, offering more utility, a higher seating position, and optional three-row seating.",
                        "https://res.cloudinary.com/dchtww9gf/image/upload/v1758450497/Tesla_Model_Y_m9txrs.jpg",
                        "Tesla Model Y",
                        (short)2020,
                    },
                    {
                        new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                        "A battery-electric mid-size sedan with a fastback body style, marketed as a more affordable electric vehicle than Tesla's previous models.",
                        "https://res.cloudinary.com/dchtww9gf/image/upload/v1758450495/Tesla_Model_3_evqd0p.jpg",
                        "Tesla Model 3",
                        (short)2017,
                    },
                }
            );

            migrationBuilder.InsertData(
                table: "Features",
                columns: new[] { "Id", "CategoryId", "FeatureName" },
                values: new object[,]
                {
                    {
                        new Guid("10000000-0000-0000-0000-000000000001"),
                        new Guid("22222222-2222-2222-2222-222222222222"),
                        "Adaptive Cruise Control",
                    },
                    {
                        new Guid("10000000-0000-0000-0000-000000000002"),
                        new Guid("22222222-2222-2222-2222-222222222222"),
                        "Cooled Seats",
                    },
                    {
                        new Guid("10000000-0000-0000-0000-000000000003"),
                        new Guid("22222222-2222-2222-2222-222222222222"),
                        "Heated Seats",
                    },
                    {
                        new Guid("10000000-0000-0000-0000-000000000004"),
                        new Guid("22222222-2222-2222-2222-222222222222"),
                        "Heated Steering Wheel",
                    },
                    {
                        new Guid("10000000-0000-0000-0000-000000000005"),
                        new Guid("22222222-2222-2222-2222-222222222222"),
                        "Keyless Entry",
                    },
                    {
                        new Guid("10000000-0000-0000-0000-000000000006"),
                        new Guid("22222222-2222-2222-2222-222222222222"),
                        "Keyless Start",
                    },
                    {
                        new Guid("10000000-0000-0000-0000-000000000007"),
                        new Guid("22222222-2222-2222-2222-222222222222"),
                        "Navigation System",
                    },
                    {
                        new Guid("10000000-0000-0000-0000-000000000008"),
                        new Guid("22222222-2222-2222-2222-222222222222"),
                        "Power Liftgate",
                    },
                    {
                        new Guid("10000000-0000-0000-0000-000000000009"),
                        new Guid("22222222-2222-2222-2222-222222222222"),
                        "Rain Sensing Wipers",
                    },
                    {
                        new Guid("20000000-0000-0000-0000-000000000001"),
                        new Guid("33333333-3333-3333-3333-333333333333"),
                        "Android Auto®",
                    },
                    {
                        new Guid("20000000-0000-0000-0000-000000000002"),
                        new Guid("33333333-3333-3333-3333-333333333333"),
                        "Apple CarPlay®",
                    },
                    {
                        new Guid("20000000-0000-0000-0000-000000000003"),
                        new Guid("33333333-3333-3333-3333-333333333333"),
                        "Bluetooth®",
                    },
                    {
                        new Guid("20000000-0000-0000-0000-000000000004"),
                        new Guid("33333333-3333-3333-3333-333333333333"),
                        "HomeLink",
                    },
                    {
                        new Guid("20000000-0000-0000-0000-000000000005"),
                        new Guid("33333333-3333-3333-3333-333333333333"),
                        "Premium Sound System",
                    },
                    {
                        new Guid("20000000-0000-0000-0000-000000000006"),
                        new Guid("33333333-3333-3333-3333-333333333333"),
                        "USB Port",
                    },
                    {
                        new Guid("20000000-0000-0000-0000-000000000007"),
                        new Guid("33333333-3333-3333-3333-333333333333"),
                        "WiFi Hotspot",
                    },
                    {
                        new Guid("20000000-0000-0000-0000-000000000008"),
                        new Guid("33333333-3333-3333-3333-333333333333"),
                        "Satellite Radio",
                    },
                    {
                        new Guid("20000000-0000-0000-0000-000000000009"),
                        new Guid("33333333-3333-3333-3333-333333333333"),
                        "AUX Input",
                    },
                    {
                        new Guid("30000000-0000-0000-0000-000000000001"),
                        new Guid("44444444-4444-4444-4444-444444444444"),
                        "Alloy Wheels",
                    },
                    {
                        new Guid("30000000-0000-0000-0000-000000000002"),
                        new Guid("44444444-4444-4444-4444-444444444444"),
                        "Tow Hitch",
                    },
                    {
                        new Guid("30000000-0000-0000-0000-000000000003"),
                        new Guid("44444444-4444-4444-4444-444444444444"),
                        "Fog Lights",
                    },
                    {
                        new Guid("30000000-0000-0000-0000-000000000004"),
                        new Guid("44444444-4444-4444-4444-444444444444"),
                        "Roof Rails",
                    },
                    {
                        new Guid("30000000-0000-0000-0000-000000000005"),
                        new Guid("44444444-4444-4444-4444-444444444444"),
                        "Sunroof",
                    },
                    {
                        new Guid("30000000-0000-0000-0000-000000000006"),
                        new Guid("44444444-4444-4444-4444-444444444444"),
                        "Power Mirrors",
                    },
                    {
                        new Guid("30000000-0000-0000-0000-000000000007"),
                        new Guid("44444444-4444-4444-4444-444444444444"),
                        "Rear Spoiler",
                    },
                    {
                        new Guid("30000000-0000-0000-0000-000000000008"),
                        new Guid("44444444-4444-4444-4444-444444444444"),
                        "Automatic Headlights",
                    },
                    {
                        new Guid("30000000-0000-0000-0000-000000000009"),
                        new Guid("44444444-4444-4444-4444-444444444444"),
                        "Daytime Running Lights",
                    },
                    {
                        new Guid("40000000-0000-0000-0000-000000000001"),
                        new Guid("11111111-1111-1111-1111-111111111111"),
                        "Automatic Emergency Braking",
                    },
                    {
                        new Guid("40000000-0000-0000-0000-000000000002"),
                        new Guid("11111111-1111-1111-1111-111111111111"),
                        "Backup Camera",
                    },
                    {
                        new Guid("40000000-0000-0000-0000-000000000003"),
                        new Guid("11111111-1111-1111-1111-111111111111"),
                        "Blind Spot Monitor",
                    },
                    {
                        new Guid("40000000-0000-0000-0000-000000000004"),
                        new Guid("11111111-1111-1111-1111-111111111111"),
                        "Brake Assist",
                    },
                    {
                        new Guid("40000000-0000-0000-0000-000000000005"),
                        new Guid("11111111-1111-1111-1111-111111111111"),
                        "LED Headlights",
                    },
                    {
                        new Guid("40000000-0000-0000-0000-000000000006"),
                        new Guid("11111111-1111-1111-1111-111111111111"),
                        "Lane Departure Warning",
                    },
                    {
                        new Guid("40000000-0000-0000-0000-000000000007"),
                        new Guid("11111111-1111-1111-1111-111111111111"),
                        "Rear Cross Traffic Alert",
                    },
                    {
                        new Guid("40000000-0000-0000-0000-000000000008"),
                        new Guid("11111111-1111-1111-1111-111111111111"),
                        "Stability Control",
                    },
                    {
                        new Guid("40000000-0000-0000-0000-000000000009"),
                        new Guid("11111111-1111-1111-1111-111111111111"),
                        "Traction Control",
                    },
                    {
                        new Guid("40000000-0000-0000-0000-000000000010"),
                        new Guid("11111111-1111-1111-1111-111111111111"),
                        "Parking Sensors",
                    },
                    {
                        new Guid("50000000-0000-0000-0000-000000000001"),
                        new Guid("55555555-5555-5555-5555-555555555555"),
                        "Leather Seats",
                    },
                    {
                        new Guid("50000000-0000-0000-0000-000000000002"),
                        new Guid("55555555-5555-5555-5555-555555555555"),
                        "Memory Seat",
                    },
                    {
                        new Guid("50000000-0000-0000-0000-000000000003"),
                        new Guid("55555555-5555-5555-5555-555555555555"),
                        "Power Driver Seat",
                    },
                    {
                        new Guid("50000000-0000-0000-0000-000000000004"),
                        new Guid("55555555-5555-5555-5555-555555555555"),
                        "Power Passenger Seat",
                    },
                    {
                        new Guid("50000000-0000-0000-0000-000000000005"),
                        new Guid("55555555-5555-5555-5555-555555555555"),
                        "Heated Rear Seats",
                    },
                    {
                        new Guid("50000000-0000-0000-0000-000000000006"),
                        new Guid("55555555-5555-5555-5555-555555555555"),
                        "Ventilated Seats",
                    },
                    {
                        new Guid("50000000-0000-0000-0000-000000000007"),
                        new Guid("55555555-5555-5555-5555-555555555555"),
                        "Split Folding Rear Seat",
                    },
                    {
                        new Guid("50000000-0000-0000-0000-000000000008"),
                        new Guid("55555555-5555-5555-5555-555555555555"),
                        "Adjustable Lumbar Support",
                    },
                    {
                        new Guid("50000000-0000-0000-0000-000000000009"),
                        new Guid("55555555-5555-5555-5555-555555555555"),
                        "Bucket Seats",
                    },
                    {
                        new Guid("50000000-0000-0000-0000-000000000010"),
                        new Guid("55555555-5555-5555-5555-555555555555"),
                        "Third Row Seating",
                    },
                }
            );

            migrationBuilder.InsertData(
                table: "Specs",
                columns: new[] { "Id", "SpecCategoryId", "SpecName", "Unit" },
                values: new object[,]
                {
                    {
                        new Guid("11111111-1111-1111-1111-111111111110"),
                        new Guid("11111111-1111-1111-1111-111111111111"),
                        "Horsepower",
                        "hp",
                    },
                    {
                        new Guid("11111111-1111-1111-1111-111111111111"),
                        new Guid("11111111-1111-1111-1111-111111111111"),
                        "Torque",
                        "Nm",
                    },
                    {
                        new Guid("11111111-1111-1111-1111-111111111112"),
                        new Guid("11111111-1111-1111-1111-111111111111"),
                        "0-100 km/h Acceleration",
                        "s",
                    },
                    {
                        new Guid("11111111-1111-1111-1111-111111111113"),
                        new Guid("11111111-1111-1111-1111-111111111111"),
                        "Drive Type",
                        null,
                    },
                    {
                        new Guid("11111111-1111-1111-1111-111111111114"),
                        new Guid("11111111-1111-1111-1111-111111111111"),
                        "Motor Type",
                        null,
                    },
                    {
                        new Guid("11111111-1111-1111-1111-111111111115"),
                        new Guid("11111111-1111-1111-1111-111111111111"),
                        "Top Speed",
                        "km/h",
                    },
                    {
                        new Guid("11111111-1111-1111-1111-111111111116"),
                        new Guid("11111111-1111-1111-1111-111111111111"),
                        "Curb Weight",
                        "kg",
                    },
                    {
                        new Guid("22222222-2222-2222-2222-222222222220"),
                        new Guid("22222222-2222-2222-2222-222222222222"),
                        "Battery Capacity",
                        "kWh",
                    },
                    {
                        new Guid("22222222-2222-2222-2222-222222222221"),
                        new Guid("22222222-2222-2222-2222-222222222222"),
                        "Range",
                        "km",
                    },
                    {
                        new Guid("22222222-2222-2222-2222-222222222222"),
                        new Guid("22222222-2222-2222-2222-222222222222"),
                        "Efficiency",
                        "Wh/km",
                    },
                    {
                        new Guid("22222222-2222-2222-2222-222222222223"),
                        new Guid("22222222-2222-2222-2222-222222222222"),
                        "Battery Chemistry",
                        null,
                    },
                    {
                        new Guid("22222222-2222-2222-2222-222222222224"),
                        new Guid("22222222-2222-2222-2222-222222222222"),
                        "Battery Voltage Architecture",
                        "V",
                    },
                    {
                        new Guid("22222222-2222-2222-2222-222222222225"),
                        new Guid("22222222-2222-2222-2222-222222222222"),
                        "Regenerative Braking Capacity",
                        null,
                    },
                    {
                        new Guid("33333333-3333-3333-3333-333333333330"),
                        new Guid("33333333-3333-3333-3333-333333333333"),
                        "Max AC Charging Rate",
                        "kW",
                    },
                    {
                        new Guid("33333333-3333-3333-3333-333333333331"),
                        new Guid("33333333-3333-3333-3333-333333333333"),
                        "Max DC Fast Charging Rate",
                        "kW",
                    },
                    {
                        new Guid("33333333-3333-3333-3333-333333333332"),
                        new Guid("33333333-3333-3333-3333-333333333333"),
                        "DC Fast Charging Time (10-80%)",
                        "min",
                    },
                    {
                        new Guid("33333333-3333-3333-3333-333333333333"),
                        new Guid("33333333-3333-3333-3333-333333333333"),
                        "AC Charging Time (0-100%)",
                        "h",
                    },
                    {
                        new Guid("33333333-3333-3333-3333-333333333334"),
                        new Guid("33333333-3333-3333-3333-333333333333"),
                        "Charging Port Type(s)",
                        null,
                    },
                    {
                        new Guid("44444444-4444-4444-4444-444444444440"),
                        new Guid("44444444-4444-4444-4444-444444444444"),
                        "Towing Capacity",
                        "kg",
                    },
                    {
                        new Guid("44444444-4444-4444-4444-444444444441"),
                        new Guid("44444444-4444-4444-4444-444444444444"),
                        "Frunk Volume",
                        "L",
                    },
                    {
                        new Guid("44444444-4444-4444-4444-444444444442"),
                        new Guid("44444444-4444-4444-4444-444444444444"),
                        "Cargo Volume",
                        "L",
                    },
                    {
                        new Guid("44444444-4444-4444-4444-444444444443"),
                        new Guid("44444444-4444-4444-4444-444444444444"),
                        "Heat Pump",
                        null,
                    },
                    {
                        new Guid("44444444-4444-4444-4444-444444444444"),
                        new Guid("44444444-4444-4444-4444-444444444444"),
                        "V2L (Vehicle-to-Load) Capability",
                        "kW",
                    },
                }
            );

            migrationBuilder.InsertData(
                table: "VehicleVariants",
                columns: new[] { "Id", "BasePrice", "ModelId", "VariantName" },
                values: new object[,]
                {
                    {
                        new Guid("11111111-1111-1111-1111-111111111101"),
                        42600m,
                        new Guid("11111111-1111-1111-1111-111111111111"),
                        "Hyundai Ioniq 5 SE (Standard Range RWD)",
                    },
                    {
                        new Guid("11111111-1111-1111-1111-111111111102"),
                        49600m,
                        new Guid("11111111-1111-1111-1111-111111111111"),
                        "Hyundai Ioniq 5 SEL (RWD)",
                    },
                    {
                        new Guid("11111111-1111-1111-1111-111111111103"),
                        54300m,
                        new Guid("11111111-1111-1111-1111-111111111111"),
                        "Hyundai Ioniq 5 Limited (RWD)",
                    },
                    {
                        new Guid("22222222-2222-2222-2222-222222222201"),
                        37995m,
                        new Guid("22222222-2222-2222-2222-222222222222"),
                        "Ford Mustang Mach-E Select (RWD)",
                    },
                    {
                        new Guid("22222222-2222-2222-2222-222222222202"),
                        41995m,
                        new Guid("22222222-2222-2222-2222-222222222222"),
                        "Ford Mustang Mach-E Premium (RWD, Standard Range)",
                    },
                    {
                        new Guid("22222222-2222-2222-2222-222222222203"),
                        54000m,
                        new Guid("22222222-2222-2222-2222-222222222222"),
                        "Ford Mustang Mach-E California Route 1",
                    },
                    {
                        new Guid("22222222-2222-2222-2222-222222222204"),
                        54495m,
                        new Guid("22222222-2222-2222-2222-222222222222"),
                        "Ford Mustang Mach-E GT (AWD)",
                    },
                    {
                        new Guid("33333333-3333-3333-3333-333333333301"),
                        42900m,
                        new Guid("33333333-3333-3333-3333-333333333333"),
                        "Kia EV6 Light (RWD)",
                    },
                    {
                        new Guid("33333333-3333-3333-3333-333333333302"),
                        50300m,
                        new Guid("33333333-3333-3333-3333-333333333333"),
                        "Kia EV6 Wind (RWD)",
                    },
                    {
                        new Guid("33333333-3333-3333-3333-333333333303"),
                        63800m,
                        new Guid("33333333-3333-3333-3333-333333333333"),
                        "Kia EV6 GT (AWD)",
                    },
                    {
                        new Guid("44444444-4444-4444-4444-444444444401"),
                        44600m,
                        new Guid("44444444-4444-4444-4444-444444444444"),
                        "Chevrolet Blazer EV LT (FWD)",
                    },
                    {
                        new Guid("44444444-4444-4444-4444-444444444402"),
                        49900m,
                        new Guid("44444444-4444-4444-4444-444444444444"),
                        "Chevrolet Blazer EV RS (RWD)",
                    },
                    {
                        new Guid("44444444-4444-4444-4444-444444444403"),
                        60600m,
                        new Guid("44444444-4444-4444-4444-444444444444"),
                        "Chevrolet Blazer EV SS (AWD)",
                    },
                    {
                        new Guid("55555555-5555-5555-5555-555555555501"),
                        69900m,
                        new Guid("55555555-5555-5555-5555-555555555555"),
                        "Lucid Air Pure (RWD)",
                    },
                    {
                        new Guid("55555555-5555-5555-5555-555555555502"),
                        78900m,
                        new Guid("55555555-5555-5555-5555-555555555555"),
                        "Lucid Air Touring (AWD)",
                    },
                    {
                        new Guid("55555555-5555-5555-5555-555555555503"),
                        110900m,
                        new Guid("55555555-5555-5555-5555-555555555555"),
                        "Lucid Air Grand Touring (AWD)",
                    },
                    {
                        new Guid("55555555-5555-5555-5555-555555555504"),
                        249000m,
                        new Guid("55555555-5555-5555-5555-555555555555"),
                        "Lucid Air Sapphire (AWD)",
                    },
                    {
                        new Guid("66666666-6666-6666-6666-666666666601"),
                        39770m,
                        new Guid("66666666-6666-6666-6666-666666666666"),
                        "Nissan Ariya Engage (Standard Range FWD)",
                    },
                    {
                        new Guid("66666666-6666-6666-6666-666666666602"),
                        44370m,
                        new Guid("66666666-6666-6666-6666-666666666666"),
                        "Nissan Ariya Evolve+ (Extended Range FWD)",
                    },
                    {
                        new Guid("66666666-6666-6666-6666-666666666603"),
                        49260m,
                        new Guid("66666666-6666-6666-6666-666666666666"),
                        "Nissan Ariya Empower+",
                    },
                    {
                        new Guid("66666666-6666-6666-6666-666666666604"),
                        52380m,
                        new Guid("66666666-6666-6666-6666-666666666666"),
                        "Nissan Ariya Premiere",
                    },
                    {
                        new Guid("66666666-6666-6666-6666-666666666605"),
                        54370m,
                        new Guid("66666666-6666-6666-6666-666666666666"),
                        "Nissan Ariya Platinum+ (Extended Range AWD)",
                    },
                    {
                        new Guid("77777777-7777-7777-7777-777777777701"),
                        99400m,
                        new Guid("77777777-7777-7777-7777-777777777777"),
                        "Porsche Taycan Base (RWD Sedan)",
                    },
                    {
                        new Guid("77777777-7777-7777-7777-777777777702"),
                        118500m,
                        new Guid("77777777-7777-7777-7777-777777777777"),
                        "Porsche Taycan 4S (AWD Sedan)",
                    },
                    {
                        new Guid("77777777-7777-7777-7777-777777777703"),
                        147900m,
                        new Guid("77777777-7777-7777-7777-777777777777"),
                        "Porsche Taycan GTS (AWD Sedan)",
                    },
                    {
                        new Guid("77777777-7777-7777-7777-777777777704"),
                        173600m,
                        new Guid("77777777-7777-7777-7777-777777777777"),
                        "Porsche Taycan Turbo (AWD Sedan)",
                    },
                    {
                        new Guid("77777777-7777-7777-7777-777777777705"),
                        209000m,
                        new Guid("77777777-7777-7777-7777-777777777777"),
                        "Porsche Taycan Turbo S (AWD Sedan)",
                    },
                    {
                        new Guid("88888888-8888-8888-8888-888888888801"),
                        52200m,
                        new Guid("88888888-8888-8888-8888-888888888888"),
                        "BMW i4 eDrive35 (RWD)",
                    },
                    {
                        new Guid("88888888-8888-8888-8888-888888888802"),
                        57900m,
                        new Guid("88888888-8888-8888-8888-888888888888"),
                        "BMW i4 eDrive40 (RWD)",
                    },
                    {
                        new Guid("88888888-8888-8888-8888-888888888803"),
                        62300m,
                        new Guid("88888888-8888-8888-8888-888888888888"),
                        "BMW i4 xDrive40 (AWD)",
                    },
                    {
                        new Guid("88888888-8888-8888-8888-888888888804"),
                        70700m,
                        new Guid("88888888-8888-8888-8888-888888888888"),
                        "BMW i4 M50 (AWD)",
                    },
                    {
                        new Guid("99999999-9999-9999-9999-999999999901"),
                        46630m,
                        new Guid("99999999-9999-9999-9999-999999999999"),
                        "Tesla Model Y Long Range All-Wheel Drive",
                    },
                    {
                        new Guid("99999999-9999-9999-9999-999999999902"),
                        57000m,
                        new Guid("99999999-9999-9999-9999-999999999999"),
                        "Tesla Model Y Performance",
                    },
                    {
                        new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa01"),
                        54990m,
                        new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                        "Tesla Model 3 Performance",
                    },
                }
            );

            migrationBuilder.InsertData(
                table: "VariantSpecs",
                columns: new[] { "Id", "SpecId", "Value", "VariantId" },
                values: new object[,]
                {
                    {
                        new Guid("11111111-1111-1111-1111-000000000000"),
                        new Guid("11111111-1111-1111-1111-111111111110"),
                        "168",
                        new Guid("11111111-1111-1111-1111-111111111101"),
                    },
                    {
                        new Guid("11111111-1111-1111-1111-000000000001"),
                        new Guid("11111111-1111-1111-1111-111111111111"),
                        "350",
                        new Guid("11111111-1111-1111-1111-111111111101"),
                    },
                    {
                        new Guid("11111111-1111-1111-1111-000000000002"),
                        new Guid("11111111-1111-1111-1111-111111111112"),
                        "~8.5",
                        new Guid("11111111-1111-1111-1111-111111111101"),
                    },
                    {
                        new Guid("11111111-1111-1111-1111-000000000003"),
                        new Guid("11111111-1111-1111-1111-111111111113"),
                        "RWD",
                        new Guid("11111111-1111-1111-1111-111111111101"),
                    },
                    {
                        new Guid("11111111-1111-1111-1111-000000000004"),
                        new Guid("11111111-1111-1111-1111-111111111114"),
                        "Permanent Magnet Synchronous",
                        new Guid("11111111-1111-1111-1111-111111111101"),
                    },
                    {
                        new Guid("11111111-1111-1111-1111-000000000005"),
                        new Guid("11111111-1111-1111-1111-111111111115"),
                        "185",
                        new Guid("11111111-1111-1111-1111-111111111101"),
                    },
                    {
                        new Guid("11111111-1111-1111-1111-000000000006"),
                        new Guid("11111111-1111-1111-1111-111111111116"),
                        "~1830",
                        new Guid("11111111-1111-1111-1111-111111111101"),
                    },
                    {
                        new Guid("11111111-1111-1111-1111-000000000007"),
                        new Guid("22222222-2222-2222-2222-222222222220"),
                        "58",
                        new Guid("11111111-1111-1111-1111-111111111101"),
                    },
                    {
                        new Guid("11111111-1111-1111-1111-000000000008"),
                        new Guid("22222222-2222-2222-2222-222222222221"),
                        "~354",
                        new Guid("11111111-1111-1111-1111-111111111101"),
                    },
                    {
                        new Guid("11111111-1111-1111-1111-000000000009"),
                        new Guid("22222222-2222-2222-2222-222222222222"),
                        "~164",
                        new Guid("11111111-1111-1111-1111-111111111101"),
                    },
                    {
                        new Guid("11111111-1111-1111-1111-00000000000a"),
                        new Guid("22222222-2222-2222-2222-222222222223"),
                        "Lithium-ion (NMC)",
                        new Guid("11111111-1111-1111-1111-111111111101"),
                    },
                    {
                        new Guid("11111111-1111-1111-1111-00000000000b"),
                        new Guid("22222222-2222-2222-2222-222222222224"),
                        "800",
                        new Guid("11111111-1111-1111-1111-111111111101"),
                    },
                    {
                        new Guid("11111111-1111-1111-1111-00000000000c"),
                        new Guid("22222222-2222-2222-2222-222222222225"),
                        "Adjustable (paddle-controlled)",
                        new Guid("11111111-1111-1111-1111-111111111101"),
                    },
                    {
                        new Guid("11111111-1111-1111-1111-00000000000d"),
                        new Guid("33333333-3333-3333-3333-333333333330"),
                        "11",
                        new Guid("11111111-1111-1111-1111-111111111101"),
                    },
                    {
                        new Guid("11111111-1111-1111-1111-00000000000e"),
                        new Guid("33333333-3333-3333-3333-333333333331"),
                        "350",
                        new Guid("11111111-1111-1111-1111-111111111101"),
                    },
                    {
                        new Guid("11111111-1111-1111-1111-00000000000f"),
                        new Guid("33333333-3333-3333-3333-333333333332"),
                        "~18",
                        new Guid("11111111-1111-1111-1111-111111111101"),
                    },
                    {
                        new Guid("11111111-1111-1111-1111-000000000010"),
                        new Guid("33333333-3333-3333-3333-333333333333"),
                        "~6",
                        new Guid("11111111-1111-1111-1111-111111111101"),
                    },
                    {
                        new Guid("11111111-1111-1111-1111-000000000011"),
                        new Guid("33333333-3333-3333-3333-333333333334"),
                        "CCS Combo",
                        new Guid("11111111-1111-1111-1111-111111111101"),
                    },
                    {
                        new Guid("11111111-1111-1111-1111-000000000012"),
                        new Guid("44444444-4444-4444-4444-444444444441"),
                        "~57",
                        new Guid("11111111-1111-1111-1111-111111111101"),
                    },
                    {
                        new Guid("11111111-1111-1111-1111-000000000013"),
                        new Guid("44444444-4444-4444-4444-444444444442"),
                        "~531 (max 1,587 seats down)",
                        new Guid("11111111-1111-1111-1111-111111111101"),
                    },
                    {
                        new Guid("11111111-1111-1111-1111-000000000014"),
                        new Guid("44444444-4444-4444-4444-444444444443"),
                        "Optional",
                        new Guid("11111111-1111-1111-1111-111111111101"),
                    },
                    {
                        new Guid("11111111-1111-1111-1111-000000000015"),
                        new Guid("44444444-4444-4444-4444-444444444444"),
                        "3.6",
                        new Guid("11111111-1111-1111-1111-111111111101"),
                    },
                    {
                        new Guid("11111111-1111-1111-1111-000000000016"),
                        new Guid("11111111-1111-1111-1111-111111111110"),
                        "225",
                        new Guid("11111111-1111-1111-1111-111111111102"),
                    },
                    {
                        new Guid("11111111-1111-1111-1111-000000000017"),
                        new Guid("11111111-1111-1111-1111-111111111111"),
                        "350",
                        new Guid("11111111-1111-1111-1111-111111111102"),
                    },
                    {
                        new Guid("11111111-1111-1111-1111-000000000018"),
                        new Guid("11111111-1111-1111-1111-111111111112"),
                        "~7.4",
                        new Guid("11111111-1111-1111-1111-111111111102"),
                    },
                    {
                        new Guid("11111111-1111-1111-1111-000000000019"),
                        new Guid("11111111-1111-1111-1111-111111111113"),
                        "RWD",
                        new Guid("11111111-1111-1111-1111-111111111102"),
                    },
                    {
                        new Guid("11111111-1111-1111-1111-00000000001a"),
                        new Guid("11111111-1111-1111-1111-111111111114"),
                        "Permanent Magnet Synchronous",
                        new Guid("11111111-1111-1111-1111-111111111102"),
                    },
                    {
                        new Guid("11111111-1111-1111-1111-00000000001b"),
                        new Guid("11111111-1111-1111-1111-111111111115"),
                        "185",
                        new Guid("11111111-1111-1111-1111-111111111102"),
                    },
                    {
                        new Guid("11111111-1111-1111-1111-00000000001c"),
                        new Guid("11111111-1111-1111-1111-111111111116"),
                        "~1910",
                        new Guid("11111111-1111-1111-1111-111111111102"),
                    },
                    {
                        new Guid("11111111-1111-1111-1111-00000000001d"),
                        new Guid("22222222-2222-2222-2222-222222222220"),
                        "77.4",
                        new Guid("11111111-1111-1111-1111-111111111102"),
                    },
                    {
                        new Guid("11111111-1111-1111-1111-00000000001e"),
                        new Guid("22222222-2222-2222-2222-222222222221"),
                        "~488",
                        new Guid("11111111-1111-1111-1111-111111111102"),
                    },
                    {
                        new Guid("11111111-1111-1111-1111-00000000001f"),
                        new Guid("22222222-2222-2222-2222-222222222222"),
                        "~159",
                        new Guid("11111111-1111-1111-1111-111111111102"),
                    },
                    {
                        new Guid("11111111-1111-1111-1111-000000000020"),
                        new Guid("22222222-2222-2222-2222-222222222223"),
                        "Lithium-ion (NMC)",
                        new Guid("11111111-1111-1111-1111-111111111102"),
                    },
                    {
                        new Guid("11111111-1111-1111-1111-000000000021"),
                        new Guid("22222222-2222-2222-2222-222222222224"),
                        "800",
                        new Guid("11111111-1111-1111-1111-111111111102"),
                    },
                    {
                        new Guid("11111111-1111-1111-1111-000000000022"),
                        new Guid("22222222-2222-2222-2222-222222222225"),
                        "Adjustable",
                        new Guid("11111111-1111-1111-1111-111111111102"),
                    },
                    {
                        new Guid("11111111-1111-1111-1111-000000000023"),
                        new Guid("33333333-3333-3333-3333-333333333330"),
                        "11",
                        new Guid("11111111-1111-1111-1111-111111111102"),
                    },
                    {
                        new Guid("11111111-1111-1111-1111-000000000024"),
                        new Guid("33333333-3333-3333-3333-333333333331"),
                        "350",
                        new Guid("11111111-1111-1111-1111-111111111102"),
                    },
                    {
                        new Guid("11111111-1111-1111-1111-000000000025"),
                        new Guid("33333333-3333-3333-3333-333333333332"),
                        "~18",
                        new Guid("11111111-1111-1111-1111-111111111102"),
                    },
                    {
                        new Guid("11111111-1111-1111-1111-000000000026"),
                        new Guid("33333333-3333-3333-3333-333333333333"),
                        "~7",
                        new Guid("11111111-1111-1111-1111-111111111102"),
                    },
                    {
                        new Guid("11111111-1111-1111-1111-000000000027"),
                        new Guid("33333333-3333-3333-3333-333333333334"),
                        "CCS Combo",
                        new Guid("11111111-1111-1111-1111-111111111102"),
                    },
                    {
                        new Guid("11111111-1111-1111-1111-000000000028"),
                        new Guid("44444444-4444-4444-4444-444444444441"),
                        "~57",
                        new Guid("11111111-1111-1111-1111-111111111102"),
                    },
                    {
                        new Guid("11111111-1111-1111-1111-000000000029"),
                        new Guid("44444444-4444-4444-4444-444444444442"),
                        "Same",
                        new Guid("11111111-1111-1111-1111-111111111102"),
                    },
                    {
                        new Guid("11111111-1111-1111-1111-00000000002a"),
                        new Guid("44444444-4444-4444-4444-444444444443"),
                        "Optional",
                        new Guid("11111111-1111-1111-1111-111111111102"),
                    },
                    {
                        new Guid("11111111-1111-1111-1111-00000000002b"),
                        new Guid("44444444-4444-4444-4444-444444444444"),
                        "3.6",
                        new Guid("11111111-1111-1111-1111-111111111102"),
                    },
                    {
                        new Guid("11111111-1111-1111-1111-00000000002c"),
                        new Guid("11111111-1111-1111-1111-111111111110"),
                        "225",
                        new Guid("11111111-1111-1111-1111-111111111103"),
                    },
                    {
                        new Guid("11111111-1111-1111-1111-00000000002d"),
                        new Guid("11111111-1111-1111-1111-111111111111"),
                        "350",
                        new Guid("11111111-1111-1111-1111-111111111103"),
                    },
                    {
                        new Guid("11111111-1111-1111-1111-00000000002e"),
                        new Guid("11111111-1111-1111-1111-111111111112"),
                        "~7.4",
                        new Guid("11111111-1111-1111-1111-111111111103"),
                    },
                    {
                        new Guid("11111111-1111-1111-1111-00000000002f"),
                        new Guid("11111111-1111-1111-1111-111111111113"),
                        "RWD",
                        new Guid("11111111-1111-1111-1111-111111111103"),
                    },
                    {
                        new Guid("11111111-1111-1111-1111-000000000030"),
                        new Guid("11111111-1111-1111-1111-111111111114"),
                        "Permanent Magnet Synchronous",
                        new Guid("11111111-1111-1111-1111-111111111103"),
                    },
                    {
                        new Guid("11111111-1111-1111-1111-000000000031"),
                        new Guid("11111111-1111-1111-1111-111111111115"),
                        "185",
                        new Guid("11111111-1111-1111-1111-111111111103"),
                    },
                    {
                        new Guid("11111111-1111-1111-1111-000000000032"),
                        new Guid("11111111-1111-1111-1111-111111111116"),
                        "~1950",
                        new Guid("11111111-1111-1111-1111-111111111103"),
                    },
                    {
                        new Guid("11111111-1111-1111-1111-000000000033"),
                        new Guid("22222222-2222-2222-2222-222222222220"),
                        "77.4",
                        new Guid("11111111-1111-1111-1111-111111111103"),
                    },
                    {
                        new Guid("11111111-1111-1111-1111-000000000034"),
                        new Guid("22222222-2222-2222-2222-222222222221"),
                        "~488",
                        new Guid("11111111-1111-1111-1111-111111111103"),
                    },
                    {
                        new Guid("11111111-1111-1111-1111-000000000035"),
                        new Guid("22222222-2222-2222-2222-222222222222"),
                        "~159",
                        new Guid("11111111-1111-1111-1111-111111111103"),
                    },
                    {
                        new Guid("11111111-1111-1111-1111-000000000036"),
                        new Guid("22222222-2222-2222-2222-222222222223"),
                        "Lithium-ion (NMC)",
                        new Guid("11111111-1111-1111-1111-111111111103"),
                    },
                    {
                        new Guid("11111111-1111-1111-1111-000000000037"),
                        new Guid("22222222-2222-2222-2222-222222222224"),
                        "800",
                        new Guid("11111111-1111-1111-1111-111111111103"),
                    },
                    {
                        new Guid("11111111-1111-1111-1111-000000000038"),
                        new Guid("22222222-2222-2222-2222-222222222225"),
                        "Adjustable",
                        new Guid("11111111-1111-1111-1111-111111111103"),
                    },
                    {
                        new Guid("11111111-1111-1111-1111-000000000039"),
                        new Guid("33333333-3333-3333-3333-333333333330"),
                        "11",
                        new Guid("11111111-1111-1111-1111-111111111103"),
                    },
                    {
                        new Guid("11111111-1111-1111-1111-00000000003a"),
                        new Guid("33333333-3333-3333-3333-333333333331"),
                        "350",
                        new Guid("11111111-1111-1111-1111-111111111103"),
                    },
                    {
                        new Guid("11111111-1111-1111-1111-00000000003b"),
                        new Guid("33333333-3333-3333-3333-333333333332"),
                        "~18",
                        new Guid("11111111-1111-1111-1111-111111111103"),
                    },
                    {
                        new Guid("11111111-1111-1111-1111-00000000003c"),
                        new Guid("33333333-3333-3333-3333-333333333333"),
                        "~7",
                        new Guid("11111111-1111-1111-1111-111111111103"),
                    },
                    {
                        new Guid("11111111-1111-1111-1111-00000000003d"),
                        new Guid("33333333-3333-3333-3333-333333333334"),
                        "CCS Combo",
                        new Guid("11111111-1111-1111-1111-111111111103"),
                    },
                    {
                        new Guid("11111111-1111-1111-1111-00000000003e"),
                        new Guid("44444444-4444-4444-4444-444444444441"),
                        "~57",
                        new Guid("11111111-1111-1111-1111-111111111103"),
                    },
                    {
                        new Guid("11111111-1111-1111-1111-00000000003f"),
                        new Guid("44444444-4444-4444-4444-444444444442"),
                        "Same",
                        new Guid("11111111-1111-1111-1111-111111111103"),
                    },
                    {
                        new Guid("11111111-1111-1111-1111-000000000040"),
                        new Guid("44444444-4444-4444-4444-444444444443"),
                        "Standard",
                        new Guid("11111111-1111-1111-1111-111111111103"),
                    },
                    {
                        new Guid("11111111-1111-1111-1111-000000000041"),
                        new Guid("44444444-4444-4444-4444-444444444444"),
                        "3.6",
                        new Guid("11111111-1111-1111-1111-111111111103"),
                    },
                    {
                        new Guid("22222222-2222-2222-2222-000000000000"),
                        new Guid("11111111-1111-1111-1111-111111111110"),
                        "~264",
                        new Guid("22222222-2222-2222-2222-222222222201"),
                    },
                    {
                        new Guid("22222222-2222-2222-2222-000000000001"),
                        new Guid("11111111-1111-1111-1111-111111111111"),
                        "~430",
                        new Guid("22222222-2222-2222-2222-222222222201"),
                    },
                    {
                        new Guid("22222222-2222-2222-2222-000000000002"),
                        new Guid("11111111-1111-1111-1111-111111111112"),
                        "~6.3–6.9",
                        new Guid("22222222-2222-2222-2222-222222222201"),
                    },
                    {
                        new Guid("22222222-2222-2222-2222-000000000003"),
                        new Guid("11111111-1111-1111-1111-111111111113"),
                        "RWD",
                        new Guid("22222222-2222-2222-2222-222222222201"),
                    },
                    {
                        new Guid("22222222-2222-2222-2222-000000000004"),
                        new Guid("11111111-1111-1111-1111-111111111114"),
                        "Single permanent magnet",
                        new Guid("22222222-2222-2222-2222-222222222201"),
                    },
                    {
                        new Guid("22222222-2222-2222-2222-000000000005"),
                        new Guid("11111111-1111-1111-1111-111111111115"),
                        "180",
                        new Guid("22222222-2222-2222-2222-222222222201"),
                    },
                    {
                        new Guid("22222222-2222-2222-2222-000000000006"),
                        new Guid("11111111-1111-1111-1111-111111111116"),
                        "~2100",
                        new Guid("22222222-2222-2222-2222-222222222201"),
                    },
                    {
                        new Guid("22222222-2222-2222-2222-000000000007"),
                        new Guid("22222222-2222-2222-2222-222222222220"),
                        "~72",
                        new Guid("22222222-2222-2222-2222-222222222201"),
                    },
                    {
                        new Guid("22222222-2222-2222-2222-000000000008"),
                        new Guid("22222222-2222-2222-2222-222222222221"),
                        "~402",
                        new Guid("22222222-2222-2222-2222-222222222201"),
                    },
                    {
                        new Guid("22222222-2222-2222-2222-000000000009"),
                        new Guid("22222222-2222-2222-2222-222222222222"),
                        "~172",
                        new Guid("22222222-2222-2222-2222-222222222201"),
                    },
                    {
                        new Guid("22222222-2222-2222-2222-00000000000a"),
                        new Guid("22222222-2222-2222-2222-222222222223"),
                        "LFP (Standard Range)",
                        new Guid("22222222-2222-2222-2222-222222222201"),
                    },
                    {
                        new Guid("22222222-2222-2222-2222-00000000000b"),
                        new Guid("22222222-2222-2222-2222-222222222224"),
                        "400",
                        new Guid("22222222-2222-2222-2222-222222222201"),
                    },
                    {
                        new Guid("22222222-2222-2222-2222-00000000000c"),
                        new Guid("22222222-2222-2222-2222-222222222225"),
                        "Adjustable (1‑pedal drive)",
                        new Guid("22222222-2222-2222-2222-222222222201"),
                    },
                    {
                        new Guid("22222222-2222-2222-2222-00000000000d"),
                        new Guid("33333333-3333-3333-3333-333333333330"),
                        "11",
                        new Guid("22222222-2222-2222-2222-222222222201"),
                    },
                    {
                        new Guid("22222222-2222-2222-2222-00000000000e"),
                        new Guid("33333333-3333-3333-3333-333333333331"),
                        "115–150",
                        new Guid("22222222-2222-2222-2222-222222222201"),
                    },
                    {
                        new Guid("22222222-2222-2222-2222-00000000000f"),
                        new Guid("33333333-3333-3333-3333-333333333332"),
                        "~32–35",
                        new Guid("22222222-2222-2222-2222-222222222201"),
                    },
                    {
                        new Guid("22222222-2222-2222-2222-000000000010"),
                        new Guid("33333333-3333-3333-3333-333333333333"),
                        "~7–9",
                        new Guid("22222222-2222-2222-2222-222222222201"),
                    },
                    {
                        new Guid("22222222-2222-2222-2222-000000000011"),
                        new Guid("33333333-3333-3333-3333-333333333334"),
                        "CCS Combo",
                        new Guid("22222222-2222-2222-2222-222222222201"),
                    },
                    {
                        new Guid("22222222-2222-2222-2222-000000000012"),
                        new Guid("44444444-4444-4444-4444-444444444440"),
                        "~1000",
                        new Guid("22222222-2222-2222-2222-222222222201"),
                    },
                    {
                        new Guid("22222222-2222-2222-2222-000000000013"),
                        new Guid("44444444-4444-4444-4444-444444444441"),
                        "~100",
                        new Guid("22222222-2222-2222-2222-222222222201"),
                    },
                    {
                        new Guid("22222222-2222-2222-2222-000000000014"),
                        new Guid("44444444-4444-4444-4444-444444444442"),
                        "402 / 1420 max",
                        new Guid("22222222-2222-2222-2222-222222222201"),
                    },
                    {
                        new Guid("22222222-2222-2222-2222-000000000015"),
                        new Guid("44444444-4444-4444-4444-444444444443"),
                        "Optional",
                        new Guid("22222222-2222-2222-2222-222222222201"),
                    },
                    {
                        new Guid("22222222-2222-2222-2222-000000000016"),
                        new Guid("11111111-1111-1111-1111-111111111110"),
                        "~265",
                        new Guid("22222222-2222-2222-2222-222222222202"),
                    },
                    {
                        new Guid("22222222-2222-2222-2222-000000000017"),
                        new Guid("11111111-1111-1111-1111-111111111111"),
                        "430",
                        new Guid("22222222-2222-2222-2222-222222222202"),
                    },
                    {
                        new Guid("22222222-2222-2222-2222-000000000018"),
                        new Guid("11111111-1111-1111-1111-111111111112"),
                        "~6.3–6.9",
                        new Guid("22222222-2222-2222-2222-222222222202"),
                    },
                    {
                        new Guid("22222222-2222-2222-2222-000000000019"),
                        new Guid("11111111-1111-1111-1111-111111111113"),
                        "RWD",
                        new Guid("22222222-2222-2222-2222-222222222202"),
                    },
                    {
                        new Guid("22222222-2222-2222-2222-00000000001a"),
                        new Guid("11111111-1111-1111-1111-111111111114"),
                        "Single permanent magnet",
                        new Guid("22222222-2222-2222-2222-222222222202"),
                    },
                    {
                        new Guid("22222222-2222-2222-2222-00000000001b"),
                        new Guid("11111111-1111-1111-1111-111111111115"),
                        "180",
                        new Guid("22222222-2222-2222-2222-222222222202"),
                    },
                    {
                        new Guid("22222222-2222-2222-2222-00000000001c"),
                        new Guid("11111111-1111-1111-1111-111111111116"),
                        "~2120",
                        new Guid("22222222-2222-2222-2222-222222222202"),
                    },
                    {
                        new Guid("22222222-2222-2222-2222-00000000001d"),
                        new Guid("22222222-2222-2222-2222-222222222220"),
                        "~72",
                        new Guid("22222222-2222-2222-2222-222222222202"),
                    },
                    {
                        new Guid("22222222-2222-2222-2222-00000000001e"),
                        new Guid("22222222-2222-2222-2222-222222222221"),
                        "~402",
                        new Guid("22222222-2222-2222-2222-222222222202"),
                    },
                    {
                        new Guid("22222222-2222-2222-2222-00000000001f"),
                        new Guid("22222222-2222-2222-2222-222222222222"),
                        "~172",
                        new Guid("22222222-2222-2222-2222-222222222202"),
                    },
                    {
                        new Guid("22222222-2222-2222-2222-000000000020"),
                        new Guid("22222222-2222-2222-2222-222222222223"),
                        "LFP (Standard Range)",
                        new Guid("22222222-2222-2222-2222-222222222202"),
                    },
                    {
                        new Guid("22222222-2222-2222-2222-000000000021"),
                        new Guid("22222222-2222-2222-2222-222222222224"),
                        "400",
                        new Guid("22222222-2222-2222-2222-222222222202"),
                    },
                    {
                        new Guid("22222222-2222-2222-2222-000000000022"),
                        new Guid("22222222-2222-2222-2222-222222222225"),
                        "Adjustable",
                        new Guid("22222222-2222-2222-2222-222222222202"),
                    },
                    {
                        new Guid("22222222-2222-2222-2222-000000000023"),
                        new Guid("33333333-3333-3333-3333-333333333330"),
                        "11",
                        new Guid("22222222-2222-2222-2222-222222222202"),
                    },
                    {
                        new Guid("22222222-2222-2222-2222-000000000024"),
                        new Guid("33333333-3333-3333-3333-333333333331"),
                        "115–150",
                        new Guid("22222222-2222-2222-2222-222222222202"),
                    },
                    {
                        new Guid("22222222-2222-2222-2222-000000000025"),
                        new Guid("33333333-3333-3333-3333-333333333332"),
                        "~32–35",
                        new Guid("22222222-2222-2222-2222-222222222202"),
                    },
                    {
                        new Guid("22222222-2222-2222-2222-000000000026"),
                        new Guid("33333333-3333-3333-3333-333333333333"),
                        "~7–9",
                        new Guid("22222222-2222-2222-2222-222222222202"),
                    },
                    {
                        new Guid("22222222-2222-2222-2222-000000000027"),
                        new Guid("33333333-3333-3333-3333-333333333334"),
                        "CCS Combo",
                        new Guid("22222222-2222-2222-2222-222222222202"),
                    },
                    {
                        new Guid("22222222-2222-2222-2222-000000000028"),
                        new Guid("44444444-4444-4444-4444-444444444440"),
                        "~1000",
                        new Guid("22222222-2222-2222-2222-222222222202"),
                    },
                    {
                        new Guid("22222222-2222-2222-2222-000000000029"),
                        new Guid("44444444-4444-4444-4444-444444444441"),
                        "~100",
                        new Guid("22222222-2222-2222-2222-222222222202"),
                    },
                    {
                        new Guid("22222222-2222-2222-2222-00000000002a"),
                        new Guid("44444444-4444-4444-4444-444444444442"),
                        "402 / 1420 max",
                        new Guid("22222222-2222-2222-2222-222222222202"),
                    },
                    {
                        new Guid("22222222-2222-2222-2222-00000000002b"),
                        new Guid("44444444-4444-4444-4444-444444444443"),
                        "Optional",
                        new Guid("22222222-2222-2222-2222-222222222202"),
                    },
                    {
                        new Guid("22222222-2222-2222-2222-00000000002c"),
                        new Guid("11111111-1111-1111-1111-111111111110"),
                        "346",
                        new Guid("22222222-2222-2222-2222-222222222203"),
                    },
                    {
                        new Guid("22222222-2222-2222-2222-00000000002d"),
                        new Guid("11111111-1111-1111-1111-111111111111"),
                        "580",
                        new Guid("22222222-2222-2222-2222-222222222203"),
                    },
                    {
                        new Guid("22222222-2222-2222-2222-00000000002e"),
                        new Guid("11111111-1111-1111-1111-111111111112"),
                        "~5.1",
                        new Guid("22222222-2222-2222-2222-222222222203"),
                    },
                    {
                        new Guid("22222222-2222-2222-2222-00000000002f"),
                        new Guid("11111111-1111-1111-1111-111111111113"),
                        "AWD",
                        new Guid("22222222-2222-2222-2222-222222222203"),
                    },
                    {
                        new Guid("22222222-2222-2222-2222-000000000030"),
                        new Guid("11111111-1111-1111-1111-111111111114"),
                        "Dual permanent magnet",
                        new Guid("22222222-2222-2222-2222-222222222203"),
                    },
                    {
                        new Guid("22222222-2222-2222-2222-000000000031"),
                        new Guid("11111111-1111-1111-1111-111111111115"),
                        "180",
                        new Guid("22222222-2222-2222-2222-222222222203"),
                    },
                    {
                        new Guid("22222222-2222-2222-2222-000000000032"),
                        new Guid("11111111-1111-1111-1111-111111111116"),
                        "~2145",
                        new Guid("22222222-2222-2222-2222-222222222203"),
                    },
                    {
                        new Guid("22222222-2222-2222-2222-000000000033"),
                        new Guid("22222222-2222-2222-2222-222222222220"),
                        "~91",
                        new Guid("22222222-2222-2222-2222-222222222203"),
                    },
                    {
                        new Guid("22222222-2222-2222-2222-000000000034"),
                        new Guid("22222222-2222-2222-2222-222222222221"),
                        "~505",
                        new Guid("22222222-2222-2222-2222-222222222203"),
                    },
                    {
                        new Guid("22222222-2222-2222-2222-000000000035"),
                        new Guid("22222222-2222-2222-2222-222222222222"),
                        "~200",
                        new Guid("22222222-2222-2222-2222-222222222203"),
                    },
                    {
                        new Guid("22222222-2222-2222-2222-000000000036"),
                        new Guid("22222222-2222-2222-2222-222222222223"),
                        "NMC (Extended Range)",
                        new Guid("22222222-2222-2222-2222-222222222203"),
                    },
                    {
                        new Guid("22222222-2222-2222-2222-000000000037"),
                        new Guid("22222222-2222-2222-2222-222222222224"),
                        "400",
                        new Guid("22222222-2222-2222-2222-222222222203"),
                    },
                    {
                        new Guid("22222222-2222-2222-2222-000000000038"),
                        new Guid("22222222-2222-2222-2222-222222222225"),
                        "Adjustable",
                        new Guid("22222222-2222-2222-2222-222222222203"),
                    },
                    {
                        new Guid("22222222-2222-2222-2222-000000000039"),
                        new Guid("33333333-3333-3333-3333-333333333330"),
                        "11",
                        new Guid("22222222-2222-2222-2222-222222222203"),
                    },
                    {
                        new Guid("22222222-2222-2222-2222-00000000003a"),
                        new Guid("33333333-3333-3333-3333-333333333331"),
                        "150",
                        new Guid("22222222-2222-2222-2222-222222222203"),
                    },
                    {
                        new Guid("22222222-2222-2222-2222-00000000003b"),
                        new Guid("33333333-3333-3333-3333-333333333332"),
                        "~38",
                        new Guid("22222222-2222-2222-2222-222222222203"),
                    },
                    {
                        new Guid("22222222-2222-2222-2222-00000000003c"),
                        new Guid("33333333-3333-3333-3333-333333333333"),
                        "~10–11",
                        new Guid("22222222-2222-2222-2222-222222222203"),
                    },
                    {
                        new Guid("22222222-2222-2222-2222-00000000003d"),
                        new Guid("33333333-3333-3333-3333-333333333334"),
                        "CCS Combo",
                        new Guid("22222222-2222-2222-2222-222222222203"),
                    },
                    {
                        new Guid("22222222-2222-2222-2222-00000000003e"),
                        new Guid("44444444-4444-4444-4444-444444444440"),
                        "~1000",
                        new Guid("22222222-2222-2222-2222-222222222203"),
                    },
                    {
                        new Guid("22222222-2222-2222-2222-00000000003f"),
                        new Guid("44444444-4444-4444-4444-444444444441"),
                        "~100",
                        new Guid("22222222-2222-2222-2222-222222222203"),
                    },
                    {
                        new Guid("22222222-2222-2222-2222-000000000040"),
                        new Guid("44444444-4444-4444-4444-444444444442"),
                        "841 / 1823 max",
                        new Guid("22222222-2222-2222-2222-222222222203"),
                    },
                    {
                        new Guid("22222222-2222-2222-2222-000000000041"),
                        new Guid("44444444-4444-4444-4444-444444444443"),
                        "Standard",
                        new Guid("22222222-2222-2222-2222-222222222203"),
                    },
                    {
                        new Guid("22222222-2222-2222-2222-000000000042"),
                        new Guid("11111111-1111-1111-1111-111111111110"),
                        "480",
                        new Guid("22222222-2222-2222-2222-222222222204"),
                    },
                    {
                        new Guid("22222222-2222-2222-2222-000000000043"),
                        new Guid("11111111-1111-1111-1111-111111111111"),
                        "813",
                        new Guid("22222222-2222-2222-2222-222222222204"),
                    },
                    {
                        new Guid("22222222-2222-2222-2222-000000000044"),
                        new Guid("11111111-1111-1111-1111-111111111112"),
                        "4.4",
                        new Guid("22222222-2222-2222-2222-222222222204"),
                    },
                    {
                        new Guid("22222222-2222-2222-2222-000000000045"),
                        new Guid("11111111-1111-1111-1111-111111111113"),
                        "AWD",
                        new Guid("22222222-2222-2222-2222-222222222204"),
                    },
                    {
                        new Guid("22222222-2222-2222-2222-000000000046"),
                        new Guid("11111111-1111-1111-1111-111111111114"),
                        "Dual permanent magnet",
                        new Guid("22222222-2222-2222-2222-222222222204"),
                    },
                    {
                        new Guid("22222222-2222-2222-2222-000000000047"),
                        new Guid("11111111-1111-1111-1111-111111111115"),
                        "200",
                        new Guid("22222222-2222-2222-2222-222222222204"),
                    },
                    {
                        new Guid("22222222-2222-2222-2222-000000000048"),
                        new Guid("11111111-1111-1111-1111-111111111116"),
                        "~2273",
                        new Guid("22222222-2222-2222-2222-222222222204"),
                    },
                    {
                        new Guid("22222222-2222-2222-2222-000000000049"),
                        new Guid("22222222-2222-2222-2222-222222222220"),
                        "~88",
                        new Guid("22222222-2222-2222-2222-222222222204"),
                    },
                    {
                        new Guid("22222222-2222-2222-2222-00000000004a"),
                        new Guid("22222222-2222-2222-2222-222222222221"),
                        "~450",
                        new Guid("22222222-2222-2222-2222-222222222204"),
                    },
                    {
                        new Guid("22222222-2222-2222-2222-00000000004b"),
                        new Guid("22222222-2222-2222-2222-222222222222"),
                        "~230",
                        new Guid("22222222-2222-2222-2222-222222222204"),
                    },
                    {
                        new Guid("22222222-2222-2222-2222-00000000004c"),
                        new Guid("22222222-2222-2222-2222-222222222223"),
                        "NMC (Extended Range)",
                        new Guid("22222222-2222-2222-2222-222222222204"),
                    },
                    {
                        new Guid("22222222-2222-2222-2222-00000000004d"),
                        new Guid("22222222-2222-2222-2222-222222222224"),
                        "400",
                        new Guid("22222222-2222-2222-2222-222222222204"),
                    },
                    {
                        new Guid("22222222-2222-2222-2222-00000000004e"),
                        new Guid("22222222-2222-2222-2222-222222222225"),
                        "Adjustable",
                        new Guid("22222222-2222-2222-2222-222222222204"),
                    },
                    {
                        new Guid("22222222-2222-2222-2222-00000000004f"),
                        new Guid("33333333-3333-3333-3333-333333333330"),
                        "11",
                        new Guid("22222222-2222-2222-2222-222222222204"),
                    },
                    {
                        new Guid("22222222-2222-2222-2222-000000000050"),
                        new Guid("33333333-3333-3333-3333-333333333331"),
                        "150",
                        new Guid("22222222-2222-2222-2222-222222222204"),
                    },
                    {
                        new Guid("22222222-2222-2222-2222-000000000051"),
                        new Guid("33333333-3333-3333-3333-333333333332"),
                        "~38",
                        new Guid("22222222-2222-2222-2222-222222222204"),
                    },
                    {
                        new Guid("22222222-2222-2222-2222-000000000052"),
                        new Guid("33333333-3333-3333-3333-333333333333"),
                        "~10",
                        new Guid("22222222-2222-2222-2222-222222222204"),
                    },
                    {
                        new Guid("22222222-2222-2222-2222-000000000053"),
                        new Guid("33333333-3333-3333-3333-333333333334"),
                        "CCS Combo",
                        new Guid("22222222-2222-2222-2222-222222222204"),
                    },
                    {
                        new Guid("22222222-2222-2222-2222-000000000054"),
                        new Guid("44444444-4444-4444-4444-444444444440"),
                        "~750",
                        new Guid("22222222-2222-2222-2222-222222222204"),
                    },
                    {
                        new Guid("22222222-2222-2222-2222-000000000055"),
                        new Guid("44444444-4444-4444-4444-444444444441"),
                        "~100",
                        new Guid("22222222-2222-2222-2222-222222222204"),
                    },
                    {
                        new Guid("22222222-2222-2222-2222-000000000056"),
                        new Guid("44444444-4444-4444-4444-444444444442"),
                        "402 / 1420 max",
                        new Guid("22222222-2222-2222-2222-222222222204"),
                    },
                    {
                        new Guid("22222222-2222-2222-2222-000000000057"),
                        new Guid("44444444-4444-4444-4444-444444444443"),
                        "Standard",
                        new Guid("22222222-2222-2222-2222-222222222204"),
                    },
                    {
                        new Guid("33333333-3333-3333-3333-000000000000"),
                        new Guid("11111111-1111-1111-1111-111111111110"),
                        "167",
                        new Guid("33333333-3333-3333-3333-333333333301"),
                    },
                    {
                        new Guid("33333333-3333-3333-3333-000000000001"),
                        new Guid("11111111-1111-1111-1111-111111111111"),
                        "350",
                        new Guid("33333333-3333-3333-3333-333333333301"),
                    },
                    {
                        new Guid("33333333-3333-3333-3333-000000000002"),
                        new Guid("11111111-1111-1111-1111-111111111112"),
                        "~8.3",
                        new Guid("33333333-3333-3333-3333-333333333301"),
                    },
                    {
                        new Guid("33333333-3333-3333-3333-000000000003"),
                        new Guid("11111111-1111-1111-1111-111111111113"),
                        "RWD",
                        new Guid("33333333-3333-3333-3333-333333333301"),
                    },
                    {
                        new Guid("33333333-3333-3333-3333-000000000004"),
                        new Guid("11111111-1111-1111-1111-111111111114"),
                        "Permanent Magnet Synchronous",
                        new Guid("33333333-3333-3333-3333-333333333301"),
                    },
                    {
                        new Guid("33333333-3333-3333-3333-000000000005"),
                        new Guid("11111111-1111-1111-1111-111111111115"),
                        "185",
                        new Guid("33333333-3333-3333-3333-333333333301"),
                    },
                    {
                        new Guid("33333333-3333-3333-3333-000000000006"),
                        new Guid("11111111-1111-1111-1111-111111111116"),
                        "~1875–1880",
                        new Guid("33333333-3333-3333-3333-333333333301"),
                    },
                    {
                        new Guid("33333333-3333-3333-3333-000000000007"),
                        new Guid("22222222-2222-2222-2222-222222222220"),
                        "58–63",
                        new Guid("33333333-3333-3333-3333-333333333301"),
                    },
                    {
                        new Guid("33333333-3333-3333-3333-000000000008"),
                        new Guid("22222222-2222-2222-2222-222222222221"),
                        "~381",
                        new Guid("33333333-3333-3333-3333-333333333301"),
                    },
                    {
                        new Guid("33333333-3333-3333-3333-000000000009"),
                        new Guid("22222222-2222-2222-2222-222222222222"),
                        "~165",
                        new Guid("33333333-3333-3333-3333-333333333301"),
                    },
                    {
                        new Guid("33333333-3333-3333-3333-00000000000a"),
                        new Guid("22222222-2222-2222-2222-222222222223"),
                        "Lithium‑ion (NMC)",
                        new Guid("33333333-3333-3333-3333-333333333301"),
                    },
                    {
                        new Guid("33333333-3333-3333-3333-00000000000b"),
                        new Guid("22222222-2222-2222-2222-222222222224"),
                        "~523",
                        new Guid("33333333-3333-3333-3333-333333333301"),
                    },
                    {
                        new Guid("33333333-3333-3333-3333-00000000000c"),
                        new Guid("22222222-2222-2222-2222-222222222225"),
                        "Adjustable (i‑Pedal)",
                        new Guid("33333333-3333-3333-3333-333333333301"),
                    },
                    {
                        new Guid("33333333-3333-3333-3333-00000000000d"),
                        new Guid("33333333-3333-3333-3333-333333333330"),
                        "11",
                        new Guid("33333333-3333-3333-3333-333333333301"),
                    },
                    {
                        new Guid("33333333-3333-3333-3333-00000000000e"),
                        new Guid("33333333-3333-3333-3333-333333333331"),
                        "180",
                        new Guid("33333333-3333-3333-3333-333333333301"),
                    },
                    {
                        new Guid("33333333-3333-3333-3333-00000000000f"),
                        new Guid("33333333-3333-3333-3333-333333333332"),
                        "~20",
                        new Guid("33333333-3333-3333-3333-333333333301"),
                    },
                    {
                        new Guid("33333333-3333-3333-3333-000000000010"),
                        new Guid("33333333-3333-3333-3333-333333333333"),
                        "~6",
                        new Guid("33333333-3333-3333-3333-333333333301"),
                    },
                    {
                        new Guid("33333333-3333-3333-3333-000000000011"),
                        new Guid("33333333-3333-3333-3333-333333333334"),
                        "CCS Combo",
                        new Guid("33333333-3333-3333-3333-333333333301"),
                    },
                    {
                        new Guid("33333333-3333-3333-3333-000000000012"),
                        new Guid("44444444-4444-4444-4444-444444444441"),
                        "~52",
                        new Guid("33333333-3333-3333-3333-333333333301"),
                    },
                    {
                        new Guid("33333333-3333-3333-3333-000000000013"),
                        new Guid("44444444-4444-4444-4444-444444444442"),
                        "520 / 1300+ seats down",
                        new Guid("33333333-3333-3333-3333-333333333301"),
                    },
                    {
                        new Guid("33333333-3333-3333-3333-000000000014"),
                        new Guid("44444444-4444-4444-4444-444444444443"),
                        "Optional",
                        new Guid("33333333-3333-3333-3333-333333333301"),
                    },
                    {
                        new Guid("33333333-3333-3333-3333-000000000015"),
                        new Guid("44444444-4444-4444-4444-444444444444"),
                        "3.6",
                        new Guid("33333333-3333-3333-3333-333333333301"),
                    },
                    {
                        new Guid("33333333-3333-3333-3333-000000000016"),
                        new Guid("11111111-1111-1111-1111-111111111110"),
                        "225",
                        new Guid("33333333-3333-3333-3333-333333333302"),
                    },
                    {
                        new Guid("33333333-3333-3333-3333-000000000017"),
                        new Guid("11111111-1111-1111-1111-111111111111"),
                        "350",
                        new Guid("33333333-3333-3333-3333-333333333302"),
                    },
                    {
                        new Guid("33333333-3333-3333-3333-000000000018"),
                        new Guid("11111111-1111-1111-1111-111111111112"),
                        "~7.2",
                        new Guid("33333333-3333-3333-3333-333333333302"),
                    },
                    {
                        new Guid("33333333-3333-3333-3333-000000000019"),
                        new Guid("11111111-1111-1111-1111-111111111113"),
                        "RWD",
                        new Guid("33333333-3333-3333-3333-333333333302"),
                    },
                    {
                        new Guid("33333333-3333-3333-3333-00000000001a"),
                        new Guid("11111111-1111-1111-1111-111111111114"),
                        "Permanent Magnet Synchronous",
                        new Guid("33333333-3333-3333-3333-333333333302"),
                    },
                    {
                        new Guid("33333333-3333-3333-3333-00000000001b"),
                        new Guid("11111111-1111-1111-1111-111111111115"),
                        "185",
                        new Guid("33333333-3333-3333-3333-333333333302"),
                    },
                    {
                        new Guid("33333333-3333-3333-3333-00000000001c"),
                        new Guid("11111111-1111-1111-1111-111111111116"),
                        "~2050",
                        new Guid("33333333-3333-3333-3333-333333333302"),
                    },
                    {
                        new Guid("33333333-3333-3333-3333-00000000001d"),
                        new Guid("22222222-2222-2222-2222-222222222220"),
                        "77.4–84",
                        new Guid("33333333-3333-3333-3333-333333333302"),
                    },
                    {
                        new Guid("33333333-3333-3333-3333-00000000001e"),
                        new Guid("22222222-2222-2222-2222-222222222221"),
                        "~499",
                        new Guid("33333333-3333-3333-3333-333333333302"),
                    },
                    {
                        new Guid("33333333-3333-3333-3333-00000000001f"),
                        new Guid("22222222-2222-2222-2222-222222222222"),
                        "~155",
                        new Guid("33333333-3333-3333-3333-333333333302"),
                    },
                    {
                        new Guid("33333333-3333-3333-3333-000000000020"),
                        new Guid("22222222-2222-2222-2222-222222222223"),
                        "Lithium‑ion (NMC)",
                        new Guid("33333333-3333-3333-3333-333333333302"),
                    },
                    {
                        new Guid("33333333-3333-3333-3333-000000000021"),
                        new Guid("22222222-2222-2222-2222-222222222224"),
                        "~697",
                        new Guid("33333333-3333-3333-3333-333333333302"),
                    },
                    {
                        new Guid("33333333-3333-3333-3333-000000000022"),
                        new Guid("22222222-2222-2222-2222-222222222225"),
                        "Adjustable",
                        new Guid("33333333-3333-3333-3333-333333333302"),
                    },
                    {
                        new Guid("33333333-3333-3333-3333-000000000023"),
                        new Guid("33333333-3333-3333-3333-333333333330"),
                        "11",
                        new Guid("33333333-3333-3333-3333-333333333302"),
                    },
                    {
                        new Guid("33333333-3333-3333-3333-000000000024"),
                        new Guid("33333333-3333-3333-3333-333333333331"),
                        "240–350",
                        new Guid("33333333-3333-3333-3333-333333333302"),
                    },
                    {
                        new Guid("33333333-3333-3333-3333-000000000025"),
                        new Guid("33333333-3333-3333-3333-333333333332"),
                        "~18",
                        new Guid("33333333-3333-3333-3333-333333333302"),
                    },
                    {
                        new Guid("33333333-3333-3333-3333-000000000026"),
                        new Guid("33333333-3333-3333-3333-333333333333"),
                        "~7–8",
                        new Guid("33333333-3333-3333-3333-333333333302"),
                    },
                    {
                        new Guid("33333333-3333-3333-3333-000000000027"),
                        new Guid("33333333-3333-3333-3333-333333333334"),
                        "CCS Combo",
                        new Guid("33333333-3333-3333-3333-333333333302"),
                    },
                    {
                        new Guid("33333333-3333-3333-3333-000000000028"),
                        new Guid("44444444-4444-4444-4444-444444444440"),
                        "~1000",
                        new Guid("33333333-3333-3333-3333-333333333302"),
                    },
                    {
                        new Guid("33333333-3333-3333-3333-000000000029"),
                        new Guid("44444444-4444-4444-4444-444444444441"),
                        "~52",
                        new Guid("33333333-3333-3333-3333-333333333302"),
                    },
                    {
                        new Guid("33333333-3333-3333-3333-00000000002a"),
                        new Guid("44444444-4444-4444-4444-444444444442"),
                        "520 / 1300+",
                        new Guid("33333333-3333-3333-3333-333333333302"),
                    },
                    {
                        new Guid("33333333-3333-3333-3333-00000000002b"),
                        new Guid("44444444-4444-4444-4444-444444444443"),
                        "Optional",
                        new Guid("33333333-3333-3333-3333-333333333302"),
                    },
                    {
                        new Guid("33333333-3333-3333-3333-00000000002c"),
                        new Guid("44444444-4444-4444-4444-444444444444"),
                        "3.6",
                        new Guid("33333333-3333-3333-3333-333333333302"),
                    },
                    {
                        new Guid("33333333-3333-3333-3333-00000000002d"),
                        new Guid("11111111-1111-1111-1111-111111111110"),
                        "576",
                        new Guid("33333333-3333-3333-3333-333333333303"),
                    },
                    {
                        new Guid("33333333-3333-3333-3333-00000000002e"),
                        new Guid("11111111-1111-1111-1111-111111111111"),
                        "740",
                        new Guid("33333333-3333-3333-3333-333333333303"),
                    },
                    {
                        new Guid("33333333-3333-3333-3333-00000000002f"),
                        new Guid("11111111-1111-1111-1111-111111111112"),
                        "3.5–3.6",
                        new Guid("33333333-3333-3333-3333-333333333303"),
                    },
                    {
                        new Guid("33333333-3333-3333-3333-000000000030"),
                        new Guid("11111111-1111-1111-1111-111111111113"),
                        "AWD",
                        new Guid("33333333-3333-3333-3333-333333333303"),
                    },
                    {
                        new Guid("33333333-3333-3333-3333-000000000031"),
                        new Guid("11111111-1111-1111-1111-111111111114"),
                        "Dual Permanent Magnet Synchronous",
                        new Guid("33333333-3333-3333-3333-333333333303"),
                    },
                    {
                        new Guid("33333333-3333-3333-3333-000000000032"),
                        new Guid("11111111-1111-1111-1111-111111111115"),
                        "260",
                        new Guid("33333333-3333-3333-3333-333333333303"),
                    },
                    {
                        new Guid("33333333-3333-3333-3333-000000000033"),
                        new Guid("11111111-1111-1111-1111-111111111116"),
                        "~2220",
                        new Guid("33333333-3333-3333-3333-333333333303"),
                    },
                    {
                        new Guid("33333333-3333-3333-3333-000000000034"),
                        new Guid("22222222-2222-2222-2222-222222222220"),
                        "77.4–84",
                        new Guid("33333333-3333-3333-3333-333333333303"),
                    },
                    {
                        new Guid("33333333-3333-3333-3333-000000000035"),
                        new Guid("22222222-2222-2222-2222-222222222221"),
                        "~395–450",
                        new Guid("33333333-3333-3333-3333-333333333303"),
                    },
                    {
                        new Guid("33333333-3333-3333-3333-000000000036"),
                        new Guid("22222222-2222-2222-2222-222222222222"),
                        "~203",
                        new Guid("33333333-3333-3333-3333-333333333303"),
                    },
                    {
                        new Guid("33333333-3333-3333-3333-000000000037"),
                        new Guid("22222222-2222-2222-2222-222222222223"),
                        "Lithium‑ion (NMC)",
                        new Guid("33333333-3333-3333-3333-333333333303"),
                    },
                    {
                        new Guid("33333333-3333-3333-3333-000000000038"),
                        new Guid("22222222-2222-2222-2222-222222222224"),
                        "~697",
                        new Guid("33333333-3333-3333-3333-333333333303"),
                    },
                    {
                        new Guid("33333333-3333-3333-3333-000000000039"),
                        new Guid("22222222-2222-2222-2222-222222222225"),
                        "Adjustable",
                        new Guid("33333333-3333-3333-3333-333333333303"),
                    },
                    {
                        new Guid("33333333-3333-3333-3333-00000000003a"),
                        new Guid("33333333-3333-3333-3333-333333333330"),
                        "11",
                        new Guid("33333333-3333-3333-3333-333333333303"),
                    },
                    {
                        new Guid("33333333-3333-3333-3333-00000000003b"),
                        new Guid("33333333-3333-3333-3333-333333333331"),
                        "240–350",
                        new Guid("33333333-3333-3333-3333-333333333303"),
                    },
                    {
                        new Guid("33333333-3333-3333-3333-00000000003c"),
                        new Guid("33333333-3333-3333-3333-333333333332"),
                        "~18",
                        new Guid("33333333-3333-3333-3333-333333333303"),
                    },
                    {
                        new Guid("33333333-3333-3333-3333-00000000003d"),
                        new Guid("33333333-3333-3333-3333-333333333333"),
                        "~7–8",
                        new Guid("33333333-3333-3333-3333-333333333303"),
                    },
                    {
                        new Guid("33333333-3333-3333-3333-00000000003e"),
                        new Guid("33333333-3333-3333-3333-333333333334"),
                        "CCS Combo",
                        new Guid("33333333-3333-3333-3333-333333333303"),
                    },
                    {
                        new Guid("33333333-3333-3333-3333-00000000003f"),
                        new Guid("44444444-4444-4444-4444-444444444440"),
                        "~1600",
                        new Guid("33333333-3333-3333-3333-333333333303"),
                    },
                    {
                        new Guid("33333333-3333-3333-3333-000000000040"),
                        new Guid("44444444-4444-4444-4444-444444444441"),
                        "~20–52",
                        new Guid("33333333-3333-3333-3333-333333333303"),
                    },
                    {
                        new Guid("33333333-3333-3333-3333-000000000041"),
                        new Guid("44444444-4444-4444-4444-444444444442"),
                        "480–490 / 1260",
                        new Guid("33333333-3333-3333-3333-333333333303"),
                    },
                    {
                        new Guid("33333333-3333-3333-3333-000000000042"),
                        new Guid("44444444-4444-4444-4444-444444444443"),
                        "Standard",
                        new Guid("33333333-3333-3333-3333-333333333303"),
                    },
                    {
                        new Guid("33333333-3333-3333-3333-000000000043"),
                        new Guid("44444444-4444-4444-4444-444444444444"),
                        "3.6",
                        new Guid("33333333-3333-3333-3333-333333333303"),
                    },
                    {
                        new Guid("44444444-4444-4444-4444-000000000000"),
                        new Guid("11111111-1111-1111-1111-111111111110"),
                        "220",
                        new Guid("44444444-4444-4444-4444-444444444401"),
                    },
                    {
                        new Guid("44444444-4444-4444-4444-000000000001"),
                        new Guid("11111111-1111-1111-1111-111111111111"),
                        "~330",
                        new Guid("44444444-4444-4444-4444-444444444401"),
                    },
                    {
                        new Guid("44444444-4444-4444-4444-000000000002"),
                        new Guid("11111111-1111-1111-1111-111111111112"),
                        "~7.0–7.5",
                        new Guid("44444444-4444-4444-4444-444444444401"),
                    },
                    {
                        new Guid("44444444-4444-4444-4444-000000000003"),
                        new Guid("11111111-1111-1111-1111-111111111113"),
                        "FWD",
                        new Guid("44444444-4444-4444-4444-444444444401"),
                    },
                    {
                        new Guid("44444444-4444-4444-4444-000000000004"),
                        new Guid("11111111-1111-1111-1111-111111111114"),
                        "Single PMSM (front)",
                        new Guid("44444444-4444-4444-4444-444444444401"),
                    },
                    {
                        new Guid("44444444-4444-4444-4444-000000000005"),
                        new Guid("11111111-1111-1111-1111-111111111115"),
                        "~180",
                        new Guid("44444444-4444-4444-4444-444444444401"),
                    },
                    {
                        new Guid("44444444-4444-4444-4444-000000000006"),
                        new Guid("11111111-1111-1111-1111-111111111116"),
                        "~2270",
                        new Guid("44444444-4444-4444-4444-444444444401"),
                    },
                    {
                        new Guid("44444444-4444-4444-4444-000000000007"),
                        new Guid("22222222-2222-2222-2222-222222222220"),
                        "~85",
                        new Guid("44444444-4444-4444-4444-444444444401"),
                    },
                    {
                        new Guid("44444444-4444-4444-4444-000000000008"),
                        new Guid("22222222-2222-2222-2222-222222222221"),
                        "~502",
                        new Guid("44444444-4444-4444-4444-444444444401"),
                    },
                    {
                        new Guid("44444444-4444-4444-4444-000000000009"),
                        new Guid("22222222-2222-2222-2222-222222222222"),
                        "~169",
                        new Guid("44444444-4444-4444-4444-444444444401"),
                    },
                    {
                        new Guid("44444444-4444-4444-4444-00000000000a"),
                        new Guid("22222222-2222-2222-2222-222222222223"),
                        "Ultium Li‑ion (NMC)",
                        new Guid("44444444-4444-4444-4444-444444444401"),
                    },
                    {
                        new Guid("44444444-4444-4444-4444-00000000000b"),
                        new Guid("22222222-2222-2222-2222-222222222224"),
                        "400",
                        new Guid("44444444-4444-4444-4444-444444444401"),
                    },
                    {
                        new Guid("44444444-4444-4444-4444-00000000000c"),
                        new Guid("22222222-2222-2222-2222-222222222225"),
                        "One‑Pedal Driving",
                        new Guid("44444444-4444-4444-4444-444444444401"),
                    },
                    {
                        new Guid("44444444-4444-4444-4444-00000000000d"),
                        new Guid("33333333-3333-3333-3333-333333333330"),
                        "11.5",
                        new Guid("44444444-4444-4444-4444-444444444401"),
                    },
                    {
                        new Guid("44444444-4444-4444-4444-00000000000e"),
                        new Guid("33333333-3333-3333-3333-333333333331"),
                        "150",
                        new Guid("44444444-4444-4444-4444-444444444401"),
                    },
                    {
                        new Guid("44444444-4444-4444-4444-00000000000f"),
                        new Guid("33333333-3333-3333-3333-333333333332"),
                        "~35",
                        new Guid("44444444-4444-4444-4444-444444444401"),
                    },
                    {
                        new Guid("44444444-4444-4444-4444-000000000010"),
                        new Guid("33333333-3333-3333-3333-333333333333"),
                        "~9.5",
                        new Guid("44444444-4444-4444-4444-444444444401"),
                    },
                    {
                        new Guid("44444444-4444-4444-4444-000000000011"),
                        new Guid("33333333-3333-3333-3333-333333333334"),
                        "CCS Combo",
                        new Guid("44444444-4444-4444-4444-444444444401"),
                    },
                    {
                        new Guid("44444444-4444-4444-4444-000000000012"),
                        new Guid("44444444-4444-4444-4444-444444444440"),
                        "~680",
                        new Guid("44444444-4444-4444-4444-444444444401"),
                    },
                    {
                        new Guid("44444444-4444-4444-4444-000000000013"),
                        new Guid("44444444-4444-4444-4444-444444444442"),
                        "722–1674",
                        new Guid("44444444-4444-4444-4444-444444444401"),
                    },
                    {
                        new Guid("44444444-4444-4444-4444-000000000014"),
                        new Guid("44444444-4444-4444-4444-444444444443"),
                        "Standard",
                        new Guid("44444444-4444-4444-4444-444444444401"),
                    },
                    {
                        new Guid("44444444-4444-4444-4444-000000000015"),
                        new Guid("11111111-1111-1111-1111-111111111110"),
                        "345–365",
                        new Guid("44444444-4444-4444-4444-444444444402"),
                    },
                    {
                        new Guid("44444444-4444-4444-4444-000000000016"),
                        new Guid("11111111-1111-1111-1111-111111111111"),
                        "441",
                        new Guid("44444444-4444-4444-4444-444444444402"),
                    },
                    {
                        new Guid("44444444-4444-4444-4444-000000000017"),
                        new Guid("11111111-1111-1111-1111-111111111112"),
                        "~5.7–6.0",
                        new Guid("44444444-4444-4444-4444-444444444402"),
                    },
                    {
                        new Guid("44444444-4444-4444-4444-000000000018"),
                        new Guid("11111111-1111-1111-1111-111111111113"),
                        "RWD",
                        new Guid("44444444-4444-4444-4444-444444444402"),
                    },
                    {
                        new Guid("44444444-4444-4444-4444-000000000019"),
                        new Guid("11111111-1111-1111-1111-111111111114"),
                        "Single PMSM (rear)",
                        new Guid("44444444-4444-4444-4444-444444444402"),
                    },
                    {
                        new Guid("44444444-4444-4444-4444-00000000001a"),
                        new Guid("11111111-1111-1111-1111-111111111115"),
                        "~210",
                        new Guid("44444444-4444-4444-4444-444444444402"),
                    },
                    {
                        new Guid("44444444-4444-4444-4444-00000000001b"),
                        new Guid("11111111-1111-1111-1111-111111111116"),
                        "~2470–2540",
                        new Guid("44444444-4444-4444-4444-444444444402"),
                    },
                    {
                        new Guid("44444444-4444-4444-4444-00000000001c"),
                        new Guid("22222222-2222-2222-2222-222222222220"),
                        "~91–102",
                        new Guid("44444444-4444-4444-4444-444444444402"),
                    },
                    {
                        new Guid("44444444-4444-4444-4444-00000000001d"),
                        new Guid("22222222-2222-2222-2222-222222222221"),
                        "~449–521",
                        new Guid("44444444-4444-4444-4444-444444444402"),
                    },
                    {
                        new Guid("44444444-4444-4444-4444-00000000001e"),
                        new Guid("22222222-2222-2222-2222-222222222222"),
                        "~200–228",
                        new Guid("44444444-4444-4444-4444-444444444402"),
                    },
                    {
                        new Guid("44444444-4444-4444-4444-00000000001f"),
                        new Guid("22222222-2222-2222-2222-222222222223"),
                        "Ultium Li‑ion (NMC)",
                        new Guid("44444444-4444-4444-4444-444444444402"),
                    },
                    {
                        new Guid("44444444-4444-4444-4444-000000000020"),
                        new Guid("22222222-2222-2222-2222-222222222224"),
                        "400",
                        new Guid("44444444-4444-4444-4444-444444444402"),
                    },
                    {
                        new Guid("44444444-4444-4444-4444-000000000021"),
                        new Guid("22222222-2222-2222-2222-222222222225"),
                        "One‑Pedal Driving",
                        new Guid("44444444-4444-4444-4444-444444444402"),
                    },
                    {
                        new Guid("44444444-4444-4444-4444-000000000022"),
                        new Guid("33333333-3333-3333-3333-333333333330"),
                        "11.5",
                        new Guid("44444444-4444-4444-4444-444444444402"),
                    },
                    {
                        new Guid("44444444-4444-4444-4444-000000000023"),
                        new Guid("33333333-3333-3333-3333-333333333331"),
                        "150",
                        new Guid("44444444-4444-4444-4444-444444444402"),
                    },
                    {
                        new Guid("44444444-4444-4444-4444-000000000024"),
                        new Guid("33333333-3333-3333-3333-333333333332"),
                        "~35",
                        new Guid("44444444-4444-4444-4444-444444444402"),
                    },
                    {
                        new Guid("44444444-4444-4444-4444-000000000025"),
                        new Guid("33333333-3333-3333-3333-333333333333"),
                        "~8",
                        new Guid("44444444-4444-4444-4444-444444444402"),
                    },
                    {
                        new Guid("44444444-4444-4444-4444-000000000026"),
                        new Guid("33333333-3333-3333-3333-333333333334"),
                        "CCS Combo",
                        new Guid("44444444-4444-4444-4444-444444444402"),
                    },
                    {
                        new Guid("44444444-4444-4444-4444-000000000027"),
                        new Guid("44444444-4444-4444-4444-444444444440"),
                        "~1588",
                        new Guid("44444444-4444-4444-4444-444444444402"),
                    },
                    {
                        new Guid("44444444-4444-4444-4444-000000000028"),
                        new Guid("44444444-4444-4444-4444-444444444442"),
                        "722–1674",
                        new Guid("44444444-4444-4444-4444-444444444402"),
                    },
                    {
                        new Guid("44444444-4444-4444-4444-000000000029"),
                        new Guid("44444444-4444-4444-4444-444444444443"),
                        "Standard",
                        new Guid("44444444-4444-4444-4444-444444444402"),
                    },
                    {
                        new Guid("44444444-4444-4444-4444-00000000002a"),
                        new Guid("44444444-4444-4444-4444-444444444444"),
                        "V2H supported",
                        new Guid("44444444-4444-4444-4444-444444444402"),
                    },
                    {
                        new Guid("44444444-4444-4444-4444-00000000002b"),
                        new Guid("11111111-1111-1111-1111-111111111110"),
                        "615",
                        new Guid("44444444-4444-4444-4444-444444444403"),
                    },
                    {
                        new Guid("44444444-4444-4444-4444-00000000002c"),
                        new Guid("11111111-1111-1111-1111-111111111111"),
                        "880",
                        new Guid("44444444-4444-4444-4444-444444444403"),
                    },
                    {
                        new Guid("44444444-4444-4444-4444-00000000002d"),
                        new Guid("11111111-1111-1111-1111-111111111112"),
                        "~3.4–4.0",
                        new Guid("44444444-4444-4444-4444-444444444403"),
                    },
                    {
                        new Guid("44444444-4444-4444-4444-00000000002e"),
                        new Guid("11111111-1111-1111-1111-111111111113"),
                        "AWD",
                        new Guid("44444444-4444-4444-4444-444444444403"),
                    },
                    {
                        new Guid("44444444-4444-4444-4444-00000000002f"),
                        new Guid("11111111-1111-1111-1111-111111111114"),
                        "Dual PMSM (front + rear)",
                        new Guid("44444444-4444-4444-4444-444444444403"),
                    },
                    {
                        new Guid("44444444-4444-4444-4444-000000000030"),
                        new Guid("11111111-1111-1111-1111-111111111115"),
                        "~210+",
                        new Guid("44444444-4444-4444-4444-444444444403"),
                    },
                    {
                        new Guid("44444444-4444-4444-4444-000000000031"),
                        new Guid("11111111-1111-1111-1111-111111111116"),
                        "~2600",
                        new Guid("44444444-4444-4444-4444-444444444403"),
                    },
                    {
                        new Guid("44444444-4444-4444-4444-000000000032"),
                        new Guid("22222222-2222-2222-2222-222222222220"),
                        "102",
                        new Guid("44444444-4444-4444-4444-444444444403"),
                    },
                    {
                        new Guid("44444444-4444-4444-4444-000000000033"),
                        new Guid("22222222-2222-2222-2222-222222222221"),
                        "~486",
                        new Guid("44444444-4444-4444-4444-444444444403"),
                    },
                    {
                        new Guid("44444444-4444-4444-4444-000000000034"),
                        new Guid("22222222-2222-2222-2222-222222222222"),
                        "~210–220",
                        new Guid("44444444-4444-4444-4444-444444444403"),
                    },
                    {
                        new Guid("44444444-4444-4444-4444-000000000035"),
                        new Guid("22222222-2222-2222-2222-222222222223"),
                        "Ultium Li‑ion (NMC)",
                        new Guid("44444444-4444-4444-4444-444444444403"),
                    },
                    {
                        new Guid("44444444-4444-4444-4444-000000000036"),
                        new Guid("22222222-2222-2222-2222-222222222224"),
                        "400",
                        new Guid("44444444-4444-4444-4444-444444444403"),
                    },
                    {
                        new Guid("44444444-4444-4444-4444-000000000037"),
                        new Guid("22222222-2222-2222-2222-222222222225"),
                        "One‑Pedal Driving + Regen on Demand",
                        new Guid("44444444-4444-4444-4444-444444444403"),
                    },
                    {
                        new Guid("44444444-4444-4444-4444-000000000038"),
                        new Guid("33333333-3333-3333-3333-333333333330"),
                        "11.5",
                        new Guid("44444444-4444-4444-4444-444444444403"),
                    },
                    {
                        new Guid("44444444-4444-4444-4444-000000000039"),
                        new Guid("33333333-3333-3333-3333-333333333331"),
                        "190–200",
                        new Guid("44444444-4444-4444-4444-444444444403"),
                    },
                    {
                        new Guid("44444444-4444-4444-4444-00000000003a"),
                        new Guid("33333333-3333-3333-3333-333333333332"),
                        "~30–32",
                        new Guid("44444444-4444-4444-4444-444444444403"),
                    },
                    {
                        new Guid("44444444-4444-4444-4444-00000000003b"),
                        new Guid("33333333-3333-3333-3333-333333333333"),
                        "~11.2",
                        new Guid("44444444-4444-4444-4444-444444444403"),
                    },
                    {
                        new Guid("44444444-4444-4444-4444-00000000003c"),
                        new Guid("33333333-3333-3333-3333-333333333334"),
                        "CCS Combo",
                        new Guid("44444444-4444-4444-4444-444444444403"),
                    },
                    {
                        new Guid("44444444-4444-4444-4444-00000000003d"),
                        new Guid("44444444-4444-4444-4444-444444444442"),
                        "722–1674",
                        new Guid("44444444-4444-4444-4444-444444444403"),
                    },
                    {
                        new Guid("44444444-4444-4444-4444-00000000003e"),
                        new Guid("44444444-4444-4444-4444-444444444443"),
                        "Standard",
                        new Guid("44444444-4444-4444-4444-444444444403"),
                    },
                    {
                        new Guid("55555555-5555-5555-5555-000000000000"),
                        new Guid("11111111-1111-1111-1111-111111111110"),
                        "430",
                        new Guid("55555555-5555-5555-5555-555555555501"),
                    },
                    {
                        new Guid("55555555-5555-5555-5555-000000000001"),
                        new Guid("11111111-1111-1111-1111-111111111111"),
                        "~550",
                        new Guid("55555555-5555-5555-5555-555555555501"),
                    },
                    {
                        new Guid("55555555-5555-5555-5555-000000000002"),
                        new Guid("11111111-1111-1111-1111-111111111112"),
                        "4.7",
                        new Guid("55555555-5555-5555-5555-555555555501"),
                    },
                    {
                        new Guid("55555555-5555-5555-5555-000000000003"),
                        new Guid("11111111-1111-1111-1111-111111111113"),
                        "RWD",
                        new Guid("55555555-5555-5555-5555-555555555501"),
                    },
                    {
                        new Guid("55555555-5555-5555-5555-000000000004"),
                        new Guid("11111111-1111-1111-1111-111111111114"),
                        "Single PMSM (rear)",
                        new Guid("55555555-5555-5555-5555-555555555501"),
                    },
                    {
                        new Guid("55555555-5555-5555-5555-000000000005"),
                        new Guid("11111111-1111-1111-1111-111111111115"),
                        "200",
                        new Guid("55555555-5555-5555-5555-555555555501"),
                    },
                    {
                        new Guid("55555555-5555-5555-5555-000000000006"),
                        new Guid("11111111-1111-1111-1111-111111111116"),
                        "~2070",
                        new Guid("55555555-5555-5555-5555-555555555501"),
                    },
                    {
                        new Guid("55555555-5555-5555-5555-000000000007"),
                        new Guid("22222222-2222-2222-2222-222222222220"),
                        "84",
                        new Guid("55555555-5555-5555-5555-555555555501"),
                    },
                    {
                        new Guid("55555555-5555-5555-5555-000000000008"),
                        new Guid("22222222-2222-2222-2222-222222222221"),
                        "~676",
                        new Guid("55555555-5555-5555-5555-555555555501"),
                    },
                    {
                        new Guid("55555555-5555-5555-5555-000000000009"),
                        new Guid("22222222-2222-2222-2222-222222222222"),
                        "~158",
                        new Guid("55555555-5555-5555-5555-555555555501"),
                    },
                    {
                        new Guid("55555555-5555-5555-5555-00000000000a"),
                        new Guid("22222222-2222-2222-2222-222222222223"),
                        "Li‑ion (NMC)",
                        new Guid("55555555-5555-5555-5555-555555555501"),
                    },
                    {
                        new Guid("55555555-5555-5555-5555-00000000000b"),
                        new Guid("22222222-2222-2222-2222-222222222224"),
                        "800+",
                        new Guid("55555555-5555-5555-5555-555555555501"),
                    },
                    {
                        new Guid("55555555-5555-5555-5555-00000000000c"),
                        new Guid("22222222-2222-2222-2222-222222222225"),
                        "Adjustable",
                        new Guid("55555555-5555-5555-5555-555555555501"),
                    },
                    {
                        new Guid("55555555-5555-5555-5555-00000000000d"),
                        new Guid("33333333-3333-3333-3333-333333333330"),
                        "22",
                        new Guid("55555555-5555-5555-5555-555555555501"),
                    },
                    {
                        new Guid("55555555-5555-5555-5555-00000000000e"),
                        new Guid("33333333-3333-3333-3333-333333333331"),
                        "210",
                        new Guid("55555555-5555-5555-5555-555555555501"),
                    },
                    {
                        new Guid("55555555-5555-5555-5555-00000000000f"),
                        new Guid("33333333-3333-3333-3333-333333333332"),
                        "~27",
                        new Guid("55555555-5555-5555-5555-555555555501"),
                    },
                    {
                        new Guid("55555555-5555-5555-5555-000000000010"),
                        new Guid("33333333-3333-3333-3333-333333333333"),
                        "~10",
                        new Guid("55555555-5555-5555-5555-555555555501"),
                    },
                    {
                        new Guid("55555555-5555-5555-5555-000000000011"),
                        new Guid("33333333-3333-3333-3333-333333333334"),
                        "CCS Combo",
                        new Guid("55555555-5555-5555-5555-555555555501"),
                    },
                    {
                        new Guid("55555555-5555-5555-5555-000000000012"),
                        new Guid("44444444-4444-4444-4444-444444444441"),
                        "~283",
                        new Guid("55555555-5555-5555-5555-555555555501"),
                    },
                    {
                        new Guid("55555555-5555-5555-5555-000000000013"),
                        new Guid("44444444-4444-4444-4444-444444444442"),
                        "~910 total (frunk + trunk)",
                        new Guid("55555555-5555-5555-5555-555555555501"),
                    },
                    {
                        new Guid("55555555-5555-5555-5555-000000000014"),
                        new Guid("44444444-4444-4444-4444-444444444443"),
                        "Standard",
                        new Guid("55555555-5555-5555-5555-555555555501"),
                    },
                    {
                        new Guid("55555555-5555-5555-5555-000000000015"),
                        new Guid("44444444-4444-4444-4444-444444444444"),
                        "Supported",
                        new Guid("55555555-5555-5555-5555-555555555501"),
                    },
                    {
                        new Guid("55555555-5555-5555-5555-000000000016"),
                        new Guid("11111111-1111-1111-1111-111111111110"),
                        "620",
                        new Guid("55555555-5555-5555-5555-555555555502"),
                    },
                    {
                        new Guid("55555555-5555-5555-5555-000000000017"),
                        new Guid("11111111-1111-1111-1111-111111111111"),
                        "~1200",
                        new Guid("55555555-5555-5555-5555-555555555502"),
                    },
                    {
                        new Guid("55555555-5555-5555-5555-000000000018"),
                        new Guid("11111111-1111-1111-1111-111111111112"),
                        "3.6",
                        new Guid("55555555-5555-5555-5555-555555555502"),
                    },
                    {
                        new Guid("55555555-5555-5555-5555-000000000019"),
                        new Guid("11111111-1111-1111-1111-111111111113"),
                        "AWD",
                        new Guid("55555555-5555-5555-5555-555555555502"),
                    },
                    {
                        new Guid("55555555-5555-5555-5555-00000000001a"),
                        new Guid("11111111-1111-1111-1111-111111111114"),
                        "Dual PMSM",
                        new Guid("55555555-5555-5555-5555-555555555502"),
                    },
                    {
                        new Guid("55555555-5555-5555-5555-00000000001b"),
                        new Guid("11111111-1111-1111-1111-111111111115"),
                        "225",
                        new Guid("55555555-5555-5555-5555-555555555502"),
                    },
                    {
                        new Guid("55555555-5555-5555-5555-00000000001c"),
                        new Guid("11111111-1111-1111-1111-111111111116"),
                        "~2270",
                        new Guid("55555555-5555-5555-5555-555555555502"),
                    },
                    {
                        new Guid("55555555-5555-5555-5555-00000000001d"),
                        new Guid("22222222-2222-2222-2222-222222222220"),
                        "~89–92",
                        new Guid("55555555-5555-5555-5555-555555555502"),
                    },
                    {
                        new Guid("55555555-5555-5555-5555-00000000001e"),
                        new Guid("22222222-2222-2222-2222-222222222221"),
                        "~653",
                        new Guid("55555555-5555-5555-5555-555555555502"),
                    },
                    {
                        new Guid("55555555-5555-5555-5555-00000000001f"),
                        new Guid("22222222-2222-2222-2222-222222222222"),
                        "~162",
                        new Guid("55555555-5555-5555-5555-555555555502"),
                    },
                    {
                        new Guid("55555555-5555-5555-5555-000000000020"),
                        new Guid("22222222-2222-2222-2222-222222222223"),
                        "Li‑ion (NMC)",
                        new Guid("55555555-5555-5555-5555-555555555502"),
                    },
                    {
                        new Guid("55555555-5555-5555-5555-000000000021"),
                        new Guid("22222222-2222-2222-2222-222222222224"),
                        "700+",
                        new Guid("55555555-5555-5555-5555-555555555502"),
                    },
                    {
                        new Guid("55555555-5555-5555-5555-000000000022"),
                        new Guid("22222222-2222-2222-2222-222222222225"),
                        "Adjustable",
                        new Guid("55555555-5555-5555-5555-555555555502"),
                    },
                    {
                        new Guid("55555555-5555-5555-5555-000000000023"),
                        new Guid("33333333-3333-3333-3333-333333333330"),
                        "19.2",
                        new Guid("55555555-5555-5555-5555-555555555502"),
                    },
                    {
                        new Guid("55555555-5555-5555-5555-000000000024"),
                        new Guid("33333333-3333-3333-3333-333333333331"),
                        "250",
                        new Guid("55555555-5555-5555-5555-555555555502"),
                    },
                    {
                        new Guid("55555555-5555-5555-5555-000000000025"),
                        new Guid("33333333-3333-3333-3333-333333333332"),
                        "~32",
                        new Guid("55555555-5555-5555-5555-555555555502"),
                    },
                    {
                        new Guid("55555555-5555-5555-5555-000000000026"),
                        new Guid("33333333-3333-3333-3333-333333333333"),
                        "~10",
                        new Guid("55555555-5555-5555-5555-555555555502"),
                    },
                    {
                        new Guid("55555555-5555-5555-5555-000000000027"),
                        new Guid("33333333-3333-3333-3333-333333333334"),
                        "CCS Combo",
                        new Guid("55555555-5555-5555-5555-555555555502"),
                    },
                    {
                        new Guid("55555555-5555-5555-5555-000000000028"),
                        new Guid("44444444-4444-4444-4444-444444444441"),
                        "~280",
                        new Guid("55555555-5555-5555-5555-555555555502"),
                    },
                    {
                        new Guid("55555555-5555-5555-5555-000000000029"),
                        new Guid("44444444-4444-4444-4444-444444444442"),
                        "~910",
                        new Guid("55555555-5555-5555-5555-555555555502"),
                    },
                    {
                        new Guid("55555555-5555-5555-5555-00000000002a"),
                        new Guid("44444444-4444-4444-4444-444444444443"),
                        "Standard",
                        new Guid("55555555-5555-5555-5555-555555555502"),
                    },
                    {
                        new Guid("55555555-5555-5555-5555-00000000002b"),
                        new Guid("44444444-4444-4444-4444-444444444444"),
                        "Supported",
                        new Guid("55555555-5555-5555-5555-555555555502"),
                    },
                    {
                        new Guid("55555555-5555-5555-5555-00000000002c"),
                        new Guid("11111111-1111-1111-1111-111111111110"),
                        "819",
                        new Guid("55555555-5555-5555-5555-555555555503"),
                    },
                    {
                        new Guid("55555555-5555-5555-5555-00000000002d"),
                        new Guid("11111111-1111-1111-1111-111111111111"),
                        "1200",
                        new Guid("55555555-5555-5555-5555-555555555503"),
                    },
                    {
                        new Guid("55555555-5555-5555-5555-00000000002e"),
                        new Guid("11111111-1111-1111-1111-111111111112"),
                        "3.2",
                        new Guid("55555555-5555-5555-5555-555555555503"),
                    },
                    {
                        new Guid("55555555-5555-5555-5555-00000000002f"),
                        new Guid("11111111-1111-1111-1111-111111111113"),
                        "AWD",
                        new Guid("55555555-5555-5555-5555-555555555503"),
                    },
                    {
                        new Guid("55555555-5555-5555-5555-000000000030"),
                        new Guid("11111111-1111-1111-1111-111111111114"),
                        "Dual PMSM",
                        new Guid("55555555-5555-5555-5555-555555555503"),
                    },
                    {
                        new Guid("55555555-5555-5555-5555-000000000031"),
                        new Guid("11111111-1111-1111-1111-111111111115"),
                        "270",
                        new Guid("55555555-5555-5555-5555-555555555503"),
                    },
                    {
                        new Guid("55555555-5555-5555-5555-000000000032"),
                        new Guid("11111111-1111-1111-1111-111111111116"),
                        "~2360–2435",
                        new Guid("55555555-5555-5555-5555-555555555503"),
                    },
                    {
                        new Guid("55555555-5555-5555-5555-000000000033"),
                        new Guid("22222222-2222-2222-2222-222222222220"),
                        "112",
                        new Guid("55555555-5555-5555-5555-555555555503"),
                    },
                    {
                        new Guid("55555555-5555-5555-5555-000000000034"),
                        new Guid("22222222-2222-2222-2222-222222222221"),
                        "~824",
                        new Guid("55555555-5555-5555-5555-555555555503"),
                    },
                    {
                        new Guid("55555555-5555-5555-5555-000000000035"),
                        new Guid("22222222-2222-2222-2222-222222222222"),
                        "~160",
                        new Guid("55555555-5555-5555-5555-555555555503"),
                    },
                    {
                        new Guid("55555555-5555-5555-5555-000000000036"),
                        new Guid("22222222-2222-2222-2222-222222222223"),
                        "Li‑ion (NMC)",
                        new Guid("55555555-5555-5555-5555-555555555503"),
                    },
                    {
                        new Guid("55555555-5555-5555-5555-000000000037"),
                        new Guid("22222222-2222-2222-2222-222222222224"),
                        "900+",
                        new Guid("55555555-5555-5555-5555-555555555503"),
                    },
                    {
                        new Guid("55555555-5555-5555-5555-000000000038"),
                        new Guid("22222222-2222-2222-2222-222222222225"),
                        "Adjustable",
                        new Guid("55555555-5555-5555-5555-555555555503"),
                    },
                    {
                        new Guid("55555555-5555-5555-5555-000000000039"),
                        new Guid("33333333-3333-3333-3333-333333333330"),
                        "19.2",
                        new Guid("55555555-5555-5555-5555-555555555503"),
                    },
                    {
                        new Guid("55555555-5555-5555-5555-00000000003a"),
                        new Guid("33333333-3333-3333-3333-333333333331"),
                        "300",
                        new Guid("55555555-5555-5555-5555-555555555503"),
                    },
                    {
                        new Guid("55555555-5555-5555-5555-00000000003b"),
                        new Guid("33333333-3333-3333-3333-333333333332"),
                        "~33",
                        new Guid("55555555-5555-5555-5555-555555555503"),
                    },
                    {
                        new Guid("55555555-5555-5555-5555-00000000003c"),
                        new Guid("33333333-3333-3333-3333-333333333333"),
                        "~13",
                        new Guid("55555555-5555-5555-5555-555555555503"),
                    },
                    {
                        new Guid("55555555-5555-5555-5555-00000000003d"),
                        new Guid("33333333-3333-3333-3333-333333333334"),
                        "CCS Combo",
                        new Guid("55555555-5555-5555-5555-555555555503"),
                    },
                    {
                        new Guid("55555555-5555-5555-5555-00000000003e"),
                        new Guid("44444444-4444-4444-4444-444444444441"),
                        "~280",
                        new Guid("55555555-5555-5555-5555-555555555503"),
                    },
                    {
                        new Guid("55555555-5555-5555-5555-00000000003f"),
                        new Guid("44444444-4444-4444-4444-444444444442"),
                        "~910",
                        new Guid("55555555-5555-5555-5555-555555555503"),
                    },
                    {
                        new Guid("55555555-5555-5555-5555-000000000040"),
                        new Guid("44444444-4444-4444-4444-444444444443"),
                        "Standard",
                        new Guid("55555555-5555-5555-5555-555555555503"),
                    },
                    {
                        new Guid("55555555-5555-5555-5555-000000000041"),
                        new Guid("44444444-4444-4444-4444-444444444444"),
                        "Supported",
                        new Guid("55555555-5555-5555-5555-555555555503"),
                    },
                    {
                        new Guid("55555555-5555-5555-5555-000000000042"),
                        new Guid("11111111-1111-1111-1111-111111111110"),
                        "1234",
                        new Guid("55555555-5555-5555-5555-555555555504"),
                    },
                    {
                        new Guid("55555555-5555-5555-5555-000000000043"),
                        new Guid("11111111-1111-1111-1111-111111111111"),
                        "1390",
                        new Guid("55555555-5555-5555-5555-555555555504"),
                    },
                    {
                        new Guid("55555555-5555-5555-5555-000000000044"),
                        new Guid("11111111-1111-1111-1111-111111111112"),
                        "~2.0",
                        new Guid("55555555-5555-5555-5555-555555555504"),
                    },
                    {
                        new Guid("55555555-5555-5555-5555-000000000045"),
                        new Guid("11111111-1111-1111-1111-111111111113"),
                        "AWD (triple motor)",
                        new Guid("55555555-5555-5555-5555-555555555504"),
                    },
                    {
                        new Guid("55555555-5555-5555-5555-000000000046"),
                        new Guid("11111111-1111-1111-1111-111111111114"),
                        "Triple PMSM (2 rear + 1 front)",
                        new Guid("55555555-5555-5555-5555-555555555504"),
                    },
                    {
                        new Guid("55555555-5555-5555-5555-000000000047"),
                        new Guid("11111111-1111-1111-1111-111111111115"),
                        "330",
                        new Guid("55555555-5555-5555-5555-555555555504"),
                    },
                    {
                        new Guid("55555555-5555-5555-5555-000000000048"),
                        new Guid("11111111-1111-1111-1111-111111111116"),
                        "~2420–2435",
                        new Guid("55555555-5555-5555-5555-555555555504"),
                    },
                    {
                        new Guid("55555555-5555-5555-5555-000000000049"),
                        new Guid("22222222-2222-2222-2222-222222222220"),
                        "118",
                        new Guid("55555555-5555-5555-5555-555555555504"),
                    },
                    {
                        new Guid("55555555-5555-5555-5555-00000000004a"),
                        new Guid("22222222-2222-2222-2222-222222222221"),
                        "~687",
                        new Guid("55555555-5555-5555-5555-555555555504"),
                    },
                    {
                        new Guid("55555555-5555-5555-5555-00000000004b"),
                        new Guid("22222222-2222-2222-2222-222222222222"),
                        "~190",
                        new Guid("55555555-5555-5555-5555-555555555504"),
                    },
                    {
                        new Guid("55555555-5555-5555-5555-00000000004c"),
                        new Guid("22222222-2222-2222-2222-222222222223"),
                        "Li‑ion (NMC)",
                        new Guid("55555555-5555-5555-5555-555555555504"),
                    },
                    {
                        new Guid("55555555-5555-5555-5555-00000000004d"),
                        new Guid("22222222-2222-2222-2222-222222222224"),
                        "900",
                        new Guid("55555555-5555-5555-5555-555555555504"),
                    },
                    {
                        new Guid("55555555-5555-5555-5555-00000000004e"),
                        new Guid("22222222-2222-2222-2222-222222222225"),
                        "Adjustable (track‑tuned)",
                        new Guid("55555555-5555-5555-5555-555555555504"),
                    },
                    {
                        new Guid("55555555-5555-5555-5555-00000000004f"),
                        new Guid("33333333-3333-3333-3333-333333333330"),
                        "19.2",
                        new Guid("55555555-5555-5555-5555-555555555504"),
                    },
                    {
                        new Guid("55555555-5555-5555-5555-000000000050"),
                        new Guid("33333333-3333-3333-3333-333333333331"),
                        "300",
                        new Guid("55555555-5555-5555-5555-555555555504"),
                    },
                    {
                        new Guid("55555555-5555-5555-5555-000000000051"),
                        new Guid("33333333-3333-3333-3333-333333333332"),
                        "~33",
                        new Guid("55555555-5555-5555-5555-555555555504"),
                    },
                    {
                        new Guid("55555555-5555-5555-5555-000000000052"),
                        new Guid("33333333-3333-3333-3333-333333333333"),
                        "~13",
                        new Guid("55555555-5555-5555-5555-555555555504"),
                    },
                    {
                        new Guid("55555555-5555-5555-5555-000000000053"),
                        new Guid("33333333-3333-3333-3333-333333333334"),
                        "CCS Combo",
                        new Guid("55555555-5555-5555-5555-555555555504"),
                    },
                    {
                        new Guid("55555555-5555-5555-5555-000000000054"),
                        new Guid("44444444-4444-4444-4444-444444444441"),
                        "~280",
                        new Guid("55555555-5555-5555-5555-555555555504"),
                    },
                    {
                        new Guid("55555555-5555-5555-5555-000000000055"),
                        new Guid("44444444-4444-4444-4444-444444444442"),
                        "~910",
                        new Guid("55555555-5555-5555-5555-555555555504"),
                    },
                    {
                        new Guid("55555555-5555-5555-5555-000000000056"),
                        new Guid("44444444-4444-4444-4444-444444444443"),
                        "Standard",
                        new Guid("55555555-5555-5555-5555-555555555504"),
                    },
                    {
                        new Guid("55555555-5555-5555-5555-000000000057"),
                        new Guid("44444444-4444-4444-4444-444444444444"),
                        "Supported",
                        new Guid("55555555-5555-5555-5555-555555555504"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-000000000000"),
                        new Guid("11111111-1111-1111-1111-111111111110"),
                        "214",
                        new Guid("66666666-6666-6666-6666-666666666601"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-000000000001"),
                        new Guid("11111111-1111-1111-1111-111111111111"),
                        "300",
                        new Guid("66666666-6666-6666-6666-666666666601"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-000000000002"),
                        new Guid("11111111-1111-1111-1111-111111111112"),
                        "~7.5",
                        new Guid("66666666-6666-6666-6666-666666666601"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-000000000003"),
                        new Guid("11111111-1111-1111-1111-111111111113"),
                        "FWD",
                        new Guid("66666666-6666-6666-6666-666666666601"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-000000000004"),
                        new Guid("11111111-1111-1111-1111-111111111114"),
                        "Single PMSM (front)",
                        new Guid("66666666-6666-6666-6666-666666666601"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-000000000005"),
                        new Guid("11111111-1111-1111-1111-111111111115"),
                        "160",
                        new Guid("66666666-6666-6666-6666-666666666601"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-000000000006"),
                        new Guid("11111111-1111-1111-1111-111111111116"),
                        "~1960",
                        new Guid("66666666-6666-6666-6666-666666666601"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-000000000007"),
                        new Guid("22222222-2222-2222-2222-222222222220"),
                        "63–66",
                        new Guid("66666666-6666-6666-6666-666666666601"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-000000000008"),
                        new Guid("22222222-2222-2222-2222-222222222221"),
                        "~348",
                        new Guid("66666666-6666-6666-6666-666666666601"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-000000000009"),
                        new Guid("22222222-2222-2222-2222-222222222222"),
                        "~207",
                        new Guid("66666666-6666-6666-6666-666666666601"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-00000000000a"),
                        new Guid("22222222-2222-2222-2222-222222222223"),
                        "Li‑ion (NMC)",
                        new Guid("66666666-6666-6666-6666-666666666601"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-00000000000b"),
                        new Guid("22222222-2222-2222-2222-222222222224"),
                        "350",
                        new Guid("66666666-6666-6666-6666-666666666601"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-00000000000c"),
                        new Guid("22222222-2222-2222-2222-222222222225"),
                        "Adjustable (1‑pedal)",
                        new Guid("66666666-6666-6666-6666-666666666601"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-00000000000d"),
                        new Guid("33333333-3333-3333-3333-333333333330"),
                        "7.2–11",
                        new Guid("66666666-6666-6666-6666-666666666601"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-00000000000e"),
                        new Guid("33333333-3333-3333-3333-333333333331"),
                        "130",
                        new Guid("66666666-6666-6666-6666-666666666601"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-00000000000f"),
                        new Guid("33333333-3333-3333-3333-333333333332"),
                        "~35",
                        new Guid("66666666-6666-6666-6666-666666666601"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-000000000010"),
                        new Guid("33333333-3333-3333-3333-333333333333"),
                        "~10",
                        new Guid("66666666-6666-6666-6666-666666666601"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-000000000011"),
                        new Guid("33333333-3333-3333-3333-333333333334"),
                        "CCS Combo",
                        new Guid("66666666-6666-6666-6666-666666666601"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-000000000012"),
                        new Guid("44444444-4444-4444-4444-444444444442"),
                        "646–1691",
                        new Guid("66666666-6666-6666-6666-666666666601"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-000000000013"),
                        new Guid("44444444-4444-4444-4444-444444444443"),
                        "Optional",
                        new Guid("66666666-6666-6666-6666-666666666601"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-000000000014"),
                        new Guid("11111111-1111-1111-1111-111111111110"),
                        "238",
                        new Guid("66666666-6666-6666-6666-666666666602"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-000000000015"),
                        new Guid("11111111-1111-1111-1111-111111111111"),
                        "300",
                        new Guid("66666666-6666-6666-6666-666666666602"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-000000000016"),
                        new Guid("11111111-1111-1111-1111-111111111112"),
                        "~7.6",
                        new Guid("66666666-6666-6666-6666-666666666602"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-000000000017"),
                        new Guid("11111111-1111-1111-1111-111111111113"),
                        "FWD",
                        new Guid("66666666-6666-6666-6666-666666666602"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-000000000018"),
                        new Guid("11111111-1111-1111-1111-111111111114"),
                        "Single PMSM (front)",
                        new Guid("66666666-6666-6666-6666-666666666602"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-000000000019"),
                        new Guid("11111111-1111-1111-1111-111111111115"),
                        "160",
                        new Guid("66666666-6666-6666-6666-666666666602"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-00000000001a"),
                        new Guid("11111111-1111-1111-1111-111111111116"),
                        "~2090",
                        new Guid("66666666-6666-6666-6666-666666666602"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-00000000001b"),
                        new Guid("22222222-2222-2222-2222-222222222220"),
                        "87–91",
                        new Guid("66666666-6666-6666-6666-666666666602"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-00000000001c"),
                        new Guid("22222222-2222-2222-2222-222222222221"),
                        "~465",
                        new Guid("66666666-6666-6666-6666-666666666602"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-00000000001d"),
                        new Guid("22222222-2222-2222-2222-222222222222"),
                        "~193",
                        new Guid("66666666-6666-6666-6666-666666666602"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-00000000001e"),
                        new Guid("22222222-2222-2222-2222-222222222223"),
                        "Li‑ion (NMC)",
                        new Guid("66666666-6666-6666-6666-666666666602"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-00000000001f"),
                        new Guid("22222222-2222-2222-2222-222222222224"),
                        "350",
                        new Guid("66666666-6666-6666-6666-666666666602"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-000000000020"),
                        new Guid("22222222-2222-2222-2222-222222222225"),
                        "Adjustable (1‑pedal)",
                        new Guid("66666666-6666-6666-6666-666666666602"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-000000000021"),
                        new Guid("33333333-3333-3333-3333-333333333330"),
                        "7.2–11",
                        new Guid("66666666-6666-6666-6666-666666666602"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-000000000022"),
                        new Guid("33333333-3333-3333-3333-333333333331"),
                        "130",
                        new Guid("66666666-6666-6666-6666-666666666602"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-000000000023"),
                        new Guid("33333333-3333-3333-3333-333333333332"),
                        "~35",
                        new Guid("66666666-6666-6666-6666-666666666602"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-000000000024"),
                        new Guid("33333333-3333-3333-3333-333333333333"),
                        "~14",
                        new Guid("66666666-6666-6666-6666-666666666602"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-000000000025"),
                        new Guid("33333333-3333-3333-3333-333333333334"),
                        "CCS Combo",
                        new Guid("66666666-6666-6666-6666-666666666602"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-000000000026"),
                        new Guid("44444444-4444-4444-4444-444444444442"),
                        "646–1691",
                        new Guid("66666666-6666-6666-6666-666666666602"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-000000000027"),
                        new Guid("44444444-4444-4444-4444-444444444443"),
                        "Optional",
                        new Guid("66666666-6666-6666-6666-666666666602"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-000000000028"),
                        new Guid("11111111-1111-1111-1111-111111111110"),
                        "238",
                        new Guid("66666666-6666-6666-6666-666666666603"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-000000000029"),
                        new Guid("11111111-1111-1111-1111-111111111111"),
                        "300",
                        new Guid("66666666-6666-6666-6666-666666666603"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-00000000002a"),
                        new Guid("11111111-1111-1111-1111-111111111112"),
                        "~7.6",
                        new Guid("66666666-6666-6666-6666-666666666603"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-00000000002b"),
                        new Guid("11111111-1111-1111-1111-111111111113"),
                        "FWD",
                        new Guid("66666666-6666-6666-6666-666666666603"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-00000000002c"),
                        new Guid("11111111-1111-1111-1111-111111111114"),
                        "Single PMSM (front)",
                        new Guid("66666666-6666-6666-6666-666666666603"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-00000000002d"),
                        new Guid("11111111-1111-1111-1111-111111111115"),
                        "160",
                        new Guid("66666666-6666-6666-6666-666666666603"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-00000000002e"),
                        new Guid("11111111-1111-1111-1111-111111111116"),
                        "~2090",
                        new Guid("66666666-6666-6666-6666-666666666603"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-00000000002f"),
                        new Guid("22222222-2222-2222-2222-222222222220"),
                        "87–91",
                        new Guid("66666666-6666-6666-6666-666666666603"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-000000000030"),
                        new Guid("22222222-2222-2222-2222-222222222221"),
                        "~465",
                        new Guid("66666666-6666-6666-6666-666666666603"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-000000000031"),
                        new Guid("22222222-2222-2222-2222-222222222222"),
                        "~193",
                        new Guid("66666666-6666-6666-6666-666666666603"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-000000000032"),
                        new Guid("22222222-2222-2222-2222-222222222223"),
                        "Li‑ion (NMC)",
                        new Guid("66666666-6666-6666-6666-666666666603"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-000000000033"),
                        new Guid("22222222-2222-2222-2222-222222222224"),
                        "350",
                        new Guid("66666666-6666-6666-6666-666666666603"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-000000000034"),
                        new Guid("22222222-2222-2222-2222-222222222225"),
                        "Adjustable (1‑pedal)",
                        new Guid("66666666-6666-6666-6666-666666666603"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-000000000035"),
                        new Guid("33333333-3333-3333-3333-333333333330"),
                        "7.2–11",
                        new Guid("66666666-6666-6666-6666-666666666603"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-000000000036"),
                        new Guid("33333333-3333-3333-3333-333333333331"),
                        "130",
                        new Guid("66666666-6666-6666-6666-666666666603"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-000000000037"),
                        new Guid("33333333-3333-3333-3333-333333333332"),
                        "~35",
                        new Guid("66666666-6666-6666-6666-666666666603"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-000000000038"),
                        new Guid("33333333-3333-3333-3333-333333333333"),
                        "~14",
                        new Guid("66666666-6666-6666-6666-666666666603"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-000000000039"),
                        new Guid("33333333-3333-3333-3333-333333333334"),
                        "CCS Combo",
                        new Guid("66666666-6666-6666-6666-666666666603"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-00000000003a"),
                        new Guid("44444444-4444-4444-4444-444444444442"),
                        "646–1691",
                        new Guid("66666666-6666-6666-6666-666666666603"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-00000000003b"),
                        new Guid("44444444-4444-4444-4444-444444444443"),
                        "Optional",
                        new Guid("66666666-6666-6666-6666-666666666603"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-00000000003c"),
                        new Guid("11111111-1111-1111-1111-111111111110"),
                        "238",
                        new Guid("66666666-6666-6666-6666-666666666604"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-00000000003d"),
                        new Guid("11111111-1111-1111-1111-111111111111"),
                        "300",
                        new Guid("66666666-6666-6666-6666-666666666604"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-00000000003e"),
                        new Guid("11111111-1111-1111-1111-111111111112"),
                        "~7.6",
                        new Guid("66666666-6666-6666-6666-666666666604"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-00000000003f"),
                        new Guid("11111111-1111-1111-1111-111111111113"),
                        "FWD",
                        new Guid("66666666-6666-6666-6666-666666666604"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-000000000040"),
                        new Guid("11111111-1111-1111-1111-111111111114"),
                        "Single PMSM (front)",
                        new Guid("66666666-6666-6666-6666-666666666604"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-000000000041"),
                        new Guid("11111111-1111-1111-1111-111111111115"),
                        "160",
                        new Guid("66666666-6666-6666-6666-666666666604"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-000000000042"),
                        new Guid("11111111-1111-1111-1111-111111111116"),
                        "~2090",
                        new Guid("66666666-6666-6666-6666-666666666604"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-000000000043"),
                        new Guid("22222222-2222-2222-2222-222222222220"),
                        "87–91",
                        new Guid("66666666-6666-6666-6666-666666666604"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-000000000044"),
                        new Guid("22222222-2222-2222-2222-222222222221"),
                        "~465",
                        new Guid("66666666-6666-6666-6666-666666666604"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-000000000045"),
                        new Guid("22222222-2222-2222-2222-222222222222"),
                        "~193",
                        new Guid("66666666-6666-6666-6666-666666666604"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-000000000046"),
                        new Guid("22222222-2222-2222-2222-222222222223"),
                        "Li‑ion (NMC)",
                        new Guid("66666666-6666-6666-6666-666666666604"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-000000000047"),
                        new Guid("22222222-2222-2222-2222-222222222224"),
                        "350",
                        new Guid("66666666-6666-6666-6666-666666666604"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-000000000048"),
                        new Guid("22222222-2222-2222-2222-222222222225"),
                        "Adjustable (1‑pedal)",
                        new Guid("66666666-6666-6666-6666-666666666604"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-000000000049"),
                        new Guid("33333333-3333-3333-3333-333333333330"),
                        "7.2–11",
                        new Guid("66666666-6666-6666-6666-666666666604"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-00000000004a"),
                        new Guid("33333333-3333-3333-3333-333333333331"),
                        "130",
                        new Guid("66666666-6666-6666-6666-666666666604"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-00000000004b"),
                        new Guid("33333333-3333-3333-3333-333333333332"),
                        "~35",
                        new Guid("66666666-6666-6666-6666-666666666604"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-00000000004c"),
                        new Guid("33333333-3333-3333-3333-333333333333"),
                        "~14",
                        new Guid("66666666-6666-6666-6666-666666666604"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-00000000004d"),
                        new Guid("33333333-3333-3333-3333-333333333334"),
                        "CCS Combo",
                        new Guid("66666666-6666-6666-6666-666666666604"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-00000000004e"),
                        new Guid("44444444-4444-4444-4444-444444444442"),
                        "646–1691",
                        new Guid("66666666-6666-6666-6666-666666666604"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-00000000004f"),
                        new Guid("44444444-4444-4444-4444-444444444443"),
                        "Optional",
                        new Guid("66666666-6666-6666-6666-666666666604"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-000000000050"),
                        new Guid("11111111-1111-1111-1111-111111111110"),
                        "389",
                        new Guid("66666666-6666-6666-6666-666666666605"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-000000000051"),
                        new Guid("11111111-1111-1111-1111-111111111111"),
                        "600",
                        new Guid("66666666-6666-6666-6666-666666666605"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-000000000052"),
                        new Guid("11111111-1111-1111-1111-111111111112"),
                        "~5.1",
                        new Guid("66666666-6666-6666-6666-666666666605"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-000000000053"),
                        new Guid("11111111-1111-1111-1111-111111111113"),
                        "AWD (e‑4ORCE)",
                        new Guid("66666666-6666-6666-6666-666666666605"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-000000000054"),
                        new Guid("11111111-1111-1111-1111-111111111114"),
                        "Dual PMSM (front + rear)",
                        new Guid("66666666-6666-6666-6666-666666666605"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-000000000055"),
                        new Guid("11111111-1111-1111-1111-111111111115"),
                        "160",
                        new Guid("66666666-6666-6666-6666-666666666605"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-000000000056"),
                        new Guid("11111111-1111-1111-1111-111111111116"),
                        "~2294–2490",
                        new Guid("66666666-6666-6666-6666-666666666605"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-000000000057"),
                        new Guid("22222222-2222-2222-2222-222222222220"),
                        "87–91",
                        new Guid("66666666-6666-6666-6666-666666666605"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-000000000058"),
                        new Guid("22222222-2222-2222-2222-222222222221"),
                        "~438",
                        new Guid("66666666-6666-6666-6666-666666666605"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-000000000059"),
                        new Guid("22222222-2222-2222-2222-222222222222"),
                        "~228",
                        new Guid("66666666-6666-6666-6666-666666666605"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-00000000005a"),
                        new Guid("22222222-2222-2222-2222-222222222223"),
                        "Li‑ion (NMC)",
                        new Guid("66666666-6666-6666-6666-666666666605"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-00000000005b"),
                        new Guid("22222222-2222-2222-2222-222222222224"),
                        "350",
                        new Guid("66666666-6666-6666-6666-666666666605"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-00000000005c"),
                        new Guid("22222222-2222-2222-2222-222222222225"),
                        "Adjustable (1‑pedal)",
                        new Guid("66666666-6666-6666-6666-666666666605"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-00000000005d"),
                        new Guid("33333333-3333-3333-3333-333333333330"),
                        "7.2–11",
                        new Guid("66666666-6666-6666-6666-666666666605"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-00000000005e"),
                        new Guid("33333333-3333-3333-3333-333333333331"),
                        "130",
                        new Guid("66666666-6666-6666-6666-666666666605"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-00000000005f"),
                        new Guid("33333333-3333-3333-3333-333333333332"),
                        "~35",
                        new Guid("66666666-6666-6666-6666-666666666605"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-000000000060"),
                        new Guid("33333333-3333-3333-3333-333333333333"),
                        "~13",
                        new Guid("66666666-6666-6666-6666-666666666605"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-000000000061"),
                        new Guid("33333333-3333-3333-3333-333333333334"),
                        "CCS Combo",
                        new Guid("66666666-6666-6666-6666-666666666605"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-000000000062"),
                        new Guid("44444444-4444-4444-4444-444444444440"),
                        "~680–1000",
                        new Guid("66666666-6666-6666-6666-666666666605"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-000000000063"),
                        new Guid("44444444-4444-4444-4444-444444444442"),
                        "646–1691",
                        new Guid("66666666-6666-6666-6666-666666666605"),
                    },
                    {
                        new Guid("66666666-6666-6666-6666-000000000064"),
                        new Guid("44444444-4444-4444-4444-444444444443"),
                        "Standard",
                        new Guid("66666666-6666-6666-6666-666666666605"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-777777777700"),
                        new Guid("11111111-1111-1111-1111-111111111110"),
                        "402–429",
                        new Guid("77777777-7777-7777-7777-777777777701"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-777777777701"),
                        new Guid("11111111-1111-1111-1111-111111111111"),
                        "345–420",
                        new Guid("77777777-7777-7777-7777-777777777701"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-777777777702"),
                        new Guid("11111111-1111-1111-1111-111111111112"),
                        "5.4",
                        new Guid("77777777-7777-7777-7777-777777777701"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-777777777703"),
                        new Guid("11111111-1111-1111-1111-111111111113"),
                        "RWD",
                        new Guid("77777777-7777-7777-7777-777777777701"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-777777777704"),
                        new Guid("11111111-1111-1111-1111-111111111114"),
                        "Single PMSM",
                        new Guid("77777777-7777-7777-7777-777777777701"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-777777777705"),
                        new Guid("11111111-1111-1111-1111-111111111115"),
                        "230",
                        new Guid("77777777-7777-7777-7777-777777777701"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-777777777706"),
                        new Guid("11111111-1111-1111-1111-111111111116"),
                        "~2,100–2,125",
                        new Guid("77777777-7777-7777-7777-777777777701"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-777777777707"),
                        new Guid("22222222-2222-2222-2222-222222222220"),
                        "71–82",
                        new Guid("77777777-7777-7777-7777-777777777701"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-777777777708"),
                        new Guid("22222222-2222-2222-2222-222222222221"),
                        "431–503",
                        new Guid("77777777-7777-7777-7777-777777777701"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-777777777709"),
                        new Guid("22222222-2222-2222-2222-222222222222"),
                        "~200",
                        new Guid("77777777-7777-7777-7777-777777777701"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-77777777770a"),
                        new Guid("22222222-2222-2222-2222-222222222223"),
                        "Li‑ion (NMC)",
                        new Guid("77777777-7777-7777-7777-777777777701"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-77777777770b"),
                        new Guid("22222222-2222-2222-2222-222222222224"),
                        "800",
                        new Guid("77777777-7777-7777-7777-777777777701"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-77777777770c"),
                        new Guid("22222222-2222-2222-2222-222222222225"),
                        "Adjustable",
                        new Guid("77777777-7777-7777-7777-777777777701"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-77777777770d"),
                        new Guid("33333333-3333-3333-3333-333333333330"),
                        "11 (22 opt.)",
                        new Guid("77777777-7777-7777-7777-777777777701"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-77777777770e"),
                        new Guid("33333333-3333-3333-3333-333333333331"),
                        "225–270",
                        new Guid("77777777-7777-7777-7777-777777777701"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-77777777770f"),
                        new Guid("33333333-3333-3333-3333-333333333332"),
                        "~18–22",
                        new Guid("77777777-7777-7777-7777-777777777701"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-777777777710"),
                        new Guid("33333333-3333-3333-3333-333333333333"),
                        "~9–11",
                        new Guid("77777777-7777-7777-7777-777777777701"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-777777777711"),
                        new Guid("33333333-3333-3333-3333-333333333334"),
                        "CCS Combo",
                        new Guid("77777777-7777-7777-7777-777777777701"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-777777777712"),
                        new Guid("44444444-4444-4444-4444-444444444441"),
                        "~84",
                        new Guid("77777777-7777-7777-7777-777777777701"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-777777777713"),
                        new Guid("44444444-4444-4444-4444-444444444442"),
                        "~407–491",
                        new Guid("77777777-7777-7777-7777-777777777701"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-777777777714"),
                        new Guid("44444444-4444-4444-4444-444444444443"),
                        "Standard",
                        new Guid("77777777-7777-7777-7777-777777777701"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-777777777715"),
                        new Guid("11111111-1111-1111-1111-111111111110"),
                        "523–590",
                        new Guid("77777777-7777-7777-7777-777777777702"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-777777777716"),
                        new Guid("11111111-1111-1111-1111-111111111111"),
                        "650–710",
                        new Guid("77777777-7777-7777-7777-777777777702"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-777777777717"),
                        new Guid("11111111-1111-1111-1111-111111111112"),
                        "3.7–4.0",
                        new Guid("77777777-7777-7777-7777-777777777702"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-777777777718"),
                        new Guid("11111111-1111-1111-1111-111111111113"),
                        "AWD",
                        new Guid("77777777-7777-7777-7777-777777777702"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-777777777719"),
                        new Guid("11111111-1111-1111-1111-111111111114"),
                        "Dual PMSM",
                        new Guid("77777777-7777-7777-7777-777777777702"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-77777777771a"),
                        new Guid("11111111-1111-1111-1111-111111111115"),
                        "250",
                        new Guid("77777777-7777-7777-7777-777777777702"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-77777777771b"),
                        new Guid("11111111-1111-1111-1111-111111111116"),
                        "~2,190–2,200",
                        new Guid("77777777-7777-7777-7777-777777777702"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-77777777771c"),
                        new Guid("22222222-2222-2222-2222-222222222220"),
                        "82–97",
                        new Guid("77777777-7777-7777-7777-777777777702"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-77777777771d"),
                        new Guid("22222222-2222-2222-2222-222222222221"),
                        "407–506",
                        new Guid("77777777-7777-7777-7777-777777777702"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-77777777771e"),
                        new Guid("22222222-2222-2222-2222-222222222222"),
                        "~210",
                        new Guid("77777777-7777-7777-7777-777777777702"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-77777777771f"),
                        new Guid("22222222-2222-2222-2222-222222222223"),
                        "Li‑ion (NMC)",
                        new Guid("77777777-7777-7777-7777-777777777702"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-777777777720"),
                        new Guid("22222222-2222-2222-2222-222222222224"),
                        "800",
                        new Guid("77777777-7777-7777-7777-777777777702"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-777777777721"),
                        new Guid("22222222-2222-2222-2222-222222222225"),
                        "Adjustable",
                        new Guid("77777777-7777-7777-7777-777777777702"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-777777777722"),
                        new Guid("33333333-3333-3333-3333-333333333330"),
                        "11 (22 opt.)",
                        new Guid("77777777-7777-7777-7777-777777777702"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-777777777723"),
                        new Guid("33333333-3333-3333-3333-333333333331"),
                        "225–270",
                        new Guid("77777777-7777-7777-7777-777777777702"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-777777777724"),
                        new Guid("33333333-3333-3333-3333-333333333332"),
                        "~18–22",
                        new Guid("77777777-7777-7777-7777-777777777702"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-777777777725"),
                        new Guid("33333333-3333-3333-3333-333333333333"),
                        "~9–11",
                        new Guid("77777777-7777-7777-7777-777777777702"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-777777777726"),
                        new Guid("33333333-3333-3333-3333-333333333334"),
                        "CCS Combo",
                        new Guid("77777777-7777-7777-7777-777777777702"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-777777777727"),
                        new Guid("44444444-4444-4444-4444-444444444441"),
                        "~84",
                        new Guid("77777777-7777-7777-7777-777777777702"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-777777777728"),
                        new Guid("44444444-4444-4444-4444-444444444442"),
                        "~488",
                        new Guid("77777777-7777-7777-7777-777777777702"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-777777777729"),
                        new Guid("44444444-4444-4444-4444-444444444443"),
                        "Standard",
                        new Guid("77777777-7777-7777-7777-777777777702"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-77777777772a"),
                        new Guid("11111111-1111-1111-1111-111111111110"),
                        "590–690",
                        new Guid("77777777-7777-7777-7777-777777777703"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-77777777772b"),
                        new Guid("11111111-1111-1111-1111-111111111111"),
                        "850",
                        new Guid("77777777-7777-7777-7777-777777777703"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-77777777772c"),
                        new Guid("11111111-1111-1111-1111-111111111112"),
                        "3.3–3.7",
                        new Guid("77777777-7777-7777-7777-777777777703"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-77777777772d"),
                        new Guid("11111111-1111-1111-1111-111111111113"),
                        "AWD",
                        new Guid("77777777-7777-7777-7777-777777777703"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-77777777772e"),
                        new Guid("11111111-1111-1111-1111-111111111114"),
                        "Dual PMSM",
                        new Guid("77777777-7777-7777-7777-777777777703"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-77777777772f"),
                        new Guid("11111111-1111-1111-1111-111111111115"),
                        "250",
                        new Guid("77777777-7777-7777-7777-777777777703"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-777777777730"),
                        new Guid("11111111-1111-1111-1111-111111111116"),
                        "~2,345",
                        new Guid("77777777-7777-7777-7777-777777777703"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-777777777731"),
                        new Guid("22222222-2222-2222-2222-222222222220"),
                        "84–97",
                        new Guid("77777777-7777-7777-7777-777777777703"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-777777777732"),
                        new Guid("22222222-2222-2222-2222-222222222221"),
                        "504–505",
                        new Guid("77777777-7777-7777-7777-777777777703"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-777777777733"),
                        new Guid("22222222-2222-2222-2222-222222222222"),
                        "~186–203",
                        new Guid("77777777-7777-7777-7777-777777777703"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-777777777734"),
                        new Guid("22222222-2222-2222-2222-222222222223"),
                        "Li‑ion (NMC)",
                        new Guid("77777777-7777-7777-7777-777777777703"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-777777777735"),
                        new Guid("22222222-2222-2222-2222-222222222224"),
                        "800",
                        new Guid("77777777-7777-7777-7777-777777777703"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-777777777736"),
                        new Guid("22222222-2222-2222-2222-222222222225"),
                        "Adjustable",
                        new Guid("77777777-7777-7777-7777-777777777703"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-777777777737"),
                        new Guid("33333333-3333-3333-3333-333333333330"),
                        "11 (22 opt.)",
                        new Guid("77777777-7777-7777-7777-777777777703"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-777777777738"),
                        new Guid("33333333-3333-3333-3333-333333333331"),
                        "270–320",
                        new Guid("77777777-7777-7777-7777-777777777703"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-777777777739"),
                        new Guid("33333333-3333-3333-3333-333333333332"),
                        "~18",
                        new Guid("77777777-7777-7777-7777-777777777703"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-77777777773a"),
                        new Guid("33333333-3333-3333-3333-333333333333"),
                        "~11",
                        new Guid("77777777-7777-7777-7777-777777777703"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-77777777773b"),
                        new Guid("33333333-3333-3333-3333-333333333334"),
                        "CCS Combo",
                        new Guid("77777777-7777-7777-7777-777777777703"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-77777777773c"),
                        new Guid("44444444-4444-4444-4444-444444444441"),
                        "~81",
                        new Guid("77777777-7777-7777-7777-777777777703"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-77777777773d"),
                        new Guid("44444444-4444-4444-4444-444444444442"),
                        "~488",
                        new Guid("77777777-7777-7777-7777-777777777703"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-77777777773e"),
                        new Guid("44444444-4444-4444-4444-444444444443"),
                        "Standard",
                        new Guid("77777777-7777-7777-7777-777777777703"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-77777777773f"),
                        new Guid("11111111-1111-1111-1111-111111111110"),
                        "671–871",
                        new Guid("77777777-7777-7777-7777-777777777704"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-777777777740"),
                        new Guid("11111111-1111-1111-1111-111111111111"),
                        "850–890",
                        new Guid("77777777-7777-7777-7777-777777777704"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-777777777741"),
                        new Guid("11111111-1111-1111-1111-111111111112"),
                        "2.7–3.2",
                        new Guid("77777777-7777-7777-7777-777777777704"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-777777777742"),
                        new Guid("11111111-1111-1111-1111-111111111113"),
                        "AWD",
                        new Guid("77777777-7777-7777-7777-777777777704"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-777777777743"),
                        new Guid("11111111-1111-1111-1111-111111111114"),
                        "Dual PMSM",
                        new Guid("77777777-7777-7777-7777-777777777704"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-777777777744"),
                        new Guid("11111111-1111-1111-1111-111111111115"),
                        "260",
                        new Guid("77777777-7777-7777-7777-777777777704"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-777777777745"),
                        new Guid("11111111-1111-1111-1111-111111111116"),
                        "~2,355",
                        new Guid("77777777-7777-7777-7777-777777777704"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-777777777746"),
                        new Guid("22222222-2222-2222-2222-222222222220"),
                        "84–97",
                        new Guid("77777777-7777-7777-7777-777777777704"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-777777777747"),
                        new Guid("22222222-2222-2222-2222-222222222221"),
                        "450–505",
                        new Guid("77777777-7777-7777-7777-777777777704"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-777777777748"),
                        new Guid("22222222-2222-2222-2222-222222222222"),
                        "~220–230",
                        new Guid("77777777-7777-7777-7777-777777777704"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-777777777749"),
                        new Guid("22222222-2222-2222-2222-222222222223"),
                        "Li‑ion (NMC)",
                        new Guid("77777777-7777-7777-7777-777777777704"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-77777777774a"),
                        new Guid("22222222-2222-2222-2222-222222222224"),
                        "800",
                        new Guid("77777777-7777-7777-7777-777777777704"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-77777777774b"),
                        new Guid("22222222-2222-2222-2222-222222222225"),
                        "Adjustable",
                        new Guid("77777777-7777-7777-7777-777777777704"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-77777777774c"),
                        new Guid("33333333-3333-3333-3333-333333333330"),
                        "11 (22 opt.)",
                        new Guid("77777777-7777-7777-7777-777777777704"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-77777777774d"),
                        new Guid("33333333-3333-3333-3333-333333333331"),
                        "270–320",
                        new Guid("77777777-7777-7777-7777-777777777704"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-77777777774e"),
                        new Guid("33333333-3333-3333-3333-333333333332"),
                        "~18",
                        new Guid("77777777-7777-7777-7777-777777777704"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-77777777774f"),
                        new Guid("33333333-3333-3333-3333-333333333333"),
                        "~11",
                        new Guid("77777777-7777-7777-7777-777777777704"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-777777777750"),
                        new Guid("33333333-3333-3333-3333-333333333334"),
                        "CCS Combo",
                        new Guid("77777777-7777-7777-7777-777777777704"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-777777777751"),
                        new Guid("44444444-4444-4444-4444-444444444441"),
                        "~81",
                        new Guid("77777777-7777-7777-7777-777777777704"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-777777777752"),
                        new Guid("44444444-4444-4444-4444-444444444442"),
                        "~447",
                        new Guid("77777777-7777-7777-7777-777777777704"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-777777777753"),
                        new Guid("44444444-4444-4444-4444-444444444443"),
                        "Standard",
                        new Guid("77777777-7777-7777-7777-777777777704"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-777777777754"),
                        new Guid("11111111-1111-1111-1111-111111111110"),
                        "751–938",
                        new Guid("77777777-7777-7777-7777-777777777705"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-777777777755"),
                        new Guid("11111111-1111-1111-1111-111111111111"),
                        "1,050–1,110",
                        new Guid("77777777-7777-7777-7777-777777777705"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-777777777756"),
                        new Guid("11111111-1111-1111-1111-111111111112"),
                        "2.4–2.8",
                        new Guid("77777777-7777-7777-7777-777777777705"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-777777777757"),
                        new Guid("11111111-1111-1111-1111-111111111113"),
                        "AWD",
                        new Guid("77777777-7777-7777-7777-777777777705"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-777777777758"),
                        new Guid("11111111-1111-1111-1111-111111111114"),
                        "Dual PMSM",
                        new Guid("77777777-7777-7777-7777-777777777705"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-777777777759"),
                        new Guid("11111111-1111-1111-1111-111111111115"),
                        "260",
                        new Guid("77777777-7777-7777-7777-777777777705"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-77777777775a"),
                        new Guid("11111111-1111-1111-1111-111111111116"),
                        "~2,295–2,345",
                        new Guid("77777777-7777-7777-7777-777777777705"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-77777777775b"),
                        new Guid("22222222-2222-2222-2222-222222222220"),
                        "84–97",
                        new Guid("77777777-7777-7777-7777-777777777705"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-77777777775c"),
                        new Guid("22222222-2222-2222-2222-222222222221"),
                        "412–506",
                        new Guid("77777777-7777-7777-7777-777777777705"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-77777777775d"),
                        new Guid("22222222-2222-2222-2222-222222222222"),
                        "~230–250",
                        new Guid("77777777-7777-7777-7777-777777777705"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-77777777775e"),
                        new Guid("22222222-2222-2222-2222-222222222223"),
                        "Li‑ion (NMC)",
                        new Guid("77777777-7777-7777-7777-777777777705"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-77777777775f"),
                        new Guid("22222222-2222-2222-2222-222222222224"),
                        "800",
                        new Guid("77777777-7777-7777-7777-777777777705"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-777777777760"),
                        new Guid("22222222-2222-2222-2222-222222222225"),
                        "Adjustable",
                        new Guid("77777777-7777-7777-7777-777777777705"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-777777777761"),
                        new Guid("33333333-3333-3333-3333-333333333330"),
                        "11 (22 opt.)",
                        new Guid("77777777-7777-7777-7777-777777777705"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-777777777762"),
                        new Guid("33333333-3333-3333-3333-333333333331"),
                        "270–320",
                        new Guid("77777777-7777-7777-7777-777777777705"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-777777777763"),
                        new Guid("33333333-3333-3333-3333-333333333332"),
                        "~18",
                        new Guid("77777777-7777-7777-7777-777777777705"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-777777777764"),
                        new Guid("33333333-3333-3333-3333-333333333333"),
                        "~11",
                        new Guid("77777777-7777-7777-7777-777777777705"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-777777777765"),
                        new Guid("33333333-3333-3333-3333-333333333334"),
                        "CCS Combo",
                        new Guid("77777777-7777-7777-7777-777777777705"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-777777777766"),
                        new Guid("44444444-4444-4444-4444-444444444441"),
                        "~81",
                        new Guid("77777777-7777-7777-7777-777777777705"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-777777777767"),
                        new Guid("44444444-4444-4444-4444-444444444442"),
                        "~447",
                        new Guid("77777777-7777-7777-7777-777777777705"),
                    },
                    {
                        new Guid("77777777-7777-7777-7777-777777777768"),
                        new Guid("44444444-4444-4444-4444-444444444443"),
                        "Standard",
                        new Guid("77777777-7777-7777-7777-777777777705"),
                    },
                    {
                        new Guid("88888888-8888-8888-8888-888888888800"),
                        new Guid("11111111-1111-1111-1111-111111111110"),
                        "282",
                        new Guid("88888888-8888-8888-8888-888888888801"),
                    },
                    {
                        new Guid("88888888-8888-8888-8888-888888888801"),
                        new Guid("11111111-1111-1111-1111-111111111111"),
                        "400",
                        new Guid("88888888-8888-8888-8888-888888888801"),
                    },
                    {
                        new Guid("88888888-8888-8888-8888-888888888802"),
                        new Guid("11111111-1111-1111-1111-111111111112"),
                        "5.8–6.0",
                        new Guid("88888888-8888-8888-8888-888888888801"),
                    },
                    {
                        new Guid("88888888-8888-8888-8888-888888888803"),
                        new Guid("11111111-1111-1111-1111-111111111113"),
                        "RWD",
                        new Guid("88888888-8888-8888-8888-888888888801"),
                    },
                    {
                        new Guid("88888888-8888-8888-8888-888888888804"),
                        new Guid("11111111-1111-1111-1111-111111111114"),
                        "Single Synchronous",
                        new Guid("88888888-8888-8888-8888-888888888801"),
                    },
                    {
                        new Guid("88888888-8888-8888-8888-888888888805"),
                        new Guid("11111111-1111-1111-1111-111111111115"),
                        "190",
                        new Guid("88888888-8888-8888-8888-888888888801"),
                    },
                    {
                        new Guid("88888888-8888-8888-8888-888888888806"),
                        new Guid("11111111-1111-1111-1111-111111111116"),
                        "~2,000–2,075",
                        new Guid("88888888-8888-8888-8888-888888888801"),
                    },
                    {
                        new Guid("88888888-8888-8888-8888-888888888807"),
                        new Guid("22222222-2222-2222-2222-222222222220"),
                        "67.1",
                        new Guid("88888888-8888-8888-8888-888888888801"),
                    },
                    {
                        new Guid("88888888-8888-8888-8888-888888888808"),
                        new Guid("22222222-2222-2222-2222-222222222221"),
                        "406–485",
                        new Guid("88888888-8888-8888-8888-888888888801"),
                    },
                    {
                        new Guid("88888888-8888-8888-8888-888888888809"),
                        new Guid("22222222-2222-2222-2222-222222222222"),
                        "~156",
                        new Guid("88888888-8888-8888-8888-888888888801"),
                    },
                    {
                        new Guid("88888888-8888-8888-8888-88888888880a"),
                        new Guid("22222222-2222-2222-2222-222222222223"),
                        "Li‑ion (NMC)",
                        new Guid("88888888-8888-8888-8888-888888888801"),
                    },
                    {
                        new Guid("88888888-8888-8888-8888-88888888880b"),
                        new Guid("22222222-2222-2222-2222-222222222224"),
                        "~353",
                        new Guid("88888888-8888-8888-8888-888888888801"),
                    },
                    {
                        new Guid("88888888-8888-8888-8888-88888888880c"),
                        new Guid("22222222-2222-2222-2222-222222222225"),
                        "Adjustable",
                        new Guid("88888888-8888-8888-8888-888888888801"),
                    },
                    {
                        new Guid("88888888-8888-8888-8888-88888888880d"),
                        new Guid("33333333-3333-3333-3333-333333333330"),
                        "11",
                        new Guid("88888888-8888-8888-8888-888888888801"),
                    },
                    {
                        new Guid("88888888-8888-8888-8888-88888888880e"),
                        new Guid("33333333-3333-3333-3333-333333333331"),
                        "180",
                        new Guid("88888888-8888-8888-8888-888888888801"),
                    },
                    {
                        new Guid("88888888-8888-8888-8888-88888888880f"),
                        new Guid("33333333-3333-3333-3333-333333333332"),
                        "~32",
                        new Guid("88888888-8888-8888-8888-888888888801"),
                    },
                    {
                        new Guid("88888888-8888-8888-8888-888888888810"),
                        new Guid("33333333-3333-3333-3333-333333333333"),
                        "~7",
                        new Guid("88888888-8888-8888-8888-888888888801"),
                    },
                    {
                        new Guid("88888888-8888-8888-8888-888888888811"),
                        new Guid("33333333-3333-3333-3333-333333333334"),
                        "CCS Combo",
                        new Guid("88888888-8888-8888-8888-888888888801"),
                    },
                    {
                        new Guid("88888888-8888-8888-8888-888888888812"),
                        new Guid("44444444-4444-4444-4444-444444444440"),
                        "1,600",
                        new Guid("88888888-8888-8888-8888-888888888801"),
                    },
                    {
                        new Guid("88888888-8888-8888-8888-888888888813"),
                        new Guid("44444444-4444-4444-4444-444444444442"),
                        "470 / 1,290 seats down",
                        new Guid("88888888-8888-8888-8888-888888888801"),
                    },
                    {
                        new Guid("88888888-8888-8888-8888-888888888814"),
                        new Guid("44444444-4444-4444-4444-444444444443"),
                        "Optional",
                        new Guid("88888888-8888-8888-8888-888888888801"),
                    },
                    {
                        new Guid("88888888-8888-8888-8888-888888888815"),
                        new Guid("11111111-1111-1111-1111-111111111110"),
                        "335–340",
                        new Guid("88888888-8888-8888-8888-888888888802"),
                    },
                    {
                        new Guid("88888888-8888-8888-8888-888888888816"),
                        new Guid("11111111-1111-1111-1111-111111111111"),
                        "430",
                        new Guid("88888888-8888-8888-8888-888888888802"),
                    },
                    {
                        new Guid("88888888-8888-8888-8888-888888888817"),
                        new Guid("11111111-1111-1111-1111-111111111112"),
                        "5.6–5.7",
                        new Guid("88888888-8888-8888-8888-888888888802"),
                    },
                    {
                        new Guid("88888888-8888-8888-8888-888888888818"),
                        new Guid("11111111-1111-1111-1111-111111111113"),
                        "RWD",
                        new Guid("88888888-8888-8888-8888-888888888802"),
                    },
                    {
                        new Guid("88888888-8888-8888-8888-888888888819"),
                        new Guid("11111111-1111-1111-1111-111111111114"),
                        "Single Synchronous",
                        new Guid("88888888-8888-8888-8888-888888888802"),
                    },
                    {
                        new Guid("88888888-8888-8888-8888-88888888881a"),
                        new Guid("11111111-1111-1111-1111-111111111115"),
                        "190",
                        new Guid("88888888-8888-8888-8888-888888888802"),
                    },
                    {
                        new Guid("88888888-8888-8888-8888-88888888881b"),
                        new Guid("11111111-1111-1111-1111-111111111116"),
                        "~2,050–2,125",
                        new Guid("88888888-8888-8888-8888-888888888802"),
                    },
                    {
                        new Guid("88888888-8888-8888-8888-88888888881c"),
                        new Guid("22222222-2222-2222-2222-222222222220"),
                        "81.3",
                        new Guid("88888888-8888-8888-8888-888888888802"),
                    },
                    {
                        new Guid("88888888-8888-8888-8888-88888888881d"),
                        new Guid("22222222-2222-2222-2222-222222222221"),
                        "493–590",
                        new Guid("88888888-8888-8888-8888-888888888802"),
                    },
                    {
                        new Guid("88888888-8888-8888-8888-88888888881e"),
                        new Guid("22222222-2222-2222-2222-222222222222"),
                        "~159",
                        new Guid("88888888-8888-8888-8888-888888888802"),
                    },
                    {
                        new Guid("88888888-8888-8888-8888-88888888881f"),
                        new Guid("22222222-2222-2222-2222-222222222223"),
                        "Li‑ion (NMC)",
                        new Guid("88888888-8888-8888-8888-888888888802"),
                    },
                    {
                        new Guid("88888888-8888-8888-8888-888888888820"),
                        new Guid("22222222-2222-2222-2222-222222222224"),
                        "~399",
                        new Guid("88888888-8888-8888-8888-888888888802"),
                    },
                    {
                        new Guid("88888888-8888-8888-8888-888888888821"),
                        new Guid("22222222-2222-2222-2222-222222222225"),
                        "Adjustable",
                        new Guid("88888888-8888-8888-8888-888888888802"),
                    },
                    {
                        new Guid("88888888-8888-8888-8888-888888888822"),
                        new Guid("33333333-3333-3333-3333-333333333330"),
                        "11",
                        new Guid("88888888-8888-8888-8888-888888888802"),
                    },
                    {
                        new Guid("88888888-8888-8888-8888-888888888823"),
                        new Guid("33333333-3333-3333-3333-333333333331"),
                        "205",
                        new Guid("88888888-8888-8888-8888-888888888802"),
                    },
                    {
                        new Guid("88888888-8888-8888-8888-888888888824"),
                        new Guid("33333333-3333-3333-3333-333333333332"),
                        "~30",
                        new Guid("88888888-8888-8888-8888-888888888802"),
                    },
                    {
                        new Guid("88888888-8888-8888-8888-888888888825"),
                        new Guid("33333333-3333-3333-3333-333333333333"),
                        "~8",
                        new Guid("88888888-8888-8888-8888-888888888802"),
                    },
                    {
                        new Guid("88888888-8888-8888-8888-888888888826"),
                        new Guid("33333333-3333-3333-3333-333333333334"),
                        "CCS Combo",
                        new Guid("88888888-8888-8888-8888-888888888802"),
                    },
                    {
                        new Guid("88888888-8888-8888-8888-888888888827"),
                        new Guid("44444444-4444-4444-4444-444444444440"),
                        "1,600",
                        new Guid("88888888-8888-8888-8888-888888888802"),
                    },
                    {
                        new Guid("88888888-8888-8888-8888-888888888828"),
                        new Guid("44444444-4444-4444-4444-444444444442"),
                        "470 / 1,290",
                        new Guid("88888888-8888-8888-8888-888888888802"),
                    },
                    {
                        new Guid("88888888-8888-8888-8888-888888888829"),
                        new Guid("44444444-4444-4444-4444-444444444443"),
                        "Optional",
                        new Guid("88888888-8888-8888-8888-888888888802"),
                    },
                    {
                        new Guid("88888888-8888-8888-8888-88888888882a"),
                        new Guid("11111111-1111-1111-1111-111111111110"),
                        "396–401",
                        new Guid("88888888-8888-8888-8888-888888888803"),
                    },
                    {
                        new Guid("88888888-8888-8888-8888-88888888882b"),
                        new Guid("11111111-1111-1111-1111-111111111111"),
                        "600",
                        new Guid("88888888-8888-8888-8888-888888888803"),
                    },
                    {
                        new Guid("88888888-8888-8888-8888-88888888882c"),
                        new Guid("11111111-1111-1111-1111-111111111112"),
                        "4.8–5.1",
                        new Guid("88888888-8888-8888-8888-888888888803"),
                    },
                    {
                        new Guid("88888888-8888-8888-8888-88888888882d"),
                        new Guid("11111111-1111-1111-1111-111111111113"),
                        "AWD",
                        new Guid("88888888-8888-8888-8888-888888888803"),
                    },
                    {
                        new Guid("88888888-8888-8888-8888-88888888882e"),
                        new Guid("11111111-1111-1111-1111-111111111114"),
                        "Dual Synchronous",
                        new Guid("88888888-8888-8888-8888-888888888803"),
                    },
                    {
                        new Guid("88888888-8888-8888-8888-88888888882f"),
                        new Guid("11111111-1111-1111-1111-111111111115"),
                        "200",
                        new Guid("88888888-8888-8888-8888-888888888803"),
                    },
                    {
                        new Guid("88888888-8888-8888-8888-888888888830"),
                        new Guid("11111111-1111-1111-1111-111111111116"),
                        "~2,185–2,260",
                        new Guid("88888888-8888-8888-8888-888888888803"),
                    },
                    {
                        new Guid("88888888-8888-8888-8888-888888888831"),
                        new Guid("22222222-2222-2222-2222-222222222220"),
                        "81.3",
                        new Guid("88888888-8888-8888-8888-888888888803"),
                    },
                    {
                        new Guid("88888888-8888-8888-8888-888888888832"),
                        new Guid("22222222-2222-2222-2222-222222222221"),
                        "459–546",
                        new Guid("88888888-8888-8888-8888-888888888803"),
                    },
                    {
                        new Guid("88888888-8888-8888-8888-888888888833"),
                        new Guid("22222222-2222-2222-2222-222222222222"),
                        "~166",
                        new Guid("88888888-8888-8888-8888-888888888803"),
                    },
                    {
                        new Guid("88888888-8888-8888-8888-888888888834"),
                        new Guid("22222222-2222-2222-2222-222222222223"),
                        "Li‑ion (NMC)",
                        new Guid("88888888-8888-8888-8888-888888888803"),
                    },
                    {
                        new Guid("88888888-8888-8888-8888-888888888835"),
                        new Guid("22222222-2222-2222-2222-222222222224"),
                        "~399",
                        new Guid("88888888-8888-8888-8888-888888888803"),
                    },
                    {
                        new Guid("88888888-8888-8888-8888-888888888836"),
                        new Guid("22222222-2222-2222-2222-222222222225"),
                        "Adjustable",
                        new Guid("88888888-8888-8888-8888-888888888803"),
                    },
                    {
                        new Guid("88888888-8888-8888-8888-888888888837"),
                        new Guid("33333333-3333-3333-3333-333333333330"),
                        "11",
                        new Guid("88888888-8888-8888-8888-888888888803"),
                    },
                    {
                        new Guid("88888888-8888-8888-8888-888888888838"),
                        new Guid("33333333-3333-3333-3333-333333333331"),
                        "205",
                        new Guid("88888888-8888-8888-8888-888888888803"),
                    },
                    {
                        new Guid("88888888-8888-8888-8888-888888888839"),
                        new Guid("33333333-3333-3333-3333-333333333332"),
                        "~30",
                        new Guid("88888888-8888-8888-8888-888888888803"),
                    },
                    {
                        new Guid("88888888-8888-8888-8888-88888888883a"),
                        new Guid("33333333-3333-3333-3333-333333333333"),
                        "~8",
                        new Guid("88888888-8888-8888-8888-888888888803"),
                    },
                    {
                        new Guid("88888888-8888-8888-8888-88888888883b"),
                        new Guid("33333333-3333-3333-3333-333333333334"),
                        "CCS Combo",
                        new Guid("88888888-8888-8888-8888-888888888803"),
                    },
                    {
                        new Guid("88888888-8888-8888-8888-88888888883c"),
                        new Guid("44444444-4444-4444-4444-444444444440"),
                        "1,600",
                        new Guid("88888888-8888-8888-8888-888888888803"),
                    },
                    {
                        new Guid("88888888-8888-8888-8888-88888888883d"),
                        new Guid("44444444-4444-4444-4444-444444444442"),
                        "470 / 1,290",
                        new Guid("88888888-8888-8888-8888-888888888803"),
                    },
                    {
                        new Guid("88888888-8888-8888-8888-88888888883e"),
                        new Guid("44444444-4444-4444-4444-444444444443"),
                        "Optional",
                        new Guid("88888888-8888-8888-8888-888888888803"),
                    },
                    {
                        new Guid("88888888-8888-8888-8888-88888888883f"),
                        new Guid("11111111-1111-1111-1111-111111111110"),
                        "536–544",
                        new Guid("88888888-8888-8888-8888-888888888804"),
                    },
                    {
                        new Guid("88888888-8888-8888-8888-888888888840"),
                        new Guid("11111111-1111-1111-1111-111111111111"),
                        "795",
                        new Guid("88888888-8888-8888-8888-888888888804"),
                    },
                    {
                        new Guid("88888888-8888-8888-8888-888888888841"),
                        new Guid("11111111-1111-1111-1111-111111111112"),
                        "3.7–3.9",
                        new Guid("88888888-8888-8888-8888-888888888804"),
                    },
                    {
                        new Guid("88888888-8888-8888-8888-888888888842"),
                        new Guid("11111111-1111-1111-1111-111111111113"),
                        "AWD",
                        new Guid("88888888-8888-8888-8888-888888888804"),
                    },
                    {
                        new Guid("88888888-8888-8888-8888-888888888843"),
                        new Guid("11111111-1111-1111-1111-111111111114"),
                        "Dual Synchronous",
                        new Guid("88888888-8888-8888-8888-888888888804"),
                    },
                    {
                        new Guid("88888888-8888-8888-8888-888888888844"),
                        new Guid("11111111-1111-1111-1111-111111111115"),
                        "225",
                        new Guid("88888888-8888-8888-8888-888888888804"),
                    },
                    {
                        new Guid("88888888-8888-8888-8888-888888888845"),
                        new Guid("11111111-1111-1111-1111-111111111116"),
                        "~2,215–2,290",
                        new Guid("88888888-8888-8888-8888-888888888804"),
                    },
                    {
                        new Guid("88888888-8888-8888-8888-888888888846"),
                        new Guid("22222222-2222-2222-2222-222222222220"),
                        "81.3",
                        new Guid("88888888-8888-8888-8888-888888888804"),
                    },
                    {
                        new Guid("88888888-8888-8888-8888-888888888847"),
                        new Guid("22222222-2222-2222-2222-222222222221"),
                        "416–521",
                        new Guid("88888888-8888-8888-8888-888888888804"),
                    },
                    {
                        new Guid("88888888-8888-8888-8888-888888888848"),
                        new Guid("22222222-2222-2222-2222-222222222222"),
                        "~180–225",
                        new Guid("88888888-8888-8888-8888-888888888804"),
                    },
                    {
                        new Guid("88888888-8888-8888-8888-888888888849"),
                        new Guid("22222222-2222-2222-2222-222222222223"),
                        "Li‑ion (NMC)",
                        new Guid("88888888-8888-8888-8888-888888888804"),
                    },
                    {
                        new Guid("88888888-8888-8888-8888-88888888884a"),
                        new Guid("22222222-2222-2222-2222-222222222224"),
                        "~399",
                        new Guid("88888888-8888-8888-8888-888888888804"),
                    },
                    {
                        new Guid("88888888-8888-8888-8888-88888888884b"),
                        new Guid("22222222-2222-2222-2222-222222222225"),
                        "Adjustable",
                        new Guid("88888888-8888-8888-8888-888888888804"),
                    },
                    {
                        new Guid("88888888-8888-8888-8888-88888888884c"),
                        new Guid("33333333-3333-3333-3333-333333333330"),
                        "11",
                        new Guid("88888888-8888-8888-8888-888888888804"),
                    },
                    {
                        new Guid("88888888-8888-8888-8888-88888888884d"),
                        new Guid("33333333-3333-3333-3333-333333333331"),
                        "205",
                        new Guid("88888888-8888-8888-8888-888888888804"),
                    },
                    {
                        new Guid("88888888-8888-8888-8888-88888888884e"),
                        new Guid("33333333-3333-3333-3333-333333333332"),
                        "~30",
                        new Guid("88888888-8888-8888-8888-888888888804"),
                    },
                    {
                        new Guid("88888888-8888-8888-8888-88888888884f"),
                        new Guid("33333333-3333-3333-3333-333333333333"),
                        "~8",
                        new Guid("88888888-8888-8888-8888-888888888804"),
                    },
                    {
                        new Guid("88888888-8888-8888-8888-888888888850"),
                        new Guid("33333333-3333-3333-3333-333333333334"),
                        "CCS Combo",
                        new Guid("88888888-8888-8888-8888-888888888804"),
                    },
                    {
                        new Guid("88888888-8888-8888-8888-888888888851"),
                        new Guid("44444444-4444-4444-4444-444444444440"),
                        "1,600",
                        new Guid("88888888-8888-8888-8888-888888888804"),
                    },
                    {
                        new Guid("88888888-8888-8888-8888-888888888852"),
                        new Guid("44444444-4444-4444-4444-444444444442"),
                        "470 / 1,290",
                        new Guid("88888888-8888-8888-8888-888888888804"),
                    },
                    {
                        new Guid("88888888-8888-8888-8888-888888888853"),
                        new Guid("44444444-4444-4444-4444-444444444443"),
                        "Standard",
                        new Guid("88888888-8888-8888-8888-888888888804"),
                    },
                    {
                        new Guid("99999999-9999-9999-9999-999999999900"),
                        new Guid("11111111-1111-1111-1111-111111111110"),
                        "~514",
                        new Guid("99999999-9999-9999-9999-999999999901"),
                    },
                    {
                        new Guid("99999999-9999-9999-9999-999999999901"),
                        new Guid("11111111-1111-1111-1111-111111111111"),
                        "~493",
                        new Guid("99999999-9999-9999-9999-999999999901"),
                    },
                    {
                        new Guid("99999999-9999-9999-9999-999999999902"),
                        new Guid("11111111-1111-1111-1111-111111111112"),
                        "4.8",
                        new Guid("99999999-9999-9999-9999-999999999901"),
                    },
                    {
                        new Guid("99999999-9999-9999-9999-999999999903"),
                        new Guid("11111111-1111-1111-1111-111111111113"),
                        "AWD (dual motor)",
                        new Guid("99999999-9999-9999-9999-999999999901"),
                    },
                    {
                        new Guid("99999999-9999-9999-9999-999999999904"),
                        new Guid("11111111-1111-1111-1111-111111111114"),
                        "Dual PMSM",
                        new Guid("99999999-9999-9999-9999-999999999901"),
                    },
                    {
                        new Guid("99999999-9999-9999-9999-999999999905"),
                        new Guid("11111111-1111-1111-1111-111111111115"),
                        "201",
                        new Guid("99999999-9999-9999-9999-999999999901"),
                    },
                    {
                        new Guid("99999999-9999-9999-9999-999999999906"),
                        new Guid("11111111-1111-1111-1111-111111111116"),
                        "~1,994–2,072",
                        new Guid("99999999-9999-9999-9999-999999999901"),
                    },
                    {
                        new Guid("99999999-9999-9999-9999-999999999907"),
                        new Guid("22222222-2222-2222-2222-222222222220"),
                        "~75–78",
                        new Guid("99999999-9999-9999-9999-999999999901"),
                    },
                    {
                        new Guid("99999999-9999-9999-9999-999999999908"),
                        new Guid("22222222-2222-2222-2222-222222222221"),
                        "~533",
                        new Guid("99999999-9999-9999-9999-999999999901"),
                    },
                    {
                        new Guid("99999999-9999-9999-9999-999999999909"),
                        new Guid("22222222-2222-2222-2222-222222222222"),
                        "~165",
                        new Guid("99999999-9999-9999-9999-999999999901"),
                    },
                    {
                        new Guid("99999999-9999-9999-9999-99999999990a"),
                        new Guid("22222222-2222-2222-2222-222222222223"),
                        "Li‑ion (NCM)",
                        new Guid("99999999-9999-9999-9999-999999999901"),
                    },
                    {
                        new Guid("99999999-9999-9999-9999-99999999990b"),
                        new Guid("22222222-2222-2222-2222-222222222224"),
                        "~345–360",
                        new Guid("99999999-9999-9999-9999-999999999901"),
                    },
                    {
                        new Guid("99999999-9999-9999-9999-99999999990c"),
                        new Guid("22222222-2222-2222-2222-222222222225"),
                        "Standard (1‑pedal)",
                        new Guid("99999999-9999-9999-9999-999999999901"),
                    },
                    {
                        new Guid("99999999-9999-9999-9999-99999999990d"),
                        new Guid("33333333-3333-3333-3333-333333333330"),
                        "11",
                        new Guid("99999999-9999-9999-9999-999999999901"),
                    },
                    {
                        new Guid("99999999-9999-9999-9999-99999999990e"),
                        new Guid("33333333-3333-3333-3333-333333333331"),
                        "250",
                        new Guid("99999999-9999-9999-9999-999999999901"),
                    },
                    {
                        new Guid("99999999-9999-9999-9999-99999999990f"),
                        new Guid("33333333-3333-3333-3333-333333333332"),
                        "~27–30",
                        new Guid("99999999-9999-9999-9999-999999999901"),
                    },
                    {
                        new Guid("99999999-9999-9999-9999-999999999910"),
                        new Guid("33333333-3333-3333-3333-333333333333"),
                        "~8",
                        new Guid("99999999-9999-9999-9999-999999999901"),
                    },
                    {
                        new Guid("99999999-9999-9999-9999-999999999911"),
                        new Guid("33333333-3333-3333-3333-333333333334"),
                        "Tesla NACS (NA) / CCS (EU)",
                        new Guid("99999999-9999-9999-9999-999999999901"),
                    },
                    {
                        new Guid("99999999-9999-9999-9999-999999999912"),
                        new Guid("44444444-4444-4444-4444-444444444440"),
                        "~1,600",
                        new Guid("99999999-9999-9999-9999-999999999901"),
                    },
                    {
                        new Guid("99999999-9999-9999-9999-999999999913"),
                        new Guid("44444444-4444-4444-4444-444444444441"),
                        "~117",
                        new Guid("99999999-9999-9999-9999-999999999901"),
                    },
                    {
                        new Guid("99999999-9999-9999-9999-999999999914"),
                        new Guid("44444444-4444-4444-4444-444444444442"),
                        "854–2,158",
                        new Guid("99999999-9999-9999-9999-999999999901"),
                    },
                    {
                        new Guid("99999999-9999-9999-9999-999999999915"),
                        new Guid("44444444-4444-4444-4444-444444444443"),
                        "Standard",
                        new Guid("99999999-9999-9999-9999-999999999901"),
                    },
                    {
                        new Guid("99999999-9999-9999-9999-999999999916"),
                        new Guid("11111111-1111-1111-1111-111111111110"),
                        "~534",
                        new Guid("99999999-9999-9999-9999-999999999902"),
                    },
                    {
                        new Guid("99999999-9999-9999-9999-999999999917"),
                        new Guid("11111111-1111-1111-1111-111111111111"),
                        "~741",
                        new Guid("99999999-9999-9999-9999-999999999902"),
                    },
                    {
                        new Guid("99999999-9999-9999-9999-999999999918"),
                        new Guid("11111111-1111-1111-1111-111111111112"),
                        "3.5–3.7",
                        new Guid("99999999-9999-9999-9999-999999999902"),
                    },
                    {
                        new Guid("99999999-9999-9999-9999-999999999919"),
                        new Guid("11111111-1111-1111-1111-111111111113"),
                        "AWD (dual motor)",
                        new Guid("99999999-9999-9999-9999-999999999902"),
                    },
                    {
                        new Guid("99999999-9999-9999-9999-99999999991a"),
                        new Guid("11111111-1111-1111-1111-111111111114"),
                        "Dual PMSM",
                        new Guid("99999999-9999-9999-9999-999999999902"),
                    },
                    {
                        new Guid("99999999-9999-9999-9999-99999999991b"),
                        new Guid("11111111-1111-1111-1111-111111111115"),
                        "250",
                        new Guid("99999999-9999-9999-9999-999999999902"),
                    },
                    {
                        new Guid("99999999-9999-9999-9999-99999999991c"),
                        new Guid("11111111-1111-1111-1111-111111111116"),
                        "~1,995–2,108",
                        new Guid("99999999-9999-9999-9999-999999999902"),
                    },
                    {
                        new Guid("99999999-9999-9999-9999-99999999991d"),
                        new Guid("22222222-2222-2222-2222-222222222220"),
                        "~77–79",
                        new Guid("99999999-9999-9999-9999-999999999902"),
                    },
                    {
                        new Guid("99999999-9999-9999-9999-99999999991e"),
                        new Guid("22222222-2222-2222-2222-222222222221"),
                        "~460–514",
                        new Guid("99999999-9999-9999-9999-999999999902"),
                    },
                    {
                        new Guid("99999999-9999-9999-9999-99999999991f"),
                        new Guid("22222222-2222-2222-2222-222222222222"),
                        "~172",
                        new Guid("99999999-9999-9999-9999-999999999902"),
                    },
                    {
                        new Guid("99999999-9999-9999-9999-999999999920"),
                        new Guid("22222222-2222-2222-2222-222222222223"),
                        "Li‑ion (NCM)",
                        new Guid("99999999-9999-9999-9999-999999999902"),
                    },
                    {
                        new Guid("99999999-9999-9999-9999-999999999921"),
                        new Guid("22222222-2222-2222-2222-222222222224"),
                        "~360",
                        new Guid("99999999-9999-9999-9999-999999999902"),
                    },
                    {
                        new Guid("99999999-9999-9999-9999-999999999922"),
                        new Guid("22222222-2222-2222-2222-222222222225"),
                        "Standard (1‑pedal)",
                        new Guid("99999999-9999-9999-9999-999999999902"),
                    },
                    {
                        new Guid("99999999-9999-9999-9999-999999999923"),
                        new Guid("33333333-3333-3333-3333-333333333330"),
                        "11",
                        new Guid("99999999-9999-9999-9999-999999999902"),
                    },
                    {
                        new Guid("99999999-9999-9999-9999-999999999924"),
                        new Guid("33333333-3333-3333-3333-333333333331"),
                        "250",
                        new Guid("99999999-9999-9999-9999-999999999902"),
                    },
                    {
                        new Guid("99999999-9999-9999-9999-999999999925"),
                        new Guid("33333333-3333-3333-3333-333333333332"),
                        "~29–30",
                        new Guid("99999999-9999-9999-9999-999999999902"),
                    },
                    {
                        new Guid("99999999-9999-9999-9999-999999999926"),
                        new Guid("33333333-3333-3333-3333-333333333333"),
                        "~8.5",
                        new Guid("99999999-9999-9999-9999-999999999902"),
                    },
                    {
                        new Guid("99999999-9999-9999-9999-999999999927"),
                        new Guid("33333333-3333-3333-3333-333333333334"),
                        "Tesla NACS / CCS",
                        new Guid("99999999-9999-9999-9999-999999999902"),
                    },
                    {
                        new Guid("99999999-9999-9999-9999-999999999928"),
                        new Guid("44444444-4444-4444-4444-444444444440"),
                        "~1,600",
                        new Guid("99999999-9999-9999-9999-999999999902"),
                    },
                    {
                        new Guid("99999999-9999-9999-9999-999999999929"),
                        new Guid("44444444-4444-4444-4444-444444444441"),
                        "~117",
                        new Guid("99999999-9999-9999-9999-999999999902"),
                    },
                    {
                        new Guid("99999999-9999-9999-9999-99999999992a"),
                        new Guid("44444444-4444-4444-4444-444444444442"),
                        "854–2,158",
                        new Guid("99999999-9999-9999-9999-999999999902"),
                    },
                    {
                        new Guid("99999999-9999-9999-9999-99999999992b"),
                        new Guid("44444444-4444-4444-4444-444444444443"),
                        "Standard",
                        new Guid("99999999-9999-9999-9999-999999999902"),
                    },
                    {
                        new Guid("99999999-9999-9999-9999-99999999992c"),
                        new Guid("11111111-1111-1111-1111-111111111110"),
                        "~510–530",
                        new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa01"),
                    },
                    {
                        new Guid("99999999-9999-9999-9999-99999999992d"),
                        new Guid("11111111-1111-1111-1111-111111111111"),
                        "~660",
                        new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa01"),
                    },
                    {
                        new Guid("99999999-9999-9999-9999-99999999992e"),
                        new Guid("11111111-1111-1111-1111-111111111112"),
                        "2.9–3.3",
                        new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa01"),
                    },
                    {
                        new Guid("99999999-9999-9999-9999-99999999992f"),
                        new Guid("11111111-1111-1111-1111-111111111113"),
                        "AWD (dual motor)",
                        new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa01"),
                    },
                    {
                        new Guid("99999999-9999-9999-9999-999999999930"),
                        new Guid("11111111-1111-1111-1111-111111111114"),
                        "Dual PMSM",
                        new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa01"),
                    },
                    {
                        new Guid("99999999-9999-9999-9999-999999999931"),
                        new Guid("11111111-1111-1111-1111-111111111115"),
                        "260–261",
                        new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa01"),
                    },
                    {
                        new Guid("99999999-9999-9999-9999-999999999932"),
                        new Guid("11111111-1111-1111-1111-111111111116"),
                        "~1,851–1,906",
                        new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa01"),
                    },
                    {
                        new Guid("99999999-9999-9999-9999-999999999933"),
                        new Guid("22222222-2222-2222-2222-222222222220"),
                        "~82",
                        new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa01"),
                    },
                    {
                        new Guid("99999999-9999-9999-9999-999999999934"),
                        new Guid("22222222-2222-2222-2222-222222222221"),
                        "~567",
                        new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa01"),
                    },
                    {
                        new Guid("99999999-9999-9999-9999-999999999935"),
                        new Guid("22222222-2222-2222-2222-222222222222"),
                        "~139–172",
                        new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa01"),
                    },
                    {
                        new Guid("99999999-9999-9999-9999-999999999936"),
                        new Guid("22222222-2222-2222-2222-222222222223"),
                        "Li‑ion (NCM)",
                        new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa01"),
                    },
                    {
                        new Guid("99999999-9999-9999-9999-999999999937"),
                        new Guid("22222222-2222-2222-2222-222222222224"),
                        "~360",
                        new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa01"),
                    },
                    {
                        new Guid("99999999-9999-9999-9999-999999999938"),
                        new Guid("22222222-2222-2222-2222-222222222225"),
                        "Standard (1‑pedal)",
                        new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa01"),
                    },
                    {
                        new Guid("99999999-9999-9999-9999-999999999939"),
                        new Guid("33333333-3333-3333-3333-333333333330"),
                        "11",
                        new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa01"),
                    },
                    {
                        new Guid("99999999-9999-9999-9999-99999999993a"),
                        new Guid("33333333-3333-3333-3333-333333333331"),
                        "250",
                        new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa01"),
                    },
                    {
                        new Guid("99999999-9999-9999-9999-99999999993b"),
                        new Guid("33333333-3333-3333-3333-333333333332"),
                        "~25–27",
                        new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa01"),
                    },
                    {
                        new Guid("99999999-9999-9999-9999-99999999993c"),
                        new Guid("33333333-3333-3333-3333-333333333333"),
                        "~8",
                        new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa01"),
                    },
                    {
                        new Guid("99999999-9999-9999-9999-99999999993d"),
                        new Guid("33333333-3333-3333-3333-333333333334"),
                        "Tesla NACS / CCS",
                        new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa01"),
                    },
                    {
                        new Guid("99999999-9999-9999-9999-99999999993e"),
                        new Guid("44444444-4444-4444-4444-444444444440"),
                        "~1,000",
                        new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa01"),
                    },
                    {
                        new Guid("99999999-9999-9999-9999-99999999993f"),
                        new Guid("44444444-4444-4444-4444-444444444441"),
                        "~88",
                        new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa01"),
                    },
                    {
                        new Guid("99999999-9999-9999-9999-999999999940"),
                        new Guid("44444444-4444-4444-4444-444444444442"),
                        "542",
                        new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa01"),
                    },
                    {
                        new Guid("99999999-9999-9999-9999-999999999941"),
                        new Guid("44444444-4444-4444-4444-444444444443"),
                        "Standard",
                        new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa01"),
                    },
                }
            );

            migrationBuilder.CreateIndex(
                name: "IX_CustomerDealers_CustomerId",
                table: "CustomerDealers",
                column: "CustomerId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_CustomerDealers_DealerId",
                table: "CustomerDealers",
                column: "DealerId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_DealerAllocations_DealerId",
                table: "DealerAllocations",
                column: "DealerId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_DealerAllocations_VehicleId",
                table: "DealerAllocations",
                column: "VehicleId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_DealerContracts_DealerId",
                table: "DealerContracts",
                column: "DealerId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_DealerOrderItems_ColorId",
                table: "DealerOrderItems",
                column: "ColorId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_DealerOrderItems_OrderId",
                table: "DealerOrderItems",
                column: "OrderId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_DealerOrderItems_VariantId",
                table: "DealerOrderItems",
                column: "VariantId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_DealerOrders_DealerId",
                table: "DealerOrders",
                column: "DealerId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_Features_CategoryId",
                table: "Features",
                column: "CategoryId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_CustomerId",
                table: "Feedbacks",
                column: "CustomerId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_DealerId",
                table: "Feedbacks",
                column: "DealerId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_OemInventories_VehicleId",
                table: "OemInventories",
                column: "VehicleId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_Payments_SalesContractId",
                table: "Payments",
                column: "SalesContractId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_Promotions_DealerId",
                table: "Promotions",
                column: "DealerId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_Quotations_CustomerId",
                table: "Quotations",
                column: "CustomerId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_Quotations_DealerId",
                table: "Quotations",
                column: "DealerId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_Quotations_UserId",
                table: "Quotations",
                column: "UserId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_SalesContracts_SalesOrderId",
                table: "SalesContracts",
                column: "SalesOrderId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrders_CustomerId",
                table: "SalesOrders",
                column: "CustomerId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrders_DealerId",
                table: "SalesOrders",
                column: "DealerId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrders_QuotationId",
                table: "SalesOrders",
                column: "QuotationId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrders_UserId",
                table: "SalesOrders",
                column: "UserId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrders_VehicleId",
                table: "SalesOrders",
                column: "VehicleId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_Specs_SpecCategoryId",
                table: "Specs",
                column: "SpecCategoryId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_TestDrives_CustomerId",
                table: "TestDrives",
                column: "CustomerId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_TestDrives_DealerId",
                table: "TestDrives",
                column: "DealerId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_TestDrives_VehicleId",
                table: "TestDrives",
                column: "VehicleId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_Users_DealerId",
                table: "Users",
                column: "DealerId"
            );

            migrationBuilder.CreateIndex(name: "IX_Users_RoleId", table: "Users", column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_VariantFeatures_FeatureId",
                table: "VariantFeatures",
                column: "FeatureId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_VariantFeatures_VariantId",
                table: "VariantFeatures",
                column: "VariantId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_VariantSpecs_SpecId",
                table: "VariantSpecs",
                column: "SpecId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_VariantSpecs_VariantId",
                table: "VariantSpecs",
                column: "VariantId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_ColorId",
                table: "Vehicles",
                column: "ColorId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_VariantId",
                table: "Vehicles",
                column: "VariantId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_Vin",
                table: "Vehicles",
                column: "Vin",
                unique: true
            );

            migrationBuilder.CreateIndex(
                name: "IX_VehicleVariants_ModelId",
                table: "VehicleVariants",
                column: "ModelId"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "CustomerDealers");

            migrationBuilder.DropTable(name: "DealerAllocations");

            migrationBuilder.DropTable(name: "DealerContracts");

            migrationBuilder.DropTable(name: "DealerOrderItems");

            migrationBuilder.DropTable(name: "Feedbacks");

            migrationBuilder.DropTable(name: "OemInventories");

            migrationBuilder.DropTable(name: "Payments");

            migrationBuilder.DropTable(name: "Promotions");

            migrationBuilder.DropTable(name: "TestDrives");

            migrationBuilder.DropTable(name: "VariantFeatures");

            migrationBuilder.DropTable(name: "VariantSpecs");

            migrationBuilder.DropTable(name: "DealerOrders");

            migrationBuilder.DropTable(name: "SalesContracts");

            migrationBuilder.DropTable(name: "Features");

            migrationBuilder.DropTable(name: "Specs");

            migrationBuilder.DropTable(name: "SalesOrders");

            migrationBuilder.DropTable(name: "FeatureCategories");

            migrationBuilder.DropTable(name: "SpecCategories");

            migrationBuilder.DropTable(name: "Quotations");

            migrationBuilder.DropTable(name: "Vehicles");

            migrationBuilder.DropTable(name: "Customers");

            migrationBuilder.DropTable(name: "Users");

            migrationBuilder.DropTable(name: "VehicleColors");

            migrationBuilder.DropTable(name: "VehicleVariants");

            migrationBuilder.DropTable(name: "Dealers");

            migrationBuilder.DropTable(name: "Roles");

            migrationBuilder.DropTable(name: "VehicleModels");
        }
    }
}
