using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TicketJam.WinForm.ApiClient;
using TicketJam.WinForm.DTO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace TicketJam.WinForm
{
    public partial class RegisterOrganizer : Form
    {
        private OrganizerAPIConsumer _organizerAPIConsumer = new OrganizerAPIConsumer("https://localhost:7280/api/v1/Organizer", "https://localhost:7280/api/v1/Login");
        public RegisterOrganizer()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            PressedBtnSubmit();
        }

        private void PressedBtnSubmit()
        {
            if (txtEmailWrite.Text == "" || txtPhoneNoWrite.Text == "" || txtPasswordWrite.Text == "")
            {
                MessageBox.Show("Please fill out all fields", "Please fill out all fields", MessageBoxButtons.OK);
                return;
            }
            OrganizerDto organizerDto = new OrganizerDto();
            try
            {
                var mailAddress = new MailAddress(txtEmailWrite.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Not a valid email", "Email is not correct format", MessageBoxButtons.OK);
                return;
            }
            organizerDto.Email = txtEmailWrite.Text;
            organizerDto.PhoneNo = txtPhoneNoWrite.Text;
            organizerDto.Password = txtPasswordWrite.Text;

            _organizerAPIConsumer.AddEvent(organizerDto);

            MessageBox.Show("Account created!", "Account created!", MessageBoxButtons.OK);

            OrganizerLogin organizerLogin = new OrganizerLogin();
            this.Hide();
            organizerLogin.ShowDialog();
            organizerLogin.Dispose();
            this.Dispose();
        }

        private void txtEmailWrite_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
