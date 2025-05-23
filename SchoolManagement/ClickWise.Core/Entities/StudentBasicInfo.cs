using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ClickWise.Core.Entities
{
    public class StudentBasicInfo
    {
        [Key]
        public int Id { get; set; }

        public string? FirstName { get; set; } 
        public string? LastName { get; set; } 
        public string? paymentMethod { get; set; } 
        public string? Kohen_Levi_Israel { get; set; }
        public string? IdentityNumber { get; set; } 
        public string? Address { get; set; } 
        public string? City { get; set; }
        public string? Phone { get; set; } 
        public string? CountryOfBirth { get; set; } 
        public string? BuildingNumber { get; set; }
        public string? folderKey { get; set; }
        public bool? RegisterStudent { get; set; }

        public int? GroupId { get; set; }

        public DateTime DateOfBirth { get; set; }
        public DateTime HebrewDateOfBirth { get; set; }
        public string HealthInsurance { get; set; } 

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        //public Folders Folders { get; set; }
        public StudentDetails AdditionalInfo { get; set; }
        
    }
}
