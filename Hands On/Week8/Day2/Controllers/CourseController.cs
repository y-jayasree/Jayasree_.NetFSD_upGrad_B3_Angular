using Microsoft.AspNetCore.Mvc;
using WebApplication5.Repository;

namespace WebApplication5.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseRepository _repo;

        public CourseController(ICourseRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            var data = _repo.GetAllCoursesWithStudents();
            return View(data);
        }
    }
}
