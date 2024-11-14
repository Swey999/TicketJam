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
        // Arrange
        Venue venue = new Venue() { id = 2 };
        Section section = new Section() { description = "Ny sektion med Transaction, wow", ticketAmount = 250, venue = venue };

        int startTicket = section.ticketAmount;

        Console.WriteLine($"Start mængde af tickets: {startTicket}");

        // Act
        using IDbConnection connection = new SqlConnection(_connectionString);
        connection.Open();
        IDbTransaction transaction = connection.BeginTransaction();
        
        try
        {
            int amountTaken = 300;


            if(section.ticketAmount >= amountTaken)
            {
                section.ticketAmount -= amountTaken;
                Console.WriteLine($"Mængden af ticket efter der er taget 300 tickets: {section.ticketAmount}");
                transaction.Commit();
            } 
        }

        catch (Exception ex)
        {
            transaction.Rollback();
            throw new Exception($"Der er ikke flere billetter tilbage. Nuværende mængde billetter: {section.ticketAmount} - transaction rolledback", ex);
        }

        // Assert
        Assert.AreEqual(startTicket, section.ticketAmount, "Billetterne er de samme efter rollback");
    }
    

    [Test]
    public void PurchaseTicketsFromSectionCantGoBelowZeroTestFailed()
    {

        // Arrange
        Venue venue = new Venue();
        Section section = new Section() { description = "Ny sektion med Transaction, wow", ticketAmount = 250, venue = venue };
        int startTicket = section.ticketAmount;

        Console.WriteLine($"Start mængde af tickets: {startTicket}");

        // Act
        using IDbConnection connection = new SqlConnection(_connectionString);
        connection.Open();
        IDbTransaction transaction = connection.BeginTransaction();

        try
        {
            int amountTaken = 300;


            if (section.ticketAmount < amountTaken)
            {
                section.ticketAmount -= amountTaken;
                Console.WriteLine($"Mængden af ticket efter der er taget 300 tickets: {section.ticketAmount}");
                transaction.Commit();
            }
        }

        catch (Exception ex)
        {
            transaction.Rollback();
            throw new Exception($"Der er ikke flere billetter tilbage. Nuværende mængde billetter: {section.ticketAmount} - transaction rolledback", ex);
        }

        // Assert
        Assert.AreEqual(startTicket, section.ticketAmount, "Billetterne er de samme efter rollback");
    }



}
