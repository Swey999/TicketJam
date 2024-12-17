using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using TicketJam.DAL.Model;
using static Dapper.SqlMapper;

namespace TicketJam.DAL.DAO
{
    public class OrderDAO : IDAO<Order>, IOrderDAO
    {
        private string _connectionString;
        private string _insertOrderSQL = "INSERT INTO Orders (OrderNo, Customer_ID_FK) VALUES (@OrderNo, @CustomerId); SELECT CAST(SCOPE_IDENTITY() as int)";
        private string _insertOrderLineSQL = "INSERT INTO Orderline (Quantity, Ticket_ID_FK, Order_ID_FK) VALUES (@Quantity, @TicketId, @OrderId); SELECT CAST(SCOPE_IDENTITY() as int)";

        private string _deleteOrderSQL = "DELETE FROM Orders WHERE Id = @id";
        private string _deleteOrderLineSQL = "DELETE FROM OrderLines WHERE OrderId = @id";

        private string _getOrderByIdSQL= "SELECT Id, OrderNo FROM Orders WHERE Id = @id";
        private string _getIdByOrderSQL = "SELECT Id FROM Orders";
        private string _getOrdersByCustomerId = "SELECT * FROM Orders WHERE Customer_ID_FK = @CustomerId";

        //TODO: * skal rettes så vi ikke henter ALT op fra databasen. Det bliver en senere opgave. 

        private string _orderLIneJoinSQL = "SELECT DISTINCT OL.*, T.*, S.*, V.*, E.*, A.* FROM Orderline OL JOIN Ticket T ON T.Id = OL.Ticket_ID_FK JOIN Section S ON S.Id = T.Section_ID_FK JOIN Venue V ON V.Id = S.Venue_ID_FK JOIN Event E ON E.Id = T.Event_ID_FK JOIN Address A ON A.Id = V.Address_ID_FK WHERE OL.Order_ID_FK = @orderId;";

        private TicketDAO _ticketDao;

        public OrderDAO(String connectionStringns)
        {
            this._connectionString = connectionStringns;
            _ticketDao = new TicketDAO(_connectionString);
        }

        /// <summary>
        /// Inserts an Order and its orderlines and updates Ticket Count in database to ensure too many tickets weren't sold
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        /// Returns an Order with its identity ID
        /// <exception cref="Exception"></exception>
        /// Throws exception if error with connecting with database or problem inserting
        public Order Create(Order order)
        {
            using IDbConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            IDbTransaction transaction = connection.BeginTransaction();

            //TODO: Change random to something more unique.
            Random random = new Random();
            order.OrderNo = random.Next();

            try
            {
                var parameters = new
                {
                    orderNo = order.OrderNo,
                    customerId = order.CustomerId
                };

                order.Id = connection.ExecuteScalar<int>(_insertOrderSQL, parameters, transaction);
                foreach (OrderLine orderline in order.OrderLines)
                {
                    connection.Execute(_insertOrderLineSQL, new { orderId = order.Id, quantity = orderline.Quantity , ticketId = orderline.TicketId}, transaction);
                    if (_ticketDao.Update(orderline.Quantity, orderline.TicketId, connection, transaction) != true)
                    {
                        order.Id = 0;
                    }
                    else
                    {
                        transaction.Commit();
                    }
                }
            }
            catch (Exception e)
            {
                transaction.Rollback();
                order.Id = 0;
                throw new Exception ($"There was an issue inserting order, error message was {e.Message}", e);
            } finally
            {
                connection.Close();
            }
            return order;
        }

        /// <summary>
        /// Deletes an order using ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// Returns bool telling if action successful
        /// <exception cref="Exception"></exception>
        /// Throws exception if not able to delete order, order doesn't exist or problem connecting with database
        public bool Delete(int id)
        {
            
            // Using = releases all resources
            using IDbConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            var transaction = connection.BeginTransaction();

            try
            {
                connection.Execute(_deleteOrderLineSQL, new { Id = id }, transaction);
                connection.Execute(_deleteOrderSQL, new { Id = id }, transaction);
                transaction.Commit();
                return true;
            }

            catch (SqlException e)
            {
                transaction.Rollback();
                return false;
                throw new Exception($"Couldn't delete Order on ID: {id}, the error was: {e.Message}", e);
            } finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// Retrieves an order using ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// Returns an order with its orderlines
        /// <exception cref="Exception"></exception>
        /// Throws exception if error finding order or problem connecting to database
        public Order GetById(int id)
        {
            using IDbConnection connection = new SqlConnection(_connectionString);
            try
            {
                Order order = connection.QuerySingle<Order>(_getOrderByIdSQL, new { id = id });
                order.OrderLines = connection.Query<OrderLine>(_orderLIneJoinSQL, new { orderId = order.Id }).ToList();
                return order;
            }
            catch (SqlException e)
            {
                throw new Exception ($"There was an issue getting order by ID: {id}, error message was {e.Message}", e);
            } finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public IEnumerable<Order> Read()
        {
            using IDbConnection connection = new SqlConnection(_connectionString);
            try
            {
                return connection.Query<Order>(_getIdByOrderSQL);
            }
            catch (SqlException e)
            {
                throw new Exception ($"An error occurred while reading Order.", e);
            } finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// Retrives all orders that a specified Customer has placed
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        /// Returns an IEnumerable of all orders a Customer has placed
        /// <exception cref="Exception"></exception>
        /// Throws exception if not able to find any orders made by Customer or issues connecting to database
        public IEnumerable<Order> GetOrdersByCustomer(int customerId)
        {
            using IDbConnection connection = new SqlConnection(_connectionString);
            try
            {
                var orders = connection.Query<Order>(_getOrdersByCustomerId, new { CustomerId = customerId }).ToList();
                foreach (var order in orders)
                {
                    // Get order lines for each order
                    order.OrderLines = connection.Query<OrderLine>(_orderLIneJoinSQL, new { orderId = order.Id }).ToList();
                }
                return orders;
            }
            catch (SqlException e)
            {
                throw new Exception($"Error fetching orders for customer with ID: {customerId}. {e.Message}", e);
            } finally
            {
                connection.Close();
            }
        }

        public Order Update(Order entity)
        {
            throw new NotImplementedException();
        }
    }
}
