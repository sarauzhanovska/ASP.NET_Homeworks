using BurgerApp.DataAccess.Interfaces;
using BurgerApp.Domain;


namespace BurgerApp.DataAccess.Implementations
{
    public class OrderRepository : IRepository<Order>
    {


        public IEnumerable<Order> GetAll()
        {
            return InMemoryDataBase.Orders;
        }

        public Order GetById(int id)
        {
            return InMemoryDataBase.Orders.FirstOrDefault(o => o.Id == id);
        }
        public void Add(Order entity)
        {
            entity.Id = InMemoryDataBase.Orders.Count + 1;
            InMemoryDataBase.Orders.Add(entity);
        }

        public void Update(Order entity)
        {
             var order  = GetById(entity.Id);
            if(order != null)
            {
                var orderIndex = InMemoryDataBase.Orders.IndexOf(order);
                InMemoryDataBase.Orders[orderIndex] = entity;
            }
        }
        public void Delete(int id)
        {
            var order = GetById(id);
            if(order != null)
            {
                InMemoryDataBase.Orders.Remove(order);
            }
        }
    }
}
