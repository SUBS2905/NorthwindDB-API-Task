using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NorthWindDB_API.Models;
using NorthWindDB_API.Services;

namespace NorthWindDB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService _customerService;

        public CustomerController(CustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Customer>> GetAllCustomers()
        {
            return Ok(_customerService.GetAllCustomers());
        }

        [HttpGet("{id}")]
        public ActionResult<Customer> GetCustomerById(string id)
        {
            var customer = _customerService.GetCustomerById(id);
            if(customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpGet("{customerId}/orders")]
        public ActionResult<IEnumerable<OrderShipper>> GetOrderAndShipperById(string customerId)
        {
            var orderShipper = _customerService.GetOrderAndShipperById(customerId);
            if (orderShipper == null)
            {
                return NotFound();
            }
            return Ok(orderShipper);
        }
    }
}
