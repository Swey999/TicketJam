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

    private string _GETBYID_SQL = "SELECT * FROM Event WHERE Id = @id";
    private string _GET_EVENT_FROM_ID_SQL = "SELECT Id, EventNo, TotalAmount, StartDate, EndDate, Name FROM Event WHERE Id = @id";
    private string _GET_EVENT_SQL = "SELECT * FROM Event";

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
        return connection.Query<Event>(_GET_EVENT_SQL);
    }

    public Event Update(Event entity)
    {
        throw new NotImplementedException();
    }
}