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
    public partial class RegisterOrganizer : Form
    {
        private OrganizerAPIConsumer _organizerAPIConsumer = new OrganizerAPIConsumer("https://localhost:7280/api/v1/OrganizerControllerAPI", "https://localhost:7280/api/v1/LoginControllerAPI");
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
            OrganizerDto organizerDto = new OrganizerDto();
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
