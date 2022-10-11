
using System.ComponentModel.DataAnnotations;

namespace BulkyBookWeb.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Quantity { get; set; }
        
        // relationships
        public ICollection<CustomerProduct>? CustomerProducts { get; set; }
    }
}