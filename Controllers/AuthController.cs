using Microsoft.AspNetCore.Mvc;
using Security_with_Password_Hashing.Services;

namespace Security_with_Password_Hashing.Controllers
{

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly TokenService _tokenService;

    public AuthController(ApplicationDbContext context, TokenService tokenService)
    {
        _context = context;
        _tokenService = tokenService;
    }

    [HttpPost("login")]
    public IActionResult Login(string username, string password)
    {
        var user = _context.Users.SingleOrDefault(u => u.Username == username);
        if (user == null || !PasswordService.VerifyPassword(user.PasswordHash, password))
        {
            return Unauthorized("Invalid credentials.");
        }

        var token = _tokenService.GenerateToken(user.Username, user.Role);
        return Ok(new { Token = token });
    }
}
}