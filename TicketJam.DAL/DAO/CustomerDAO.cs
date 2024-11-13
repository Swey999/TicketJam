using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketJam.DAL.Model;

namespace TicketJam.DAL.DAO
{
    public class CustomerDAO : IDAO<Customer>
    {
        private readonly string _connectionString;
        private string _createCustomerSQL = "INSERT INTO Customer (CustomerNo, FirstName, LastName, PhoneNo, Email, Password) VALUES (@CustomerNo, @FirstName, @LastName, @PhoneNo, @Email, @Password); SELECT SCOPE_IDENTITY();";
        private string _findCustomerByIdSQL = "SELECT * FROM Customer WHERE Id=@Id";

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
                entity.id = connection.ExecuteScalar<int>(_createCustomerSQL, entity);
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
            IDbConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            return connection.QuerySingle<Customer>(_findCustomerByIdSQL, new { id = id });
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
