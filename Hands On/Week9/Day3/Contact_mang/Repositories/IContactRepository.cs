using WebApplication13.Models;

namespace WebApplication13.Repositories
{
    public interface IContactRepository
    {
        List<Contact> GetAll();
        Contact GetById(int id);
        void Add(Contact contact);
        void Update(Contact contact);
        void Delete(int id);

    }
}
