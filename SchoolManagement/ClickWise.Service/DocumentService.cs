
using AutoMapper;
using ClickWise.Core.DTOs;
using ClickWise.Core.Entities;
using ClickWise.Core.Repositories;
using ClickWise.Core.Services;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
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

        public async Task<Folders?> AddAsync(string S3Key)
        {

            var folder = new Folders
            {
                S3Key = S3Key, // FullName+UniqueKey
                FilePath = $"https://click-wise-testpnoren.s3.amazonaws.com/{S3Key}/",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            var createFolder = await _repositoryManager.Documents.AddAsync(folder);
            await _repositoryManager.SaveAsync();
            return createFolder;
        } 
        public async Task<bool> DeleteAsync(Folders document)
        {
            
            if (document == null) return false;

            await _repositoryManager.Documents.DeleteAsync(document);
            await _repositoryManager.SaveAsync();
            return true;
        }

        public async Task<IEnumerable<Folders>> GetAllAsync()
        {
            var documents = await _repositoryManager.Documents.GetAllAsync();
            return documents;
        }

        public async Task<Folders?> GetByIdAsync(int id)
        {
            var document = await _repositoryManager.Documents.GetByIdAsync(id);
            return document;
        }
        public async Task<Folders?> GetByStudentIdAsync(int studentId)
        {
            return await _repositoryManager.Documents.GetByStudentIdAsync(studentId);
        }
        public async Task<Folders?> UploadAsync(int studentId, Folders documentToAdd)
        {
            if (documentToAdd == null) return null;

            documentToAdd.Id = studentId;
            await _repositoryManager.Documents.AddAsync(documentToAdd);
            await _repositoryManager.SaveAsync();

            return documentToAdd;
        }
    }
}

