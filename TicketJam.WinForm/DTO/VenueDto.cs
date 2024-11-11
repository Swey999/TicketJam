using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketJam.WinForm.DTO
{
    public class VenueDto
    {
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
