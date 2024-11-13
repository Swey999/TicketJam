using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketJam.DAL.DAO;
using TicketJam.DAL.Model;

namespace TicketJam.Test.Orders.Test
{
    public class OrderTest
    {
        private IDAO<Order> _orderDao;

        [SetUp]
        public void SetUp()
        {
            _orderDao = new OrderDAO("Server=hildur.ucn.dk;Database=DMA-CSD-S232_10503088;User Id=DMA-CSD-S232_10503088;Password=Password1!;; TrustServerCertificate=True");
        }

        [Test]
        public void CreateOrderAndInsertIntoDatabaseTestSuccess()
        {

            // Arrange
            Order order = new() { orderNo = 42231, customerId = 1};
            order.orderLines = new List<OrderLine>();
            OrderLine line = new() { quantity = 1, ticketId = 1 };
            order.orderLines.Add(line);

            // Act
            var insertIntoDatabase = _orderDao.Create(order);

            // Assert
            Assert.That(insertIntoDatabase, Is.Not.Null);
        }

        [Test]
        public void ReadOrderTestSucces()
        {
            // Arrange

            // Act
            var orderRead = _orderDao.GetById(1);
            // Assert
            Assert.That(orderRead, Is.Not.Null);

        }

        [Test]
        public void DeleteOrderSucces()
        {
            // Arrange

            // Act
            var deletedOrderId = _orderDao.Delete(1);
            // Assert
            Assert.That(deletedOrderId, Is.False);

        }

    }
}
