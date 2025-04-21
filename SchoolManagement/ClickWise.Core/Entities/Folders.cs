using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClickWise.Core.Entities
{
    public class Folders
    {
        [Key, ForeignKey("Student")]
        public int Id { get; set; } 

       
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        public int OwnerId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public StudentBasicInfo Student { get; set; }

        public ICollection<Documents> Files { get; set; } = new List<Documents>();

    }
}
