using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ClickWise.Core.Entities
{
    public class StudentBasicInfo
    {
        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string paymentMethod { get; set; } = string.Empty;
        public string? Kohen_Levi_Israel { get; set; } = string.Empty;
        public string IdentityNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string CountryOfBirth { get; set; } = string.Empty;
        public string BuildingNumber { get; set; } = string.Empty;

        public DateTime DateOfBirth { get; set; }
        public DateTime HebrewDateOfBirth { get; set; }
        public string HealthInsurance { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public StudentDetails AdditionalInfo { get; set; }
        public Folders Folders { get; set; }
    }
}
