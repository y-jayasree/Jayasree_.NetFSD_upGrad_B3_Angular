using WebApplication15.Models;
using WebApplication15.Data;

namespace WebApplication15.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CategoryDbContext _context;

        public CategoryRepository(CategoryDbContext context)
        {
            _context = context;
        }

        public List<Category> GetAll()
        {
            return _context.Categories.ToList();
        }

        public Category GetById(int id)
        {
            return _context.Categories.Find(id);
        }

        public void Add(Category contact)
        {
            _context.Categories.Add(contact);
            _context.SaveChanges();
        }

        public void Update(Category contact)
        {
            _context.Categories.Update(contact);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var contact = _context.Categories.Find(id);
            if (contact != null)
            {
                _context.Categories.Remove(contact);
                _context.SaveChanges();
            }
        }
    }
}

