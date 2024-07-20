using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace GerenciadorEstoque.Presentation.Services;

public class ApiService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ApiService(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
    {
        _httpClientFactory = httpClientFactory;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<HttpResponseMessage> Get(string url)
    {
        var client = _httpClientFactory.CreateClient("GerenciadorApi");
        var token = _httpContextAccessor.HttpContext.Session.GetString("JWT");
        if (!string.IsNullOrEmpty(token))
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        return await client.GetAsync(url);
    }

    public async Task<HttpResponseMessage> Post(string url, object data)
    {
        var client = _httpClientFactory.CreateClient("GerenciadorApi");
        var token = _httpContextAccessor.HttpContext.Session.GetString("JWT");
        if (!string.IsNullOrEmpty(token))
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        var json = JsonSerializer.Serialize(data);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        return await client.PostAsync(url, content);
    }

    public async Task<HttpResponseMessage> Put(string url, object data)
    {
        var client = _httpClientFactory.CreateClient("GerenciadorApi");
        var token = _httpContextAccessor.HttpContext.Session.GetString("JWT");
        if (!string.IsNullOrEmpty(token))
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        var json = JsonSerializer.Serialize(data);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        return await client.PutAsync(url, content);
    }

    public async Task<HttpResponseMessage> Delete(string url)
    {
        var client = _httpClientFactory.CreateClient("GerenciadorApi");
        var token = _httpContextAccessor.HttpContext.Session.GetString("JWT");
        if (!string.IsNullOrEmpty(token))
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        return await client.DeleteAsync(url);
    }
}