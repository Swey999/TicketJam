using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketJam.DAL.DAO;
using TicketJam.DAL.Model;

namespace TicketJam.Test.CreateOrder.Test;

public class EventTest
{
    private IDAO<Event> _eventDAO;
    private IEventDAO _eventDAOTwo;



    [SetUp]
    public void SetUp()
    {
        _eventDAO = new EventDAO("Server=hildur.ucn.dk;Database=DMA-CSD-S232_10503088;User Id=DMA-CSD-S232_10503088;Password=Password1!;; TrustServerCertificate=True");
        _eventDAOTwo = new EventDAO("Server=hildur.ucn.dk;Database=DMA-CSD-S232_10503088;User Id=DMA-CSD-S232_10503088;Password=Password1!;; TrustServerCertificate=True");
    }

    [Test]
    public void CreateEventTestSuccess()
    {
        // ARRANGE
        Event Event = new() { EventNo = 2988, Description = "MongoMediaCorporation", TotalAmount = 1000, StartDate = DateTime.Now, EndDate = DateTime.Now};
        // ACT
        var test = _eventDAOTwo.InsertEvent(Event, 1, 1);
        // ASSERT
        Assert.That(test, Is.GreaterThan(0));


    }

    [Test]
    public void FindEventByIdTestSuccess()
    {
        //ARRANGE
        int eventId = 1;

        //ACT
        var test = _eventDAO.GetById(eventId);

        //ASSERT
        Assert.That(test, Is.Not.Null);
    }


    [Test]
    public void FindAllEventsTestSuccess()
    {
        // Aarange


        // Act
        IEnumerable<Event> foundEvents = _eventDAO.Read();
        foreach (Event e in foundEvents)
        {
            Console.WriteLine(e.Name);
        }

        // Assert

        Assert.That(foundEvents, Is.Not.Null);
    }



}