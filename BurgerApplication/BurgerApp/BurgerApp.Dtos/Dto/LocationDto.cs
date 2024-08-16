

namespace BurgerApp.Dtos.Dto
{
    public class LocationDto
    {
        public int Id { get; set; }
        public string LocationName { get; set; }

        public string Address { get; set; }

        public DateTime OpensAt { get; set; }

        public DateTime ClosesAt { get; set; }
    }
}
