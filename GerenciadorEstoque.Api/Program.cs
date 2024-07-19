using GerenciadorEstoque.Application.ProdutoAggregate.Query.GetAllProdutos;
using GerenciadorEstoque.Auth.Data;
using GerenciadorEstoque.Auth.Interfaces;
using GerenciadorEstoque.Auth.Models;
using GerenciadorEstoque.Auth.Services;
using GerenciadorEstoque.Domain.Aggregates.LojaAggregate.Interfaces;
using GerenciadorEstoque.Domain.Aggregates.ProdutoAggregate.Interfaces;
using GerenciadorEstoque.Domain.Aggregates.ProdutoEstoqueAggregate.Interfaces;
using GerenciadorEstoque.Domain.Aggregates.VendaAggregate.Interfaces;
using GerenciadorEstoque.Domain.Aggregates.VendaProdutoAggregate.Interfaces;
using GerenciadorEstoque.Infra.Context;
using GerenciadorEstoque.Infra.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDbContext<AuthDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("GerenciadorEstoque.Auth")));

builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped<ILojaRepository, LojaRepository>();
builder.Services.AddScoped<IProdutoEstoqueRepository, ProdutoEstoqueRepository>();
builder.Services.AddScoped<IVendaRepository, VendaRepository>();
builder.Services.AddScoped<IVendaProdutoRepository, VendaProdutoRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(
    Assembly.GetExecutingAssembly(),
    typeof(GetAllProdutosHandler).Assembly 
));



builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<AuthDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});


builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin", policy => policy.RequireRole("Administrator"));
    options.AddPolicy("User", policy => policy.RequireRole("User"));
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;

    var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    var adminRole = "Administrator";

    if (!await roleManager.RoleExistsAsync(adminRole))
    {
        await roleManager.CreateAsync(new IdentityRole(adminRole));
    }
    var adminEmail = "super@admin.com";
    var adminUserName = "superadmin";
    var adminPassword = "Senha123!";

    var adminUser = await userManager.FindByEmailAsync(adminEmail);
    if (adminUser == null)
    {
        var newAdminUser = new ApplicationUser
        {
            UserName = adminUserName,
            Email = adminEmail,
            FullName = "Super Admin",
        };

        var result = await userManager.CreateAsync(newAdminUser, adminPassword);
        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(newAdminUser, adminRole);
        }
    }
}
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

//dotnet ef database update --project ./GerenciadorEstoque.Infra/ --startup-project ./GerenciadorEstoque.Api/
//dotnet ef migrations add InitialCreateAuth --context AuthDbContext --project ./Auth/ --startup-project ./GerenciadorEstoque.Api/ 
//dotnet ef database update --context AuthDbContext --project ./Auth/ --startup-project ./GerenciadorEstoque.Api/

