using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciadorEstoque.Infra.Migrations
{
    /// <inheritdoc />
    public partial class ProdutosEstoquePopulate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
               table: "ProdutoEstoques",
               columns: new[] { "LojaId", "ProdutoId", "Estoque" },
               values: new object[,]
               {
                    {"03e38606-76de-40d6-a8bc-02e0472d18f3", "7d7d8e24-981f-4ab3-8216-147c034b8268", 50 },
                    {"03e38606-76de-40d6-a8bc-02e0472d18f3", "58595f02-3980-41bd-ba47-9de50ee2e225", 30 },
                    {"03e38606-76de-40d6-a8bc-02e0472d18f3", "b61aa7b4-fdda-40ff-aa9c-67de56bc62f2", 40 },
                    {"4a9ad699-c47e-4512-80e6-953fd7a0e0c2", "dd56bfa5-691b-4121-8bb2-d17eb4245819", 20 },
                    {"4a9ad699-c47e-4512-80e6-953fd7a0e0c2", "f1b9b04b-845a-4471-859d-f19e8ee60ce5", 25 },
                    {"4a9ad699-c47e-4512-80e6-953fd7a0e0c2", "2ad5d3ce-df8d-45ca-b220-2f01a2961738", 15 },
                    {"f0072a52-59fb-4fe6-885e-18479d9c7bc6", "a48c62d7-76ef-4948-ba13-9065a20e2362", 35 },
                    {"f0072a52-59fb-4fe6-885e-18479d9c7bc6", "7988f8f3-1d0d-49c6-9f4d-6a40e0ea292e", 45 },
                    {"f0072a52-59fb-4fe6-885e-18479d9c7bc6", "944f4b4e-2b20-48eb-885f-88cccef7ba0a", 60 },
                    {"df8bac5d-5a2e-40de-b665-6add0a1044c8", "c6b1379e-1682-4fd0-bdb2-ca43c3721d64", 10 },
                    {"df8bac5d-5a2e-40de-b665-6add0a1044c8", "8308cc39-1be6-4c0f-ad2c-5023da2bb734", 50 },
                    {"df8bac5d-5a2e-40de-b665-6add0a1044c8", "2f8988ed-4650-41b0-a4da-874fb9d00232", 30 },
                    {"e1a4fabe-f8aa-4f80-af52-1ef801f139fd", "50592d2f-4a5f-46db-aa6e-29c73f73bdc9", 25 },
                    {"e1a4fabe-f8aa-4f80-af52-1ef801f139fd", "e162b3d0-0a2a-4a3b-8624-d8a09cc205cd", 40 },
                    {"e1a4fabe-f8aa-4f80-af52-1ef801f139fd", "f9ef1128-67de-4b6c-a3d1-a52d8a4aaeb3", 35 },
                    {"03e38606-76de-40d6-a8bc-02e0472d18f3", "aa56c01c-4144-40b0-86d5-b0d9b7f4bae0", 50 },
                    {"4a9ad699-c47e-4512-80e6-953fd7a0e0c2", "5fe6a934-34bf-45f7-8798-3d287dd139b4", 60 },
                    {"f0072a52-59fb-4fe6-885e-18479d9c7bc6", "d0f69ad1-31f6-4d17-8449-0e4d84abeff8", 40 },
                    {"df8bac5d-5a2e-40de-b665-6add0a1044c8", "d4d8270e-080d-4541-9167-136798980aae", 25 },
                    {"e1a4fabe-f8aa-4f80-af52-1ef801f139fd", "1f44b591-ed74-44b0-af50-1c8dae7a2d42", 30 }
               }
           );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
