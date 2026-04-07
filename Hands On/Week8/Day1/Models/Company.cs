using System.ComponentModel.DataAnnotations;

namespace WebApplication5.Models
{
    public class Company
    {
        public int CompanyId { get; set; }
        [Required]
        public string CompanyName { get; set; }
    }
}
