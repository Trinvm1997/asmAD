using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using asmAD.Models;

namespace asmAD.DAL
{
    public class ITSInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ITSContext>
    {
        protected override void Seed(ITSContext context)
        {
            var trainees = new List<Trainee>
            {
            new Trainee{TE_Name = "Tri", TE_Age = 21, TE_DOB = DateTime.Parse("1997-02-12"), TE_Education = "High School", TE_MainLang = "Vietnamese",
                TE_TOEIC = 0, EnrollmentDate = DateTime.Parse("2019-08-13")},
            new Trainee{TE_Name = "Hai", TE_Age = 20, TE_DOB = DateTime.Parse("1998-01-01"), TE_Education = "High School", TE_MainLang="Vietnamese",
                TE_TOEIC = 10, EnrollmentDate=DateTime.Parse("2019-08-13")},
            new Trainee{TE_Name = "Minh", TE_Age = 22, TE_DOB = DateTime.Parse("1996-01-01"), TE_Education = "High School", TE_MainLang="Vietnamese",
                TE_TOEIC = 20, EnrollmentDate=DateTime.Parse("2019-08-13")},
            };

            trainees.ForEach(s => context.Trainees.Add(s));
            context.SaveChanges();

            var courses = new List<Course>
            {
            new Course{CourseID = 0001, CourseName = "Programming", CourseDescription = "Basic Course",},
            new Course{CourseID = 0002, CourseName = "Networking", CourseDescription = "Basic Course",},
            new Course{CourseID = 0003, CourseName = "Database", CourseDescription = "Basic Course",},
            };
            courses.ForEach(s => context.Courses.Add(s));
            context.SaveChanges();

            var enrollments = new List<Enrollment>
            {
            new Enrollment{TraineeID=1,CourseID=0001},
            new Enrollment{TraineeID=2,CourseID=0001},
            new Enrollment{TraineeID=3,CourseID=0001},
            new Enrollment{TraineeID=1,CourseID=0002},
            new Enrollment{TraineeID=2,CourseID=0002},
            new Enrollment{TraineeID=3,CourseID=0002},
            new Enrollment{TraineeID=1,CourseID=0003},
            new Enrollment{TraineeID=2,CourseID=0003},
            new Enrollment{TraineeID=3,CourseID=0003},
            };
            enrollments.ForEach(s => context.Enrollments.Add(s));
            context.SaveChanges();
        }
    }
}