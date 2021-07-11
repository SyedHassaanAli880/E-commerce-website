using Microsoft.EntityFrameworkCore.Migrations;

namespace BethinyShop.Migrations
{
    public partial class categoryAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImagePhoto",
                table: "Products",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Products",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "ImagePhoto",
                table: "Products",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
