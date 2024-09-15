using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace REAgency.DAL.Migrations
{
    /// <inheritdoc />
    public partial class migrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "idObject",
                table: "Orders");

            migrationBuilder.CreateTable(
                name: "ObjectsForOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    EstateObjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjectsForOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ObjectsForOrders_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ObjectsForOrders_OrderId",
                table: "ObjectsForOrders",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ObjectsForOrders");

            migrationBuilder.AddColumn<string>(
                name: "idObject",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
