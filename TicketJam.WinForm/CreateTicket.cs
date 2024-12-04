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
        private BindingList<TicketDto> _bindingList = new BindingList<TicketDto>();

        public cboxTicketCategory(BindingList<TicketDto> list)
        {
            InitializeComponent();
            this._bindingList = list;
        }


        private void btnSubmitTicket_Click(object sender, EventArgs e)
        {
            submitButtonPressed();
        }

        /// <summary>
        /// Fills out all information needed to transfer ticket into binding list for display and further handling in Create Event
        /// </summary>
        private void submitButtonPressed()
        {
            //Check if fields are not filled before continuing
            if (txtTicketDescription.Text == "" || txtPrice.Text == "")
            {
                MessageBox.Show("Please ensure all fields are filled out", "Failed to create new ticket", MessageBoxButtons.OK);
                return;
            }

            TicketDto ticketDto = new TicketDto();

            // Try to parse, catch FormatException if fails and display to user
            try
            {
                ticketDto.Price = decimal.Parse(txtPrice.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Please make sure price is a numerical value", "Wrong input", MessageBoxButtons.OK);
                return;
            }

            ticketDto.Description = txtTicketDescription.Text;
            ticketDto.TimeCreated = DateTime.Now;
            TicketDto tempObject = (TicketDto)comboBoxTicketCategory.SelectedItem;
            ticketDto.TicketCategory = tempObject.TicketCategory;
            _bindingList.Add(ticketDto);
            MessageBox.Show("Ticket created!", "Created new ticket!", MessageBoxButtons.OK);
            this.Close();
        }
    }
}
