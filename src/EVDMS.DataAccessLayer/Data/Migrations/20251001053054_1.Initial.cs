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
                name: "customers",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    full_name = table.Column<string>(type: "text", nullable: false),
                    phone = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    address = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false,
                        defaultValueSql: "CURRENT_TIMESTAMP"
                    ),
                    updated_at = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false,
                        defaultValueSql: "CURRENT_TIMESTAMP"
                    ),
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_customers", x => x.id);
                }
            );

            migrationBuilder.CreateTable(
                name: "dealers",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    region = table.Column<string>(type: "text", nullable: false),
                    address = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false,
                        defaultValueSql: "CURRENT_TIMESTAMP"
                    ),
                    updated_at = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false,
                        defaultValueSql: "CURRENT_TIMESTAMP"
                    ),
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_dealers", x => x.id);
                }
            );

            migrationBuilder.CreateTable(
                name: "vehicle_models",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    image_url = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false,
                        defaultValueSql: "CURRENT_TIMESTAMP"
                    ),
                    updated_at = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false,
                        defaultValueSql: "CURRENT_TIMESTAMP"
                    ),
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vehicle_models", x => x.id);
                }
            );

            migrationBuilder.CreateTable(
                name: "dealer_contracts",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    dealer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    start_date = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false
                    ),
                    end_date = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false
                    ),
                    sales_target = table.Column<decimal>(type: "numeric", nullable: false),
                    outstanding_debt = table.Column<decimal>(type: "numeric", nullable: false),
                    created_at = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false,
                        defaultValueSql: "CURRENT_TIMESTAMP"
                    ),
                    updated_at = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false,
                        defaultValueSql: "CURRENT_TIMESTAMP"
                    ),
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_dealer_contracts", x => x.id);
                    table.ForeignKey(
                        name: "fk_dealer_contracts_dealers_dealer_id",
                        column: x => x.dealer_id,
                        principalTable: "dealers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "feedbacks",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    customer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    dealer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    content = table.Column<string>(type: "text", nullable: false),
                    status = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false,
                        defaultValueSql: "CURRENT_TIMESTAMP"
                    ),
                    updated_at = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false,
                        defaultValueSql: "CURRENT_TIMESTAMP"
                    ),
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_feedbacks", x => x.id);
                    table.ForeignKey(
                        name: "fk_feedbacks_customers_customer_id",
                        column: x => x.customer_id,
                        principalTable: "customers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict
                    );
                    table.ForeignKey(
                        name: "fk_feedbacks_dealers_dealer_id",
                        column: x => x.dealer_id,
                        principalTable: "dealers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "promotions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    dealer_id = table.Column<Guid>(type: "uuid", nullable: true),
                    type = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    discount_percent = table.Column<decimal>(type: "numeric", nullable: false),
                    start_date = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false
                    ),
                    end_date = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false
                    ),
                    created_at = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false,
                        defaultValueSql: "CURRENT_TIMESTAMP"
                    ),
                    updated_at = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false,
                        defaultValueSql: "CURRENT_TIMESTAMP"
                    ),
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_promotions", x => x.id);
                    table.ForeignKey(
                        name: "fk_promotions_dealers_dealer_id",
                        column: x => x.dealer_id,
                        principalTable: "dealers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    dealer_id = table.Column<Guid>(type: "uuid", nullable: true),
                    full_name = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    password_hash = table.Column<string>(type: "text", nullable: false),
                    role = table.Column<string>(type: "text", nullable: false),
                    last_login_at = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: true
                    ),
                    password_reset_token = table.Column<string>(type: "text", nullable: true),
                    password_reset_token_expires_at = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: true
                    ),
                    is_active = table.Column<bool>(
                        type: "boolean",
                        nullable: false,
                        defaultValue: true
                    ),
                    created_at = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false,
                        defaultValueSql: "CURRENT_TIMESTAMP"
                    ),
                    updated_at = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false,
                        defaultValueSql: "CURRENT_TIMESTAMP"
                    ),
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                    table.ForeignKey(
                        name: "fk_users_dealers_dealer_id",
                        column: x => x.dealer_id,
                        principalTable: "dealers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "vehicle_variants",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    model_id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    base_price = table.Column<decimal>(type: "numeric", nullable: false),
                    specs = table.Column<string>(type: "jsonb", nullable: false),
                    features = table.Column<string>(type: "jsonb", nullable: false),
                    created_at = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false,
                        defaultValueSql: "CURRENT_TIMESTAMP"
                    ),
                    updated_at = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false,
                        defaultValueSql: "CURRENT_TIMESTAMP"
                    ),
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vehicle_variants", x => x.id);
                    table.ForeignKey(
                        name: "fk_vehicle_variants_vehicle_models_model_id",
                        column: x => x.model_id,
                        principalTable: "vehicle_models",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "audit_logs",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    action = table.Column<int>(type: "integer", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false,
                        defaultValueSql: "CURRENT_TIMESTAMP"
                    ),
                    updated_at = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false,
                        defaultValueSql: "CURRENT_TIMESTAMP"
                    ),
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_audit_logs", x => x.id);
                    table.ForeignKey(
                        name: "fk_audit_logs_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "quotations",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    dealer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    customer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    total_amount = table.Column<decimal>(type: "numeric", nullable: false),
                    status = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false,
                        defaultValueSql: "CURRENT_TIMESTAMP"
                    ),
                    updated_at = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false,
                        defaultValueSql: "CURRENT_TIMESTAMP"
                    ),
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_quotations", x => x.id);
                    table.ForeignKey(
                        name: "fk_quotations_customers_customer_id",
                        column: x => x.customer_id,
                        principalTable: "customers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict
                    );
                    table.ForeignKey(
                        name: "fk_quotations_dealers_dealer_id",
                        column: x => x.dealer_id,
                        principalTable: "dealers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict
                    );
                    table.ForeignKey(
                        name: "fk_quotations_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "refresh_tokens",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    token_hash = table.Column<string>(type: "text", nullable: false),
                    expires_at = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false
                    ),
                    is_revoked = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false,
                        defaultValueSql: "CURRENT_TIMESTAMP"
                    ),
                    updated_at = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false,
                        defaultValueSql: "CURRENT_TIMESTAMP"
                    ),
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_refresh_tokens", x => x.id);
                    table.ForeignKey(
                        name: "fk_refresh_tokens_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "oem_inventories",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    variant_id = table.Column<Guid>(type: "uuid", nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false,
                        defaultValueSql: "CURRENT_TIMESTAMP"
                    ),
                    updated_at = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false,
                        defaultValueSql: "CURRENT_TIMESTAMP"
                    ),
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_oem_inventories", x => x.id);
                    table.ForeignKey(
                        name: "fk_oem_inventories_vehicle_variants_variant_id",
                        column: x => x.variant_id,
                        principalTable: "vehicle_variants",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "vehicles",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    variant_id = table.Column<Guid>(type: "uuid", nullable: false),
                    dealer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    vin = table.Column<string>(type: "text", nullable: false),
                    color = table.Column<string>(type: "text", nullable: false),
                    type = table.Column<string>(type: "text", nullable: false),
                    status = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false,
                        defaultValueSql: "CURRENT_TIMESTAMP"
                    ),
                    updated_at = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false,
                        defaultValueSql: "CURRENT_TIMESTAMP"
                    ),
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vehicles", x => x.id);
                    table.ForeignKey(
                        name: "fk_vehicles_dealers_dealer_id",
                        column: x => x.dealer_id,
                        principalTable: "dealers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict
                    );
                    table.ForeignKey(
                        name: "fk_vehicles_vehicle_variants_variant_id",
                        column: x => x.variant_id,
                        principalTable: "vehicle_variants",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "sales_orders",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    quotation_id = table.Column<Guid>(type: "uuid", nullable: false),
                    dealer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    customer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    vehicle_id = table.Column<Guid>(type: "uuid", nullable: false),
                    date = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false
                    ),
                    status = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false,
                        defaultValueSql: "CURRENT_TIMESTAMP"
                    ),
                    updated_at = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false,
                        defaultValueSql: "CURRENT_TIMESTAMP"
                    ),
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_sales_orders", x => x.id);
                    table.ForeignKey(
                        name: "fk_sales_orders_customers_customer_id",
                        column: x => x.customer_id,
                        principalTable: "customers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict
                    );
                    table.ForeignKey(
                        name: "fk_sales_orders_dealers_dealer_id",
                        column: x => x.dealer_id,
                        principalTable: "dealers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict
                    );
                    table.ForeignKey(
                        name: "fk_sales_orders_quotations_quotation_id",
                        column: x => x.quotation_id,
                        principalTable: "quotations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict
                    );
                    table.ForeignKey(
                        name: "fk_sales_orders_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict
                    );
                    table.ForeignKey(
                        name: "fk_sales_orders_vehicles_vehicle_id",
                        column: x => x.vehicle_id,
                        principalTable: "vehicles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "test_drives",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    customer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    dealer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    vehicle_id = table.Column<Guid>(type: "uuid", nullable: false),
                    scheduled_at = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false
                    ),
                    status = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false,
                        defaultValueSql: "CURRENT_TIMESTAMP"
                    ),
                    updated_at = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false,
                        defaultValueSql: "CURRENT_TIMESTAMP"
                    ),
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_test_drives", x => x.id);
                    table.ForeignKey(
                        name: "fk_test_drives_customers_customer_id",
                        column: x => x.customer_id,
                        principalTable: "customers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict
                    );
                    table.ForeignKey(
                        name: "fk_test_drives_dealers_dealer_id",
                        column: x => x.dealer_id,
                        principalTable: "dealers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict
                    );
                    table.ForeignKey(
                        name: "fk_test_drives_vehicles_vehicle_id",
                        column: x => x.vehicle_id,
                        principalTable: "vehicles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "payments",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    sales_order_id = table.Column<Guid>(type: "uuid", nullable: false),
                    amount = table.Column<decimal>(type: "numeric", nullable: false),
                    date = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false
                    ),
                    method = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false,
                        defaultValueSql: "CURRENT_TIMESTAMP"
                    ),
                    updated_at = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false,
                        defaultValueSql: "CURRENT_TIMESTAMP"
                    ),
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_payments", x => x.id);
                    table.ForeignKey(
                        name: "fk_payments_sales_orders_sales_order_id",
                        column: x => x.sales_order_id,
                        principalTable: "sales_orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict
                    );
                }
            );

            migrationBuilder.InsertData(
                table: "customers",
                columns: new[] { "id", "address", "email", "full_name", "phone" },
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
                table: "dealers",
                columns: new[] { "id", "address", "name", "region" },
                values: new object[]
                {
                    new Guid("30000000-0000-0000-0000-000000000001"),
                    "100 Nguyen Van Cu, District 1, Ho Chi Minh City",
                    "EV Motors Saigon",
                    "Ho Chi Minh City",
                }
            );

            migrationBuilder.InsertData(
                table: "promotions",
                columns: new[]
                {
                    "id",
                    "dealer_id",
                    "description",
                    "discount_percent",
                    "end_date",
                    "start_date",
                    "type",
                },
                values: new object[]
                {
                    new Guid("60000000-0000-0000-0000-000000000001"),
                    null,
                    "Spring Sale: 10% off all vehicles!",
                    10m,
                    new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Utc),
                    new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc),
                    "Oem",
                }
            );

            migrationBuilder.InsertData(
                table: "users",
                columns: new[]
                {
                    "id",
                    "dealer_id",
                    "email",
                    "full_name",
                    "last_login_at",
                    "password_hash",
                    "password_reset_token",
                    "password_reset_token_expires_at",
                    "role",
                },
                values: new object[,]
                {
                    {
                        new Guid("20000000-0000-0000-0000-000000000001"),
                        null,
                        "admin@example.com",
                        "Admin User",
                        null,
                        "$2a$11$nAccBp1/4t.CxdEBKLXSp.cM3DcozB5b.itLdNwAYPYx/El1ENIdW",
                        null,
                        null,
                        "Admin",
                    },
                    {
                        new Guid("20000000-0000-0000-0000-000000000004"),
                        null,
                        "evmstaff@example.com",
                        "EVM Staff User",
                        null,
                        "$2a$11$RQaQvAyAEnDiAved/V5wzOQGwKG3CTmDiWa7uxTBlvR2IUUZ06pWm",
                        null,
                        null,
                        "EvmStaff",
                    },
                }
            );

            migrationBuilder.InsertData(
                table: "vehicle_models",
                columns: new[] { "id", "description", "image_url", "name" },
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
                table: "dealer_contracts",
                columns: new[]
                {
                    "id",
                    "dealer_id",
                    "end_date",
                    "outstanding_debt",
                    "sales_target",
                    "start_date",
                },
                values: new object[,]
                {
                    {
                        new Guid("10000000-0000-0000-0000-000000000001"),
                        new Guid("30000000-0000-0000-0000-000000000001"),
                        new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Utc),
                        50000m,
                        1000000m,
                        new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc),
                    },
                    {
                        new Guid("10000000-0000-0000-0000-000000000002"),
                        new Guid("30000000-0000-0000-0000-000000000001"),
                        new DateTime(2025, 11, 30, 0, 0, 0, 0, DateTimeKind.Utc),
                        25000m,
                        750000m,
                        new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Utc),
                    },
                }
            );

            migrationBuilder.InsertData(
                table: "feedbacks",
                columns: new[] { "id", "content", "customer_id", "dealer_id", "status" },
                values: new object[,]
                {
                    {
                        new Guid("40000000-0000-0000-0000-000000000001"),
                        "Great service and friendly staff!",
                        new Guid("10000000-0000-0000-0000-000000000001"),
                        new Guid("30000000-0000-0000-0000-000000000001"),
                        "New",
                    },
                    {
                        new Guid("40000000-0000-0000-0000-000000000002"),
                        "Quick response to my queries.",
                        new Guid("10000000-0000-0000-0000-000000000002"),
                        new Guid("30000000-0000-0000-0000-000000000001"),
                        "Reviewed",
                    },
                    {
                        new Guid("40000000-0000-0000-0000-000000000003"),
                        "Had some issues with paperwork, but resolved.",
                        new Guid("10000000-0000-0000-0000-000000000003"),
                        new Guid("30000000-0000-0000-0000-000000000001"),
                        "Resolved",
                    },
                }
            );

            migrationBuilder.InsertData(
                table: "promotions",
                columns: new[]
                {
                    "id",
                    "dealer_id",
                    "description",
                    "discount_percent",
                    "end_date",
                    "start_date",
                    "type",
                },
                values: new object[]
                {
                    new Guid("60000000-0000-0000-0000-000000000002"),
                    new Guid("30000000-0000-0000-0000-000000000001"),
                    "Year-end Clearance: 15% off selected models!",
                    15m,
                    new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Utc),
                    new DateTime(2024, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc),
                    "Dealer",
                }
            );

            migrationBuilder.InsertData(
                table: "users",
                columns: new[]
                {
                    "id",
                    "dealer_id",
                    "email",
                    "full_name",
                    "last_login_at",
                    "password_hash",
                    "password_reset_token",
                    "password_reset_token_expires_at",
                    "role",
                },
                values: new object[,]
                {
                    {
                        new Guid("20000000-0000-0000-0000-000000000002"),
                        new Guid("30000000-0000-0000-0000-000000000001"),
                        "dealermanager@example.com",
                        "Dealer Manager User",
                        null,
                        "$2a$11$DdO35yfXHIifSg.NNvGoEuTw04wZosGk4nSZuuQDYI73T.YbRM56K",
                        null,
                        null,
                        "DealerManager",
                    },
                    {
                        new Guid("20000000-0000-0000-0000-000000000003"),
                        new Guid("30000000-0000-0000-0000-000000000001"),
                        "dealerstaff@example.com",
                        "Dealer Staff User",
                        null,
                        "$2a$11$BIDX9UfH9hf91sM8KXg87upxxbcYLXYC/mKIeen0hkNvFY94h15Sq",
                        null,
                        null,
                        "DealerStaff",
                    },
                }
            );

            migrationBuilder.InsertData(
                table: "vehicle_variants",
                columns: new[] { "id", "base_price", "features", "model_id", "name", "specs" },
                values: new object[,]
                {
                    {
                        new Guid("11111111-1111-1111-1111-111111111101"),
                        46630m,
                        "{\"Safety\":[\"AutomaticEmergencyBraking\",\"BlindSpotMonitor\",\"LaneDepartureWarning\",\"BackupCamera\"],\"Convenience\":[\"KeylessEntry\",\"PowerLiftgate\",\"AdaptiveCruiseControl\"],\"Entertainment\":[\"AppleCarPlay\",\"AndroidAuto\",\"PremiumSoundSystem\",\"WifiHotspot\"],\"Exterior\":[\"AlloyWheels\",\"LedHeadlights\",\"RoofRails\",\"Sunroof\"],\"Seating\":[\"HeatedSeats\",\"VentilatedSeats\",\"ThirdRowSeating\"]}",
                        new Guid("11111111-1111-1111-1111-111111111111"),
                        "Tesla Model Y Long Range All-Wheel Drive",
                        "{\"Horsepower\":{\"Value\":514,\"Unit\":\"hp\"},\"Torque\":{\"Value\":493,\"Unit\":\"Nm\"},\"Acceleration\":{\"Value\":4.8,\"Unit\":\"s\"},\"DriveType\":{\"Value\":\"AWD\"},\"MotorType\":{\"Value\":\"Dual PMSM\"},\"TopSpeed\":{\"Value\":201,\"Unit\":\"km/h\"},\"CurbWeight\":{\"Value\":1994,\"Unit\":\"kg\"},\"BatteryCapacity\":{\"Value\":75,\"Unit\":\"kWh\"},\"Range\":{\"Value\":533,\"Unit\":\"km\"},\"Efficiency\":{\"Value\":165,\"Unit\":\"Wh/km\"},\"BatteryChemistry\":{\"Value\":\"Li\\u2011ion (NCM)\"},\"BatteryVoltageArchitecture\":{\"Value\":345,\"Unit\":\"V\"},\"RegenerativeBrakingCapacity\":{\"Value\":\"Standard (1\\u2011pedal)\"},\"MaxAcChargingRate\":{\"Value\":11,\"Unit\":\"kW\"},\"MaxDcFastChargingRate\":{\"Value\":250,\"Unit\":\"kW\"},\"DcFastChargingTime\":{\"Value\":27,\"Unit\":\"min\"},\"AcChargingTime\":{\"Value\":8,\"Unit\":\"h\"},\"ChargingPortTypes\":{\"Value\":\"Tesla NACS (NA) / CCS (EU)\"},\"TowingCapacity\":{\"Value\":1600,\"Unit\":\"kg\"},\"FrunkVolume\":{\"Value\":117,\"Unit\":\"L\"},\"CargoVolume\":{\"Value\":854,\"Unit\":\"L\"},\"HeatPump\":{\"Value\":\"Standard\"},\"V2lCapability\":{\"Value\":3.6,\"Unit\":\"kW\"}}",
                    },
                    {
                        new Guid("11111111-1111-1111-1111-111111111102"),
                        57000m,
                        "{\"Safety\":[\"AutomaticEmergencyBraking\",\"BlindSpotMonitor\",\"LaneDepartureWarning\",\"BackupCamera\"],\"Convenience\":[\"KeylessEntry\",\"PowerLiftgate\",\"AdaptiveCruiseControl\"],\"Entertainment\":[\"AppleCarPlay\",\"AndroidAuto\",\"PremiumSoundSystem\",\"WifiHotspot\"],\"Exterior\":[\"AlloyWheels\",\"LedHeadlights\",\"RoofRails\",\"Sunroof\"],\"Seating\":[\"HeatedSeats\",\"ThirdRowSeating\"]}",
                        new Guid("11111111-1111-1111-1111-111111111111"),
                        "Tesla Model Y Performance",
                        "{\"Horsepower\":{\"Value\":534,\"Unit\":\"hp\"},\"Torque\":{\"Value\":660,\"Unit\":\"Nm\"},\"Acceleration\":{\"Value\":3.7,\"Unit\":\"s\"},\"DriveType\":{\"Value\":\"AWD\"},\"MotorType\":{\"Value\":\"Dual PMSM Performance\"},\"TopSpeed\":{\"Value\":250,\"Unit\":\"km/h\"},\"CurbWeight\":{\"Value\":2003,\"Unit\":\"kg\"},\"BatteryCapacity\":{\"Value\":78,\"Unit\":\"kWh\"},\"Range\":{\"Value\":488,\"Unit\":\"km\"},\"Efficiency\":{\"Value\":175,\"Unit\":\"Wh/km\"},\"BatteryChemistry\":{\"Value\":\"Li\\u2011ion (NCA)\"},\"BatteryVoltageArchitecture\":{\"Value\":355,\"Unit\":\"V\"},\"RegenerativeBrakingCapacity\":{\"Value\":\"Enhanced (1\\u2011pedal)\"},\"MaxAcChargingRate\":{\"Value\":11,\"Unit\":\"kW\"},\"MaxDcFastChargingRate\":{\"Value\":250,\"Unit\":\"kW\"},\"DcFastChargingTime\":{\"Value\":25,\"Unit\":\"min\"},\"AcChargingTime\":{\"Value\":7.5,\"Unit\":\"h\"},\"ChargingPortTypes\":{\"Value\":\"Tesla NACS (NA) / CCS (EU)\"},\"TowingCapacity\":{\"Value\":1500,\"Unit\":\"kg\"},\"FrunkVolume\":{\"Value\":110,\"Unit\":\"L\"},\"CargoVolume\":{\"Value\":860,\"Unit\":\"L\"},\"HeatPump\":{\"Value\":\"Standard\"},\"V2lCapability\":{\"Value\":3.6,\"Unit\":\"kW\"}}",
                    },
                    {
                        new Guid("22222222-2222-2222-2222-222222222201"),
                        54990m,
                        "{\"Safety\":[\"AutomaticEmergencyBraking\",\"LaneDepartureWarning\",\"BackupCamera\"],\"Convenience\":[\"KeylessEntry\",\"PowerLiftgate\"],\"Entertainment\":[\"PremiumSoundSystem\"],\"Exterior\":[\"LedHeadlights\",\"AlloyWheels\"],\"Seating\":[\"HeatedSeats\"]}",
                        new Guid("22222222-2222-2222-2222-222222222222"),
                        "Tesla Model 3 Performance",
                        "{\"Horsepower\":{\"Value\":510,\"Unit\":\"hp\"},\"Torque\":{\"Value\":660,\"Unit\":\"Nm\"},\"Acceleration\":{\"Value\":3.1,\"Unit\":\"s\"},\"DriveType\":{\"Value\":\"AWD\"},\"MotorType\":{\"Value\":\"Dual PMSM\"},\"TopSpeed\":{\"Value\":261,\"Unit\":\"km/h\"},\"CurbWeight\":{\"Value\":1844,\"Unit\":\"kg\"},\"BatteryCapacity\":{\"Value\":82,\"Unit\":\"kWh\"},\"Range\":{\"Value\":547,\"Unit\":\"km\"},\"Efficiency\":{\"Value\":153,\"Unit\":\"Wh/km\"},\"BatteryChemistry\":{\"Value\":\"Li\\u2011ion (NCA)\"},\"BatteryVoltageArchitecture\":{\"Value\":355,\"Unit\":\"V\"},\"RegenerativeBrakingCapacity\":{\"Value\":\"Standard (1\\u2011pedal)\"},\"MaxAcChargingRate\":{\"Value\":11,\"Unit\":\"kW\"},\"MaxDcFastChargingRate\":{\"Value\":250,\"Unit\":\"kW\"},\"DcFastChargingTime\":{\"Value\":30,\"Unit\":\"min\"},\"AcChargingTime\":{\"Value\":8,\"Unit\":\"h\"},\"ChargingPortTypes\":{\"Value\":\"Tesla NACS (NA) / CCS (EU)\"},\"TowingCapacity\":{\"Value\":1000,\"Unit\":\"kg\"},\"FrunkVolume\":{\"Value\":88,\"Unit\":\"L\"},\"CargoVolume\":{\"Value\":542,\"Unit\":\"L\"}}",
                    },
                }
            );

            migrationBuilder.InsertData(
                table: "oem_inventories",
                columns: new[] { "id", "quantity", "variant_id" },
                values: new object[,]
                {
                    {
                        new Guid("50000000-0000-0000-0000-000000000001"),
                        10,
                        new Guid("11111111-1111-1111-1111-111111111101"),
                    },
                    {
                        new Guid("50000000-0000-0000-0000-000000000002"),
                        5,
                        new Guid("11111111-1111-1111-1111-111111111102"),
                    },
                    {
                        new Guid("50000000-0000-0000-0000-000000000003"),
                        8,
                        new Guid("22222222-2222-2222-2222-222222222201"),
                    },
                }
            );

            migrationBuilder.InsertData(
                table: "quotations",
                columns: new[]
                {
                    "id",
                    "customer_id",
                    "dealer_id",
                    "status",
                    "total_amount",
                    "user_id",
                },
                values: new object[,]
                {
                    {
                        new Guid("70000000-0000-0000-0000-000000000001"),
                        new Guid("10000000-0000-0000-0000-000000000001"),
                        new Guid("30000000-0000-0000-0000-000000000001"),
                        "Sent",
                        0m,
                        new Guid("20000000-0000-0000-0000-000000000002"),
                    },
                    {
                        new Guid("70000000-0000-0000-0000-000000000002"),
                        new Guid("10000000-0000-0000-0000-000000000002"),
                        new Guid("30000000-0000-0000-0000-000000000001"),
                        "Approved",
                        0m,
                        new Guid("20000000-0000-0000-0000-000000000003"),
                    },
                }
            );

            migrationBuilder.InsertData(
                table: "vehicles",
                columns: new[]
                {
                    "id",
                    "color",
                    "dealer_id",
                    "status",
                    "type",
                    "variant_id",
                    "vin",
                },
                values: new object[,]
                {
                    {
                        new Guid("80000000-0000-0000-0000-000000000001"),
                        "White",
                        new Guid("30000000-0000-0000-0000-000000000001"),
                        "Available",
                        "Sale",
                        new Guid("11111111-1111-1111-1111-111111111101"),
                        "5YJYGDEE8LF000001",
                    },
                    {
                        new Guid("80000000-0000-0000-0000-000000000002"),
                        "Black",
                        new Guid("30000000-0000-0000-0000-000000000001"),
                        "Reserved",
                        "Display",
                        new Guid("11111111-1111-1111-1111-111111111102"),
                        "5YJYGDEE8LF000002",
                    },
                    {
                        new Guid("80000000-0000-0000-0000-000000000003"),
                        "Blue",
                        new Guid("30000000-0000-0000-0000-000000000001"),
                        "Reserved",
                        "Demo",
                        new Guid("22222222-2222-2222-2222-222222222201"),
                        "5YJ3E1EA7LF000003",
                    },
                }
            );

            migrationBuilder.InsertData(
                table: "sales_orders",
                columns: new[]
                {
                    "id",
                    "customer_id",
                    "date",
                    "dealer_id",
                    "quotation_id",
                    "status",
                    "user_id",
                    "vehicle_id",
                },
                values: new object[,]
                {
                    {
                        new Guid("90000000-0000-0000-0000-000000000001"),
                        new Guid("10000000-0000-0000-0000-000000000001"),
                        new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc),
                        new Guid("30000000-0000-0000-0000-000000000001"),
                        new Guid("70000000-0000-0000-0000-000000000001"),
                        "Pending",
                        new Guid("20000000-0000-0000-0000-000000000002"),
                        new Guid("80000000-0000-0000-0000-000000000001"),
                    },
                    {
                        new Guid("90000000-0000-0000-0000-000000000002"),
                        new Guid("10000000-0000-0000-0000-000000000002"),
                        new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc),
                        new Guid("30000000-0000-0000-0000-000000000001"),
                        new Guid("70000000-0000-0000-0000-000000000002"),
                        "Confirmed",
                        new Guid("20000000-0000-0000-0000-000000000003"),
                        new Guid("80000000-0000-0000-0000-000000000002"),
                    },
                }
            );

            migrationBuilder.InsertData(
                table: "test_drives",
                columns: new[]
                {
                    "id",
                    "customer_id",
                    "dealer_id",
                    "scheduled_at",
                    "status",
                    "vehicle_id",
                },
                values: new object[,]
                {
                    {
                        new Guid("b0000000-0000-0000-0000-000000000001"),
                        new Guid("10000000-0000-0000-0000-000000000001"),
                        new Guid("30000000-0000-0000-0000-000000000001"),
                        new DateTime(2024, 4, 10, 9, 0, 0, 0, DateTimeKind.Utc),
                        "Scheduled",
                        new Guid("80000000-0000-0000-0000-000000000001"),
                    },
                    {
                        new Guid("b0000000-0000-0000-0000-000000000002"),
                        new Guid("10000000-0000-0000-0000-000000000002"),
                        new Guid("30000000-0000-0000-0000-000000000001"),
                        new DateTime(2024, 5, 15, 14, 0, 0, 0, DateTimeKind.Utc),
                        "Completed",
                        new Guid("80000000-0000-0000-0000-000000000002"),
                    },
                }
            );

            migrationBuilder.InsertData(
                table: "payments",
                columns: new[] { "id", "amount", "date", "method", "sales_order_id" },
                values: new object[,]
                {
                    {
                        new Guid("a0000000-0000-0000-0000-000000000001"),
                        500000m,
                        new DateTime(2024, 4, 2, 0, 0, 0, 0, DateTimeKind.Utc),
                        "BankTransfer",
                        new Guid("90000000-0000-0000-0000-000000000001"),
                    },
                    {
                        new Guid("a0000000-0000-0000-0000-000000000002"),
                        750000m,
                        new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Utc),
                        "Cash",
                        new Guid("90000000-0000-0000-0000-000000000002"),
                    },
                }
            );

            migrationBuilder.CreateIndex(
                name: "ix_audit_logs_user_id",
                table: "audit_logs",
                column: "user_id"
            );

            migrationBuilder.CreateIndex(
                name: "ix_dealer_contracts_dealer_id",
                table: "dealer_contracts",
                column: "dealer_id"
            );

            migrationBuilder.CreateIndex(
                name: "ix_feedbacks_customer_id",
                table: "feedbacks",
                column: "customer_id"
            );

            migrationBuilder.CreateIndex(
                name: "ix_feedbacks_dealer_id",
                table: "feedbacks",
                column: "dealer_id"
            );

            migrationBuilder.CreateIndex(
                name: "ix_oem_inventories_variant_id",
                table: "oem_inventories",
                column: "variant_id"
            );

            migrationBuilder.CreateIndex(
                name: "ix_payments_sales_order_id",
                table: "payments",
                column: "sales_order_id"
            );

            migrationBuilder.CreateIndex(
                name: "ix_promotions_dealer_id",
                table: "promotions",
                column: "dealer_id"
            );

            migrationBuilder.CreateIndex(
                name: "ix_quotations_customer_id",
                table: "quotations",
                column: "customer_id"
            );

            migrationBuilder.CreateIndex(
                name: "ix_quotations_dealer_id",
                table: "quotations",
                column: "dealer_id"
            );

            migrationBuilder.CreateIndex(
                name: "ix_quotations_user_id",
                table: "quotations",
                column: "user_id"
            );

            migrationBuilder.CreateIndex(
                name: "ix_refresh_tokens_user_id",
                table: "refresh_tokens",
                column: "user_id"
            );

            migrationBuilder.CreateIndex(
                name: "ix_sales_orders_customer_id",
                table: "sales_orders",
                column: "customer_id"
            );

            migrationBuilder.CreateIndex(
                name: "ix_sales_orders_dealer_id",
                table: "sales_orders",
                column: "dealer_id"
            );

            migrationBuilder.CreateIndex(
                name: "ix_sales_orders_quotation_id",
                table: "sales_orders",
                column: "quotation_id"
            );

            migrationBuilder.CreateIndex(
                name: "ix_sales_orders_user_id",
                table: "sales_orders",
                column: "user_id"
            );

            migrationBuilder.CreateIndex(
                name: "ix_sales_orders_vehicle_id",
                table: "sales_orders",
                column: "vehicle_id"
            );

            migrationBuilder.CreateIndex(
                name: "ix_test_drives_customer_id",
                table: "test_drives",
                column: "customer_id"
            );

            migrationBuilder.CreateIndex(
                name: "ix_test_drives_dealer_id",
                table: "test_drives",
                column: "dealer_id"
            );

            migrationBuilder.CreateIndex(
                name: "ix_test_drives_vehicle_id",
                table: "test_drives",
                column: "vehicle_id"
            );

            migrationBuilder.CreateIndex(
                name: "ix_users_dealer_id",
                table: "users",
                column: "dealer_id"
            );

            migrationBuilder.CreateIndex(
                name: "ix_users_email",
                table: "users",
                column: "email",
                unique: true
            );

            migrationBuilder.CreateIndex(
                name: "ix_vehicle_variants_model_id",
                table: "vehicle_variants",
                column: "model_id"
            );

            migrationBuilder.CreateIndex(
                name: "ix_vehicles_dealer_id",
                table: "vehicles",
                column: "dealer_id"
            );

            migrationBuilder.CreateIndex(
                name: "ix_vehicles_variant_id",
                table: "vehicles",
                column: "variant_id"
            );

            migrationBuilder.CreateIndex(
                name: "ix_vehicles_vin",
                table: "vehicles",
                column: "vin",
                unique: true
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "audit_logs");

            migrationBuilder.DropTable(name: "dealer_contracts");

            migrationBuilder.DropTable(name: "feedbacks");

            migrationBuilder.DropTable(name: "oem_inventories");

            migrationBuilder.DropTable(name: "payments");

            migrationBuilder.DropTable(name: "promotions");

            migrationBuilder.DropTable(name: "refresh_tokens");

            migrationBuilder.DropTable(name: "test_drives");

            migrationBuilder.DropTable(name: "sales_orders");

            migrationBuilder.DropTable(name: "quotations");

            migrationBuilder.DropTable(name: "vehicles");

            migrationBuilder.DropTable(name: "customers");

            migrationBuilder.DropTable(name: "users");

            migrationBuilder.DropTable(name: "vehicle_variants");

            migrationBuilder.DropTable(name: "dealers");

            migrationBuilder.DropTable(name: "vehicle_models");
        }
    }
}
