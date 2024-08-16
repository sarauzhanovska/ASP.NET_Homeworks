

using BurgerApp.Domain;
using Microsoft.EntityFrameworkCore;

namespace BurgerApp.DataAccess
{
    public class BurgerAppDbContext : DbContext
    {
        public DbSet<Order> Order { get; set; }
        public DbSet<Burger> Burger { get; set; }
        public DbSet<Location> Location { get; set; }


        public BurgerAppDbContext(DbContextOptions<BurgerAppDbContext> options) : base(options) 
        { 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Burger>()
                .Property(b => b.Price)
                .HasColumnType("decimal(18,2)");


            modelBuilder.Entity<Burger>().HasData(
    new Burger { Id = 1, Name = "Hamburger", HasFries = true, IsVegan = false, IsVegetarian = false, Price = 8 },
    new Burger { Id = 2, Name = "Chicken Burger", HasFries = false, IsVegan = true, IsVegetarian = true, Price = 9 },

    new Burger { Id = 5, Name = "Bacon Burger", HasFries = true, IsVegan = true, IsVegetarian = true, Price = 8 }
);



            modelBuilder.Entity<Order>().HasData(
                new Order { Id = 1, FullName = "John Doe", Address = "123 SK", IsDelivered = false, Location = "Location1" },
                new Order { Id = 6, FullName = "Bob Bobsky", Address = "123 BT", IsDelivered = true, Location = "Location2" }
            );

            modelBuilder.Entity<Location>().HasData(
                 new Location { Id = 1, LocationName ="BurgerBitola",Address="Bitola", OpensAt = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 9, 0, 0), ClosesAt = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 5, 0, 0) },
                  new Location { Id = 2, LocationName = "BurgerSkopje", Address = "Skopje", OpensAt = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 9, 0, 0), ClosesAt = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 5, 0, 0) }
           );

            base.OnModelCreating(modelBuilder);
        }


    }
}
