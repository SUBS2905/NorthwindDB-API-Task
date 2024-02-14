using NorthWindDB_API.Models;
using NorthWindDB_API.Repository;
using NorthWindDB_API.Repository.Interfaces;
using NorthWindDB_API.Services.Interfaces;

namespace NorthWindDB_API.Services
{
    public class ShipperService: IShipperService
    {
        private readonly IShipperRepository _shipperRepository;
        public ShipperService(IShipperRepository shipperRepository) { 
            _shipperRepository = shipperRepository;
        }

        public IEnumerable<Shipper> GetAllShippers()
        {
            return _shipperRepository.GetAllShippers();
        }

        public Shipper GetShipperById(int id)
        {
            return _shipperRepository.GetShipperById(id);
        }

        public Shipper AddShipper(Shipper shipper)
        {
            return _shipperRepository.AddShipper(shipper);
        }

        public int DeleteShipperById(int id)
        {
            return _shipperRepository.DeleteShipperById(id);
        }

    }
}
