using ClickWise.Core.Entities;
using ClickWise.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickWise.Data.Repositories
{
    public class DocumentsRepository : Repository<Documents>, IDocumentsRepository
    {
        public DocumentsRepository(DataContext dataContext) : base(dataContext){ }
    }
}
