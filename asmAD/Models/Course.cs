using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace asmAD.Models
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseID { get; set; }
        [Display(Name ="NAME")]
        public string CourseName { get; set; }
        [Display(Name = "DESCRIPTION")]
        public string CourseDescription { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}