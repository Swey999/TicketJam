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
    public class OrderDAO : IDAO<Order>
    {
        private string _connectionString;
        private string _INSERT_ORDER_QUERY = "INSERT INTO Orders (OrderNo, Customer_ID_FK) VALUES (@OrderNo, @CustomerId); SELECT CAST(SCOPE_IDENTITY() as int)";
        private string _INSERT_ORDERLINE_QUERY = "INSERT INTO Orderline (Quantity, Ticket_ID_FK, Order_ID_FK) VALUES (@Quantity, @TicketId, @OrderId); SELECT CAST(SCOPE_IDENTITY() as int)";

        private string _DELETE_ORDER_QUERY = "DELETE FROM Orders WHERE Id = @id";
        private string _DELETE_ORDERLINES_QUERY = "DELETE FROM OrderLines WHERE OrderId = @id";

        private string _GET_ORDER_FROM_ID_QUERY = "SELECT Id, OrderNo FROM Orders WHERE Id = @id";
        private string _GET_ID_FROM_ORDER_QUERY = "SELECT Id FROM Orders";

        //TODO: * skal rettes så vi ikke henter ALT op fra databasen. Det bliver en senere opgave. 
        private string _ORDERLINE_JOIN_QUERY = "SELECT DISTINCT Orderline.*, Ticket.*, Section.*, Venue.*, Event.*, Address.* FROM Orderline JOIN Ticket ON Ticket.Id = Orderline.Ticket_ID_FK JOIN Section ON Section.Id = Ticket.Section_ID_FK JOIN Venue ON Venue.Id = Section.Venue_ID_FK JOIN Event ON Venue.Id = Event.Venue_ID_FK JOIN Address ON Venue.Address_ID_FK = Address.Id WHERE Orderline.Order_ID_FK = @orderId";
        


        public OrderDAO(String connectionStringns)
        {
            this._connectionString = connectionStringns;
        }
        public Order Create(Order entity)
        {
            using IDbConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            IDbTransaction transaction = connection.BeginTransaction();

            //TODO: Change random to something more unique.
            Random random = new Random();
            entity.OrderNo = random.Next();


            try
            {
                var parameters = new
                {
                    orderNo = entity.OrderNo,
                    customerId = entity.CustomerId
                };

                entity.Id = connection.ExecuteScalar<int>(_INSERT_ORDER_QUERY, parameters, transaction);
                foreach (OrderLine orderline in entity.OrderLines)
                {
                    connection.Execute(_INSERT_ORDERLINE_QUERY, new { orderId = entity.Id, quantity = orderline.Quantity , ticketId = orderline.TicketId}, transaction);
                }
                transaction.Commit();
            }
            catch (SqlException e)
            {
                throw new Exception ($"There was an issue inserting order, error message was {e.Message}", e);
                transaction.Rollback();
            } finally
            {
                connection.Close();
            }

            return entity;
        }

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

            catch (Exception ex)
            {
                transaction.Rollback();
                return false;
                throw new Exception($"Couldn't delete Order on ID: {id}, the error was: {ex.Message}", ex);
            } finally
            {
                connection.Close();
            }
        }


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

        public Order Update(Order entity)
        {
            return null;
        }
    }
}
