
using BurgerApp.DataAccess.Interfaces;
using BurgerApp.Domain;

namespace BurgerApp.DataAccess.Implementations
{
    public class BurgerRepository : IRepository<Burger>
    {
        public IEnumerable<Burger> GetAll()
        {
            return InMemoryDataBase.Burgers;
        }

        public Burger GetById(int id)
        {
            return InMemoryDataBase.Burgers.FirstOrDefault(b => b.Id == id);
        }

        public void Add(Burger entity)
        {
            entity.Id = InMemoryDataBase.Burgers.Count + 1;
            InMemoryDataBase.Burgers.Add(entity);
        }

        public void Update(Burger entity)
        {
            var burger = GetById(entity.Id);
            if (burger != null)
            {
                var burgerIndex = InMemoryDataBase.Burgers.IndexOf(burger);
                InMemoryDataBase.Burgers[burgerIndex] = entity;
            }
        }

        public void Delete(int id)
        {
            var burger = GetById(id);
            if (burger != null)
            {
                InMemoryDataBase.Burgers.Remove(burger);
            }
        }
    }
}
