
using BurgerApp.Dtos.Dto;

namespace BurgerApp.Services.Interfaces
{
    public interface IOrderService
    {
        List<OrderDto> GetAllOrders();
        OrderDto GetOrderById(int id);
        void AddOrder(OrderDto order);
        void UpdateOrder(OrderDto order);
        void DeleteOrder(int id);
    }
}
