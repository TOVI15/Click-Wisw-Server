using ClickWise.Core.Entities;
using ClickWise.Core.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ClickWise.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DataContext dataContext) : base(dataContext) { }
        public async Task<User?> GetUserByName(string name , string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(e => e.Identity == name && e.Password == password);
            return user;

        }
        public async Task<User?> GetUserByEmail(string name)
        {
            var user = await _context.Users.FirstOrDefaultAsync(e => e.Email == name);
            return user;

        }
        public async Task<User?> GetByNationalIdAsync(string nationalId)
        {
            return await _context.Users.FirstOrDefaultAsync(e => e.Identity == nationalId);
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
