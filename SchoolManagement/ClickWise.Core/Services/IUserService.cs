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
      public Task<IEnumerable<UserDTO>> GetAllAsync();
      public Task<UserDTO> GetByIdAsync(int id);
      public Task<UserDTO> GetUserByName(string name);
      public Task<UserDTO?> AddAsync(UserDTO user);
      public Task<UserDTO?> UpdateAsync(int id, UserDTO user);
      public Task<bool> DeleteAsync(int id);
    }
}
