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
      public Task<IEnumerable<DocumentsDTO>> GetAllAsync();
      public Task<DocumentsDTO?> GetByIdAsync(int id);
      public Task<DocumentsDTO?> UploadAsync(int id, DocumentsDTO documentDto);
      public Task<bool> DeleteAsync(DocumentsDTO documentDto);
    }
}
