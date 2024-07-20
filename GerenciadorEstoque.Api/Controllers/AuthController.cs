using GerenciadorEstoque.Auth.Interfaces;
using GerenciadorEstoque.Auth.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorEstoque.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly UserManager<ApplicationUser> _userManager;

    public AuthController(IAuthService authService, UserManager<ApplicationUser> userManager)
    {
        _authService = authService;
        _userManager = userManager;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginModel model)
    {
        var token = await _authService.LoginAsync(model.Username, model.Password);
        if (token == null)
        {
            return Unauthorized();
        }

        var user = await _userManager.FindByNameAsync(model.Username);
        return Ok(new { token, refreshToken = user.RefreshToken });
    }

    [HttpPost("refresh")]
    public async Task<IActionResult> Refresh([FromBody] RefreshModel model)
    {
        var user = await _authService.GetUserByRefreshToken(model.RefreshToken);
        if (user == null || user.RefreshTokenExpiryTime <= DateTime.Now)
        {
            return Unauthorized();
        }

        var token = _authService.GenerateJwtToken(user);
        user.RefreshToken = await _authService.GenerateRefreshToken(user.UserName);
        user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);
        await _userManager.UpdateAsync(user);

        return Ok(new { token, refreshToken = user.RefreshToken });
    }
}
