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
        private string connectionString;

        public OrderDAO(String connectionStringns)
        {
            this.connectionString = connectionStringns;
        }
        public Order Create(Order entity)
        {
            IDbConnection connection = new SqlConnection(connectionString);
            connection.Open();
            IDbTransaction transaction = connection.BeginTransaction();
            try
            {
                string commandText = "INSERT INTO Orders (OrderNo, Customer_ID_FK) VALUES (@OrderNo, @CustomerId); SELECT CAST(SCOPE_IDENTITY() as int)";

                // Create an anonymous object for parameters
                var parameters = new
                {
                    OrderNo = entity.OrderNo,
                    CustomerId = entity.CustomerId// Directly access Customer.Id here
                };

                // Execute the command with the anonymous object
                entity.Id = connection.ExecuteScalar<int>(commandText, parameters, transaction);

                string insertOrderlineSql = "INSERT INTO Orderline (Quantity, Ticket_ID_FK, Order_ID_FK) VALUES (@Quantity, @TicketId, @OrderId); SELECT CAST(SCOPE_IDENTITY() as int)";
                foreach (OrderLine orderline in entity.OrderLines)
                {
                    connection.Execute(insertOrderlineSql, new { OrderId = entity.Id, Quantity = orderline.Quantity , TicketId = orderline.TicketId}, transaction);
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
            string commandText = "DELETE FROM Orders WHERE Id = @id";

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                int rowsAffected = connection.Execute(commandText, new { Id = id });

                return true;
            }
        }


        public Order GetById(int id)
        {

            //string commandText = "Select Orders.*, OrderLine.* FROM Orders Left Join Orderline On Orders.Id = OrderLine.Order_ID_FK where orders.Id = @id";
            //IDbConnection connection = new SqlConnection(connectionString);
            //connection.Open();
            //return connection.QuerySingle<Order>(commandText, new { Id = id });

            string selectOrderSql = "SELECT Id, OrderNo FROM Orders WHERE Id = @id";
            string selectOrderlinesSql = "SELECT DISTINCT Orderline.*, Ticket.*, Section.*, Venue.*, Event.*, Address.* FROM Orderline JOIN Ticket ON Ticket.Id = Orderline.Ticket_ID_FK JOIN Section ON Section.Id = Ticket.Section_ID_FK JOIN Venue ON Venue.Id = Section.Venue_ID_FK JOIN Event ON Venue.Id = Event.Venue_ID_FK JOIN Address ON Venue.Address_ID_FK = Address.Id WHERE Orderline.Order_ID_FK = @OrderId";

            using IDbConnection connection = new SqlConnection(connectionString);
            Order order = connection.QuerySingle<Order>(selectOrderSql, new { Id = id });

            order.OrderLines = connection.Query<OrderLine>(selectOrderlinesSql, new { OrderId = order.Id }).ToList();

            return order;
        }

        public IEnumerable<Order> Read()
        {
            String commandText = "Select Id FROM Orders";
            IDbConnection connection = new SqlConnection(connectionString);
            return connection.Query<Order>(commandText);

        }

        public Order Update(Order entity)
        {
            String commandText = "UPDATE Orders SET CustomerName = @CustomerName, Discount = @Discount, Date = @Date WHERE Id = @Id";
            IDbConnection connection = new SqlConnection(connectionString);
            connection.Open();
            connection.Execute(commandText, entity);
            return entity;
        }
    }
}
