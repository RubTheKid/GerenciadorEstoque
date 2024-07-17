using GerenciadorEstoque.Presentation.Models;
using System.Text.Json;

namespace GerenciadorEstoque.Presentation.Services.LojaServices;

public class LojaService : ILojaService
{
    private readonly IHttpClientFactory _clientFactory;
    private readonly JsonSerializerOptions _options;
    private const string apiEndpoint = "api/lojas";
    private readonly ILogger<LojaService> _logger;

    public LojaService(IHttpClientFactory clientFactory, JsonSerializerOptions options, ILogger<LojaService> logger)
    {
        _clientFactory = clientFactory;
        _options = options;
        _logger = logger;
    }

    public async Task<IEnumerable<LojaViewModel>> GetAllLojasAsync()
    {
        try
        {
            var client = _clientFactory.CreateClient("GerenciadorApi");
            var response = await client.GetAsync(apiEndpoint);

            if (response.IsSuccessStatusCode)
            {
                var apiResponse = await response.Content.ReadAsStreamAsync();
                var lojas = await JsonSerializer.DeserializeAsync<IEnumerable<LojaViewModel>>(apiResponse, _options);
                return lojas;
            }
            else
            {
               
                return null;
            }
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public Task<LojaViewModel> GetLojaByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}
