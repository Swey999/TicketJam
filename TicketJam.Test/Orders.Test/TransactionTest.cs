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
    private IDAO<Order> _orderDAO;


    [SetUp]
    public void SetUp()
    {
        _sectionDAO = new SectionDAO(_connectionString);
        _venueDAO = new VenueDAO(_connectionString);
        _orderDAO = new OrderDAO(_connectionString);
    }

    [Test]
    public void PurchaseTicketsFromSectionCantGoBelowZeroTestSuccess()
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

        Order order = new Order()
        {
            Id = 0,
            CustomerId = 1
        };
        order.OrderLines = new List<OrderLine>();

        OrderLine line = new OrderLine()
        {
            Id = 0,
            Quantity = 1,
            TicketId = 2
        };

        order.OrderLines.Add(line);

        _orderDAO.Create(order);


        // Assert
        Assert.AreNotEqual(startTicket, _sectionDAO.GetById(2).TicketAmount, "Billetterne er de samme efter rollback");
        Console.WriteLine($"Slut mængde af tickets: {_sectionDAO.GetById(2).TicketAmount}");
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

        Order order = new Order()
        {
            Id = 0,
            CustomerId = 1
        };
        order.OrderLines = new List<OrderLine>();

        OrderLine line = new OrderLine()
        {
            Id = 0,
            Quantity = 500,
            TicketId = 2
        };

        order.OrderLines.Add(line);

        _orderDAO.Create(order);
        

        // Assert
        Assert.AreEqual(startTicket, _sectionDAO.GetById(2).TicketAmount, "Billetterne er de samme efter rollback");
        Console.WriteLine($"Slut mængde af tickets: {section.TicketAmount}");
    }

    [Test]
    public void MulitplePurchaseOfSingleTicketTest()
    {
        // Arrange
        var section = _sectionDAO.GetById(1); 
        int initialTicketCount = section.TicketAmount;

        Console.WriteLine($"Initial ticket count: {initialTicketCount}");

        // Act
        Task<Order> user1 = Task.Run(() =>
        {
            var order = new Order
            {
                CustomerId = 1,
                OrderLines = new List<OrderLine>
            {
                new OrderLine { TicketId = 1, Quantity = 1 }
            }
            };

            return _orderDAO.Create(order);
        });

        Task<Order> user2 = Task.Run(() =>
        {
            var order = new Order
            {
                CustomerId = 2,
                OrderLines = new List<OrderLine>
            {
                new OrderLine { TicketId = 1, Quantity = 1 }
            }
            };

            return _orderDAO.Create(order);
        });

        Task.WaitAll(user1, user2);

        // Assert
        int finalTicketCount = _sectionDAO.GetById(1).TicketAmount;

        Assert.AreEqual(initialTicketCount - 1, finalTicketCount, "The ticket count should decrease by exactly one.");

        Assert.IsTrue(
            (user1.Result.Id > 0 && user2.Result.Id == 0) || (user1.Result.Id == 0 && user2.Result.Id > 0),
            "Only one user's order should succeed."
        );

        Console.WriteLine($"Final ticket count: {finalTicketCount}");
        Console.WriteLine($"User 1 Order Success: {user1.Result.Id > 0}");
        Console.WriteLine($"User 2 Order Success: {user2.Result.Id > 0}");
    }




}
