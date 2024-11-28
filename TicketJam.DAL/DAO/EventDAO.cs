using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TicketJam.DAL.Model;
using static Dapper.SqlMapper;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TicketJam.DAL.DAO;

public class EventDAO : IEventDAO, IDAO<Event>
{
    private readonly string _connectionString;
    private string _INSERT_SQL = "INSERT INTO Event (Description, Name, TotalAmount, StartDate, EndDate, EventNo, Organizer_ID_FK, Venue_ID_FK) VALUES (@Description, @Name, @TotalAmount, @StartDate, @EndDate, @EventNo, @OrganizerId, @VenueId) SELECT CAST(SCOPE_IDENTITY() as int)";

    private string _GETBYID_SQL = "SELECT Id, Name, Description, TotalAmount, EventNo, StartDate, EndDate, Venue_ID_FK, Organizer_ID_FK FROM Event WHERE Id = @id";
    private string _GET_EVENT_FROM_ID_SQL = "SELECT Id, EventNo, TotalAmount, StartDate, EndDate, Name FROM Event WHERE Id = @id";
    private string _GET_EVENT_SQL = "SELECT Id, Name, Description, TotalAmount, EventNo, StartDate, EndDate, Venue_ID_FK, Organizer_ID_FK FROM Event";
    private string _GET_ADDRESS_ON_EVENT_SQL = "SELECT Venue.Id, Venue.Name, Address.Id, Address.StreetName, Address.City, Address.Zip, Address.HouseNo FROM Event JOIN Venue ON Event.Venue_ID_FK = Venue.Id JOIN Address ON Venue.Address_ID_FK = Address.Id WHERE Event.Id = @EventId";

   

    //TODO: * skal rettes så vi ikke henter ALT op fra databasen. Det bliver en senere opgave. 

    private string _JOIN_SQL = "SELECT DISTINCT Ticket.*, Section.*, Venue.*, Address.* FROM Ticket JOIN Section ON Section.Id = Ticket.Section_ID_FK JOIN Venue ON Venue.Id = Section.Venue_ID_FK JOIN Address ON Address.Id = Venue.Address_ID_FK WHERE Ticket.Event_ID_FK = @EventId";


    public EventDAO(string connectionString)
    {
        _connectionString = connectionString;
    }

    public Event Create(Event entity)
    {
        throw new NotImplementedException();
    }

    public bool Delete(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Venue> GetAllVenues()
    {
        throw new NotImplementedException();
    }

    public Event GetById(int id)
    {
        using IDbConnection connection = new SqlConnection(_connectionString);
        connection.Open();
        try
        {
            return connection.QuerySingle<Event>(_GETBYID_SQL, new { id = id });
        }
        catch (SqlException e)
        {

            throw new Exception ($"There was an issue getting event using ID: {id}, error message was {e.Message}", e);
        } finally
        {
            connection.Close();
        }
    }

    public Event GetEvent(int id)
    {
        throw new NotImplementedException();
    }

    public Event GetEventAndJoinData(int id)
    {

        using IDbConnection connection = new SqlConnection(_connectionString);
        try
        {
            Event Event = connection.QuerySingle<Event>(_GETBYID_SQL, new { id = id });

            Event.TicketList = connection.Query<Ticket, Section, Venue, Address, Ticket>(_JOIN_SQL, (t, s, v, a) =>
            {
                t.Section = s;
                t.Section.Venue = v;
                t.Section.Venue.Address = a;
                return t;

            }, new { EventId = Event.Id }).ToList();

            return Event;
        }
        catch (SqlException e)
        {

            throw new Exception ($"There was an error getting event data using ID: {id}, error message was {e.Message}", e);
        } finally
        {
            connection.Close();
        }
    }


    public int InsertEvent(Event Event, int organizerId, int VenueId)
    {
        using IDbConnection connection = new SqlConnection(_connectionString);
        //TODO, make with less chance of duplicate, probably uuid ish
        Random random = new Random();
        Event.EventNo = random.Next();
        connection.Open();
        try
        {
            //Cannot pass parameter Event as parameter in ExecuteScalar because it does not 1:1 match database, so we create empty object and assign the values
            Event.Id = connection.ExecuteScalar<int>(_INSERT_SQL, new
            {
                Description = Event.Description,
                Name = Event.Name,
                TotalAmount = Event.TotalAmount,
                StartDate = Event.StartDate,
                EndDate = Event.EndDate,
                EventNo = Event.EventNo,
                OrganizerId = organizerId,
                VenueId = VenueId
            });
        }
        catch (SqlException e)
        {
            throw new Exception($"There was an issue saving event, error message was {e.Message}", e);
        } finally
        {
            connection.Close();
        }

        return Event.Id;
    }
    public IEnumerable<Event> Read()
    {
        using IDbConnection connection = new SqlConnection(_connectionString);
        try
        {
            // Fetch the main Event entities
            var events = connection.Query<Event>(_GET_EVENT_SQL).ToList();

            foreach (var eventEntity in events)
            {
                // Fetch related Venue and Address for each Event
                var venue = connection.Query<Venue, Address, Venue>(
                    _GET_ADDRESS_ON_EVENT_SQL,
                    (venue, address) =>
                    {
                        venue.Address = address;
                        return venue;
                    },
                    new { EventId = eventEntity.Id }
                ).FirstOrDefault(); // Expecting a single Venue for each Event

                // Assign the Venue (along with its Address) to the Event's VenueId property
                eventEntity.Venue = venue;
            }

            return events;
        }
        catch (Exception ex)
        {
            // Handle or log exceptions
            throw new ApplicationException("An error occurred while reading events.", ex);
        }
    }

    public Event Update(Event entity)
    {
        throw new NotImplementedException();
    }
}