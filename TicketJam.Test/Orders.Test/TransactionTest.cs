using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketJam.DAL.DAO;
using TicketJam.DAL.Model;

namespace TicketJam.Test.Orders.Test;

public class TransactionTest
{
    private IDAO<Section> _sectionDAO;
    private IDAO<Venue> _venueDAO;
    private const string _connectionString = "Server=hildur.ucn.dk;Database=DMA-CSD-S232_10503088;User Id=DMA-CSD-S232_10503088;Password=Password1!;; TrustServerCertificate=True";
    

    [SetUp]
    public void SetUp()
    {
        _sectionDAO = new SectionDAO(_connectionString);
        _venueDAO = new VenueDAO(_connectionString);
    }

    [Test]
    public void PurchaseTicketsFromSectionCantGoBelowZeroTestSuccess()
    {
        //Test First

        // Arrange

        var section = _sectionDAO.GetById(2);

        IList<Section> sections = new List<Section>();
        
        

        int startTicket = section.TicketAmount;

        Console.WriteLine($"Start mængde af tickets: {startTicket}");

        // Act
        using IDbConnection connection = new SqlConnection(_connectionString);
        connection.Open();
        IDbTransaction transaction = connection.BeginTransaction();
        
        try
        {
            int amountTaken = 501;


            if(section.TicketAmount >= amountTaken)
            {
                section.TicketAmount -= amountTaken;
                Console.WriteLine($"Mængden af ticket efter der er taget 300 tickets: {section.TicketAmount}");
                transaction.Commit();
            } 
        }

        catch (Exception ex)
        {
            transaction.Rollback();
            throw new Exception($"Der er ikke flere billetter tilbage. Nuværende mængde billetter: {section.TicketAmount} - transaction rolledback", ex);
        }

        // Assert
        Assert.That(section.TicketAmount, Is.EqualTo(startTicket), "Billetterne er de samme efter rollback");
    }
    

    [Test]
    public void PurchaseTicketsFromSectionCantGoBelowZeroTestFailed()
    {
        //Test First

        // Arrange
        var section = _sectionDAO.GetById(2);
        int startTicket = section.TicketAmount;

        Console.WriteLine($"Start mængde af tickets: {startTicket}");

        // Act
        using IDbConnection connection = new SqlConnection(_connectionString);
        connection.Open();
        IDbTransaction transaction = connection.BeginTransaction();

        try
        {
            int amountTaken = 501;


            if (section.TicketAmount < amountTaken)
            {
                section.TicketAmount -= amountTaken;
                Console.WriteLine($"Mængden af ticket efter der er taget 300 tickets: {section.TicketAmount}");
                transaction.Commit();
            }
        }

        catch (Exception ex)
        {
            transaction.Rollback();
            throw new Exception($"Der er ikke flere billetter tilbage. Nuværende mængde billetter: {section.TicketAmount} - transaction rolledback", ex);
        }

        // Assert
        Assert.AreEqual(startTicket, section.TicketAmount, "Billetterne er de samme efter rollback");
    }



}
