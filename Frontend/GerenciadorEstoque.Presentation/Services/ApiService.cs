namespace GerenciadorEstoque.Presentation.Services;

public class ApiService
{
    private readonly IHttpClientFactory _factory;
    private readonly IHttpContextAccessor _accessor;

    public ApiService(IHttpClientFactory factory, IHttpContextAccessor accessor)
    {
        _factory = factory;
        _accessor = accessor;
    }

    public async Task<HttpResponseMessage> GetAsync(string url)
    {
        var client = _factory.CreateClient();
        var token = _accessor.HttpContext.Session.GetString("JWT");
        if (!string.IsNullOrEmpty(token))
        {
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        }

        return await client.GetAsync(url);
    }
}