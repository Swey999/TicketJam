﻿using System;
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
        private OrganizerAPIConsumer _organizerAPIConsumer = new OrganizerAPIConsumer("https://localhost:7280/api/v1/Organizer", "https://localhost:7280/api/v1/Login");

        public OrganizerLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            btnLoginClicked();
        }
        /// <summary>
        /// Sends login information for validation in database
        /// TODO: Implement encryption in transfer
        /// </summary>
        private void btnLoginClicked()
        {
            OrganizerDto organizerDto = new OrganizerDto();
            //Setting all values here although only email and password will be used otherwise JSON header fails in API contact
            organizerDto.Password = txtPasswordWrite.Text;
            organizerDto.Email = txtUsernameWrite.Text;
            organizerDto.PhoneNo = "";
            organizerDto.Id = 0;

            try
            {
                organizerDto = _organizerAPIConsumer.Login(organizerDto);
            }
            catch (Exception)
            {
                MessageBox.Show("Wrong password or email, please try again", "Login fail!", MessageBoxButtons.OK);
                return;
            }
            if (organizerDto.Email == "")
            {
                MessageBox.Show("Wrong password or email, please try again", "Login fail!", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Login succesful!");
                CreateEvent createEvent = new CreateEvent(organizerDto);
                createEvent.Show();
            }
        }

        private void btnNotAlreadyRegistered_Click(object sender, EventArgs e)
        {
            NotAlreadyRegistedClicked();
        }

        /// <summary>
        /// Redirects to Register Organizer
        /// </summary>
        private void NotAlreadyRegistedClicked()
        {
            RegisterOrganizer registerOrganizer = new RegisterOrganizer();
            registerOrganizer.ShowDialog();
            registerOrganizer.Dispose();
        }
    }
}
