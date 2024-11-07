using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketJam.DAL.Model;

namespace TicketJam.DAL.DAO
{
    public class OrderDao : IDao<Order>
    {
        private string connectionString;

        public OrderDao(String connectionStringns)
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
                string commandText = "INSERT INTO Orders (CustomerName, Discount, Date) VALUES (@CustomerName, @Discount, @Date)";
                entity.Id = connection.ExecuteScalar<int>(commandText, entity, transaction);

                string insertOrderlineSql = "INSERT INTO Orderlines (OrderId) VALUES (@OrderId);";
                foreach (OrderLine orderline in entity.OrderLines)
                {
                    connection.Execute(insertOrderlineSql, new { OrderId = entity.Id}, transaction);
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
            string commandText = "SELECT * FROM Orders WHERE Id = @Id";
            IDbConnection connection = new SqlConnection(connectionString);
            connection.Open();
            return connection.QuerySingle<Order>(commandText, new { Id = id });
        }

        public IEnumerable<Order> Read()
        {
            String commandText = "Select Id, CustomerName, Discount, Date FROM Orders";
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
