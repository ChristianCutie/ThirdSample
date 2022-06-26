using Microsoft.EntityFrameworkCore.Migrations;

namespace ThirdSample.Migrations
{
    public partial class UpdateInstruments : Migration
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
        }
    }
}
