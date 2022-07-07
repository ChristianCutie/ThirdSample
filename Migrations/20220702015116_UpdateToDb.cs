using Microsoft.EntityFrameworkCore.Migrations;

namespace ThirdSample.Migrations
{
    public partial class UpdateToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "instruments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    typeid = table.Column<int>(type: "int", nullable: false),
                    itemid = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<int>(type: "int", nullable: false),
                    imgpath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_instruments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_instruments_items_itemid",
                        column: x => x.itemid,
                        principalTable: "items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_instruments_types_typeid",
                        column: x => x.typeid,
                        principalTable: "types",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "logins",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userID = table.Column<int>(type: "int", nullable: true),
                    FirstNane = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LastNane = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", maxLength: 3, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_logins", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_instruments_itemid",
                table: "instruments",
                column: "itemid");

            migrationBuilder.CreateIndex(
                name: "IX_instruments_typeid",
                table: "instruments",
                column: "typeid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "instruments");

            migrationBuilder.DropTable(
                name: "logins");
        }
    }
}
