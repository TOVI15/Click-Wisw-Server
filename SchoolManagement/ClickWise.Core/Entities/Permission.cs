using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickWise.Core.Entities
{
    public class Permission
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        [Required]
        public string PermissionType { get; set; } = string.Empty; // "view_students", "edit_students", "delete_students"

        public DateTime GrantedAt { get; set; } = DateTime.UtcNow;

        // קשר חזרה למשתמש
        public User User { get; set; } = null!;
    }

}
