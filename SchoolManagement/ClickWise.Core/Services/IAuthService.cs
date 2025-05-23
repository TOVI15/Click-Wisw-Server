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
      public Task<LoginUser> LoginAsync(string identity, string password);
      public Task<LoginUser> RegisterAsync(UserDTO userDto);
      public Task<bool> ValidateUserAsync(string email, string password);
    }
}
