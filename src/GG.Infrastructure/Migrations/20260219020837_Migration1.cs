using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GG.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Migration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PedidoPratoId",
                table: "Pratos");

            migrationBuilder.DropColumn(
                name: "PratoProdutosId",
                table: "Pratos");

            migrationBuilder.DropColumn(
                name: "PedidoPratosId",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "Preco",
                table: "PedidoPrato");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PedidoPratoId",
                table: "Pratos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PratoProdutosId",
                table: "Pratos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PedidoPratosId",
                table: "Pedidos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Preco",
                table: "PedidoPrato",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
