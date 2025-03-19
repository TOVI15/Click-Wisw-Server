using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickWise.Core.DTOs
{
    public class DocumentsDTO
    {
        public class DocumentDTO
        {
            public int Id { get; set; }
            public string DocumentType { get; set; } = string.Empty;
            public string FilePath { get; set; } = string.Empty;
            public DateTime CreatedAt { get; set; }
            public DateTime UpdatedAt { get; set; }
            public string StudentFullName { get; set; } = string.Empty.ToString();
        }

    }
}
