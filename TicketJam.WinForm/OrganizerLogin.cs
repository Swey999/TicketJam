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
    public partial class OrganizerLogin : Form
    {
        private OrganizerAPIConsumer _organizerAPIConsumer = new OrganizerAPIConsumer("https://localhost:7280/api/v1/OrganizerControllerAPI", "https://localhost:7280/api/v1/LoginControllerAPI");

        public OrganizerLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            btnLoginClicked();
        }

        private void btnLoginClicked()
        {
            OrganizerDto organizerDto = new OrganizerDto();
            //Setting all values here although only email and password will be used otherwise JSON header fails in API contact
            organizerDto.Password = txtPasswordWrite.Text;
            organizerDto.Email = txtUsernameWrite.Text;
            organizerDto.PhoneNo = "";
            organizerDto.Id = 0;

            organizerDto = _organizerAPIConsumer.Login(organizerDto);
            if (organizerDto.Email == "")
            {
                MessageBox.Show("Wrong password or email, please try again", "Login fail!", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Login succesful!");
                Form1 form1 = new Form1(organizerDto);
                form1.Show();
            }
        }

        private void btnNotAlreadyRegistered_Click(object sender, EventArgs e)
        {
            NotAlreadyRegistedClicked();
        }

        private void NotAlreadyRegistedClicked()
        {
            RegisterOrganizer registerOrganizer = new RegisterOrganizer();
            registerOrganizer.ShowDialog();
            registerOrganizer.Dispose();
        }
    }
}
