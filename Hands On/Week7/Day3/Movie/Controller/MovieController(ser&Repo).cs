using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;
using WebApplication3.Services;

namespace WebApplication3.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _service;

        public MoviesController(IMovieService service)
        {
            _service = service;
        }

        // GET: Movies
        public IActionResult Index()
        {
            var movies = _service.GetAllMovies();
            return View(movies);
        }

        // GET: Movies/Details/5
        public IActionResult Details(int id)
        {
            var movie = _service.GetMovieById(id);
            return View(movie);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _service.AddMovie(movie);
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Edit/5
        public IActionResult Edit(int id)
        {
            var movie = _service.GetMovieById(id);
            return View(movie);
        }

        // POST: Movies/Edit
        [HttpPost]
        public IActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _service.UpdateMovie(movie);
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        public IActionResult Delete(int id)
        {
            var movie = _service.GetMovieById(id);
            return View(movie);
        }

        // POST: Movies/Delete
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _service.DeleteMovie(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
