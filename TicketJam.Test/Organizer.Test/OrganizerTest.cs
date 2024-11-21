using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketJam.DAL.DAO;

namespace TicketJam.Test.Organizer.Test
{
    public class OrganizerTest()
    {
        private IOrganizerDAO _organizerDAO;
        private const string _connectionString = "Server=hildur.ucn.dk;Database=DMA-CSD-S232_10503088;User Id=DMA-CSD-S232_10503088;Password=Password1!;; TrustServerCertificate=True";

        [SetUp]
        public void SetUp()
        {
            _organizerDAO = new OrganizerDAO(_connectionString);
        }

        [Test]
        public void CreateOrganizerAndReturnIdentitySuccess()
        {
            // Test First
            TicketJam.DAL.Model.Organizer organizerTest = new TicketJam.DAL.Model.Organizer()
            {
                Email = "Testmailer@gmail.com",
                Password = "password",
                PhoneNo = "88888888"
            };


            try
            {
                int identityReturned = 0;
                identityReturned = _organizerDAO.CreateOrganizerAndReturnIdentity(organizerTest);

                Assert.GreaterOrEqual(identityReturned, 1);
            }
            catch (SqlException e)
            {
            }
        }

        [Test]
        public void CreateOrganizerAndReturnIdentityFail()
        {

            // Arrange
            TicketJam.DAL.Model.Organizer organizerTest = new TicketJam.DAL.Model.Organizer();

            // Act
            int identityReturned = 0;

            try
            {
                identityReturned = _organizerDAO.CreateOrganizerAndReturnIdentity(organizerTest);
            }
            catch (Exception e)
            {

            }

            // Assert
            Assert.AreEqual(identityReturned, 0);
        }

        [Test]
        public void LoginTestSuccess()
        {
            TicketJam.DAL.Model.Organizer organizerTest = new TicketJam.DAL.Model.Organizer()
            {
                Email = "test2",
                Password = "test2",
                PhoneNo = "88888888",
                Id = 0
            };

            TicketJam.DAL.Model.Organizer organizerAssert = new DAL.Model.Organizer();

            try
            {
                organizerAssert = _organizerDAO.Login(organizerTest);
            }
            catch (SqlException e)
            {

                throw;
            }

            Assert.AreEqual(organizerAssert.Id, 4);
        }
    }
}
