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
            Order order = new() { OrderNo = 3654, CustomerId = 1};
            order.OrderLines = new List<OrderLine>();
            OrderLine line = new() { Quantity = 1, TicketId = 1 };
            order.OrderLines.Add(line);

            // Act
            var insertIntoDatabase = _orderDao.Create(order);

            // Assert
            Assert.That(insertIntoDatabase, Is.Not.Null);
        }

        [Test]
        public void ReadOrderTestSuccess()
        {
            // Arrange

            // Act
            var orderRead = _orderDao.GetById(2);
            // Assert
            Assert.That(orderRead, Is.Not.Null);

        }

        [Test]
        public void DeleteOrderTestSuccess()
        {
            // Arrange

            // Act
            var deletedOrder = _orderDao.Delete(28);
            var getDeletedOrder = _orderDao.GetById(28);
            // Assert
            Assert.That(getDeletedOrder, Is.EqualTo(null));
        }

    }
}
