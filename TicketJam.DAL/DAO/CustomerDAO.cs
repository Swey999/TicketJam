using Dapper;
using System;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketJam.DAL.Model;

namespace TicketJam.DAL.DAO
{
    public class CustomerDAO 
    {
        private readonly string _connectionString;
        private string _insertCustomerSQL = "INSERT INTO Customer (FirstName, LastName, PhoneNo, Email) VALUES (@FirstName, @LastName, @PhoneNo, @Email); SELECT SCOPE_IDENTITY();";

        public CustomerDAO(string connectionString)
        {
            _connectionString = connectionString;
        }

        #region Insert Customer Method
        public int Insert(Customer customer)
        {
            //Using realses all resources
            using IDbConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            try
            {
                //customer.Id = connection.ExecuteScalar<int>(_insertCustomerSQL, customer);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error has occured while trying to insert customer into Customer table, the error reads: {ex.Message}", ex);
            }

            return customer.Id;
        } 
        #endregion

        public bool Delete(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Customer Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetAll()
        {
            throw new NotImplementedException();
        }


        public bool Update(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
