using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NorthWindDB_API.Models;
using NorthWindDB_API.Services;

namespace NorthWindDB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipperController : ControllerBase
    {
        private ShipperService _shipperService;
        public ShipperController(ShipperService shipperService) {
            _shipperService = shipperService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Shipper>> GetAllShippers() {
            return Ok(_shipperService.GetAllShippers());
        }

        [HttpGet("{id}")]
        public ActionResult<Shipper> GetShipperById(int id)
        {
            return Ok(_shipperService.GetShipperById(id));
        }

        [HttpPost]
        public ActionResult<Shipper> AddShipper([FromBody] Shipper shipper)
        { 
            return Ok(_shipperService.AddShipper(shipper));
        }

        //Conflicting because it is a FK
        [HttpDelete]
        public ActionResult<int> DeleteShipperById(int id)
        {
            return Ok(_shipperService.DeleteShipperById(id));
        } 
    }
}
