using TicketJam.WinForm.ApiClient;
using TicketJam.WinForm.DTO;
using TicketJam.WinForm.Stubs;

namespace TicketJam.WinForm
{
    public partial class Form1 : Form
    {
        private DTO.Event _Event = new DTO.Event();
        private List<Venue> list = VenueStub.list;
        //Insert dependency injection for baseuri
        private EventAPIConsumer _eventAPIConsumer = new EventAPIConsumer("");

        public Form1()
        {
            InitializeComponent();
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
            txtLoggedInAsResult.Text = OrganizerStub.Organizer.Email;
        }

        private void btnSubmitEvent_Click(object sender, EventArgs e)
        {
            _Event.StartDate = dateTimePickerStartDateWrite.Value.Date;
            _Event.EndDate = dateTimePickerEndDateWrite.Value.Date;
            _Event.Description = txtDescriptionWrite.Text;
            _Event.TotalAmount = int.Parse(txtTicketAmountWrite.Text);
            //TODO
            //FIX THIS SO NOT HARD CODED
            _Event.Organizer = OrganizerStub.Organizer;
            _Event.Venue = VenueStub.Venue;

            _eventAPIConsumer.AddEvent(_Event);
        }
    }
}
