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
    public class CustomerDAO : IDao<Customer>
    {
        private readonly string _connectionString;
        private string _createCustomerSQL = "INSERT INTO Customer (FirstName, LastName, PhoneNo, Email) VALUES (@FirstName, @LastName, @PhoneNo, @Email); SELECT SCOPE_IDENTITY();";

        public CustomerDAO(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Customer Create(Customer entity)
        {
            //Using realses all resources
            using IDbConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            try
            {
                customer.Id = connection.ExecuteScalar<int>(_insertCustomerSQL, customer);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error has occured while trying to insert customer into Customer table, the error reads: {ex.Message}", ex);
            }

            return entity;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Customer GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> Read()
        {
            throw new NotImplementedException();
        }

        public Customer Update(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
