using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketJam.DAL.DAO;
using TicketJam.DAL.Model;

namespace TicketJam.Test.SectionTest
{
    public class SectionTest
    {
        private const string _connectionString = "Server=hildur.ucn.dk;Database=DMA-CSD-S232_10503088;User Id=DMA-CSD-S232_10503088;Password=Password1!;; TrustServerCertificate=True";
        private IDAO<Section> _sectionDAO;
        private ISectionDAO _sectionDAOTwo;



        [SetUp]
        public void SetUp()
        {
            _sectionDAO = new SectionDAO(_connectionString);
            _sectionDAOTwo = new SectionDAO(_connectionString);
        }


        [Test]
        public void GetAllSectionsTestSuccess()
        {
            // Arrange

            // Act
            IEnumerable<Section> foundSections = _sectionDAO.Read();
            foreach (Section s in foundSections)
            {
                Console.WriteLine(s.Description);
            }

            // Assert
            Assert.That(foundSections, Is.Not.Null);
        }

        [Test]
        public void GetSectionByIdTestSuccess()
        {
            // Arrange
            int sectionId = 2;

            // Act
            var foundSection = _sectionDAO.GetById(sectionId);

            // Assert
            Assert.That(foundSection, Is.Not.Null);
        }

        [Test]
        public void GetSectionsByVenueTestSuccess()
        {
            // Arrange
            int sectionId = 2;

            // Act
            var foundSection = _sectionDAOTwo.GetSectionsByVenue(sectionId);
            Console.WriteLine(foundSection);

            // Assert
            Assert.That(foundSection, Is.Not.Null, "Section was not found");
        }

    }
}
