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
    private IEventDAO _eventDAO2;


    [SetUp]
    public void SetUp()
    {
        _eventDAO = new EventDAO("Server=hildur.ucn.dk;Database=DMA-CSD-S232_10503088;User Id=DMA-CSD-S232_10503088;Password=Password1!;; TrustServerCertificate=True");
    }

    [Test]
    public void CreateEventTestSuccess()
    {
        // ARRANGE
        Event Event = new() { EventNo = 2988, Description = "Beat up William", TotalAmount = 1000, StartDate = DateTime.Now, EndDate = DateTime.Now, VenueId = 1, OrganizerId = 1 };
        // ACT
        var test = _eventDAO2.InsertEvent(Event);
        // ASSERT
        Assert.That(test, Is.GreaterThan(0));


    }

    [Test]
    public void FindEventByIdTestSuccess()
    {
    //ARRANGE

    //ACT
    var test = _eventDAO.GetById(1);

    //ASSERT
    Assert.That(test, Is.Not.Null);
    }
}