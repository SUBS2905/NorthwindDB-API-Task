using NorthWindDB_API.Models;

namespace NorthWindDB_API.Repository.Interfaces
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAllOrders();
        Order GetOrderById(int id);
    }
}
