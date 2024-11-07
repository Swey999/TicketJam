using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketJam.DAL.DAO;
using TicketJam.DAL.Model;

namespace TicketJam.Test.CreateOrder.Test
{
    public class EventTest
    {
        private EventDAO _eventDAO;
        private Venue _venue;
        private Event _newEvent;
        private Organizer _organizer;

        [SetUp]
        public void SetUp() 
        { 
            _eventDAO = new EventDAO();
            _venue = new Venue(); 
            _newEvent = new Event();
            _organizer = new Organizer();
        }
        
        [Test]
        public void CreateEvent()
        {
            //ARRANGE
            _newEvent.Organizer = _organizer;
            _newEvent.Venue = _venue;
            //ACT

            //ASSERT
            Assert.That(_newEvent.Id > 0, "Created EventID not returned");
        }

        //[Test]
        //public Event FindEventById()
        //{
            //ARRANGE
            //ACT
          //  var Event = _eventDAO.GetEvent(_newEvent.Id);
            //ASSERT
            //Assert.Equals(Event.Id, _newEvent.Id);

        //}
    }
}
