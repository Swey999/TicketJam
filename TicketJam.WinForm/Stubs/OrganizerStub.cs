using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketJam.WinForm.DTO;

namespace TicketJam.WinForm.Stubs
{
    public static class OrganizerStub
    {
        public static OrganizerDto Organizer { get; set; } = new OrganizerDto() { PhoneNo = "20202020", Email = "Dinmor@gmail.com", Password = "Hvorofr har du adgang til det her???????"};
    }
}
