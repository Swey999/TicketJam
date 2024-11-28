using TicketJam.WinForm.ApiClient;
using TicketJam.WinForm.DTO;
using TicketJam.WinForm.Stubs;

namespace TicketJam.WinForm
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtVenueReadText = new TextBox();
            btnCreateNewVenue = new Button();
            comboBoxVenueList = new ComboBox();
            txtDescriptionWrite = new TextBox();
            txtDescriptionRead = new TextBox();
            txtTicketAmountRead = new TextBox();
            txtTicketAmountWrite = new TextBox();
            dateTimePickerStartDateWrite = new DateTimePicker();
            dateTimePickerEndDateWrite = new DateTimePicker();
            txtStartDateRead = new TextBox();
            txtEndDateRead = new TextBox();
            txtLoggedInAsRead = new TextBox();
            txtLoggedInAsResult = new TextBox();
            btnSubmitEvent = new Button();
            txtNameReadOnly = new TextBox();
            txtNameWrite = new TextBox();
            txtTicketTypeSelectRead = new TextBox();
            btnCreateTicketType = new Button();
            SuspendLayout();
            // 
            // txtVenueReadText
            // 
            txtVenueReadText.Location = new Point(10, 86);
            txtVenueReadText.Margin = new Padding(3, 2, 3, 2);
            txtVenueReadText.Name = "txtVenueReadText";
            txtVenueReadText.ReadOnly = true;
            txtVenueReadText.Size = new Size(44, 23);
            txtVenueReadText.TabIndex = 0;
            txtVenueReadText.Text = "Venue";
            // 
            // btnCreateNewVenue
            // 
            btnCreateNewVenue.Location = new Point(60, 85);
            btnCreateNewVenue.Margin = new Padding(3, 2, 3, 2);
            btnCreateNewVenue.Name = "btnCreateNewVenue";
            btnCreateNewVenue.Size = new Size(82, 22);
            btnCreateNewVenue.TabIndex = 1;
            btnCreateNewVenue.Text = "Create new venue";
            btnCreateNewVenue.UseVisualStyleBackColor = true;
            // 
            // comboBoxVenueList
            // 
            comboBoxVenueList.DisplayMember = "Name";
            comboBoxVenueList.FormattingEnabled = true;
            comboBoxVenueList.Location = new Point(147, 86);
            comboBoxVenueList.Margin = new Padding(3, 2, 3, 2);
            comboBoxVenueList.Name = "comboBoxVenueList";
            comboBoxVenueList.Size = new Size(133, 23);
            comboBoxVenueList.TabIndex = 2;
            comboBoxVenueList.ValueMember = "Id";
            // 
            // txtDescriptionWrite
            // 
            txtDescriptionWrite.Location = new Point(91, 225);
            txtDescriptionWrite.Margin = new Padding(3, 2, 3, 2);
            txtDescriptionWrite.Name = "txtDescriptionWrite";
            txtDescriptionWrite.Size = new Size(189, 23);
            txtDescriptionWrite.TabIndex = 3;
            // 
            // txtDescriptionRead
            // 
            txtDescriptionRead.Location = new Point(10, 225);
            txtDescriptionRead.Margin = new Padding(3, 2, 3, 2);
            txtDescriptionRead.Name = "txtDescriptionRead";
            txtDescriptionRead.ReadOnly = true;
            txtDescriptionRead.Size = new Size(76, 23);
            txtDescriptionRead.TabIndex = 4;
            txtDescriptionRead.Text = "Description";
            // 
            // txtTicketAmountRead
            // 
            txtTicketAmountRead.Location = new Point(10, 260);
            txtTicketAmountRead.Margin = new Padding(3, 2, 3, 2);
            txtTicketAmountRead.Name = "txtTicketAmountRead";
            txtTicketAmountRead.ReadOnly = true;
            txtTicketAmountRead.Size = new Size(145, 23);
            txtTicketAmountRead.TabIndex = 5;
            txtTicketAmountRead.Text = "Total Amount of Tickets";
            // 
            // txtTicketAmountWrite
            // 
            txtTicketAmountWrite.Location = new Point(10, 285);
            txtTicketAmountWrite.Margin = new Padding(3, 2, 3, 2);
            txtTicketAmountWrite.Name = "txtTicketAmountWrite";
            txtTicketAmountWrite.Size = new Size(110, 23);
            txtTicketAmountWrite.TabIndex = 6;
            // 
            // dateTimePickerStartDateWrite
            // 
            dateTimePickerStartDateWrite.Location = new Point(10, 332);
            dateTimePickerStartDateWrite.Margin = new Padding(3, 2, 3, 2);
            dateTimePickerStartDateWrite.Name = "dateTimePickerStartDateWrite";
            dateTimePickerStartDateWrite.Size = new Size(219, 23);
            dateTimePickerStartDateWrite.TabIndex = 7;
            // 
            // dateTimePickerEndDateWrite
            // 
            dateTimePickerEndDateWrite.Location = new Point(10, 383);
            dateTimePickerEndDateWrite.Margin = new Padding(3, 2, 3, 2);
            dateTimePickerEndDateWrite.Name = "dateTimePickerEndDateWrite";
            dateTimePickerEndDateWrite.Size = new Size(219, 23);
            dateTimePickerEndDateWrite.TabIndex = 8;
            // 
            // txtStartDateRead
            // 
            txtStartDateRead.Location = new Point(10, 310);
            txtStartDateRead.Margin = new Padding(3, 2, 3, 2);
            txtStartDateRead.Name = "txtStartDateRead";
            txtStartDateRead.ReadOnly = true;
            txtStartDateRead.Size = new Size(110, 23);
            txtStartDateRead.TabIndex = 9;
            txtStartDateRead.Text = "Start Date";
            // 
            // txtEndDateRead
            // 
            txtEndDateRead.Location = new Point(10, 359);
            txtEndDateRead.Margin = new Padding(3, 2, 3, 2);
            txtEndDateRead.Name = "txtEndDateRead";
            txtEndDateRead.ReadOnly = true;
            txtEndDateRead.Size = new Size(110, 23);
            txtEndDateRead.TabIndex = 10;
            txtEndDateRead.Text = "End Date";
            txtEndDateRead.UseWaitCursor = true;
            // 
            // txtLoggedInAsRead
            // 
            txtLoggedInAsRead.Location = new Point(388, 9);
            txtLoggedInAsRead.Margin = new Padding(3, 2, 3, 2);
            txtLoggedInAsRead.Name = "txtLoggedInAsRead";
            txtLoggedInAsRead.ReadOnly = true;
            txtLoggedInAsRead.Size = new Size(110, 23);
            txtLoggedInAsRead.TabIndex = 11;
            txtLoggedInAsRead.Text = "Logged in as: ";
            // 
            // txtLoggedInAsResult
            // 
            txtLoggedInAsResult.Location = new Point(503, 9);
            txtLoggedInAsResult.Margin = new Padding(3, 2, 3, 2);
            txtLoggedInAsResult.Name = "txtLoggedInAsResult";
            txtLoggedInAsResult.ReadOnly = true;
            txtLoggedInAsResult.Size = new Size(110, 23);
            txtLoggedInAsResult.TabIndex = 12;
            txtLoggedInAsResult.TextChanged += txtLoggedInAsResult_TextChanged;
            // 
            // btnSubmitEvent
            // 
            btnSubmitEvent.Location = new Point(564, 374);
            btnSubmitEvent.Margin = new Padding(3, 2, 3, 2);
            btnSubmitEvent.Name = "btnSubmitEvent";
            btnSubmitEvent.Size = new Size(82, 22);
            btnSubmitEvent.TabIndex = 13;
            btnSubmitEvent.Text = "Submit";
            btnSubmitEvent.UseVisualStyleBackColor = true;
            btnSubmitEvent.Click += btnSubmitEvent_Click;
            // 
            // txtNameReadOnly
            // 
            txtNameReadOnly.Location = new Point(10, 21);
            txtNameReadOnly.Margin = new Padding(3, 2, 3, 2);
            txtNameReadOnly.Name = "txtNameReadOnly";
            txtNameReadOnly.ReadOnly = true;
            txtNameReadOnly.Size = new Size(132, 23);
            txtNameReadOnly.TabIndex = 14;
            txtNameReadOnly.Text = "Name of your event";
            // 
            // txtNameWrite
            // 
            txtNameWrite.Location = new Point(10, 46);
            txtNameWrite.Margin = new Padding(3, 2, 3, 2);
            txtNameWrite.Name = "txtNameWrite";
            txtNameWrite.Size = new Size(110, 23);
            txtNameWrite.TabIndex = 15;
            // 
            // txtTicketTypeSelectRead
            // 
            txtTicketTypeSelectRead.Location = new Point(12, 135);
            txtTicketTypeSelectRead.Name = "txtTicketTypeSelectRead";
            txtTicketTypeSelectRead.ReadOnly = true;
            txtTicketTypeSelectRead.Size = new Size(100, 23);
            txtTicketTypeSelectRead.TabIndex = 16;
            txtTicketTypeSelectRead.Text = "Ticket type";
            // 
            // btnCreateTicketType
            // 
            btnCreateTicketType.Location = new Point(17, 170);
            btnCreateTicketType.Name = "btnCreateTicketType";
            btnCreateTicketType.Size = new Size(112, 23);
            btnCreateTicketType.TabIndex = 17;
            btnCreateTicketType.Text = "Create new ticket";
            btnCreateTicketType.UseVisualStyleBackColor = true;
            btnCreateTicketType.Click += btnCreateTicketType_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 424);
            Controls.Add(btnCreateTicketType);
            Controls.Add(txtTicketTypeSelectRead);
            Controls.Add(txtNameWrite);
            Controls.Add(txtNameReadOnly);
            Controls.Add(btnSubmitEvent);
            Controls.Add(txtLoggedInAsResult);
            Controls.Add(txtLoggedInAsRead);
            Controls.Add(txtEndDateRead);
            Controls.Add(txtStartDateRead);
            Controls.Add(dateTimePickerEndDateWrite);
            Controls.Add(dateTimePickerStartDateWrite);
            Controls.Add(txtTicketAmountWrite);
            Controls.Add(txtTicketAmountRead);
            Controls.Add(txtDescriptionRead);
            Controls.Add(txtDescriptionWrite);
            Controls.Add(comboBoxVenueList);
            Controls.Add(btnCreateNewVenue);
            Controls.Add(txtVenueReadText);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtVenueReadText;
        private Button btnCreateNewVenue;
        private ComboBox comboBoxVenueList;
        private BindingSource venueBindingSource;
        private BindingSource venueBindingSource1;
        private TextBox txtDescriptionWrite;
        private TextBox txtDescriptionRead;
        private TextBox txtTicketAmountRead;
        private TextBox txtTicketAmountWrite;
        private DateTimePicker dateTimePickerStartDateWrite;
        private DateTimePicker dateTimePickerEndDateWrite;
        private TextBox txtStartDateRead;
        private TextBox txtEndDateRead;
        private TextBox txtLoggedInAsRead;
        private TextBox txtLoggedInAsResult;
        private Button btnSubmitEvent;
        private TextBox txtNameReadOnly;
        private TextBox txtNameWrite;
        private Button btnCreateTicketType;
        private TextBox txtTicketTypeSelectRead;
    }
}
