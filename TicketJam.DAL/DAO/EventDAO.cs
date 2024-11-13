using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

    public Event GetById(int id)
    {
        IDbConnection connection = new SqlConnection(_connectionString);
        connection.Open();
        return connection.QuerySingle<Event>(_GETBYID_SQL, new { id = id });
    }


    public Event GetEventAndJoinData(int id)
    {

        using IDbConnection connection = new SqlConnection(_connectionString);
        Event Event = connection.QuerySingle<Event>(_GET_EVENT_SQL, new { id = id });

        Event.ticketList = connection.Query<Ticket, Section, Venue, Address, Ticket>(_JOIN_SQL, (t, s, v, a) =>
        {
            t.section = s;
            t.section.venue = v;
            t.section.venue.address = a;
            return t;

        }, new { EventId = Event.id }).ToList();

        return Event;
    }

    public int InsertEvent(Event Event)
    {
        IDbConnection connection = new SqlConnection(_connectionString);
        //TODO, make with less chance of duplicate, probably uuid ish
        Random random = new Random();
        Event.eventNo = random.Next();
        connection.Open();
        IDbTransaction transaction = connection.BeginTransaction();
        try
        {
            Event.id = connection.ExecuteScalar<int>(_INSERT_SQL, Event, transaction);
        }
        catch (Exception)
        {
            transaction.Rollback();
            throw;
        }
        transaction.Commit();

        return Event.id;
    }
    public IEnumerable<Event> Read()
    {
        IDbConnection connection = new SqlConnection(_connectionString);
        return connection.Query<Event>(_GET_EVENT_SQL);
    }

    public Event Update(Event entity)
    {
        throw new NotImplementedException();
    }
}