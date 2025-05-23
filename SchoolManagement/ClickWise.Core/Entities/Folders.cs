using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ClickWise.Core.Entities
{
    public class Folders
    {
        [Key, ForeignKey("Student")]
        public int Id { get; set; }
        public StudentBasicInfo Student { get; set; }
    

        public string? Name { get; set; } = string.Empty;

        public string S3Key { get; set; }

        public string FilePath { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        

       
    }
}
