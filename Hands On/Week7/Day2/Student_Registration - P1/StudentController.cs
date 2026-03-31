using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        [Route("student/register")]
        public IActionResult Register()
        {
            return View();
        }

        // POST 
        [HttpPost]
        [Route("student/register")]
        public IActionResult Register(string name, int age, string course)
        {
            // Store data using ViewBag
            ViewBag.Name = name;
            ViewBag.Age = age;
            ViewBag.Course = course;

            return RedirectToAction("Display", new
            {
                name = name,
                age = age,
                course = course
            });
        }

        [HttpGet]
        [Route("student/display")]
        public IActionResult Display(string name, int age, string course)
        {
            // receive and store again in viewbag
            ViewBag.Name = name;
            ViewBag.Age = age;
            ViewBag.Course = course;

            return View();
        }
    }
}
