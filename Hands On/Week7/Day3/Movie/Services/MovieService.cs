using WebApplication3.Models;
using WebApplication3.Repository;

namespace WebApplication3.Services
{
    public class MovieService:IMovieService
    {
        private readonly IMovieRepository _repo;

        public MovieService(IMovieRepository repo)
        {
            _repo = repo;
        }

        public List<Movie> GetAllMovies()
        {
            return _repo.GetAll();
        }

        public Movie GetMovieById(int id)
        {
            return _repo.GetById(id);
        }

        public void AddMovie(Movie movie)
        {
            _repo.Add(movie);
        }

        public void UpdateMovie(Movie movie)
        {
            _repo.Update(movie);
        }

        public void DeleteMovie(int id)
        {
            _repo.Delete(id);
        }
    }
}

