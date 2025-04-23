using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ClickWise.Core.Entities
{
    public class Documents
    {
        [Key]
        public int Id { get; set; }
        public int StudentId { get; set; }

        
        [Required]

        public string DocumentName { get; set; }
        [Required]
       
        public string S3Key { get; set; }
        public string FilePath { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        [ForeignKey("FolderId")]
        public Folders Folder { get; set; }
        public int FolderId { get; set; }
    }
}
