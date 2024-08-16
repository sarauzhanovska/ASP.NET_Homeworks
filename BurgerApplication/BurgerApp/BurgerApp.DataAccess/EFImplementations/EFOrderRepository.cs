

using BurgerApp.DataAccess.Interfaces;
using BurgerApp.Domain;

namespace BurgerApp.DataAccess.EFImplementations
{
    public class EFOrderRepository : IRepository<Order>
    {
        private readonly BurgerAppDbContext _context;

        public EFOrderRepository(BurgerAppDbContext context) 
        { 
        _context = context;
        }

        public IEnumerable<Order> GetAll()
        {
            return _context.Order.ToList();
        }

        public Order GetById(int id)
        {
            return _context.Order.FirstOrDefault(s => s.Id == id);

        }

        public void Add(Order entity)
        {
            _context.Order.Add(entity);
            _context.SaveChanges();
        }


        public void Update(Order entity)
        {
            _context.Order.Update(entity);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var order = _context.Order.FirstOrDefault(o => o.Id == id);
            if (order != null)
            {
                _context.Order.Remove(order);
                _context.SaveChanges();
            }
        }
    }

    }

