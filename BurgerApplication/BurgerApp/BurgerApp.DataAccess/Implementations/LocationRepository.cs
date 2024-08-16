using BurgerApp.DataAccess.Interfaces;
using BurgerApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.DataAccess.Implementations
{
    public class LocationRepository : IRepository<Location>
    {
        public IEnumerable<Location> GetAll()
        {
            return InMemoryDataBase.Locations;
        }

        public Location GetById(int id)
        {
            return InMemoryDataBase.Locations.FirstOrDefault(b => b.Id == id);
        }

        public void Add(Location entity)
        {
            entity.Id = InMemoryDataBase.Locations.Count + 1;
            InMemoryDataBase.Locations.Add(entity);
        }


        public void Update(Location entity)
        {
            var location = GetById(entity.Id);
            if (location != null)
            {
                var locationIndex = InMemoryDataBase.Locations.IndexOf(location);
                InMemoryDataBase.Locations[locationIndex] = entity;
            }
        }
        public void Delete(int id)
        {
                var location = GetById(id);
                if (location != null)
                {
                    InMemoryDataBase.Locations.Remove(location);
                }
            
        }
    }
}
