using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace asmAD.Models
{
    public class Enrollment
    {
            public int EnrollmentID { get; set; }
            public int CourseID { get; set; }
            public int TraineeID { get; set; }


            public virtual Course Course { get; set; }
            public virtual Trainee Trainee { get; set; }
    }
}