using NorthWindDB_API.Models;
using NorthWindDB_API.Repository.Interfaces;

namespace NorthWindDB_API.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly string _connectionString;
        public OrderRepository(IConfiguration configuration) {
            _connectionString = configuration.GetConnectionString("Northwind");
        }
        public IEnumerable<Order> GetAllOrders()
        {
            throw new NotImplementedException();
        }

        public Order GetOrderById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
