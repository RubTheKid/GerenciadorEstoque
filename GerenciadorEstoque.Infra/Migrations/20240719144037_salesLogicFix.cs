using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciadorEstoque.Infra.Migrations
{
    /// <inheritdoc />
    public partial class salesLogicFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Codigo",
                table: "Vendas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Codigo",
                table: "Vendas");
        }
    }
}
