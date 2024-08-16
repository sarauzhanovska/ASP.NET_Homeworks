
using BurgerApp.DataAccess.Interfaces;
using BurgerApp.Domain;

namespace BurgerApp.DataAccess.EFImplementations
{
    public class EFLocationRepository : IRepository<Location>
    {
        private readonly BurgerAppDbContext _context;

        public EFLocationRepository(BurgerAppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Location> GetAll()
        {
            return _context.Location.ToList();
        }

        public Location GetById(int id)
        {
            return _context.Location.FirstOrDefault(s => s.Id == id);

        }

        public void Add(Location entity)
        {
            _context.Location.Add(entity);
            _context.SaveChanges();
        }


        public void Update(Location entity)
        {
            _context.Location.Update(entity);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var location = _context.Location.FirstOrDefault(o => o.Id == id);
            if (location != null)
            {
                _context.Location.Remove(location);
                _context.SaveChanges();
            }
        }
    }
}
