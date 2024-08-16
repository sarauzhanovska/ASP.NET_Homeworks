
using BurgerApp.DataAccess;
using BurgerApp.DataAccess.EFImplementations;
using BurgerApp.DataAccess.Implementations;
using BurgerApp.DataAccess.Interfaces;
using BurgerApp.Domain;
using BurgerApp.Dtos.Dto;
using BurgerApp.Services.Interfaces;

namespace BurgerApp.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<Burger> _burgerRepository;

        public OrderService(IRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public List<OrderDto> GetAllOrders()
        {
            return _orderRepository.GetAll().Select(o => new OrderDto
            {
                Id = o.Id,
                FullName = o.FullName,
                Address = o.Address,
                IsDelivered = o.IsDelivered,
                BurgerIds = o.Burgers.Select(b => b.Id).ToList(),
                Location = o.Location
            }).ToList();
        }

        public OrderDto GetOrderById(int id)
        {
            var order = _orderRepository.GetById(id);
            if (order == null) return null;
            return new OrderDto
            {
                Id = order.Id,
                FullName = order.FullName,
                Address = order.Address,
                IsDelivered = order.IsDelivered,
                BurgerIds = order.Burgers.Select(b => b.Id).ToList(),
                Location = order.Location
            };
        }
        public void AddOrder(OrderDto orderDto)
        {
            var burgers = orderDto.BurgerIds
       .Select(id => _burgerRepository.GetById(id))
       .Where(b => b != null)
       .ToList();
            var order = new Order
            {
                FullName = orderDto.FullName,
                Address = orderDto.Address,
                IsDelivered = orderDto.IsDelivered,
                Burgers = burgers,
                Location = orderDto.Location
            };
           
            _orderRepository.Add(order);
        }

        public void UpdateOrder(OrderDto orderDto)
        {
            var burgers = orderDto.BurgerIds
        .Select(id => _burgerRepository.GetById(id))
        .Where(b => b != null)
        .ToList();
            var order = new Order
            {
                Id = orderDto.Id,
                FullName = orderDto.FullName,
                Address = orderDto.Address,
                IsDelivered = orderDto.IsDelivered,
                Burgers = burgers,
                Location = orderDto.Location
            };
            _orderRepository.Update(order);
        }
        public void DeleteOrder(int id)
        {
            _orderRepository.Delete(id);

        }
    }
}
