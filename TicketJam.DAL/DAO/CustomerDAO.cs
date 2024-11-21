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
    public class CustomerDAO : IDAO<Customer>, ICustomerDAO
    {
        private readonly string _connectionString;
        private string _createCustomerSQL = "INSERT INTO Customer (CustomerNo, FirstName, LastName, PhoneNo, Email, Password) VALUES (@CustomerNo, @FirstName, @LastName, @PhoneNo, @Email, @Password); SELECT SCOPE_IDENTITY();";
        private string _findCustomerByIdSQL = "SELECT * FROM Customer WHERE Id=@Id";
        private string _findCustomerByEmailSQL = "SELECT * FROM CUSTOMER WHERE Email = @email";

        public CustomerDAO(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Customer Create(Customer entity)
        {
            //Using realses all resources
            using IDbConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            //TODO: Change random to something more unique.
            Random random = new Random();

            try
            {
                entity.CustomerNo = random.Next();
                entity.Id = connection.ExecuteScalar<int>(_createCustomerSQL, entity);
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
            using IDbConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            try
            {
                return connection.QuerySingle<Customer>(_findCustomerByIdSQL, new { Id = id });
            }
            catch (SqlException e)
            {
                throw new Exception ($"There was an issue finding a customer using ID: {id}, error message was {e.Message}", e);
            } finally
            {
                connection.Close();
            }
        }

        public Customer GetCustomerByEmail(string email)
        {
            using IDbConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            try
            {
                return connection.QuerySingle<Customer>(_findCustomerByEmailSQL, new { Email = email });

            }
            catch (SqlException e)
            {

                throw new Exception($"There was an issue finding a customer using Email: {email}, error message was {e.Message}", e);
            }
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
