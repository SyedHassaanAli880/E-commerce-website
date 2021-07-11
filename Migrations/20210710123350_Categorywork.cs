using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BethinyShop.Migrations
{
    public partial class Categorywork : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "Products",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.CreateTable(
                name: "CategoryModels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    IsActive = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryModels", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryModels");

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "Products",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
