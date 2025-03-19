using AutoMapper;
using ClickWise.Core.DTOs;
using ClickWise.Core.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SchoolManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        public AuthController(IAuthService authService, IMapper mapper, IConfiguration configuration)
        {
            _authService = authService;
            _mapper = mapper;
            _configuration = configuration;
        }

        // POST api/<AuthController>
        [HttpPost("login")]
        public async Task<ActionResult<LoginDTO>> LoginAsync([FromBody] LoginDTO login)
        {
            if (string.IsNullOrWhiteSpace(login.User.Email) || string.IsNullOrWhiteSpace(login.User.Password))
            {
                return BadRequest("Email and password are required.");
            }
            var user = await _authService.LoginAsync(login.User.Email, login.User.Password);
            if (user == null)
            {
                return Unauthorized();
            }
            return Ok(user);
        }

        [HttpPost("register")]
        public async Task<ActionResult<LoginDTO>> RegisterAsync([FromBody] UserDTO user)
        {
            if (string.IsNullOrWhiteSpace(user.Email) || string.IsNullOrWhiteSpace(user.Password))
            {
                return BadRequest("Email and password are required.");//400
            }
            //var hashedPassword = BCrypt.Net.BCrypt.HashPassword(user.Password);
            var userDto = _mapper.Map<UserDTO>(user);
            var userRegistered = await _authService.RegisterAsync(userDto);
            if (userRegistered == null)
            {
                return BadRequest("User already exist.");
            }
            return Ok(userRegistered);
        }

    }
}
