using WebApplication15.Models;
using WebApplication15.Repositories;

namespace WebApplication15.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repo;

        public CategoryService(ICategoryRepository repo)
        {
            _repo = repo;
        }

        public List<Category> GetAll() => _repo.GetAll();

        public Category GetById(int id) => _repo.GetById(id);

        public void Add(Category contact) => _repo.Add(contact);

        public void Update(Category contact) => _repo.Update(contact);

        public void Delete(int id) => _repo.Delete(id);
    }
}



