
using AutoMapper;
using ClickWise.Core.DTOs;
using ClickWise.Core.Entities;
using ClickWise.Core.Repositories;
using ClickWise.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickWise.Service
{
    public class DocumentService : IDocumentService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public DocumentService(IRepositoryManager repositoryManager, IMapper mapper)
        {          
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<bool> DeleteAsync(DocumentsDTO documentDto)
        {
            if (documentDto == null) return false;

            var document = _mapper.Map<Documents>(documentDto);
            if (document == null) return false;

            await _repositoryManager.Documents.DeleteAsync(document);
            await _repositoryManager.SaveAsync();
            return true;
        }

        public async Task<IEnumerable<DocumentsDTO>> GetAllAsync()
        {
            var documents = await _repositoryManager.Documents.GetAllAsync();
            return _mapper.Map<IEnumerable<DocumentsDTO>>(documents);
        }

        public async Task<DocumentsDTO?> GetByIdAsync(int id)
        {
            var document = await _repositoryManager.Documents.GetByIdAsync(id);
            return _mapper.Map<DocumentsDTO>(document);
        }

        public async Task<DocumentsDTO?> UploadAsync(int studentId, DocumentsDTO documentDto)
        {
            var documentToAdd = _mapper.Map<Documents>(documentDto);
            if (documentToAdd == null) return null;

            documentToAdd.StudentId = studentId;
            await _repositoryManager.Documents.AddAsync(documentToAdd);
            await _repositoryManager.SaveAsync();

            return _mapper.Map<DocumentsDTO>(documentToAdd);
        }
    }
}

