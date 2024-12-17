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
    private string _insertSQL = "INSERT INTO Event (Description, Name, TotalAmount, StartDate, EndDate, EventNo, Organizer_ID_FK, Venue_ID_FK) VALUES (@Description, @Name, @TotalAmount, @StartDate, @EndDate, @EventNo, @OrganizerId, @VenueId) SELECT CAST(SCOPE_IDENTITY() as int)";

    private string _getByIdSQL = "SELECT Id, Name, Description, TotalAmount, EventNo, StartDate, EndDate, Venue_ID_FK, Organizer_ID_FK FROM Event WHERE Id = @id";
    private string _getEventSQL = "SELECT Id, Name, Description, TotalAmount, EventNo, StartDate, EndDate, Venue_ID_FK, Organizer_ID_FK FROM Event";
    private string _getAddressOnEventSQL = "SELECT Venue.Id, Venue.Name, Address.Id, Address.StreetName, Address.City, Address.Zip, Address.HouseNo FROM Event JOIN Venue ON Event.Venue_ID_FK = Venue.Id JOIN Address ON Venue.Address_ID_FK = Address.Id WHERE Event.Id = @EventId";

    private string _joinSQL = "SELECT DISTINCT Ticket.*, Section.*, Venue.*, Address.* FROM Ticket JOIN Section ON Section.Id = Ticket.Section_ID_FK JOIN Venue ON Venue.Id = Section.Venue_ID_FK JOIN Address ON Address.Id = Venue.Address_ID_FK WHERE Ticket.Event_ID_FK = @EventId";


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

    /// <summary>
    /// Gets Event from database using ID
    /// </summary>
    /// <param name="id"></param>
    /// Takes parameter ID
    /// <returns></returns>
    /// Returns Event if found using ID
    /// <exception cref="Exception"></exception>
    /// Throws exception if nothing was found or failing to connect to database
    public Event GetById(int id)
    {
        using IDbConnection connection = new SqlConnection(_connectionString);
        connection.Open();
        try
        {
            return connection.QuerySingle<Event>(_getByIdSQL, new { id = id });
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

    /// <summary>
    /// Retrieves Event from database and fills out TicketList, Section, Venue, Address and Tickets using ID
    /// </summary>
    /// <param name="id"></param>
    /// Takes parameter ID
    /// <returns></returns>
    /// Returns Event if found in database
    /// <exception cref="Exception"></exception>
    /// Throws exception if error with database or nothing was found
    public Event GetEventAndJoinData(int id)
    {

        using IDbConnection connection = new SqlConnection(_connectionString);
        try
        {
            Event Event = connection.QuerySingle<Event>(_getByIdSQL, new { id = id });

            Event.TicketList = connection.Query<Ticket, Section, Venue, Address, Ticket>(_joinSQL, (t, s, v, a) =>
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

    /// <summary>
    /// Receives Event together with Organizer ID and Venue ID to create Event in database
    /// </summary>
    /// <param name="eventToInsert"></param>
    /// <param name="organizerId"></param>
    /// <param name="venueId"></param>
    /// <returns></returns>
    /// Returns ID used for connecting tickets to Event
    /// <exception cref="Exception"></exception>
    /// Throws exception if no connection to databse or problem with inserting
    public int InsertEvent(Event eventToInsert, int organizerId, int venueId)
    {
        using IDbConnection connection = new SqlConnection(_connectionString);
        //TODO, make with less chance of duplicate, probably uuid ish
        Random random = new Random();
        eventToInsert.EventNo = random.Next();
        connection.Open();
        try
        {
            //Cannot pass parameter Event as parameter in ExecuteScalar because it does not 1:1 match database, so we create empty object and assign the values
            eventToInsert.Id = connection.ExecuteScalar<int>(_insertSQL, new
            {
                Description = eventToInsert.Description,
                Name = eventToInsert.Name,
                TotalAmount = eventToInsert.TotalAmount,
                StartDate = eventToInsert.StartDate,
                EndDate = eventToInsert.EndDate,
                EventNo = eventToInsert.EventNo,
                OrganizerId = organizerId,
                VenueId = venueId
            });
            return eventToInsert.Id;
        }
        catch (SqlException e)
        {
            throw new Exception($"There was an issue saving event, error message was {e.Message}", e);
        } finally
        {
            connection.Close();
        }
    }

    /// <summary>
    /// Returns all events together with their venues and addresses
    /// </summary>
    /// <returns></returns>
    /// Returns IEnumerable<Event> of all events in database
    /// <exception cref="ApplicationException"></exception>
    /// Throws Exception if error with connecting to database
    public IEnumerable<Event> Read()
    {
        using IDbConnection connection = new SqlConnection(_connectionString);
        try
        {
            // Fetch the main Event entities
            var events = connection.Query<Event>(_getEventSQL).ToList();

            foreach (var eventEntity in events)
            {
                // Fetch related Venue and Address for each Event
                var venue = connection.Query<Venue, Address, Venue>(
                    _getAddressOnEventSQL,
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
        catch (SqlException e)
        {
            // Handle or log exceptions
            throw new Exception("An error occurred while reading events.", e);
        } finally
        {
            connection.Close();
        }
    }

    public Event Update(Event entity)
    {
        throw new NotImplementedException();
    }
}