﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketJam.DAL.Model;

namespace TicketJam.DAL.DAO
{
    public interface IEventDAO
    {
        int InsertEvent(Event Event, int organizerId, int VenueId);
        Event GetEventAndJoinData(int id);
    }
}
