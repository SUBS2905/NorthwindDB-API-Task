using NorthWindDB_API.Models;

namespace NorthWindDB_API.Services.Interfaces
{
    public interface ICustomerService
    {
        public IEnumerable<Customer> GetAllCustomers()
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomerById(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderShipper> GetOrderAndShipperById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
