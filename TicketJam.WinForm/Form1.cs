using TicketJam.WinForm.ApiClient;
using TicketJam.WinForm.DTO;
using TicketJam.WinForm.Stubs;

namespace TicketJam.WinForm
{
    public partial class Form1 : Form
    {
        private EventDto _Event = new EventDto();
        private List<VenueDto> list = VenueStub.list;
        //Insert dependency injection for baseuri
        private EventAPIConsumer _eventAPIConsumer = new EventAPIConsumer("https://localhost:7280/api/v1/EventControllerAPI");
        private VenueAPIConsumer _venueAPIConsumer = new VenueAPIConsumer("https://localhost:7280/api/VenueControllerAPI");

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
            _Event.Name = txtNameWrite.Text;
            VenueDto tempObject = (VenueDto)comboBoxVenueList.SelectedItem;
            _Event.VenueId = tempObject.Id;

            //TODO
            //FIX THIS SO NOT HARD CODED
            _Event.OrganizerId = OrganizerStub.Organizer.OrganizerId;

            _eventAPIConsumer.AddEvent(_Event);
        }

        private void btnCreateOrganizer_Click(object sender, EventArgs e)
        {
            OpenCreateOrganizerWindow();
        }

        private void OpenCreateOrganizerWindow()
        {
            RegisterOrganizer registerOrganizer = new RegisterOrganizer();
            registerOrganizer.ShowDialog();
            registerOrganizer.Dispose();
        }
    }
}
