using AutoMapper;
using ClickWise.Core.DTOs;
using ClickWise.Core.Entities;
using ClickWise.Core.Repositories;
using ClickWise.Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ClickWise.Service
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public AuthService(IConfiguration configuration, IRepositoryManager repositoryManager, IMapper mapper)
        {
            _configuration = configuration;
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<LoginDTO> LoginAsync(string email, string password)
        {
            if (await ValidateUserAsync(email, password))
            {
                var user = await _repositoryManager.User.GetUserByName(email);
                var token = GenerateJwtToken(user);
                var userDTO = _mapper.Map<UserDTO>(user);
                return new LoginDTO
                {
                    User = userDTO,
                    Token = token
                };
            }
            return null;
        }

        public async Task<LoginDTO> RegisterAsync(UserDTO userDto)
        {
            var currentUser = await _repositoryManager.User.GetUserByName(userDto.Name);
            if (currentUser != null)
            {
                return null;
            }

            var user = new User
            {
                Name = userDto.Name,
                Email = userDto.Identity,
                //PasswordHash =userDto.PasswordHash,
                //BCrypt.Net.BCrypt.HashPassword(userDto.Password),
                //CreatedAt = DateTime.UtcNow,
                //UpDateAt = DateTime.UtcNow,
                Role = "Editor",
            };

            var result = await _repositoryManager.User.AddAsync(user);
            if (result == null)
            {
                return null;
            }

            await _repositoryManager.SaveAsync();

            var token = GenerateJwtToken(result);
            var resultUserDto = _mapper.Map<UserDTO>(result);

            return new LoginDTO
            {
                User = resultUserDto,
                Token = token
            };
        }   

        public async Task<bool> ValidateUserAsync(string email, string password)
        {
            User user = await _repositoryManager.User.GetUserByName(email);
            return user != null;
                //&& BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);
        }

        protected string GenerateJwtToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
              new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
              new Claim(ClaimTypes.Email, user.Email), 
            };

            // הוספת תפקידים כ-Claims
            foreach (var role in user.Role)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.ToString()));
            }
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }



}

