using GerenciadorEstoque.Presentation.Models;
using System.Text.Json;

namespace GerenciadorEstoque.Presentation.Services.LojaServices;

public class LojaService : ILojaService
{
    private readonly IHttpClientFactory _clientFactory;
    private readonly JsonSerializerOptions _options;
    private const string apiEndpoint = "api/lojas";
    private readonly ApiService _apiService;

    public LojaService(IHttpClientFactory clientFactory, JsonSerializerOptions options, ApiService apiService)
    {
        _clientFactory = clientFactory;
        _options = options;
        _apiService = apiService;
    }

    public async Task<IEnumerable<LojaViewModel>> GetAllLojasAsync()
    {
        var response = await _apiService.Get(apiEndpoint);

        if (response.IsSuccessStatusCode)
        {
            var apiResponse = await response.Content.ReadAsStreamAsync();
            var lojas = await JsonSerializer.DeserializeAsync<IEnumerable<LojaViewModel>>(apiResponse, _options);
            return lojas;
        }
        return null;
    }

    //public async Task<LojaViewModel> GetLojaByIdAsync(Guid id)
    //{
    //    var client = _clientFactory.CreateClient("GerenciadorApi");
    //    var response = await client.GetAsync($"{apiEndpoint}/{id}");

    //    if (response.IsSuccessStatusCode)
    //    {
    //        var apiResponse = await response.Content.ReadAsStreamAsync();
    //        var loja = await JsonSerializer.DeserializeAsync<LojaViewModel>(apiResponse, _options);
    //        return loja;
    //    }
    //    return null;
    //}

    public async Task<LojaViewModel> GetLojaByIdAsync(Guid id)
    {
        var response = await _apiService.Get($"{apiEndpoint}/{id}");

        if (response.IsSuccessStatusCode)
        {
            var apiResponse = await response.Content.ReadAsStreamAsync();
            var loja = await JsonSerializer.DeserializeAsync<LojaViewModel>(apiResponse, _options);
            return loja;
        }
        return null;
    }

    public async Task<LojaViewModel> GetLojaByCodeAsync(string codigo)
    {
        var client = _clientFactory.CreateClient("GerenciadorApi");
        var response = await client.GetAsync($"{apiEndpoint}/code/{codigo}");

        if (response.IsSuccessStatusCode)
        {
            var apiResponse = await response.Content.ReadAsStreamAsync();
            var loja = await JsonSerializer.DeserializeAsync<LojaViewModel>(apiResponse, _options);
            return loja;
        }
        return null;
    }

    public async Task<bool> AddLojaAsync(LojaViewModel loja)
    {
        var client = _clientFactory.CreateClient("GerenciadorApi");
        var lojaJson = new StringContent(JsonSerializer.Serialize(loja, _options), System.Text.Encoding.UTF8, "application/json");
        var response = await client.PostAsync(apiEndpoint, lojaJson);

        return response.IsSuccessStatusCode;
    }

    public async Task<bool> UpdateLojaAsync(LojaViewModel loja)
    {
        var client = _clientFactory.CreateClient("GerenciadorApi");
        var lojaJson = new StringContent(JsonSerializer.Serialize(loja, _options), System.Text.Encoding.UTF8, "application/json");
        var response = await client.PutAsync($"{apiEndpoint}", lojaJson);

        return response.IsSuccessStatusCode;
    }

    public async Task<bool> RemoveLojaAsync(Guid id)
    {
        var client = _clientFactory.CreateClient("GerenciadorApi");
        var response = await client.DeleteAsync($"{apiEndpoint}/{id}");

        return response.IsSuccessStatusCode;
    }
}
