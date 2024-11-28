using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TicketJam.WinForm.ApiClient;
using TicketJam.WinForm.DTO;

namespace TicketJam.WinForm
{
    public partial class cboxTicketCategory : Form
    {
        private List<TicketDto> _list = new List<TicketDto>();

        public cboxTicketCategory()
        {
            InitializeComponent();
        }


        private void btnSubmitTicket_Click(object sender, EventArgs e)
        {
            submitButtonPressed();
        }

        private void submitButtonPressed()
        {
            TicketDto ticketDto = new TicketDto();
            ticketDto.Description = txtTicketDescription.Text;
            ticketDto.Price = decimal.Parse(txtPrice.Text);
            ticketDto.TimeCreated = DateTime.Now;
            TicketDto tempObject = (TicketDto)comboBoxTicketCategory.SelectedItem;
            ticketDto.TicketCategory = tempObject.TicketCategory;


        }


    }
}
