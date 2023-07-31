using KanbanFlow.API.Models.DTOs;
using KanbanFlow.API.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KanbanFlow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public readonly UserManager<IdentityUser> _userManager;
        private readonly ITokenRepository _tokenRepository;

        public AuthController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository)
        {
            _userManager = userManager;
            _tokenRepository = tokenRepository;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequestDto)
        {
            var user = new IdentityUser
            {
                UserName = registerRequestDto.UserName,
                Email = registerRequestDto.Email,
                PhoneNumber = registerRequestDto.PhoneNumber,
            };

            var identityResult = await _userManager.CreateAsync(user, registerRequestDto.Password);

            if (identityResult.Succeeded)
            {
                if (registerRequestDto.Roles != null && registerRequestDto.Roles.Any())
                    identityResult = await _userManager.AddToRolesAsync(user, registerRequestDto.Roles);

                if (identityResult.Succeeded)
                    return Ok("User was registered. Please Login.");
            }

            return BadRequest();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            var user = await _userManager.FindByEmailAsync(loginRequestDto.Email);

            if (user != null)
            {
                var checkPassword = await _userManager.CheckPasswordAsync(user, loginRequestDto.Password);
                if (checkPassword)
                {
                    var roles = await _userManager.GetRolesAsync(user);
                    if (roles != null)
                    {
                        var token = _tokenRepository.CreateJWTToken(user, roles.ToArray());
                        var response = new LoginResponseDto
                        {
                            JwtToken = token,
                        };
                        return Ok(response);
                    }
                    else return BadRequest("No roles found");
                }
                else return BadRequest("Password is incorrect");
            }
            else return BadRequest("Email is incorrect");
        }
    }
}
