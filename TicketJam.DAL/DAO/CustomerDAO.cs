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
        private string _createCustomerSQL = "INSERT INTO Customer (CustomerNo, FirstName, LastName, PhoneNo, Email) VALUES (@CustomerNo, @FirstName, @LastName, @PhoneNo, @Email); SELECT SCOPE_IDENTITY();";
        private string _findCustomerByIdSQL = "SELECT id, email, CustomerNo, FirstName, LastName, PhoneNo FROM Customer WHERE Id=@Id";
        private string _findCustomerByEmailSQL = "SELECT id, email, CustomerNo, FirstName, LastName, PhoneNo FROM Customer WHERE Email=@email";

        public CustomerDAO(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Used to insert a Customer into database and returns said Customer with their identity ID
        /// </summary>
        /// <param name="customer"></param>
        /// Takes parameter customer
        /// <returns></returns>
        /// Returns Customer with identity ID
        /// <exception cref="Exception"></exception>
        /// Throws Exception if insert fails
        public Customer Create(Customer customer)
        {
            //Using realses all resources
            using IDbConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            //TODO: Change random to something more unique.
            Random random = new Random();

            try
            {
                customer.CustomerNo = random.Next();
                customer.Id = connection.ExecuteScalar<int>(_createCustomerSQL, customer);
            }
            catch (SqlException e)
            {
                throw new Exception($"An error has occured while trying to insert customer into Customer table, the error reads: {e.Message}", e);
            }
            finally
            {
                connection.Close();
            }

            return customer;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets a Customer using their ID
        /// </summary>
        /// <param name="id"></param>
        /// Takes parameter ID to find Customer
        /// <returns></returns>
        /// Returns Customer object with said ID
        /// <exception cref="Exception"></exception>
        /// Throws exception if nothing is found or database connection fails
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

        /// <summary>
        /// Finds Customer using Email
        /// </summary>
        /// <param name="email"></param>
        /// Takes parameter email to find Customer
        /// <returns></returns>
        /// Returns Customer object if found
        /// <exception cref="Exception"></exception>
        /// Throws Exception if nothing found or error with database
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
            finally 
            {
                connection.Close();
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
