﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketJam.DAL.Model;

namespace TicketJam.DAL.DAO
{
    public interface IOrganizerDAO
    {
        int CreateOrganizerAndReturnIdentity(Organizer organizer);

        public Organizer Login (Organizer organizer);
    }
}
