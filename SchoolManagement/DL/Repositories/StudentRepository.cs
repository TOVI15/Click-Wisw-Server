using ClickWise.Core.DTOs;
using ClickWise.Core.Entities;
using ClickWise.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
        public async Task<StudentBasicInfo?> GetByIdWithDetailsAsync(int id)
        {
            return await _context.Students
                .Include(s => s.AdditionalInfo)
                .FirstOrDefaultAsync(s => s.Id == id);
        }
        public async Task<IEnumerable<StudentBasicInfo?>> GetAllWithDetailsAsync()
        {
            var students = await _dbSet
            .Include(s => s.AdditionalInfo) 
            .ToListAsync();
            return students;
        }
        public async Task<IEnumerable<StudentBasicInfo>> GetAllAIAsync()
        {
            return await _dbSet
                .Include(s => s.AdditionalInfo)
                .ToListAsync();
        }
    }
}
