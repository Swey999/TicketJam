﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TicketJam.DAL.Model;

public class Customer
{
    public int Id { get; set; }

    public int CustomerNo {  get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Address Address { get; set; }
    public string PhoneNo { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    

}
