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

        // פרטי הורים
        public string FatherName { get; set; } = string.Empty;// שם האב
        public string FatherPhone { get; set; } = string.Empty; // פלאפון אב
        public string FatherCountryOfOrigin { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty; // אימייל 
        public string FatherOccupation { get; set; } = string.Empty; // תעסוקת האב
        public string MotherName { get; set; } = string.Empty;  // שם האם
        public string MotherPhone { get; set; } = string.Empty; // פלאפון אם
        public string MotherOccupation { get; set; } = string.Empty; // תעסוקת האם
        public string MotherCountryOfOrigin { get; set; } = string.Empty;
        public string MotherPreviousFamily { get; set; } = string.Empty;

        // מידע אקדמי
        public string PreviousSchool { get; set; } = string.Empty; // שם הישיבה הקודמת
        public string PreviousSchoolAddress { get; set; } = string.Empty; // כתובת הישיבה הקודמת
        public string PreviousSchoolCity { get; set; } = string.Empty; // עיר הישיבה הקודמת
        public string PreviousSchoolPhone { get; set; } = string.Empty; // טלפון הישיבה הקודמת
        public string PreviousSchoolFax { get; set; } = string.Empty; // פקס הישיבה הקודמת
        public string PreviousSchoolEmail { get; set; } = string.Empty;  // דוא"ל הישיבה הקודמת
        public int YearsOfStudy { get; set; }  // מספר שנות לימוד

        // פרטי ראש הישיבה
        public string RoshYeshivaName { get; set; } = string.Empty; // שם ראש הישיבה
        public string RoshYeshivaPhone { get; set; } = string.Empty;  // טלפון ראש הישיבה

        // מידע נוסף
        public string StudyTrack { get; set; } = string.Empty;  // מסלול הלימודים
        public string SynagogueName { get; set; } = string.Empty;  // שם בית המדרש/ר"מ
        public string SynagogueCity { get; set; } = string.Empty;  // עיר בית המדרש
        public string Notes { get; set; } = string.Empty; // הערות
     
    }
}
