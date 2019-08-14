using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace asmAD.Models
{
    public class Trainee
    {
        public int TraineeID { get; set; }
        [Display(Name = "NAME")]
        public string TE_Name { get; set; }
        [Display(Name = "AGE")]
        public int TE_Age { get; set; }
        [Display(Name = "DATE OF BIRTH")]
        [DataType(DataType.Date)]
        public DateTime TE_DOB { get; set; }
        [Display(Name = "EDUCATION")]
        public string TE_Education { get; set; }
        [Display(Name = "MAIN LANGUAGE")]
        public string TE_MainLang { get; set; }
        [Display(Name = "TOEIC SCORE")]
        public int TE_TOEIC { get; set; }
        [Display(Name = "ENROLLMENT DATE")]
        [DataType(DataType.Date)]
        public DateTime EnrollmentDate { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}