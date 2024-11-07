using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketJam.DAL.Model;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TicketJam.DAL.DAO;

public class EventDAO : IEventDAO
{
    private readonly string _connectionString;
    private string INSERT_SQL = "INSERT INTO Event (Description, TotalAmount, StartDate, EndDate) VALUES (@Description, @TotalAmount, @StartDate, @EndDate)";
    public EventDAO()
    {
        _connectionString = "Server=hildur.ucn.dk;Database=DMA-CSD-S232_10503088;User Id=DMA-CSD-S232_10503088;Password=Password1!; TrustServerCertificate=True";
    }

    public IEnumerable<Venue> GetAllVenues()
    {
        throw new NotImplementedException();
    }

    public Event GetEvent(int id)
    {
        throw new NotImplementedException();
    }

    //public void InsertEvent(Event Event)
    //{
    //    IDbConnection connection = new SqlConnection(_connectionString);
    //    connection.Open();
    //    connection.Execute(_insertEventSQL, Event);
    //}

    public int InsertEvent(Event Event)
    {
        using (IDbConnection connection = new SqlConnection(_connectionString))
        connection.Open();
        return connection.(_insertEventSQL, Event);

    }
}
