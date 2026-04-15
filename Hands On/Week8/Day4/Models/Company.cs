using System.ComponentModel.DataAnnotations;

namespace WebApplication6.Models
{
    public class Company
    {
        public int CompanyId { get; set; }

        [Required, StringLength(100),MinLength(2)]
        public string CompanyName { get; set; }

        public ICollection<ContactInfo> Contacts { get; set; }
    }
}
