

using BurgerApp.Domain;

namespace BurgerApp.DataAccess
{
    public static class InMemoryDataBase
    {
        public static List<Burger> Burgers { get; set; }
        public static List<Order> Orders { get; set; }
        public static List<Location> Locations { get; set; }

        static InMemoryDataBase()
        {
            LoadBurgers();
            LoadOrders();
            LoadLocations();
        }

        private static void LoadBurgers()
        {
            Burgers = new List<Burger>()
            {
                new Burger {Id=1, Name= "Hamburger" },
                new Burger {Id=2, Name= "Chicken Burger"},
                new Burger {Id=3, Name = "Cheeseburger"},
                new Burger {Id=4, Name= "Vegan Burger"},
                new Burger {Id=5, Name= "Bacon Burger"}
            };
        }

        private static void LoadOrders()
        {
            Orders = new List<Order>()
            {
                new Order {
                    Id = 1,
                    FullName = "John Doe",
                    Address = "123 SK",
                    IsDelivered = false,
                    Location = "Location1",
                    Burgers = new List<Burger> { Burgers.First(b => b.Id == 1), Burgers.First(b => b.Id == 3) }
                },
                new Order {
                    Id = 2,
                    FullName = "Bob Bobsky",
                    Address = "123 BT",
                    IsDelivered = true,
                    Location = "Location2",
                    Burgers = new List<Burger> { Burgers.First(b => b.Id == 2), Burgers.First(b => b.Id == 4) }
                }
            };
        }
        private static void LoadLocations()
        {
            Locations = new List<Location>()
            {
            new Location
            {
                Id = 1,
                LocationName = "BurgerBitola",
                Address = "Bitola",
                OpensAt = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 9, 0, 0),
                ClosesAt = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 17, 0, 0)
            },
            new Location
            {
                Id = 2,
                LocationName = "BurgerSkopje",
                Address = "Skopje",
                OpensAt = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 9, 0, 0),
                ClosesAt = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 17, 0, 0)
            }
        };
        }
    }
}
