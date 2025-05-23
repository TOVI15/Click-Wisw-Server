using ClickWise.Core.DTOs;
using ClickWise.Core.Entities;
using ClickWise.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickWise.Core.Repositories
{
    public interface IStudentRepository : IRepository<StudentBasicInfo>
    {

        public Task<StudentBasicInfo?> GetStudentByName(string name);

        public Task<StudentBasicInfo?> GetByIdWithDetailsAsync(int id);
        public Task<IEnumerable<StudentBasicInfo?>> GetAllWithDetailsAsync();
        Task<IEnumerable<StudentBasicInfo>> GetAllAIAsync();

    }
}
