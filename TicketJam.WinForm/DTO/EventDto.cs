using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TicketJam.WinForm.DTO
{
    public class EventDto
    {
        public string Description { get; set; }
        public string Name { get; set; }
        public int TotalAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int VenueId { get; set; }
        public int OrganizerId { get; set; }

    }
}
