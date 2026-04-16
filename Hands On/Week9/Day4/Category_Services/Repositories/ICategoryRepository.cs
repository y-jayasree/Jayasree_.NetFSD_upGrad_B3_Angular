using WebApplication15.Models;

namespace WebApplication15.Repositories
{
    public interface ICategoryRepository
    {
        List<Category> GetAll();
        Category GetById(int id);
        void Add(Category contact);
        void Update(Category contact);
        void Delete(int id);
    }
}
