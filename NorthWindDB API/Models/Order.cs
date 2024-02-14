namespace NorthWindDB_API.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public Customer CustomerDetails { get; set; }
        public Employee EmployeeDetails { get; set; }
        public string OrderDate { get; set; }
        public string RequiredDate { get; set; }
        public string ShippedDate { get; set;}
        public Shipper ShipperDetails { get; set; }
        public float Freight { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipRegion { get; set; }
        public string ShipPostalCode { get; set;}
        public string ShipCountry { get; set; }

    }
}
