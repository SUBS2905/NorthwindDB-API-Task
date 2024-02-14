using NorthWindDB_API.Models;
using NorthWindDB_API.Repository.Interfaces;
using System.Data.SqlClient;

namespace NorthWindDB_API.Repository
{
    public class ShipperRepository: IShipperRepository
    {
        private readonly string _connectionString;

        public ShipperRepository(IConfiguration configuration) {
            _connectionString = configuration.GetConnectionString("Northwind");
        }

        public IEnumerable<Shipper> GetAllShippers()
        {
            List<Shipper> shippers = new List<Shipper>();
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand("showAllShipperDetails", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Shipper shp = new Shipper
                            {
                                ShipperID = Convert.ToInt32(reader["ShipperID"]),
                                CompanyName = reader["CompanyName"].ToString(),
                                Phone = reader["Phone"].ToString()

                            };

                            shippers.Add(shp);
                        }
                    }
                }
            }
            return shippers;
        }

        public Shipper GetShipperById(int id)
        {
            Shipper shipper;
            using(var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using(var cmd = new SqlCommand("showShipperById", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);

                    using(var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            return new Shipper
                            {
                                ShipperID = Convert.ToInt32(reader["ShipperID"]),
                                CompanyName = reader["CompanyName"].ToString(),
                                Phone = reader["Phone"].ToString()
                            };
                        }
                    }
                }
            }
            return null;
        }

        public Shipper AddShipper(Shipper shipper)
        {
            Shipper newShipper = new Shipper();
            newShipper.ShipperID = shipper.ShipperID;
            newShipper.CompanyName = shipper.CompanyName;
            newShipper.Phone = shipper.Phone;
            using(var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using(var cmd = new SqlCommand("addShipper", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ShipperID", shipper.ShipperID);
                    cmd.Parameters.AddWithValue("@CompanyName", shipper.CompanyName);
                    cmd.Parameters.AddWithValue("@Phone", shipper.Phone);
                    cmd.ExecuteNonQuery();
                }
            }
            return newShipper;
        }

        public int DeleteShipperById(int id) {
            using(var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using(var cmd = new SqlCommand("deleteShipperById", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery ();
                    return 1;
                }
            }
        }

    }
}
