using Microsoft.Extensions.Caching.Memory;
using WebApplication10.Models;
using WebApplication10.Repositories;

namespace WebApplication10.Services
{
    public class ContactService : IContactService  
    {
        private readonly IContactRepository _repository;
        private readonly IMemoryCache _cache;

        private const string CACHE_ALL_CONTACTS = "contacts_all";

        public ContactService(IContactRepository repository, IMemoryCache cache)
        {
            _repository = repository;
            _cache = cache;
        }

        public List<Contact> GetAllContacts()
        {
            if (_cache.TryGetValue(CACHE_ALL_CONTACTS, out List<Contact> cachedContacts))
            {
                return cachedContacts;
            }
            var contacts = _repository.GetAllContacts();

            _cache.Set(CACHE_ALL_CONTACTS, contacts, TimeSpan.FromSeconds(60));

            return contacts;
        }

        public Contact GetContactById(int id)
        {
            string cacheKey = $"contact_{id}";

            if (_cache.TryGetValue(cacheKey, out Contact cachedContact))
            {
                return cachedContact;
            }

            var contact = _repository.GetContactById(id);

            if (contact != null)
            {
                _cache.Set(cacheKey, contact, TimeSpan.FromSeconds(60));
            }

            return contact;
        }
    }
}
