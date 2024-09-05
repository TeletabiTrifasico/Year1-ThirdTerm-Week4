using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Collections;
using System.Data.Common;
using System.Configuration;

namespace DAL
{
    public class CustomerDAO 
    {
        private SqlConnection dbConnection;
        public CustomerDAO()
        {
            string connString = ConfigurationManager.ConnectionStrings["Programming3Week4"].ConnectionString;
            dbConnection = new SqlConnection(connString);
        }
        public List<Customer> GetAllCustomers()
        {
            dbConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Customers", dbConnection);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Customer> customers = new List<Customer>();
            while (reader.Read())
            {
                Customer customer = ReadCustomer(reader);
                customers.Add(customer);
            }
            reader.Close();
            dbConnection.Close();

            return customers;
        }

        private List<Customer> ReadTables(DataTable dataTable)
        {
            List<Customer> customers = new List<Customer>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Customer customer = new Customer
                {
                    Id = (int)dr["Id"],
                    FirstName = dr["FirstName"].ToString(),
                    LastName = dr["LastName"].ToString(),
                    EmailAddress = dr["EmailAdress"].ToString()
                };
                customers.Add(customer);
            }
            return customers;
        }
        public Customer GetById(int customerId)
        {
            dbConnection.Open();
            SqlCommand command = new SqlCommand("SELECT Id, FirstName, LastName, EmailAddress FROM Customers WHERE id = @Id", dbConnection);
            command.Parameters.AddWithValue("@Id", customerId);
            
            SqlDataReader reader = command.ExecuteReader();
            Customer customer = null;
            if (reader.Read())
                customer = ReadCustomer(reader); 
            reader.Close();
            dbConnection.Close();

            return customer;

        }

        private Customer ReadCustomer(SqlDataReader reader)
        {
            int id = (int)reader["id"];
            string FirstName = reader["FirstName"].ToString();
            string lastName = reader["LastName"].ToString();
            string emailAdress = (string)reader["EmailAddress"];

            return new Customer(id, emailAdress, FirstName, lastName);
        }
    }
}
