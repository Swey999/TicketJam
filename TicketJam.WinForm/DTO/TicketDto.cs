using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketJam.WinForm.DTO
{
    public class TicketDto
    {
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string TicketCategory { get; set; }
        public DateTime TimeCreated { get; set; }
    }
}
