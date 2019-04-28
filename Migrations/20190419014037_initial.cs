using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace licensemanager.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "public",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    IdApplication = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 50, nullable: false),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Resale",
                schema: "public",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    SocialName = table.Column<string>(maxLength: 100, nullable: false),
                    CpfCnpj = table.Column<string>(maxLength: 20, nullable: false),
                    Manager = table.Column<string>(maxLength: 50, nullable: false),
                    Phone = table.Column<string>(maxLength: 20, nullable: true),
                    CelPhone = table.Column<string>(maxLength: 20, nullable: false),
                    Email = table.Column<string>(maxLength: 255, nullable: false),
                    Password = table.Column<string>(maxLength: 50, nullable: false),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resale", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Version",
                schema: "public",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ProductID = table.Column<int>(nullable: false),
                    VersionValue = table.Column<string>(maxLength: 10, nullable: false),
                    VersionDate = table.Column<DateTime>(nullable: false),
                    VersionScript = table.Column<string>(maxLength: 50, nullable: false),
                    Script = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Version", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Version_Product_ProductID",
                        column: x => x.ProductID,
                        principalSchema: "public",
                        principalTable: "Product",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                schema: "public",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ResaleID = table.Column<int>(nullable: false),
                    ProducID = table.Column<int>(nullable: false),
                    SocialName = table.Column<string>(maxLength: 255, nullable: false),
                    Name = table.Column<string>(maxLength: 255, nullable: true),
                    Cnpj = table.Column<string>(maxLength: 20, nullable: false),
                    Ie = table.Column<string>(maxLength: 20, nullable: true),
                    Status = table.Column<string>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Message = table.Column<string>(nullable: true),
                    ProductSerial = table.Column<string>(maxLength: 255, nullable: false),
                    PaidAnnuity = table.Column<int>(nullable: false),
                    CustomerStatus = table.Column<string>(nullable: false),
                    ProductID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Customer_Product_ProductID",
                        column: x => x.ProductID,
                        principalSchema: "public",
                        principalTable: "Product",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Customer_Resale_ResaleID",
                        column: x => x.ResaleID,
                        principalSchema: "public",
                        principalTable: "Resale",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerStation",
                schema: "public",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CustomerID = table.Column<int>(nullable: false),
                    StationSerial = table.Column<string>(maxLength: 255, nullable: false),
                    StationName = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerStation", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CustomerStation_Customer_CustomerID",
                        column: x => x.CustomerID,
                        principalSchema: "public",
                        principalTable: "Customer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Module",
                schema: "public",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ProductID = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 50, nullable: false),
                    CryptDescription = table.Column<string>(maxLength: 255, nullable: false),
                    CustomerID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Module", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Module_Customer_CustomerID",
                        column: x => x.CustomerID,
                        principalSchema: "public",
                        principalTable: "Customer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Module_Product_ProductID",
                        column: x => x.ProductID,
                        principalSchema: "public",
                        principalTable: "Product",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerModule",
                schema: "public",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CustomerID = table.Column<int>(nullable: false),
                    ProductID = table.Column<int>(nullable: false),
                    ModuleID = table.Column<int>(nullable: false),
                    Status = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerModule", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CustomerModule_Customer_CustomerID",
                        column: x => x.CustomerID,
                        principalSchema: "public",
                        principalTable: "Customer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerModule_Module_ModuleID",
                        column: x => x.ModuleID,
                        principalSchema: "public",
                        principalTable: "Module",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerModule_Product_ProductID",
                        column: x => x.ProductID,
                        principalSchema: "public",
                        principalTable: "Product",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customer_ProductID",
                schema: "public",
                table: "Customer",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_ResaleID",
                schema: "public",
                table: "Customer",
                column: "ResaleID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerModule_CustomerID",
                schema: "public",
                table: "CustomerModule",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerModule_ModuleID",
                schema: "public",
                table: "CustomerModule",
                column: "ModuleID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerModule_ProductID",
                schema: "public",
                table: "CustomerModule",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerStation_CustomerID",
                schema: "public",
                table: "CustomerStation",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Module_CustomerID",
                schema: "public",
                table: "Module",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Module_ProductID",
                schema: "public",
                table: "Module",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Version_ProductID",
                schema: "public",
                table: "Version",
                column: "ProductID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerModule",
                schema: "public");

            migrationBuilder.DropTable(
                name: "CustomerStation",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Version",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Module",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Customer",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Product",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Resale",
                schema: "public");
        }
    }
}
