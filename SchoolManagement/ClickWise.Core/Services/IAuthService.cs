using ClickWise.Core.DTOs;
using ClickWise.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickWise.Core.Services
{
    public interface IAuthService
    {
      public Task<LoginDTO> LoginAsync(string email, string password);
      public Task<LoginDTO> RegisterAsync(UserDTO userDto);
      public Task<bool> ValidateUserAsync(string email, string password);
    }
}
