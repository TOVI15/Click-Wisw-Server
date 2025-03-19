using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickWise.Core.Entities
{
    public class Documents
    {
        public int Id { get; set; }
       public int StudentId { get; set; }

        [Required]
        public string DocumentType { get; set; } = string.Empty; // "passport", "id_card"

        [Required]
        public string FilePath { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public StudentBasicInfo Student { get; set; }
    }
}
