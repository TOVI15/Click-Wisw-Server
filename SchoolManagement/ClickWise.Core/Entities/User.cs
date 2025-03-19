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
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required, EmailAddress, MaxLength(100)]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        [Required]
        public string Role { get; set; } = "staff"; // "admin", "staff"

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpDateAt { get; set; } = DateTime.UtcNow;

        // קשר 1 לרבים לטבלת ההרשאות
        public ICollection<Permission> Permissions { get; set; } = new List<Permission>();

    }
}
