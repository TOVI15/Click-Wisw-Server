using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace ClickWise.Core.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
        public string Identity { get; set; } = string.Empty;

        public string? Password { get; set; } = string.Empty;
        public string? Address { get; set; } = string.Empty;
        public string? Phone { get; set; } = string.Empty;

        public string Role { get; set; } = string.Empty;
        public bool IsActive { get; set; } 
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpDatedAt { get; set; } = DateTime.Now;
    }
}