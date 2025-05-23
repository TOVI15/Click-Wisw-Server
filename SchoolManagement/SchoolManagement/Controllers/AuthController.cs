using AutoMapper;
using ClickWise.Core.DTOs;
using ClickWise.Core.Entities;
using ClickWise.Core.Services;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<ActionResult<LoginUser>> LoginAsync([FromBody] LoginRequestDTO login)
        {
            if (string.IsNullOrWhiteSpace(login.Identity) || string.IsNullOrWhiteSpace(login.Password))
            {
                return BadRequest("TZ and password are required.");
            }
            var user = await _authService.LoginAsync(login.Identity, login.Password);

            if (user == null)
            {
                return Unauthorized();
            }
            return Ok(user);
        }

        [HttpPost("register")]
        public async Task<ActionResult<LoginUser>> RegisterAsync([FromBody] UserDTO user)
        {
            if (string.IsNullOrWhiteSpace(user.Identity) || string.IsNullOrWhiteSpace(user.Password))
            {
                return BadRequest("Email and password are required.");
            }

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
