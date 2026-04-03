using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class StudentController : Controller
    {
        private readonly AppDbContext _context;

        public StudentController(AppDbContext context)
        {
            _context = context;
        }

        // Show Students
        public IActionResult Index()
        {
            var students = _context.Students
                            .Include(s => s.Course)
                            .ToList();

            return View(students);
        }

        // Create std
        public IActionResult Create()
        {
            ViewBag.Courses = new SelectList(_context.Courses, "CourseId", "CourseName");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Courses = new SelectList(_context.Courses, "CourseId", "CourseName");
                return View(student);
            }

            _context.Students.Add(student);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
