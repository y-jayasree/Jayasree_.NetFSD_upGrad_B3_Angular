using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    public class FeedbackController : Controller
    {
        [HttpGet]
        [Route("feedback/index")]
        public IActionResult Index()
        {
            return View();
        }

        // POST
        [HttpPost]
        [Route("feedback/index")]
        public IActionResult Index(string name, string comments, int rating)
        {
            if (rating >= 4)
            {
                ViewData["Message"] = "Thank You for your feedback!";
            }
            else
            {
                ViewData["Message"] = "We will improve based on your feedback.";
            }

            return View();
        }
    }
}

