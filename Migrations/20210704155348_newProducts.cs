using Microsoft.EntityFrameworkCore.Migrations;

namespace BethinyShop.Migrations
{
    public partial class newProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageThumbnailUrl",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsPieOfTheWeek",
                table: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "ShortDescription",
                table: "Products",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LongDescription",
                table: "Products",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagePhoto",
                table: "Products",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "quantity",
                table: "Products",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePhoto",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "quantity",
                table: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "ShortDescription",
                table: "Products",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LongDescription",
                table: "Products",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "ImageThumbnailUrl",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsPieOfTheWeek",
                table: "Products",
                nullable: false,
                defaultValue: false);
        }
    }
}
