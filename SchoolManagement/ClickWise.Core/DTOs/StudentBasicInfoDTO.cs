using ClickWise.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickWise.Core.DTOs
{
    public class StudentBasicInfoDTO
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? PaymentMethod { get; set; } = string.Empty;
        public string? Kohen_Levi_Israel { get; set; } = string.Empty;
        public string? IdentityNumber { get; set; } = string.Empty;
        public string? Address { get; set; } = string.Empty;
        public string? City { get; set; } = string.Empty;
        public string? Phone { get; set; } = string.Empty;
        public string? CountryOfBirth { get; set; } = string.Empty;
        public string? BuildingNumber { get; set; } = string.Empty;
        public string? folderKey { get; set; } = string.Empty;
        public bool? RegisterStudent { get; set; } = false;
        public int? GroupId { get; set; } = 0;

        //public DateTime? DateOfBirth { get; set; } 
        //public DateTime? HebrewDateOfBirth { get; set; }
        public string? HealthInsurance { get; set; } = string.Empty;

        public StudentDetailsDTO AdditionalInfo { get; set; } = new StudentDetailsDTO();
    }
}
