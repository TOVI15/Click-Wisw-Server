using ClickWise.Core.Entities;
using ClickWise.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickWise.Data.Repositories
{
    public class StudentRepository : Repository<StudentBasicInfo>, IStudentRepository
    {
       public StudentRepository(DataContext dataContext):base(dataContext) { }

        public async Task<StudentBasicInfo?> GetStudentByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return null;
            }
            return await _dbSet.FirstOrDefaultAsync(student => student.FirstName == name);
        }
    }
}
