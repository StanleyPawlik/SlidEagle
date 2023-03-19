using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SlidEagle.Migrations
{
    /// <inheritdoc />
    public partial class RideStyleCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Items",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RideStyleId",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RideStyles",
                columns: table => new
                {
                    RideStyleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RideStyles", x => x.RideStyleId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_RideStyleId",
                table: "Items",
                column: "RideStyleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_RideStyles_RideStyleId",
                table: "Items",
                column: "RideStyleId",
                principalTable: "RideStyles",
                principalColumn: "RideStyleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_RideStyles_RideStyleId",
                table: "Items");

            migrationBuilder.DropTable(
                name: "RideStyles");

            migrationBuilder.DropIndex(
                name: "IX_Items_RideStyleId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "RideStyleId",
                table: "Items");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
