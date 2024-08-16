

using System.ComponentModel.DataAnnotations;

namespace BurgerApp.Domain
{
   
    public class Order : BaseEntity
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Address { get; set; }
        public string Location { get; set; }
        public bool IsDelivered { get; set; }

        public List<Burger> Burgers { get; set; } = new List<Burger>();
   

    }
}
