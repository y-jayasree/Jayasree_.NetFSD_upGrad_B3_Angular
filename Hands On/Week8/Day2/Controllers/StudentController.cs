using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication5.Models;
using WebApplication5.Repository;

namespace WebApplication5.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository _repo;
        private readonly ICourseRepository _courseRepo;

        public StudentController(IStudentRepository repo, ICourseRepository courseRepo)
        {
            _repo = repo;
            _courseRepo = courseRepo;
        }

        public IActionResult Index()
        {
            var data = _repo.GetStudentsWithCourse();
            return View(data);
        }

        public IActionResult Create()
        {
            ViewBag.Courses = new SelectList(_courseRepo.GetCourses(), "CourseId", "CourseName");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Courses = new SelectList(
                    _courseRepo.GetCourses(),
                    "CourseId",
                    "CourseName"
                );

                return View(student);
            }

            _repo.AddStudent(student);
            return RedirectToAction("Index");
        }

    }
}

