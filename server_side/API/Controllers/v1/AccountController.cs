using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using API.DTOs;
using API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace API.Controllers.v1
{
  [AllowAnonymous]
  [ApiController]
  [Route("api/v1/[controller]")]
  public class AccountController : ControllerBase
  {
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _singInManager;
    private readonly TokenService _tokenService;

    public AccountController(UserManager<AppUser> userManager,
                             SignInManager<AppUser> singInManager,
                             TokenService tokenService)
    {
      _singInManager = singInManager;
      _userManager = userManager;
      _tokenService = tokenService;
    }

    [HttpPost]
    public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
    {
      var user = await _userManager.FindByEmailAsync(loginDto.Email);
      if (user == null) return Unauthorized();

      var result = await _singInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
      if (result.Succeeded) return CreateUserObject(user);

      return Unauthorized();
    }

    [HttpPost("register")]
    public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
    {
      if (await _userManager.Users.AnyAsync(x => x.Email == registerDto.Email))
      {
        ModelState.AddModelError("email", "Email taken");
        return ValidationProblem();
      }

      if (await _userManager.Users.AnyAsync(x => x.UserName == registerDto.Username))
      {
        ModelState.AddModelError("username", "Username taken");
        return ValidationProblem();
      }

      var user = new AppUser
      {
        DisplayName = registerDto.DisplayName,
        Email = registerDto.Email,
        UserName = registerDto.Username
      };

      var result = await _userManager.CreateAsync(user, registerDto.Password);

      if (result.Succeeded) return CreateUserObject(user);

      return BadRequest("Probelm registering user");
    }

    [Authorize]
    [HttpGet]
    public async Task<ActionResult<UserDto>> GetCurrentUser()
    {
      var user = await _userManager.FindByEmailAsync(User.FindFirstValue(ClaimTypes.Email));

      return CreateUserObject(user);
    }

    private UserDto CreateUserObject(AppUser user)
    {
      return new UserDto
      {
        DisplayName = user.DisplayName,
        Image = null,
        Token = _tokenService.CreateToken(user),
        Username = user.UserName
      };
    }
  }
}