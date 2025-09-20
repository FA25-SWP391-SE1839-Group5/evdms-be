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
                name: "Specs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SpecName = table.Column<string>(type: "text", nullable: false),
                    Unit = table.Column<string>(type: "text", nullable: false),
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
                table: "Specs",
                columns: new[] { "Id", "SpecName", "Unit" },
                values: new object[,]
                {
                    {
                        new Guid("11111111-1111-1111-1111-111111111111"),
                        "Engine Displacement",
                        "cc",
                    },
                    { new Guid("22222222-2222-2222-2222-222222222222"), "Horsepower", "hp" },
                    { new Guid("33333333-3333-3333-3333-333333333333"), "Torque", "Nm" },
                    { new Guid("44444444-4444-4444-4444-444444444444"), "Fuel Tank Capacity", "L" },
                    { new Guid("55555555-5555-5555-5555-555555555555"), "Length", "mm" },
                    { new Guid("66666666-6666-6666-6666-666666666666"), "Width", "mm" },
                    { new Guid("77777777-7777-7777-7777-777777777777"), "Height", "mm" },
                    { new Guid("88888888-8888-8888-8888-888888888888"), "Wheelbase", "mm" },
                    { new Guid("99999999-9999-9999-9999-999999999999"), "Curb Weight", "kg" },
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "Ground Clearance", "mm" },
                    {
                        new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                        "Seating Capacity",
                        "persons",
                    },
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
                columns: new[] { "Id", "Description", "ImageUrl", "ModelName" },
                values: new object[,]
                {
                    {
                        new Guid("11111111-1111-1111-1111-111111111111"),
                        "A reliable and fuel-efficient compact sedan, popular for daily commuting and sporty handling.",
                        "https://res.cloudinary.com/dchtww9gf/image/upload/v1758360467/Honda_Civic_is4uhx.jpg",
                        "Honda Civic",
                    },
                    {
                        new Guid("22222222-2222-2222-2222-222222222222"),
                        "A spacious midsize sedan known for its comfort, advanced safety features, and smooth ride.",
                        "https://res.cloudinary.com/dchtww9gf/image/upload/v1758360932/Honda_Accord_d2i6gg.jpg",
                        "Honda Accord",
                    },
                    {
                        new Guid("33333333-3333-3333-3333-333333333333"),
                        "A globally best-selling compact sedan, recognized for its durability and low maintenance costs.",
                        "https://res.cloudinary.com/dchtww9gf/image/upload/v1758361023/Toyota_Corolla_da6ch5.jpg",
                        "Toyota Corolla",
                    },
                    {
                        new Guid("44444444-4444-4444-4444-444444444444"),
                        "A refined midsize sedan offering a quiet cabin, strong resale value, and hybrid options.",
                        "https://res.cloudinary.com/dchtww9gf/image/upload/v1758361130/Toyota_Camry_p4xybr.jpg",
                        "Toyota Camry",
                    },
                    {
                        new Guid("55555555-5555-5555-5555-555555555555"),
                        "A cutting-edge electric sedan with impressive acceleration, range, and advanced technology.",
                        "https://res.cloudinary.com/dchtww9gf/image/upload/v1758361184/Tesla_Model_3_iycyuv.jpg",
                        "Tesla Model 3",
                    },
                    {
                        new Guid("66666666-6666-6666-6666-666666666666"),
                        "A luxury electric sedan featuring long range, high performance, and innovative autopilot features.",
                        "https://res.cloudinary.com/dchtww9gf/image/upload/v1758361233/Tesla_Model_S_mh7dby.jpg",
                        "Tesla Model S",
                    },
                    {
                        new Guid("77777777-7777-7777-7777-777777777777"),
                        "A versatile compact SUV with available all-wheel drive, ample cargo space, and hybrid variants.",
                        "https://res.cloudinary.com/dchtww9gf/image/upload/v1758361305/Toyota_RAV4_mmohlp.jpg",
                        "Toyota RAV4",
                    },
                    {
                        new Guid("88888888-8888-8888-8888-888888888888"),
                        "A family-friendly compact SUV known for its roomy interior, reliability, and efficient engines.",
                        "https://res.cloudinary.com/dchtww9gf/image/upload/v1758361383/Honda_CR-V_lmyrrp.jpg",
                        "Honda CR-V",
                    },
                    {
                        new Guid("99999999-9999-9999-9999-999999999999"),
                        "America's best-selling full-size pickup truck, renowned for its towing capacity and ruggedness.",
                        "https://res.cloudinary.com/dchtww9gf/image/upload/v1758361429/Ford_F-150_u5rfl2.jpg",
                        "Ford F-150",
                    },
                    {
                        new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                        "An iconic sports car offering powerful engine options and classic American muscle styling.",
                        "https://res.cloudinary.com/dchtww9gf/image/upload/v1758361569/Ford_Mustang_txbqgu.jpg",
                        "Ford Mustang",
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
                        "Remote Start",
                    },
                    {
                        new Guid("10000000-0000-0000-0000-000000000009"),
                        new Guid("22222222-2222-2222-2222-222222222222"),
                        "Power Liftgate",
                    },
                    {
                        new Guid("10000000-0000-0000-0000-000000000010"),
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
                        "CD Player",
                    },
                    {
                        new Guid("20000000-0000-0000-0000-000000000010"),
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
                        "Tow Hooks",
                    },
                    {
                        new Guid("30000000-0000-0000-0000-000000000004"),
                        new Guid("44444444-4444-4444-4444-444444444444"),
                        "Fog Lights",
                    },
                    {
                        new Guid("30000000-0000-0000-0000-000000000005"),
                        new Guid("44444444-4444-4444-4444-444444444444"),
                        "Roof Rails",
                    },
                    {
                        new Guid("30000000-0000-0000-0000-000000000006"),
                        new Guid("44444444-4444-4444-4444-444444444444"),
                        "Sunroof",
                    },
                    {
                        new Guid("30000000-0000-0000-0000-000000000007"),
                        new Guid("44444444-4444-4444-4444-444444444444"),
                        "Power Mirrors",
                    },
                    {
                        new Guid("30000000-0000-0000-0000-000000000008"),
                        new Guid("44444444-4444-4444-4444-444444444444"),
                        "Rear Spoiler",
                    },
                    {
                        new Guid("30000000-0000-0000-0000-000000000009"),
                        new Guid("44444444-4444-4444-4444-444444444444"),
                        "Automatic Headlights",
                    },
                    {
                        new Guid("30000000-0000-0000-0000-000000000010"),
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
