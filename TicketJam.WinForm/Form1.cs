using TicketJam.WinForm.ApiClient;
using TicketJam.WinForm.DTO;
using TicketJam.WinForm.Stubs;

namespace TicketJam.WinForm
{
    public partial class Form1 : Form
    {
        private OrganizerDto _organizerDto;
        public EventDto _Event = new EventDto();
        private List<VenueDto> list = new List<VenueDto>();
        //Insert dependency injection for baseuri
        private EventAPIConsumer _eventAPIConsumer = new EventAPIConsumer("https://localhost:7280/api/v1/EventControllerAPI");
        private VenueAPIConsumer _venueAPIConsumer = new VenueAPIConsumer("https://localhost:7280/api/VenueControllerAPI");
        


        public Form1(OrganizerDto organizerDto)
        {
            _organizerDto = organizerDto;
            InitializeComponent();
            list = (List<VenueDto>)GetVenueList();
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
            _Event.StartDate = dateTimePickerStartDateWrite.Value.Date;
            _Event.EndDate = dateTimePickerEndDateWrite.Value.Date;
            _Event.Description = txtDescriptionWrite.Text;
            _Event.TotalAmount = int.Parse(txtTicketAmountWrite.Text);
            _Event.Name = txtNameWrite.Text;
            VenueDto tempObject = (VenueDto)comboBoxVenueList.SelectedItem;
            _Event.OrganizerId = _organizerDto.Id;
            _Event.VenueId = tempObject.Id;
            _eventAPIConsumer.AddEvent(_Event);
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
            cboxTicketCategory CreateTicket = new cboxTicketCategory(_Event);
            CreateTicket.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
