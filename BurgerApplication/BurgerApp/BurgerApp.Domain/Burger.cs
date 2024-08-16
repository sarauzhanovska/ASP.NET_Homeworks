
using System.ComponentModel.DataAnnotations;

namespace BurgerApp.Domain
{
    public class Burger : BaseEntity
    {

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        public bool IsVegetarian { get; set; }

        public bool IsVegan { get; set; }

        public bool HasFries { get; set; }
       
        public ICollection<Order> Orders { get; set; }

    }
}
