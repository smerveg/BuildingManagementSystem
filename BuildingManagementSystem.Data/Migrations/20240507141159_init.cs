using Microsoft.EntityFrameworkCore.Migrations;

namespace BuildingManagementSystem.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buildings",
                columns: table => new
                {
                    BuildingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Properties = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.BuildingID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductID);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    RoomID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Floor = table.Column<int>(type: "int", nullable: false),
                    Properties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuildingID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.RoomID);
                    table.ForeignKey(
                        name: "FK_Rooms_Buildings_BuildingID",
                        column: x => x.BuildingID,
                        principalTable: "Buildings",
                        principalColumn: "BuildingID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Storages",
                columns: table => new
                {
                    StorageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Floor = table.Column<int>(type: "int", nullable: false),
                    Properties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuildingID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Storages", x => x.StorageID);
                    table.ForeignKey(
                        name: "FK_Storages_Buildings_BuildingID",
                        column: x => x.BuildingID,
                        principalTable: "Buildings",
                        principalColumn: "BuildingID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductStorage",
                columns: table => new
                {
                    ProductStorageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    StorageID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ProductID1 = table.Column<int>(type: "int", nullable: true),
                    StorageID1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductStorage", x => x.ProductStorageID);
                    table.ForeignKey(
                        name: "FK_ProductStorage_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductStorage_Products_ProductID1",
                        column: x => x.ProductID1,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductStorage_Storages_StorageID",
                        column: x => x.StorageID,
                        principalTable: "Storages",
                        principalColumn: "StorageID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductStorage_Storages_StorageID1",
                        column: x => x.StorageID1,
                        principalTable: "Storages",
                        principalColumn: "StorageID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductStorage_ProductID",
                table: "ProductStorage",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductStorage_ProductID1",
                table: "ProductStorage",
                column: "ProductID1");

            migrationBuilder.CreateIndex(
                name: "IX_ProductStorage_StorageID",
                table: "ProductStorage",
                column: "StorageID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductStorage_StorageID1",
                table: "ProductStorage",
                column: "StorageID1");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_BuildingID",
                table: "Rooms",
                column: "BuildingID");

            migrationBuilder.CreateIndex(
                name: "IX_Storages_BuildingID",
                table: "Storages",
                column: "BuildingID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductStorage");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Storages");

            migrationBuilder.DropTable(
                name: "Buildings");
        }
    }
}
