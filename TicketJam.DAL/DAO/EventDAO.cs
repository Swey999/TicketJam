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

public class EventDAO : IEventDAO
{
    private readonly string _connectionString;
    private string GETALLVENUES_SQL = "SELECT * FROM Venue";
    private string GETBYID_SQL = "SELECT * FROM Event WHERE Id = @Id";
    private string INSERT_SQL = "INSERT INTO Event (Description, Name, TotalAmount, StartDate, EndDate, EventNo) VALUES (@Description, @Name, @TotalAmount, @StartDate, @EndDate, @EventNo) SELECT CAST(SCOPE_IDENTITY() as int)";
    public EventDAO(string connectionString)
    {
        _connectionString = connectionString;
    }

    public IEnumerable<Venue> GetAllVenues()
    {
        IDbConnection connection = new SqlConnection(_connectionString);
        return connection.Query<Venue>(GETALLVENUES_SQL);
    }

    public Event GetEvent(int id)
    {
        IDbConnection connection = new SqlConnection(_connectionString);
        connection.Open();
        return connection.QuerySingle<Event>(GETBYID_SQL, new { Id = id });
    }

    public Event GetEventAndJoinData(int id)
    {
        string selectEventSql = "SELECT Id, EventNo, TotalAmount, StartDate, EndDate, Name FROM Event WHERE Id = @id";
        string selectTicketSql = "SELECT DISTINCT Ticket.*, Section.*, Venue.*, Address.* FROM Ticket JOIN Section ON Section.Id = Ticket.Section_ID_FK JOIN Venue ON Venue.Id = Section.Venue_ID_FK JOIN Address ON Address.Id = Venue.Address_ID_FK WHERE Ticket.Event_ID_FK = @EventId";

        using IDbConnection connection = new SqlConnection(_connectionString);
        Event events = connection.QuerySingle<Event>(selectEventSql, new { Id = id });

        events.TicketList = connection.Query<Ticket, Section, Venue, Address, Ticket>(selectTicketSql, (t, s, v, a) =>
        {
            t.Section = s;
            t.Section.Venue = v;
            t.Section.Venue.Address = a;
            return t;

        }, new { EventId = events.Id }).ToList();

        return events;
    }

    public int InsertEvent(Event Event)
    {
        IDbConnection connection = new SqlConnection(_connectionString);
        //TODO, make with less chance of duplicate, probably uuid ish
        Random random = new Random();
        Event.EventNo = random.Next();
        connection.Open();
        IDbTransaction transaction = connection.BeginTransaction();
        try
        {
            Event.Id = connection.ExecuteScalar<int>(INSERT_SQL, Event, transaction);
        }
        catch (Exception)
        {
            transaction.Rollback();
            throw;
        }
        transaction.Commit();

        return Event.Id;
    }
}