using ClickWise.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickWise.Core.IRepositories
{
    public interface IUserRepository : IRepository<User>
    {
      public Task<User?> GetUserByName(string name, string password);
      public  Task<User?> GetUserByEmail(string name);
      public Task<bool> DeleteAsync(int id);
      public Task<User?> GetByNationalIdAsync(string nationalId);
    }
}
