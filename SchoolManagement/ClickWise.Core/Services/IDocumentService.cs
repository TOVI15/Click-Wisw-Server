using ClickWise.Core.DTOs;
using ClickWise.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ClickWise.Core.Services
{
    public interface IDocumentService
    {
      public Task<IEnumerable<Folders>> GetAllAsync();
      public Task<Folders?> GetByIdAsync(int id);
      public Task<Folders?> UploadAsync(int id, Folders documentDto);
      public Task<bool> DeleteAsync(Folders documentDto);
      public Task<Folders?> AddAsync(string folder);
      public Task<Folders?> GetByStudentIdAsync(int studentId);
    }
}
