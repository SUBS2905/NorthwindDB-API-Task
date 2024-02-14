using NorthWindDB_API.Models;
using NorthWindDB_API.Repository.Interfaces;
using System.Data.SqlClient;

namespace NorthWindDB_API.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly string _connectionString;

        public CustomerRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Northwind");
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            var customers = new List<Customer>();
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand("showAllCustomerDetails", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            customers.Add(new Customer
                            {
                                CustomerId = reader["CustomerID"].ToString(),
                                CompanyName = reader["CompanyName"].ToString(),
                                ContactName = reader["ContactName"].ToString(),
                                ContactTitle = reader["ContactTitle"].ToString(),
                                Address = reader["Address"].ToString(),
                                City = reader["City"].ToString(),
                                Region = reader["Region"].ToString(),
                                PostalCode = reader["PostalCode"].ToString(),
                                Country = reader["Country"].ToString(),
                                Phone = reader["Phone"].ToString(),
                                Fax = reader["Fax"].ToString(),
                            });
                        }
                    }
                }
            }
            return customers;
        }

        public Customer GetCustomerById(string id)
        {
            using(var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using(var cmd = new SqlCommand("showCustomerDetailsById", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);

                    using(var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            return new Customer
                            {
                                CustomerId = reader["CustomerID"].ToString(),
                                CompanyName = reader["CompanyName"].ToString(),
                                ContactName = reader["ContactName"].ToString(),
                                ContactTitle = reader["ContactTitle"].ToString(),
                                Address = reader["Address"].ToString(),
                                City = reader["City"].ToString(),
                                Region = reader["Region"].ToString(),
                                PostalCode = reader["PostalCode"].ToString(),
                                Country = reader["Country"].ToString(),
                                Phone = reader["Phone"].ToString(),
                                Fax = reader["Fax"].ToString(),
                            };
                        }
                    }
                }
            }
            return null; //If no customer found
        }

        public IEnumerable<OrderShipper> GetOrderAndShipperById(string id)
        {
            List<OrderShipper> orderShipper = new List<OrderShipper>();
            using(var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using(var cmd = new SqlCommand("showOrder_ShipperDetailsByCustomerId", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@customerId", id);

                    using(var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            OrderShipper os = new OrderShipper {
                                CustomerID = reader["CustomerID"].ToString(),
                                CompanyName = reader["CompanyName"].ToString(),
                                Address = reader["Address"].ToString(),
                                ContactName = reader["ContactName"].ToString(),
                                OrderID = Convert.ToInt32(reader["OrderID"]),
                                OrderDate = reader["OrderDate"].ToString(),
                                ShipVia = Convert.ToInt32(reader["ShipVia"]),
                                ShipperName = reader["ShipperName"].ToString(),
                                Phone = reader["Phone"].ToString(),
                                ShipAddress = reader["ShipAddress"].ToString(),
                                ShipName = reader["ShipName"].ToString()
                            };
                            orderShipper.Add(os);
                        }
                    }
                }
            }
            return orderShipper;
        }
    }
    
}
