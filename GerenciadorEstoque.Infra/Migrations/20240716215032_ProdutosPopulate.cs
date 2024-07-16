using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciadorEstoque.Infra.Migrations
{
    /// <inheritdoc />
    public partial class ProdutosPopulate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "Nome", "Descricao", "Gtin", "Preco", "EstoqueMinimo", "DateCreated", "DateModified", "DateDeleted", "IsDeleted" },
                values: new object[,]
                {
                    {"7d7d8e24-981f-4ab3-8216-147c034b8268", "Paracetamol", "Analgésico e antipirético", "1234567890123", 10.0m, 5, DateTime.Now, null, null, false },
                    {"58595f02-3980-41bd-ba47-9de50ee2e225", "Ibuprofeno", "Anti-inflamatório e analgésico", "2234567890123", 15.0m, 10, DateTime.Now, null, null, false },
                    {"b61aa7b4-fdda-40ff-aa9c-67de56bc62f2", "Vitamina C", "Suplemento vitamínico", "3234567890123", 20.0m, 8, DateTime.Now, null, null, false },
                    {"dd56bfa5-691b-4121-8bb2-d17eb4245819", "Aspirina", "Analgésico e antipirético", "4234567890123", 25.0m, 7, DateTime.Now, null, null, false },
                    {"f1b9b04b-845a-4471-859d-f19e8ee60ce5", "Omeprazol", "Inibidor de bomba de prótons", "5234567890123", 30.0m, 12, DateTime.Now, null, null, false },
                    {"2ad5d3ce-df8d-45ca-b220-2f01a2961738", "Loratadina", "Antialérgico", "6234567890123", 35.0m, 9, DateTime.Now, null, null, false },
                    {"a48c62d7-76ef-4948-ba13-9065a20e2362", "Soro Fisiológico", "Solução isotônica para hidratação", "7234567890123", 40.0m, 6, DateTime.Now, null, null, false },
                    {"7988f8f3-1d0d-49c6-9f4d-6a40e0ea292e", "Álcool Gel", "Antisséptico para higienização das mãos", "8234567890123", 45.0m, 14, DateTime.Now, null, null, false },
                    {"944f4b4e-2b20-48eb-885f-88cccef7ba0a", "Dipirona", "Analgésico e antipirético", "9234567890123", 50.0m, 11, DateTime.Now, null, null, false },
                    {"c6b1379e-1682-4fd0-bdb2-ca43c3721d64", "Ranitidina", "Antagonista de receptor H2", "1034567890123", 55.0m, 4, DateTime.Now, null, null, false },
                    {"8308cc39-1be6-4c0f-ad2c-5023da2bb734", "Cloridrato de Metformina", "Antidiabético oral", "1134567890123", 60.0m, 3, DateTime.Now, null, null, false },
                    {"2f8988ed-4650-41b0-a4da-874fb9d00232", "Cloridrato de Fluoxetina", "Antidepressivo", "1234567890123", 65.0m, 2, DateTime.Now, null, null, false },
                    {"50592d2f-4a5f-46db-aa6e-29c73f73bdc9", "Amoxicilina", "Antibiótico penicilínico", "1334567890123", 70.0m, 1, DateTime.Now, null, null, false },
                    {"e162b3d0-0a2a-4a3b-8624-d8a09cc205cd", "Hidroxicloroquina", "Antimalárico e imunomodulador", "1434567890123", 75.0m, 15, DateTime.Now, null, null, false },
                    {"f9ef1128-67de-4b6c-a3d1-a52d8a4aaeb3", "Prednisona", "Corticosteroide", "1534567890123", 80.0m, 13, DateTime.Now, null, null, false },
                    {"aa56c01c-4144-40b0-86d5-b0d9b7f4bae0", "Cetoconazol", "Antifúngico", "1634567890123", 85.0m, 10, DateTime.Now, null, null, false },
                    {"5fe6a934-34bf-45f7-8798-3d287dd139b4", "Simeticona", "Antiflatulento", "1734567890123", 90.0m, 8, DateTime.Now, null, null, false },
                    {"d0f69ad1-31f6-4d17-8449-0e4d84abeff8", "Sal de Frutas Eno", "Antiácido efervescente", "1834567890123", 95.0m, 7, DateTime.Now, null, null, false },
                    {"d4d8270e-080d-4541-9167-136798980aae", "Diclofenaco", "Anti-inflamatório não esteroide", "1934567890123", 100.0m, 5, DateTime.Now, null, null, false },
                    {"1f44b591-ed74-44b0-af50-1c8dae7a2d42", "Polaramine", "Antialérgico", "2034567890123", 105.0m, 6, DateTime.Now, null, null, false }
                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
