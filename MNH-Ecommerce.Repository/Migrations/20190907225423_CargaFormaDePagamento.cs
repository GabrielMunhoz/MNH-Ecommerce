using Microsoft.EntityFrameworkCore.Migrations;

namespace MNH_Ecommerce.Repository.Migrations
{
    public partial class CargaFormaDePagamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PayWays",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Forma de pagamento Boleto", "Boleto" },
                    { 2, "Forma de pagamento Cartão de crédito", "Cartão de Crédito" },
                    { 3, "Forma de pagamento Depósito Bancário", "Depósito Bancário" },
                    { 4, "Forma de pagamento Indefinido", "Indefinido" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PayWays",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PayWays",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PayWays",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PayWays",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
