using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketJam.DAL.Model;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TicketJam.DAL.DAO;

public class EventDAO : IEventDAO
{
    private readonly string _connectionString;
    private string GETALLVENUES_SQL = "SELECT * FROM Venue";
    private string GETBYID_SQL = "SELECT * FROM Event WHERE Id = @Id";
    private string INSERT_SQL = "INSERT INTO Event (Description, TotalAmount, StartDate, EndDate) VALUES (@Description, @TotalAmount, @StartDate, @EndDate)";
    public EventDAO()
    {
        _connectionString = "Server=hildur.ucn.dk;Database=DMA-CSD-S232_10503088;User Id=DMA-CSD-S232_10503088;Password=Password1!; TrustServerCertificate=True";
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
        return connection.QuerySingle<int>(GETBYID_SQL, new { Event.Description, Event.TotalAmount, Event.StartDate, Event.EndDate });

    }
}