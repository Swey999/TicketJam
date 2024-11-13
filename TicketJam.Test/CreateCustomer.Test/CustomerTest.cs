using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using TicketJam.DAL.DAO;
using TicketJam.DAL.Model;

namespace TicketJam.Test.CreateCustomer.Test;

public class CustomerTest
{
    private CustomerDAO _customerDAO;


    [SetUp]
    public void SetUp()
    {
        _customerDAO = new CustomerDAO("Server=hildur.ucn.dk;Database=DMA-CSD-S232_10503088;User Id=DMA-CSD-S232_10503088;Password=Password1!;; TrustServerCertificate=True");
    }


    [Test]
    public void CreateCustomerAndInsertIntoDatabaseTestSuccess()
    {
        
        // Arrange
        Address address = new Address() { city = "London", streetName = "LondonStreet", houseNo = "36", zip = "9283" };
        Customer customer = new Customer() { firstName = "Bobby", lastName = "Olsen", email = "bobby@hotmail.com", phoneNo = "28734633", password = "1234", address = address };

        // Act
        var insertIntoDatabase = _customerDAO.Create(customer);

        // Assert
        Assert.That(insertIntoDatabase, Is.Not.Null);
    }


}
