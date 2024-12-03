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
        private string _INSERT_ORDER_QUERY = "INSERT INTO Orders (OrderNo, Customer_ID_FK) VALUES (@OrderNo, @CustomerId); SELECT CAST(SCOPE_IDENTITY() as int)";
        private string _INSERT_ORDERLINE_QUERY = "INSERT INTO Orderline (Quantity, Ticket_ID_FK, Order_ID_FK) VALUES (@Quantity, @TicketId, @OrderId); SELECT CAST(SCOPE_IDENTITY() as int)";

        private string _DELETE_ORDER_QUERY = "DELETE FROM Orders WHERE Id = @id";
        private string _DELETE_ORDERLINES_QUERY = "DELETE FROM OrderLines WHERE OrderId = @id";

        private string _GET_ORDER_FROM_ID_QUERY = "SELECT Id, OrderNo FROM Orders WHERE Id = @id";
        private string _GET_ID_FROM_ORDER_QUERY = "SELECT Id FROM Orders";
        private string _GET_ORDERS_BY_CUSTOMERID = "SELECT * FROM Orders WHERE Customer_ID_FK = @CustomerId";

        //TODO: * skal rettes så vi ikke henter ALT op fra databasen. Det bliver en senere opgave. 

        private string _ORDERLINE_JOIN_QUERY = "SELECT DISTINCT OL.*, T.*, S.*, V.*, E.*, A.* FROM Orderline OL JOIN Ticket T ON T.Id = OL.Ticket_ID_FK JOIN Section S ON S.Id = T.Section_ID_FK JOIN Venue V ON V.Id = S.Venue_ID_FK JOIN Event E ON E.Id = T.Event_ID_FK JOIN Address A ON A.Id = V.Address_ID_FK WHERE OL.Order_ID_FK = @orderId;\r\n\r\n\r\n\r\n\r\n\r\n";

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

                order.Id = connection.ExecuteScalar<int>(_INSERT_ORDER_QUERY, parameters, transaction);
                foreach (OrderLine orderline in order.OrderLines)
                {
                    connection.Execute(_INSERT_ORDERLINE_QUERY, new { orderId = order.Id, quantity = orderline.Quantity , ticketId = orderline.TicketId}, transaction);
                    if(_ticketDao.Update(orderline.Quantity, orderline.TicketId) != true)
                    {
                        transaction.Rollback();
                    }
                }
                transaction.Commit();
            }
            catch (SqlException e)
            {
                transaction.Rollback();
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
                connection.Execute(_DELETE_ORDERLINES_QUERY, new { Id = id }, transaction);
                connection.Execute(_DELETE_ORDER_QUERY, new { Id = id }, transaction);
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
                Order order = connection.QuerySingle<Order>(_GET_ORDER_FROM_ID_QUERY, new { id = id });
                order.OrderLines = connection.Query<OrderLine>(_ORDERLINE_JOIN_QUERY, new { orderId = order.Id }).ToList();
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
                return connection.Query<Order>(_GET_ID_FROM_ORDER_QUERY);

            }
            catch (SqlException e)
            {
                //TODO fix exception when method is done
                throw new Exception ($"", e);
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
                var orders = connection.Query<Order>(_GET_ORDERS_BY_CUSTOMERID, new { CustomerId = customerId }).ToList();
                foreach (var order in orders)
                {
                    // Get order lines for each order
                    order.OrderLines = connection.Query<OrderLine>(_ORDERLINE_JOIN_QUERY, new { orderId = order.Id }).ToList();
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
