using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using asmAD.DAL;
using asmAD.Models;
using PagedList;

namespace asmAD.Controllers
{
    public class TraineeController : Controller
    {
        private ITSContext db = new ITSContext();

        // GET: Trainee
        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.AgeSortParm = sortOrder == "Age" ? "age_desc" : "Age";
            ViewBag.EducationSortParm = sortOrder == "Education" ? "education_desc" : "Education";
            ViewBag.LangSortParm = sortOrder == "Lang" ? "lang_desc" : "Lang";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.DobSortParm1 = sortOrder == "Dob" ? "dob_desc" : "Dob";
            ViewBag.ScoreSortParm = sortOrder == "Score" ? "score_desc" : "Score";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var trainees = from s in db.Trainees
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                trainees = trainees.Where(s => s.TE_Name.Contains(searchString)
                                       || s.TE_TOEIC.ToString().Contains(searchString)
                                       || s.TE_MainLang.Contains(searchString)
                                       || s.TE_Age.ToString().Contains(searchString)
                                       || s.TE_Education.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    trainees = trainees.OrderByDescending(s => s.TE_Name);
                    break;
                case "Age":
                    trainees = trainees.OrderBy(s => s.TE_Age);
                    break;
                case "age_desc":
                    trainees = trainees.OrderByDescending(s => s.TE_Age);
                    break;
                case "Education":
                    trainees = trainees.OrderByDescending(s => s.TE_Education);
                    break;
                case "education_desc":
                    trainees = trainees.OrderByDescending(s => s.TE_Education);
                    break;
                case "Lang":
                    trainees = trainees.OrderByDescending(s => s.TE_MainLang);
                    break;
                case "lang_desc":
                    trainees = trainees.OrderByDescending(s => s.TE_MainLang);
                    break;
                case "Date":
                    trainees = trainees.OrderBy(s => s.EnrollmentDate);
                    break;
                case "date_desc":
                    trainees = trainees.OrderByDescending(s => s.EnrollmentDate);
                    break;
                case "Dob":
                    trainees = trainees.OrderBy(s => s.TE_DOB);
                    break;
                case "dob_desc":
                    trainees = trainees.OrderByDescending(s => s.TE_DOB);
                    break;
                case "Score":
                    trainees = trainees.OrderBy(s => s.TE_TOEIC);
                    break;
                case "score_desc":
                    trainees = trainees.OrderByDescending(s => s.TE_TOEIC);
                    break;
                default:
                    trainees = trainees.OrderBy(s => s.TE_Name);
                    break;
            }
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(trainees.ToPagedList(pageNumber, pageSize));
        }

        // GET: Trainee/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trainee trainee = db.Trainees.Find(id);
            if (trainee == null)
            {
                return HttpNotFound();
            }
            return View(trainee);
        }

        // GET: Trainee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Trainee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TE_Name,TE_Age,TE_DOB,TE_Education,TE_MainLang,TE_TOEIC,EnrollmentDate")]Trainee trainee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Trainees.Add(trainee);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(trainee);
        }

        // GET: Trainee/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trainee trainee = db.Trainees.Find(id);
            if (trainee == null)
            {
                return HttpNotFound();
            }
            return View(trainee);
        }

        // POST: Trainee/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var studentToUpdate = db.Trainees.Find(id);
            if (TryUpdateModel(studentToUpdate, "",
               new string[] { "TE_Name", "TE_Age", "TE_DOB", "TE_Education", "TE_MainLang", "TE_TOEIC", "EnrollmentDate" }))
            {
                try
                {
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (DataException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            return View(studentToUpdate);
        }

        // GET: Trainee/Delete/5
        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            Trainee trainee = db.Trainees.Find(id);
            if (trainee == null)
            {
                return HttpNotFound();
            }
            return View(trainee);
        }

        // POST: Trainee/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                Trainee traineeToDelete = new Trainee() { TraineeID = id };
                db.Entry(traineeToDelete).State = EntityState.Deleted;
                db.SaveChanges();
            }
            catch (DataException/* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
