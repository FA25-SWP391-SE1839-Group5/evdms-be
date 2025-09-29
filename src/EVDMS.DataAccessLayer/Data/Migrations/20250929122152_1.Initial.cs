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
                    Name = table.Column<string>(type: "text", nullable: false),
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
                name: "VehicleModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
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
                    DealerId = table.Column<Guid>(type: "uuid", nullable: true),
                    Type = table.Column<int>(type: "integer", nullable: false),
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
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DealerId = table.Column<Guid>(type: "uuid", nullable: true),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<int>(type: "integer", nullable: false),
                    LastLoginAt = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: true
                    ),
                    PasswordResetToken = table.Column<string>(type: "text", nullable: true),
                    PasswordResetTokenExpiresAt = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: true
                    ),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
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
                }
            );

            migrationBuilder.CreateTable(
                name: "VehicleVariants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ModelId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    BasePrice = table.Column<decimal>(type: "numeric", nullable: false),
                    Specs = table.Column<string>(type: "jsonb", nullable: false),
                    Features = table.Column<string>(type: "jsonb", nullable: false),
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
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    TokenHash = table.Column<string>(type: "text", nullable: false),
                    ExpiresAt = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false
                    ),
                    IsRevoked = table.Column<bool>(type: "boolean", nullable: false),
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
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "OemInventories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    VariantId = table.Column<Guid>(type: "uuid", nullable: false),
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
                    table.PrimaryKey("PK_OemInventories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OemInventories_VehicleVariants_VariantId",
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
                    DealerId = table.Column<Guid>(type: "uuid", nullable: false),
                    Vin = table.Column<string>(type: "text", nullable: false),
                    Color = table.Column<int>(type: "integer", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
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
                        name: "FK_Vehicles_Dealers_DealerId",
                        column: x => x.DealerId,
                        principalTable: "Dealers",
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
                name: "SalesOrders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    QuotationId = table.Column<Guid>(type: "uuid", nullable: false),
                    DealerId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uuid", nullable: false),
                    VehicleId = table.Column<Guid>(type: "uuid", nullable: false),
                    Date = table.Column<DateTime>(
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
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SalesOrderId = table.Column<Guid>(type: "uuid", nullable: false),
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
                        name: "FK_Payments_SalesOrders_SalesOrderId",
                        column: x => x.SalesOrderId,
                        principalTable: "SalesOrders",
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
                table: "VehicleModels",
                columns: new[] { "Id", "Description", "ImageUrl", "Name" },
                values: new object[,]
                {
                    {
                        new Guid("11111111-1111-1111-1111-111111111111"),
                        "A battery-electric compact crossover SUV that shares many components with the Model 3, offering more utility, a higher seating position, and optional three-row seating.",
                        "https://res.cloudinary.com/dchtww9gf/image/upload/v1758450497/Tesla_Model_Y_m9txrs.jpg",
                        "Tesla Model Y",
                    },
                    {
                        new Guid("22222222-2222-2222-2222-222222222222"),
                        "A battery-electric mid-size sedan with a fastback body style, marketed as a more affordable electric vehicle than Tesla's previous models.",
                        "https://res.cloudinary.com/dchtww9gf/image/upload/v1758450495/Tesla_Model_3_evqd0p.jpg",
                        "Tesla Model 3",
                    },
                }
            );

            migrationBuilder.InsertData(
                table: "VehicleVariants",
                columns: new[] { "Id", "BasePrice", "Features", "ModelId", "Name", "Specs" },
                values: new object[,]
                {
                    {
                        new Guid("11111111-1111-1111-1111-111111111101"),
                        46630m,
                        "{\"Safety\":[\"AutomaticEmergencyBraking\",\"BlindSpotMonitor\",\"LaneDepartureWarning\",\"BackupCamera\"],\"Convenience\":[\"KeylessEntry\",\"PowerLiftgate\",\"AdaptiveCruiseControl\"],\"Entertainment\":[\"AppleCarPlay\",\"AndroidAuto\",\"PremiumSoundSystem\",\"WifiHotspot\"],\"Exterior\":[\"AlloyWheels\",\"LedHeadlights\",\"RoofRails\",\"Sunroof\"],\"Seating\":[\"HeatedSeats\",\"VentilatedSeats\",\"ThirdRowSeating\"]}",
                        new Guid("11111111-1111-1111-1111-111111111111"),
                        "Tesla Model Y Long Range All-Wheel Drive",
                        "{\"Horsepower\":{\"Value\":514,\"Unit\":\"hp\"},\"Torque\":{\"Value\":493,\"Unit\":\"Nm\"},\"Acceleration\":{\"Value\":4.8,\"Unit\":\"s\"},\"DriveType\":{\"Value\":\"AWD\",\"Unit\":null},\"MotorType\":{\"Value\":\"Dual PMSM\",\"Unit\":null},\"TopSpeed\":{\"Value\":201,\"Unit\":\"km/h\"},\"CurbWeight\":{\"Value\":1994,\"Unit\":\"kg\"},\"BatteryCapacity\":{\"Value\":75,\"Unit\":\"kWh\"},\"Range\":{\"Value\":533,\"Unit\":\"km\"},\"Efficiency\":{\"Value\":165,\"Unit\":\"Wh/km\"},\"BatteryChemistry\":{\"Value\":\"Li\\u2011ion (NCM)\",\"Unit\":null},\"BatteryVoltageArchitecture\":{\"Value\":345,\"Unit\":\"V\"},\"RegenerativeBrakingCapacity\":{\"Value\":\"Standard (1\\u2011pedal)\",\"Unit\":null},\"MaxAcChargingRate\":{\"Value\":11,\"Unit\":\"kW\"},\"MaxDcFastChargingRate\":{\"Value\":250,\"Unit\":\"kW\"},\"DcFastChargingTime\":{\"Value\":27,\"Unit\":\"min\"},\"AcChargingTime\":{\"Value\":8,\"Unit\":\"h\"},\"ChargingPortTypes\":{\"Value\":\"Tesla NACS (NA) / CCS (EU)\",\"Unit\":null},\"TowingCapacity\":{\"Value\":1600,\"Unit\":\"kg\"},\"FrunkVolume\":{\"Value\":117,\"Unit\":\"L\"},\"CargoVolume\":{\"Value\":854,\"Unit\":\"L\"},\"HeatPump\":{\"Value\":\"Standard\",\"Unit\":null},\"V2lCapability\":{\"Value\":3.6,\"Unit\":\"kW\"}}",
                    },
                    {
                        new Guid("11111111-1111-1111-1111-111111111102"),
                        57000m,
                        "{\"Safety\":[\"AutomaticEmergencyBraking\",\"BlindSpotMonitor\",\"LaneDepartureWarning\",\"BackupCamera\"],\"Convenience\":[\"KeylessEntry\",\"PowerLiftgate\",\"AdaptiveCruiseControl\"],\"Entertainment\":[\"AppleCarPlay\",\"AndroidAuto\",\"PremiumSoundSystem\",\"WifiHotspot\"],\"Exterior\":[\"AlloyWheels\",\"LedHeadlights\",\"RoofRails\",\"Sunroof\"],\"Seating\":[\"HeatedSeats\",\"ThirdRowSeating\"]}",
                        new Guid("11111111-1111-1111-1111-111111111111"),
                        "Tesla Model Y Performance",
                        "{\"Horsepower\":{\"Value\":534,\"Unit\":\"hp\"},\"Torque\":{\"Value\":660,\"Unit\":\"Nm\"},\"Acceleration\":{\"Value\":3.7,\"Unit\":\"s\"},\"DriveType\":{\"Value\":\"AWD\",\"Unit\":null},\"MotorType\":{\"Value\":\"Dual PMSM Performance\",\"Unit\":null},\"TopSpeed\":{\"Value\":250,\"Unit\":\"km/h\"},\"CurbWeight\":{\"Value\":2003,\"Unit\":\"kg\"},\"BatteryCapacity\":{\"Value\":78,\"Unit\":\"kWh\"},\"Range\":{\"Value\":488,\"Unit\":\"km\"},\"Efficiency\":{\"Value\":175,\"Unit\":\"Wh/km\"},\"BatteryChemistry\":{\"Value\":\"Li\\u2011ion (NCA)\",\"Unit\":null},\"BatteryVoltageArchitecture\":{\"Value\":355,\"Unit\":\"V\"},\"RegenerativeBrakingCapacity\":{\"Value\":\"Enhanced (1\\u2011pedal)\",\"Unit\":null},\"MaxAcChargingRate\":{\"Value\":11,\"Unit\":\"kW\"},\"MaxDcFastChargingRate\":{\"Value\":250,\"Unit\":\"kW\"},\"DcFastChargingTime\":{\"Value\":25,\"Unit\":\"min\"},\"AcChargingTime\":{\"Value\":7.5,\"Unit\":\"h\"},\"ChargingPortTypes\":{\"Value\":\"Tesla NACS (NA) / CCS (EU)\",\"Unit\":null},\"TowingCapacity\":{\"Value\":1500,\"Unit\":\"kg\"},\"FrunkVolume\":{\"Value\":110,\"Unit\":\"L\"},\"CargoVolume\":{\"Value\":860,\"Unit\":\"L\"},\"HeatPump\":{\"Value\":\"Standard\",\"Unit\":null},\"V2lCapability\":{\"Value\":3.6,\"Unit\":\"kW\"}}",
                    },
                    {
                        new Guid("22222222-2222-2222-2222-222222222201"),
                        54990m,
                        "{\"Safety\":[\"AutomaticEmergencyBraking\",\"LaneDepartureWarning\",\"BackupCamera\"],\"Convenience\":[\"KeylessEntry\",\"PowerLiftgate\"],\"Entertainment\":[\"PremiumSoundSystem\"],\"Exterior\":[\"LedHeadlights\",\"AlloyWheels\"],\"Seating\":[\"HeatedSeats\"]}",
                        new Guid("22222222-2222-2222-2222-222222222222"),
                        "Tesla Model 3 Performance",
                        "{\"Horsepower\":{\"Value\":510,\"Unit\":\"hp\"},\"Torque\":{\"Value\":660,\"Unit\":\"Nm\"},\"Acceleration\":{\"Value\":3.1,\"Unit\":\"s\"},\"DriveType\":{\"Value\":\"AWD\",\"Unit\":null},\"MotorType\":{\"Value\":\"Dual PMSM\",\"Unit\":null},\"TopSpeed\":{\"Value\":261,\"Unit\":\"km/h\"},\"CurbWeight\":{\"Value\":1844,\"Unit\":\"kg\"},\"BatteryCapacity\":{\"Value\":82,\"Unit\":\"kWh\"},\"Range\":{\"Value\":547,\"Unit\":\"km\"},\"Efficiency\":{\"Value\":153,\"Unit\":\"Wh/km\"},\"BatteryChemistry\":{\"Value\":\"Li\\u2011ion (NCA)\",\"Unit\":null},\"BatteryVoltageArchitecture\":{\"Value\":355,\"Unit\":\"V\"},\"RegenerativeBrakingCapacity\":{\"Value\":\"Standard (1\\u2011pedal)\",\"Unit\":null},\"MaxAcChargingRate\":{\"Value\":11,\"Unit\":\"kW\"},\"MaxDcFastChargingRate\":{\"Value\":250,\"Unit\":\"kW\"},\"DcFastChargingTime\":{\"Value\":30,\"Unit\":\"min\"},\"AcChargingTime\":{\"Value\":8,\"Unit\":\"h\"},\"ChargingPortTypes\":{\"Value\":\"Tesla NACS (NA) / CCS (EU)\",\"Unit\":null},\"TowingCapacity\":{\"Value\":1000,\"Unit\":\"kg\"},\"FrunkVolume\":{\"Value\":88,\"Unit\":\"L\"},\"CargoVolume\":{\"Value\":542,\"Unit\":\"L\"},\"HeatPump\":{\"Value\":null,\"Unit\":null},\"V2lCapability\":{\"Value\":null,\"Unit\":null}}",
                    },
                }
            );

            migrationBuilder.CreateIndex(
                name: "IX_DealerContracts_DealerId",
                table: "DealerContracts",
                column: "DealerId"
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
                name: "IX_OemInventories_VariantId",
                table: "OemInventories",
                column: "VariantId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_Payments_SalesOrderId",
                table: "Payments",
                column: "SalesOrderId"
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
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId"
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

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_DealerId",
                table: "Vehicles",
                column: "DealerId"
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
            migrationBuilder.DropTable(name: "DealerContracts");

            migrationBuilder.DropTable(name: "Feedbacks");

            migrationBuilder.DropTable(name: "OemInventories");

            migrationBuilder.DropTable(name: "Payments");

            migrationBuilder.DropTable(name: "Promotions");

            migrationBuilder.DropTable(name: "RefreshTokens");

            migrationBuilder.DropTable(name: "TestDrives");

            migrationBuilder.DropTable(name: "SalesOrders");

            migrationBuilder.DropTable(name: "Quotations");

            migrationBuilder.DropTable(name: "Vehicles");

            migrationBuilder.DropTable(name: "Customers");

            migrationBuilder.DropTable(name: "Users");

            migrationBuilder.DropTable(name: "VehicleVariants");

            migrationBuilder.DropTable(name: "Dealers");

            migrationBuilder.DropTable(name: "VehicleModels");
        }
    }
}
