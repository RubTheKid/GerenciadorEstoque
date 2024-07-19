using GerenciadorEstoque.Presentation.Models;
using System.Text.Json;

namespace GerenciadorEstoque.Presentation.Services.VendaViewModel
{
    public class VendaService : IVendaService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly JsonSerializerOptions _options;
        private readonly IConfiguration _configuration;
        private const string apiEndpoint = "api/venda";


        public VendaService(IHttpClientFactory clientFactory, JsonSerializerOptions options, IConfiguration configuration)
        {
            _clientFactory = clientFactory;
            _options = options;
            _configuration = configuration;
        }

        public async Task<bool> RegistrarVenda(RegistrarVendaViewModel venda)
        {
            var client = _clientFactory.CreateClient("GerenciadorApi");
            var vendaJson = new StringContent(JsonSerializer.Serialize(venda, _options), System.Text.Encoding.UTF8, "application/json");

            var response = await client.PostAsync(apiEndpoint, vendaJson);

            return response.IsSuccessStatusCode;
        }
    }
}
