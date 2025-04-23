using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickWise.Core.Entities
{
    public class StudentDetails
    {

        [Key, ForeignKey("BasicInfo")]
        public int Id { get; set; }

        public StudentBasicInfo BasicInfo { get; set; }

        public string FatherName { get; set; } = string.Empty;
        public string FatherPhone { get; set; } = string.Empty;
        public string FatherCountryOfOrigin { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string FatherOccupation { get; set; } = string.Empty;
        public string MotherName { get; set; } = string.Empty;
        public string MotherPhone { get; set; } = string.Empty;
        public string MotherOccupation { get; set; } = string.Empty;
        public string MotherCountryOfOrigin { get; set; } = string.Empty;
        public string MotherPreviousFamily { get; set; } = string.Empty;
        public string PreviousSchool { get; set; } = string.Empty;
        public string PreviousSchoolAddress { get; set; } = string.Empty;
        public string PreviousSchoolCity { get; set; } = string.Empty;
        public string PreviousSchoolPhone { get; set; } = string.Empty;
        public string PreviousSchoolFax { get; set; } = string.Empty;
        public string PreviousSchoolEmail { get; set; } = string.Empty;
        public int YearsOfStudy { get; set; }
        public string RoshYeshivaName { get; set; } = string.Empty;
        public string RoshYeshivaPhone { get; set; } = string.Empty;
        public string StudyTrack { get; set; } = string.Empty;
        public string SynagogueName { get; set; } = string.Empty;
        public string SynagogueCity { get; set; } = string.Empty;
        public string? Notes { get; set; } = string.Empty;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
