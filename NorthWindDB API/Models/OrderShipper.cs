namespace NorthWindDB_API.Models
{
    public class OrderShipper
    {
        public string CustomerID { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string ContactName { get; set; }
        public int OrderID { get; set; }
        public string OrderDate { get; set; }
        public int ShipVia { get; set; }
        public string ShipperName { get; set; }
        public string Phone { get; set; }
        public string ShipAddress { get; set; }
        public string ShipName { get; set; }
    }
}
