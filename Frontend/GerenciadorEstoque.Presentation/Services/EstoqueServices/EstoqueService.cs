using GerenciadorEstoque.Presentation.Models;
using GerenciadorEstoque.Presentation.Services.LojaServices;
using System.Text.Json;

namespace GerenciadorEstoque.Presentation.Services.EstoqueServices;

public class EstoqueService : IEstoqueService
{
    private readonly IHttpClientFactory _clientFactory;
    private readonly JsonSerializerOptions _options;
    private readonly ILogger<LojaService> _logger;
    private const string apiEndpoint = "api/produtoestoque";

    public EstoqueService(IHttpClientFactory clientFactory, JsonSerializerOptions options, ILogger<LojaService> logger)
    {
        _clientFactory = clientFactory;
        _options = options;
        _logger = logger;
    }

    public async Task<IEnumerable<EstoqueViewModel>> GetEstoqueByLojaId(Guid lojaId)
    {
        try
        {
            var client = _clientFactory.CreateClient("GerenciadorApi");
            var response = await client.GetAsync($"{apiEndpoint}/loja/{lojaId}");

            if (response.IsSuccessStatusCode)
            {
                var apiResponse = await response.Content.ReadAsStreamAsync();
                var estoque = await JsonSerializer.DeserializeAsync<IEnumerable<EstoqueViewModel>>(apiResponse, _options);
                return estoque;
            }
            else
            {
                _logger.LogError($"Failed to get estoque for lojaId {lojaId}. StatusCode: {response.StatusCode}");
                return null;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Exception occurred while getting estoque for lojaId {lojaId}");
            return null;
        }
    }
}
