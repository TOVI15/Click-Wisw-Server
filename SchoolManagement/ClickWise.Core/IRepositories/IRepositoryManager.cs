using ClickWise.Core.Entities;
using ClickWise.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickWise.Core.Repositories
{
    public interface IRepositoryManager
    {
       IStudentRepository Student { get; }

       IDocumentsRepository Documents { get; }

        IUserRepository User { get; }

        public Task SaveAsync();
    }
}
