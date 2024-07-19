using GerenciadorEstoque.Presentation.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Text.Json;

namespace GerenciadorEstoque.Presentation.Services.ProdutoServices;

public class ProdutoService : IProdutoService
{
    private readonly IHttpClientFactory _clientFactory;
    private readonly JsonSerializerOptions _options;
    private const string apiEndpoint = "api/produtos";

    public ProdutoService(IHttpClientFactory clientFactory, JsonSerializerOptions options)
    {
        _clientFactory = clientFactory;
        _options = options;
    }

    public async Task<IEnumerable<ProdutoViewModel>> GetAllProdutos()
    {
        var client = _clientFactory.CreateClient("GerenciadorApi");
        var response = await client.GetAsync(apiEndpoint);

        if (response.IsSuccessStatusCode)
        {
            var apiResponse = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<ProdutoViewModel>>(apiResponse, _options);
        }
        return null;
    }

    public async Task<ProdutoViewModel> GetProdutoById(Guid id)
    {
        var client = _clientFactory.CreateClient("GerenciadorApi");
        var response = await client.GetAsync($"{apiEndpoint}/{id}");

        if (response.IsSuccessStatusCode)
        {
            var apiResponse = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<ProdutoViewModel>(apiResponse, _options);
        }
        return null;
    }

    public async Task<ProdutoViewModel> UpdateProduto(ProdutoViewModel produto)
    {
        var client = _clientFactory.CreateClient("GerenciadorApi");

        var produtoDto = new
        {
            produto.Id,
            produto.Nome,
            produto.Descricao,
            produto.Gtin,
            preco = produto.Preco.Valor,
            produto.EstoqueMinimo
        };

        var content = new StringContent(JsonSerializer.Serialize(produtoDto, _options), System.Text.Encoding.UTF8, "application/json");
        var response = await client.PutAsync(apiEndpoint, content);

        if (response.IsSuccessStatusCode)
        {
            var apiResponse = await response.Content.ReadAsStringAsync();
            return produto;
        }
        throw new Exception($"Erro ao atualizar produto: {response.ReasonPhrase}");
    }

    public async Task<ProdutoViewModel> CreateProduto(ProdutoViewModel produto)
    {
        var client = _clientFactory.CreateClient("GerenciadorApi");

        var produtoDto = new
        {
            produto.Nome,
            produto.Descricao,
            produto.Gtin,
            preco = produto.Preco.Valor,
            produto.EstoqueMinimo
        };

        var content = new StringContent(JsonSerializer.Serialize(produtoDto, _options), System.Text.Encoding.UTF8, "application/json");
        var response = await client.PostAsync(apiEndpoint, content);

        if (response.IsSuccessStatusCode)
        {
            var apiResponse = await response.Content.ReadAsStringAsync();
            return produto;
        }
        throw new Exception($"Erro ao criar produto: {response.ReasonPhrase}");
    }

    public async Task<bool> DeleteProduto(Guid id)
    {
        var client = _clientFactory.CreateClient("GerenciadorApi");
        var response = await client.DeleteAsync($"{apiEndpoint}/{id}");

        return response.IsSuccessStatusCode;
    }
}
