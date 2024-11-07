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
    private IEventDAO _eventDAO;

    [SetUp]
    public void SetUp()
    {
        _eventDAO = new EventDAO();
    }

    //TODO create rollback so test can be run without manual interference
    [Test]
    public void CreateEventTest()
    {
        //ARRANGE
        Venue venue = new() { Id = 300};
        Organizer organizer = new() { Id = 300};
        Event Event = new() { EventNo = 2988, Description = "Beat up William", TotalAmount = 1000, StartDate = DateTime.Now, EndDate = DateTime.Now, Venue = venue, Organizer = organizer };
        //ACT
        var test = _eventDAO.InsertEvent(Event);
        //ASSERT
        Assert.That(test, Is.GreaterThan(0));


    }

    [Test]
    public void FindEventById()
    {
        //ARRANGE
        var test = _eventDAO.GetEvent(1);
        //ACT
        //ASSERT
        Assert.That(test, Is.Not.Null);
    
    }
}