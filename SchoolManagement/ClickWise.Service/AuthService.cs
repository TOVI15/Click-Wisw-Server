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

        public async Task<LoginUser> LoginAsync(string identity, string password)
        {
            if (await ValidateUserAsync(identity, password))
            {
                var user = await _repositoryManager.User.GetUserByName(identity, password);
                if (user == null)
                    return null;

                var token = GenerateJwtToken(user); return new LoginUser
                {
                    FullName = user.Name,
                    Token = token
                };
            }
            return null;
        }

        public async Task<LoginUser> RegisterAsync(UserDTO userDto)
        {
            var currentUser = await _repositoryManager.User.GetUserByName(userDto.Name , userDto.Email);
            if (currentUser != null)
            {
                return null;
            }

            var user = new User
            {
                Name = userDto.Name,
                Identity = userDto.Identity,
                //PasswordHash =userDto.PasswordHash,
                //BCrypt.Net.BCrypt.HashPassword(userDto.Password),
                CreatedAt = DateTime.UtcNow,
                UpDatedAt = DateTime.UtcNow,
                Role = "staff",
            };

            var result = await _repositoryManager.User.AddAsync(user);
            if (result == null)
            {
                return null;
            }

            await _repositoryManager.SaveAsync();

            var token = GenerateJwtToken(result);
            var resultUserDto = _mapper.Map<UserDTO>(result);

            return new LoginUser
            {
                //User = resultUserDto,
                Token = token
            };
        }   

        public async Task<bool> ValidateUserAsync(string identity, string password)
        {
            User user = await _repositoryManager.User.GetUserByName(identity, password);
            return user != null;
        }

        protected string GenerateJwtToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
              new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
              new Claim(ClaimTypes.Name, user.Name),
              new Claim(ClaimTypes.Role, user.Role)
            };

            //foreach (var role in user.Role)
            //{
            //    claims.Add(new Claim(ClaimTypes.Role, role.ToString()));
            //}
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