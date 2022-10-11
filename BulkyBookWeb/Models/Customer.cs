using System.ComponentModel.DataAnnotations;

namespace BulkyBookWeb.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string Phone { get; set; }

        public IEnumerable<CustomerProduct>? CustomerProducts { get; set; }

    }
}
