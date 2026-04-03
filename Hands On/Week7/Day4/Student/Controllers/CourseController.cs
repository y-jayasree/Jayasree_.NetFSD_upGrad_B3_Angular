using Microsoft.AspNetCore.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class CourseController : Controller
    {
        private readonly AppDbContext _context;

        public CourseController(AppDbContext context)
        {
            _context = context;
        }

        // Show Courses
        public IActionResult Index()
        {
            var courses = _context.Courses.ToList();
            return View(courses);
        }

        // Add Course
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }

}
