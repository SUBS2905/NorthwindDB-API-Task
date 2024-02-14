using NorthWindDB_API.Models;
using NorthWindDB_API.Repository.Interfaces;
using NorthWindDB_API.Services.Interfaces;

namespace NorthWindDB_API.Services
{
    public class CustomerService: ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _customerRepository.GetAllCustomers();
        }

        public Customer GetCustomerById(string id)
        {
            return _customerRepository.GetCustomerById(id);
        }

        public IEnumerable<OrderShipper> GetOrderAndShipperById(string id)
        {
            return _customerRepository.GetOrderAndShipperById(id);
        }

    }
}
