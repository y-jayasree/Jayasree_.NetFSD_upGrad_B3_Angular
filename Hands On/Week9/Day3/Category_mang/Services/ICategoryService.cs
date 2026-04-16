using WebApplication15.Models;

namespace WebApplication15.Services
{
    public interface ICategoryService
    {
        List<Category> GetAll();
        Category GetById(int id);
        void Add(Category contact);
        void Update(Category contact);
        void Delete(int id);
    }
}
