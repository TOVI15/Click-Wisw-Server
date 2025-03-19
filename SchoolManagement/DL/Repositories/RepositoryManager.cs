using ClickWise.Core.Entities;
using ClickWise.Core.IRepositories;
using ClickWise.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ClickWise.Data.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly DataContext _dataContext;

        public IStudentRepository StudentRepository { get; }

        public IDocumentsRepository DocumentsRepository { get; }

        public IUserRepository UserRepository { get; }

        public IStudentRepository Student => StudentRepository;

        public IDocumentsRepository Documents => DocumentsRepository;

        public IUserRepository User => UserRepository;

        public RepositoryManager(DataContext dataContext,
            IStudentRepository studentRepository,
            IDocumentsRepository documentsRepository,
            IUserRepository userRepository)
        {
            _dataContext = dataContext;
            StudentRepository = studentRepository;
            DocumentsRepository = documentsRepository;
            UserRepository = userRepository;
        }

        public async Task SaveAsync()
        {
            await _dataContext.SaveChangesAsync();
        }
    }
}
