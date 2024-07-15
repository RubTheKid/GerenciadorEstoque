using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciadorEstoque.Infra.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lojas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Codigo = table.Column<string>(type: "varchar(4)", nullable: false),
                    Logradouro = table.Column<string>(type: "varchar(100)", nullable: false),
                    EnderecoNumero = table.Column<string>(type: "varchar(5)", nullable: false),
                    Complemento = table.Column<string>(type: "varchar(50)", nullable: false),
                    Bairro = table.Column<string>(type: "varchar(50)", nullable: false),
                    Cidade = table.Column<string>(type: "varchar(50)", nullable: false),
                    Estado = table.Column<string>(type: "varchar(2)", nullable: false),
                    Cep = table.Column<string>(type: "varchar(9)", nullable: false),
                    CodigoArea = table.Column<string>(type: "varchar(2)", nullable: false),
                    Numero = table.Column<string>(type: "varchar(9)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lojas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    Gtin = table.Column<string>(type: "varchar(13)", maxLength: 13, nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EstoqueMinimo = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProdutoEstoques",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LojaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProdutoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Estoque = table.Column<int>(type: "int", precision: 7, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutoEstoques", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProdutoEstoques_Lojas_LojaId",
                        column: x => x.LojaId,
                        principalTable: "Lojas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProdutoEstoques_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoEstoques_LojaId",
                table: "ProdutoEstoques",
                column: "LojaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoEstoques_ProdutoId",
                table: "ProdutoEstoques",
                column: "ProdutoId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProdutoEstoques");

            migrationBuilder.DropTable(
                name: "Lojas");

            migrationBuilder.DropTable(
                name: "Produtos");
        }
    }
}
