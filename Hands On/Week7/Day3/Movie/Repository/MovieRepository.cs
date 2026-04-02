using WebApplication3.Models;

namespace WebApplication3.Repository
{
    public class MovieRepository:IMovieRepository
    {
            private readonly AppDbContext _context;

            // constructor injection
            public MovieRepository(AppDbContext context)
            {
                _context = context;
            }

            public List<Movie> GetAll()
            {
                return _context.Movies.ToList();
            }

            public Movie GetById(int id)
            {
                return _context.Movies.FirstOrDefault(m => m.Id == id);
            }

            public void Add(Movie movie)
            {
                _context.Movies.Add(movie);
                _context.SaveChanges();
            }

            public void Update(Movie movie)
            {
                _context.Movies.Update(movie);
                _context.SaveChanges();
            }

            public void Delete(int id)
            {
                var movie = _context.Movies.Find(id);
                if (movie != null)
                {
                    _context.Movies.Remove(movie);
                    _context.SaveChanges();
                }
            }
        }
    }
