namespace GerenciadorEstoque.Presentation.Models;

public class LoginViewModel
{
    public string Username { get; set; }
    public string Password { get; set; }
}

public class LoginResponse
{
    public string Token { get; set; }
    public string RefreshToken { get; set; }
}