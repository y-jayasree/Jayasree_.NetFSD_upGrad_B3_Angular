using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }

        // Navigation Property
        public ICollection<ContactInfo> Contacts { get; set; }
    }
}
