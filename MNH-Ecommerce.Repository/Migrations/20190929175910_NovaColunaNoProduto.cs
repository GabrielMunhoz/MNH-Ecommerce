using Microsoft.EntityFrameworkCore.Migrations;

namespace MNH_Ecommerce.Repository.Migrations
{
    public partial class NovaColunaNoProduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "Products",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileName",
                table: "Products");
        }
    }
}
