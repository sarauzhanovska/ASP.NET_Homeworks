

using BurgerApp.Domain;

namespace BurgerApp.Dtos.Dto
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public bool IsDelivered { get; set; }
        public string Location { get; set; }
        public List<int> BurgerIds { get; set; }
        //public List<BurgerDto> Burgers { get; set; }
    }
}
