using ClickWise.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ClickWise.Core.IRepositories
{
    public interface IDocumentsRepository : IRepository<Folders>
    {
        public Task<Folders?> GetByS3KeyAsync(string s3Key);
        public Task<Folders?> GetByStudentIdAsync(int studentId);
    }
}
