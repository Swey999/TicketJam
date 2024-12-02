using System.Collections.Generic;
using System.ComponentModel;
using TicketJam.WinForm.ApiClient;
using TicketJam.WinForm.DTO;
using TicketJam.WinForm.Stubs;

namespace TicketJam.WinForm
{
    public partial class CreateEvent : Form
    {
        private OrganizerDto _organizerDto;
        private EventDto _Event = new EventDto();
        public BindingList<TicketDto> _ticketList = new BindingList<TicketDto>();
        private List<VenueDto> list = new List<VenueDto>();
        //Insert dependency injection for baseuri
        private EventAPIConsumer _eventAPIConsumer = new EventAPIConsumer("https://localhost:7280/api/v1/Event");
        private VenueAPIConsumer _venueAPIConsumer = new VenueAPIConsumer("https://localhost:7280/api/Venue");
        


        public CreateEvent(OrganizerDto organizerDto)
        {
            _organizerDto = organizerDto;
            InitializeComponent();
            list = (List<VenueDto>)GetVenueList();
            lstBoxTicket.DataSource = _ticketList;
        }

        private void comboBoxVenueList_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxVenueList_ShowList();
        }

        private void comboBoxVenueList_ShowList()
        {
        }

        private void txtLoggedInAsResult_TextChanged(object sender, EventArgs e)
        {
            txtLoggedInAsResult_ShowMessage();
        }

        private void txtLoggedInAsResult_ShowMessage()
        {
            txtLoggedInAsResult.Text = _organizerDto.Email;
        }

        private void btnSubmitEvent_Click(object sender, EventArgs e)
        {
            if (txtDescriptionWrite.Text != "" && txtTicketAmountWrite.Text != "" && txtNameWrite.Text != "")
            {
                _Event.StartDate = dateTimePickerStartDateWrite.Value.Date;
                _Event.EndDate = dateTimePickerEndDateWrite.Value.Date;
                _Event.Description = txtDescriptionWrite.Text;
                try
                {
                    _Event.TotalAmount = int.Parse(txtTicketAmountWrite.Text);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Please make sure total amount is a numerical value", "Wrong input", MessageBoxButtons.OK);
                    return;
                }
                _Event.Name = txtNameWrite.Text;
                VenueDto tempObject = (VenueDto)comboBoxVenueList.SelectedItem;
                _Event.OrganizerId = _organizerDto.Id;
                _Event.VenueId = tempObject.Id;
                _Event.ticketDtosList = _ticketList.ToList<TicketDto>();
                _eventAPIConsumer.AddEvent(_Event);
                MessageBox.Show("Event created!", "Event created!", MessageBoxButtons.OK);
            } else
            {
                MessageBox.Show("Please fill out all the text fields", "One or more text fields not filled out", MessageBoxButtons.OK);
            }
        }

        public IEnumerable<VenueDto> GetVenueList()
        {
            return _venueAPIConsumer.GetVenues();
        }

        private void btnCreateTicketType_Click(object sender, EventArgs e)
        {
            createTicketType();
        }

        private void createTicketType()
        {
            //Har ikke kunne ændre cboxTicketCategory til CreateTicket...
            cboxTicketCategory CreateTicket = new cboxTicketCategory(_ticketList);
            CreateTicket.Show();
        }
    }
}
