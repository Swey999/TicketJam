using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketJam.DAL.DAO;
using TicketJam.DAL.Model;

namespace TicketJam.Test.Organizer.Test
{
    public class OrganizerTest(IOrganizerDAO organizerDAO)
    {
        private IOrganizerDAO _organizerDAO = organizerDAO;

        [SetUp]
        public void SetUp()
        {

        }

        [Test]
        public void CreateOrganizerAndReturnIdentitySuccess()
        {

            TicketJam.DAL.Model.Organizer organizerTest = new TicketJam.DAL.Model.Organizer() { Email = "Testmail@gmail.com", Password = "password", PhoneNo = "88888888" };
            // Arrange

            // Act
            int identityReturned = 0;
            identityReturned = _organizerDAO.CreateOrganizerAndReturnIdentity(organizerTest);

            // Assert
            Assert.GreaterOrEqual(identityReturned, 1);
        }

        [Test]
        public void CreateOrganizerAndReturnIdentityFail()
        {

            // Arrange
            TicketJam.DAL.Model.Organizer organizerTest = new TicketJam.DAL.Model.Organizer() { };

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
    }
}
