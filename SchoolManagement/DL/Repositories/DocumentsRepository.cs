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
    public class DocumentsRepository : Repository<Folders>, IDocumentsRepository
    {
        public DocumentsRepository(DataContext dataContext) : base(dataContext){ }
        public async Task<Folders?> GetByS3KeyAsync(string s3Key)
        {
            return await _context.Documents.FirstOrDefaultAsync(f => f.S3Key == s3Key);
        }
        public async Task<Folders?> GetByStudentIdAsync(int studentId)
        {
            return await _dbSet.FirstOrDefaultAsync(f => f.Id == studentId);
        }
    }
}
