using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DCustomer
    {
        public static string connectionString = "Data Source=LAB1504-28\\SQLEXPRESS;Initial Catalog=TAREA;User ID=samuel;Password=123456";

        public List<Customer> GetCustomers()
        {
            List<Customer> list = new List<Customer>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "usp_ListarCustomer";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Customer customer = new Customer
                                {
                                    Customer_id = reader.GetInt32(reader.GetOrdinal("customer_id")),
                                    Name = reader.GetString("name"),
                                    Address = reader.GetString("address"),
                                    Phone = reader.GetString("phone")
                                };
                                list.Add(customer);
                            }
                        }
                    }
                }
                connection.Close();
            }
            return list;
        }
    }
}
