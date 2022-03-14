using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolExample.Data;
using SchoolExample.Models;

namespace SchoolExample.Controllers
{
    public class CourseController : Controller
    {
        private ApplicationDbContext _db;
        public CourseController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: CourseController
        public ActionResult Index()
        {
            List<Course> courses =  _db.Courses.ToList();
            return View(courses);
        }

        // GET: CourseController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CourseController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CourseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Title, AverageGrade")] Course newCourse)
        {
            if(ModelState.IsValid)
            {
                _db.Courses.Add(newCourse);
                _db.SaveChanges();
                return RedirectToAction("Index");
            } else
            {
                return BadRequest();
            }
        }

        // GET: CourseController/Edit/5
        public ActionResult Edit(int id)
        {
            Course course = _db.Courses.Find(id);

            if(course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string Title, int Id)
        {
            Course course = _db.Courses.First(c => c.Id == Id);
            course.Title = Title;
            _db.Update(course);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: CourseController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CourseController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
