using ClickWise.Core.DTOs;
using ClickWise.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickWise.Core.Services
{
    public interface IUserService
    {
      public Task<IEnumerable<User>> GetAllAsync();
      public Task<User> GetByIdAsync(int id);
      public Task<User> GetUserByName(string name);
      public  Task AddAsync(UserDTO user);
      public Task<User?> UpdateAsync(int id, UserDTO user);
      public  Task<bool> DeleteAsync(int id);
      public  Task<User> ResetPasswordAsync(User user, string token, string newPassword);
    }
}
