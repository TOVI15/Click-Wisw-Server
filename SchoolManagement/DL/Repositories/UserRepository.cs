using ClickWise.Core.Entities;
using ClickWise.Core.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickWise.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {

        public UserRepository(DataContext dataContext): base(dataContext) { }

        public async Task<User?> GetUserByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return null;
            }
            return await _dbSet.FirstOrDefaultAsync(user => user.Name == name);
        }
    }
}
