using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Configuration;


namespace Datos
{
    public class DInvoice 
    {


        public static string connectionString = "Data Source=LAB1504-31\\SQLEXPRESS;Initial Catalog=TAREA;User ID=samuel;Password=123456";

        public List<Invoice> Get()
        {
            List<Invoice> list = new List<Invoice>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "usp_ListarInvoice";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Invoice invoice = new Invoice
                                {
                                    Invoice_id = reader.GetInt32(reader.GetOrdinal("invoice_id")),
                                    Customer_id = reader.GetInt32(reader.GetOrdinal("customer_id")),
                                    Date = reader.GetDateTime(reader.GetOrdinal("date")),
                                    Total = reader.GetDecimal(reader.GetOrdinal("total")),
                                };
                                list.Add(invoice);
                            }
                        }
                    }
                }
                connection.Close();
            }

            return list;
        }

        public bool Insert(Invoice request)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                try
                {
                    SqlCommand cmd = new SqlCommand("InsertInvoice", connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@customer_id",request.Customer_id);
                    cmd.Parameters.AddWithValue("@date", request.Date);
                    cmd.Parameters.AddWithValue("@total", request.Total);
                    cmd.ExecuteNonQuery();

                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public bool Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                try
                {
                    SqlCommand cmd = new SqlCommand("DeleteInvoice", connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@invoice_id", id);
                    cmd.ExecuteNonQuery();

                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
    }
}
