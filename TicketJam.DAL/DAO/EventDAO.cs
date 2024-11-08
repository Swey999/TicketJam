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
    private string INSERT_SQL = "INSERT INTO Event (Description, TotalAmount, StartDate, EndDate, EventNo) VALUES (@Description, @TotalAmount, @StartDate, @EndDate, @EventNo) SELECT CAST(SCOPE_IDENTITY() as int)";
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

    public int InsertEvent(Event Event)
    {
        IDbConnection connection = new SqlConnection(_connectionString);
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