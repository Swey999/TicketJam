using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketJam.DAL.DAO;
using TicketJam.DAL.Model;

namespace TicketJam.Test.TicketTest
{
    public class TicketTest
    {
        private const string _connectionString = "Server=hildur.ucn.dk;Database=DMA-CSD-S232_10503088;User Id=DMA-CSD-S232_10503088;Password=Password1!;; TrustServerCertificate=True";
        private IDAO<Ticket> _ticketDAO;



        [SetUp]
        public void SetUp()
        {
            _ticketDAO = new TicketDAO(_connectionString);
        }




        [Test]
        public void GetSectionByIdTestSuccess()
        {
            // Arrange
            int sectionId = 2;

            // Act
            var foundSection = _ticketDAO.GetById(sectionId);

            // Assert
            Assert.That(foundSection, Is.Not.Null);
        }

    }
}
