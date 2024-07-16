using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciadorEstoque.Infra.Migrations
{
    /// <inheritdoc />
    public partial class LojasPopulate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
               table: "Lojas",
               columns: new[] { "Id", "Nome", "Codigo", "Logradouro", "EnderecoNumero", "Complemento", "Bairro", "Cidade", "Estado", "Cep", "CodigoArea", "Numero", "DateCreated", "DateModified", "DateDeleted", "IsDeleted" },
               values: new object[,]
               {
                    { "03e38606-76de-40d6-a8bc-02e0472d18f3", "Loja Sede", "1234", "Rua A", "100", "", "Bairro A", "Cidade A", "RJ", "12345-678", "11", "12345678", DateTime.Now, null, null, false },
                    { "4a9ad699-c47e-4512-80e6-953fd7a0e0c2", "Filial 1", "2345", "Rua B", "200", "", "Bairro B", "Cidade B", "RJ", "23456-789", "21", "23456789", DateTime.Now, null, null, false },
                    { "f0072a52-59fb-4fe6-885e-18479d9c7bc6", "Filial 2", "3456", "Rua C", "300", "", "Bairro C", "Cidade C", "ES", "34567-890", "31", "34567890", DateTime.Now, null, null, false },
                    { "df8bac5d-5a2e-40de-b665-6add0a1044c8", "Filial 3", "4567", "Rua D", "400", "Apto 101", "Bairro D", "Cidade D", "SP", "45678-901", "41", "45678901", DateTime.Now, null, null, false },
                    { "e1a4fabe-f8aa-4f80-af52-1ef801f139fd", "Filial 4", "5678", "Rua E", "500", "", "Bairro E", "Cidade E", "SP", "56789-012", "51", "56789012", DateTime.Now, null, null, false }
               }
           );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
