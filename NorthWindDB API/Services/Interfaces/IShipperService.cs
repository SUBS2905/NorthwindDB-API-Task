using NorthWindDB_API.Models;

namespace NorthWindDB_API.Services.Interfaces
{
    public interface IShipperService
    {
        public IEnumerable<Shipper> GetAllShippers()
        {
            throw new NotImplementedException();
        }
        public Shipper GetShipperById(int id)
        {
            throw new NotImplementedException();
        }

        public Shipper AddShipper(Shipper shipper)
        {
            throw new NotImplementedException();
        }

        public int DeleteShipperById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
