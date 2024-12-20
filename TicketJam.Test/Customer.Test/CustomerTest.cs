﻿using System;
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
        //Arrange
        Address address = new Address() { City = "London", StreetName = "LondonStreet", HouseNo = "36", Zip = "9283" };
        Customer customer = new Customer() { FirstName = "Karl", LastName = "Olsen", Email = "karl@hotmail.com", PhoneNo = "28734633", Address = address };

        // Act
        var insertIntoDatabase = _customerDAO.Create(customer);

        // Assert
        Assert.That(insertIntoDatabase, Is.Not.Null);
    }

    [Test]
    public void FindCustomerOnIdTestSuccess()
    {
        // Arrange
        int customerId = 1;

        // Act
        var getCustomerById = _customerDAO.GetById(customerId);

        // Assert
        Assert.That(getCustomerById, Is.Not.Null);
    }

    [Test]
    public void FindCustomerOnEmailTestSuccess()
    {
        // Arrange
        string email = "jane.smith@example.com";

        // Act
        var findCustomerByEmail = _customerDAO.GetCustomerByEmail(email);

        // Assert
        Assert.That(findCustomerByEmail, Is.Not.Null);
    }



}
