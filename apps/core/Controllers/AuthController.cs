using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace AudioStreaming.Controllers
{
  [Route("api/auth")]
  [ApiController]
  public class AuthController : ControllerBase
  {
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IConfiguration _configuration;
    private readonly ILogger _logger;

    public AuthController(
        UserManager<User> userManager,
        RoleManager<IdentityRole> roleManager,
        IConfiguration configuration,
        ILogger<AuthController> logger)
    {
      _userManager = userManager;
      _roleManager = roleManager;
      _configuration = configuration;
      _logger = logger;
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login(string name, string password)
    {
      var user = await _userManager.FindByNameAsync(name);
      if (user != null && await _userManager.CheckPasswordAsync(user, password))
      {
        var userRoles = await _userManager.GetRolesAsync(user);

        var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName!),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

        foreach (var userRole in userRoles)
        {
          authClaims.Add(new Claim(ClaimTypes.Role, userRole));
        }

        var token = GetToken(authClaims);

        return Ok(new
        {
          token = new JwtSecurityTokenHandler().WriteToken(token),
          expiration = token.ValidTo
        });
      }
      return Unauthorized();
    }

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register(string username, string password)
    {
      var userExists = await _userManager.FindByNameAsync(username);
      if (userExists != null)
        return StatusCode(StatusCodes.Status500InternalServerError, new { Status = "Error", Message = "User already exists!" });

      User user = new()
      {
        UserName = username,
        SecurityStamp = Guid.NewGuid().ToString(),
      };
      var result = await _userManager.CreateAsync(user, password);
      if (!result.Succeeded)
      {
        return StatusCode(StatusCodes.Status500InternalServerError, new { Status = "Error", Message = "User creation failed! Please check user details and try again." });
      }

      return Ok(new { Status = "Success", Message = "User created successfully!" });
    }

    private JwtSecurityToken GetToken(List<Claim> authClaims)
    {
      var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]!));

      var token = new JwtSecurityToken(
          issuer: _configuration["JWT:ValidIssuer"],
          audience: _configuration["JWT:ValidAudience"],
          expires: DateTime.Now.AddHours(3),
          claims: authClaims,
          signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
          );

      return token;
    }
  }
}
