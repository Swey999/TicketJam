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
    public class OrderDAO : IDAO<Order>
    {
        private string _connectionString;
        private string _INSERT_ORDER_QUERY = "INSERT INTO Orders (OrderNo, Customer_ID_FK) VALUES (@OrderNo, @CustomerId); SELECT CAST(SCOPE_IDENTITY() as int)";
        private string _INSERT_ORDERLINE_QUERY = "INSERT INTO Orderline (Quantity, Ticket_ID_FK, Order_ID_FK) VALUES (@Quantity, @TicketId, @OrderId); SELECT CAST(SCOPE_IDENTITY() as int)";

        private string _DELETE_ORDER_QUERY = "DELETE FROM Orders WHERE Id = @id";

        private string _GET_ORDER_FROM_ID_QUERY = "SELECT Id, OrderNo FROM Orders WHERE Id = @id";
        private string _GET_ID_FROM_ORDER_QUERY = "SELECT Id FROM Orders";
        private string _ORDERLINE_JOIN_QUERY = "SELECT DISTINCT Orderline.*, Ticket.*, Section.*, Venue.*, Event.*, Address.* FROM Orderline JOIN Ticket ON Ticket.Id = Orderline.Ticket_ID_FK JOIN Section ON Section.Id = Ticket.Section_ID_FK JOIN Venue ON Venue.Id = Section.Venue_ID_FK JOIN Event ON Venue.Id = Event.Venue_ID_FK JOIN Address ON Venue.Address_ID_FK = Address.Id WHERE Orderline.Order_ID_FK = @orderId";


        public OrderDAO(String connectionStringns)
        {
            this._connectionString = connectionStringns;
        }
        public Order Create(Order entity)
        {
            IDbConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            IDbTransaction transaction = connection.BeginTransaction();
            try
            {
                var parameters = new
                {
                    orderNo = entity.orderNo,
                    customerId = entity.customerId
                };

                entity.id = connection.ExecuteScalar<int>(_INSERT_ORDER_QUERY, parameters, transaction);
                foreach (OrderLine orderline in entity.orderLines)
                {
                    connection.Execute(_INSERT_ORDERLINE_QUERY, new { orderId = entity.id, quantity = orderline.quantity , ticketId = orderline.ticketId}, transaction);
                }
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
            transaction.Commit();

            return entity;
        }

        public bool Delete(int id)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                int rowsAffected = connection.Execute(_DELETE_ORDER_QUERY, new { id = id });

                return true;
            }
        }


        public Order GetById(int id)
        {
            using IDbConnection connection = new SqlConnection(_connectionString);
            Order order = connection.QuerySingle<Order>(_GET_ORDER_FROM_ID_QUERY, new { id = id });
            order.orderLines = connection.Query<OrderLine>(_ORDERLINE_JOIN_QUERY, new { orderId = order.id }).ToList();
            return order;
        }

        public IEnumerable<Order> Read()
        {
            IDbConnection connection = new SqlConnection(_connectionString);
            return connection.Query<Order>(_GET_ID_FROM_ORDER_QUERY);
        }

        public Order Update(Order entity)
        {
            return null;
        }
    }
}
