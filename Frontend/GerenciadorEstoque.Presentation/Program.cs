using GerenciadorEstoque.Presentation.Services.EstoqueServices;
using GerenciadorEstoque.Presentation.Services.LojaServices;
using GerenciadorEstoque.Presentation.Services.ProdutoServices;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient("GerenciadorApi", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["ServiceURI:GerenciadorApi"]);
});

builder.Services.AddSingleton(new JsonSerializerOptions
{
    PropertyNameCaseInsensitive = true
});

builder.Services.AddScoped<ILojaService, LojaService>();
builder.Services.AddScoped<IEstoqueService, EstoqueService>();
builder.Services.AddScoped<IProdutoService, ProdutoService>();

// session control
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Auth}/{action=Login}/{id?}");

app.MapControllerRoute(
    name: "defaultProtected",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
