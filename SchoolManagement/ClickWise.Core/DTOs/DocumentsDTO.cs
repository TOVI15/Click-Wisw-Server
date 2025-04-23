using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickWise.Core.DTOs
{
    public class DocumentsDTO
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string DocumentName { get; set; }
        public string S3Key { get; set; }
        public string FilePath { get; set; }
        public int FolderId { get; set; }
    }


}
