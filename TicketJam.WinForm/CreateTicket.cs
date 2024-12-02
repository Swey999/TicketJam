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

        private void submitButtonPressed()
        {
            if (txtTicketDescription.Text != "" && txtPrice.Text != "")
            {
                TicketDto ticketDto = new TicketDto();
                ticketDto.Description = txtTicketDescription.Text;
                try
                {
                    ticketDto.Price = decimal.Parse(txtPrice.Text);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Please make sure price is a numerical value", "Wrong input", MessageBoxButtons.OK);
                    return;
                }
                ticketDto.TimeCreated = DateTime.Now;
                TicketDto tempObject = (TicketDto)comboBoxTicketCategory.SelectedItem;
                ticketDto.TicketCategory = tempObject.TicketCategory;
                _bindingList.Add(ticketDto);
                MessageBox.Show("Good job!", "Created new ticket!", MessageBoxButtons.OK);
                this.Close(); 
            }
        }


    }
}
