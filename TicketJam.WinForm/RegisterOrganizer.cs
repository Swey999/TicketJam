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
        //TODO: Add dependency injection
        private OrganizerAPIConsumer _organizerAPIConsumer = new OrganizerAPIConsumer("https://localhost:7280/api/v1/Organizer", "https://localhost:7280/api/v1/Login");
        public RegisterOrganizer()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            PressedBtnSubmit();
        }

        /// <summary>
        /// Creates a new organizer and sends to database for hashing and salting of password
        /// TODO: Encryption for password in transfer
        /// </summary>
        private void PressedBtnSubmit()
        {
            //Check if all information is filled out
            if (txtEmailWrite.Text == "" || txtPhoneNoWrite.Text == "" || txtPasswordWrite.Text == "")
            {
                MessageBox.Show("Please fill out all fields", "Please fill out all fields", MessageBoxButtons.OK);
                return;
            }

            //Check if email is in valid format
            try
            {
                var mailAddress = new MailAddress(txtEmailWrite.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Not a valid email", "Email is not correct format", MessageBoxButtons.OK);
                return;
            }

            //Set organizerDto information
            OrganizerDto organizerDto = new OrganizerDto();
            organizerDto.Email = txtEmailWrite.Text;
            organizerDto.PhoneNo = txtPhoneNoWrite.Text;
            organizerDto.Password = txtPasswordWrite.Text;

            //Adds organizer to database
            _organizerAPIConsumer.AddOrganizer(organizerDto);

            //Display to show success
            MessageBox.Show("Account created!", "Account created!", MessageBoxButtons.OK);

            //Redirects to login and removes this window
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
