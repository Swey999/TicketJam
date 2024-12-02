using TicketJam.WinForm.ApiClient;
using TicketJam.WinForm.DTO;
using TicketJam.WinForm.Stubs;

namespace TicketJam.WinForm
{
    partial class CreateEvent
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
            lstBoxTicket = new ListBox();
            comboBoxVenueList.DataSource = _venueAPIConsumer.GetVenues();
            SuspendLayout();
            // 
            // txtVenueReadText
            // 
            txtVenueReadText.Location = new Point(11, 115);
            txtVenueReadText.Name = "txtVenueReadText";
            txtVenueReadText.ReadOnly = true;
            txtVenueReadText.Size = new Size(50, 27);
            txtVenueReadText.TabIndex = 0;
            txtVenueReadText.Text = "Venue";
            // 
            // btnCreateNewVenue
            // 
            btnCreateNewVenue.Location = new Point(69, 113);
            btnCreateNewVenue.Name = "btnCreateNewVenue";
            btnCreateNewVenue.Size = new Size(94, 29);
            btnCreateNewVenue.TabIndex = 1;
            btnCreateNewVenue.Text = "Create new venue";
            btnCreateNewVenue.UseVisualStyleBackColor = true;
            // 
            // comboBoxVenueList
            // 
            comboBoxVenueList.DisplayMember = "Name";
            comboBoxVenueList.FormattingEnabled = true;
            comboBoxVenueList.Location = new Point(168, 115);
            comboBoxVenueList.Name = "comboBoxVenueList";
            comboBoxVenueList.Size = new Size(151, 28);
            comboBoxVenueList.TabIndex = 2;
            comboBoxVenueList.ValueMember = "Id";
            // 
            // txtDescriptionWrite
            // 
            txtDescriptionWrite.Location = new Point(104, 300);
            txtDescriptionWrite.Name = "txtDescriptionWrite";
            txtDescriptionWrite.Size = new Size(215, 27);
            txtDescriptionWrite.TabIndex = 3;
            // 
            // txtDescriptionRead
            // 
            txtDescriptionRead.Location = new Point(11, 300);
            txtDescriptionRead.Name = "txtDescriptionRead";
            txtDescriptionRead.ReadOnly = true;
            txtDescriptionRead.Size = new Size(86, 27);
            txtDescriptionRead.TabIndex = 4;
            txtDescriptionRead.Text = "Description";
            // 
            // txtTicketAmountRead
            // 
            txtTicketAmountRead.Location = new Point(11, 347);
            txtTicketAmountRead.Name = "txtTicketAmountRead";
            txtTicketAmountRead.ReadOnly = true;
            txtTicketAmountRead.Size = new Size(165, 27);
            txtTicketAmountRead.TabIndex = 5;
            txtTicketAmountRead.Text = "Total Amount of Tickets";
            // 
            // txtTicketAmountWrite
            // 
            txtTicketAmountWrite.Location = new Point(11, 380);
            txtTicketAmountWrite.Name = "txtTicketAmountWrite";
            txtTicketAmountWrite.Size = new Size(125, 27);
            txtTicketAmountWrite.TabIndex = 6;
            // 
            // dateTimePickerStartDateWrite
            // 
            dateTimePickerStartDateWrite.Location = new Point(11, 443);
            dateTimePickerStartDateWrite.Name = "dateTimePickerStartDateWrite";
            dateTimePickerStartDateWrite.Size = new Size(250, 27);
            dateTimePickerStartDateWrite.TabIndex = 7;
            // 
            // dateTimePickerEndDateWrite
            // 
            dateTimePickerEndDateWrite.Location = new Point(11, 511);
            dateTimePickerEndDateWrite.Name = "dateTimePickerEndDateWrite";
            dateTimePickerEndDateWrite.Size = new Size(250, 27);
            dateTimePickerEndDateWrite.TabIndex = 8;
            // 
            // txtStartDateRead
            // 
            txtStartDateRead.Location = new Point(11, 413);
            txtStartDateRead.Name = "txtStartDateRead";
            txtStartDateRead.ReadOnly = true;
            txtStartDateRead.Size = new Size(125, 27);
            txtStartDateRead.TabIndex = 9;
            txtStartDateRead.Text = "Start Date";
            // 
            // txtEndDateRead
            // 
            txtEndDateRead.Location = new Point(11, 479);
            txtEndDateRead.Name = "txtEndDateRead";
            txtEndDateRead.ReadOnly = true;
            txtEndDateRead.Size = new Size(125, 27);
            txtEndDateRead.TabIndex = 10;
            txtEndDateRead.Text = "End Date";
            txtEndDateRead.UseWaitCursor = true;
            // 
            // txtLoggedInAsRead
            // 
            txtLoggedInAsRead.Location = new Point(443, 12);
            txtLoggedInAsRead.Name = "txtLoggedInAsRead";
            txtLoggedInAsRead.ReadOnly = true;
            txtLoggedInAsRead.Size = new Size(125, 27);
            txtLoggedInAsRead.TabIndex = 11;
            txtLoggedInAsRead.Text = "Logged in as: ";
            // 
            // txtLoggedInAsResult
            // 
            txtLoggedInAsResult.Location = new Point(575, 12);
            txtLoggedInAsResult.Name = "txtLoggedInAsResult";
            txtLoggedInAsResult.ReadOnly = true;
            txtLoggedInAsResult.Size = new Size(125, 27);
            txtLoggedInAsResult.TabIndex = 12;
            txtLoggedInAsResult.TextChanged += txtLoggedInAsResult_TextChanged;
            txtLoggedInAsResult.Text = _organizerDto.Email;
            // 
            // btnSubmitEvent
            // 
            btnSubmitEvent.Location = new Point(645, 499);
            btnSubmitEvent.Name = "btnSubmitEvent";
            btnSubmitEvent.Size = new Size(94, 29);
            btnSubmitEvent.TabIndex = 13;
            btnSubmitEvent.Text = "Submit";
            btnSubmitEvent.UseVisualStyleBackColor = true;
            btnSubmitEvent.Click += btnSubmitEvent_Click;
            // 
            // txtNameReadOnly
            // 
            txtNameReadOnly.Location = new Point(11, 28);
            txtNameReadOnly.Name = "txtNameReadOnly";
            txtNameReadOnly.ReadOnly = true;
            txtNameReadOnly.Size = new Size(150, 27);
            txtNameReadOnly.TabIndex = 14;
            txtNameReadOnly.Text = "Name of your event";
            // 
            // txtNameWrite
            // 
            txtNameWrite.Location = new Point(11, 61);
            txtNameWrite.Name = "txtNameWrite";
            txtNameWrite.Size = new Size(125, 27);
            txtNameWrite.TabIndex = 15;
            // 
            // txtTicketTypeSelectRead
            // 
            txtTicketTypeSelectRead.Location = new Point(14, 180);
            txtTicketTypeSelectRead.Margin = new Padding(3, 4, 3, 4);
            txtTicketTypeSelectRead.Name = "txtTicketTypeSelectRead";
            txtTicketTypeSelectRead.ReadOnly = true;
            txtTicketTypeSelectRead.Size = new Size(114, 27);
            txtTicketTypeSelectRead.TabIndex = 16;
            txtTicketTypeSelectRead.Text = "Ticket type";
            // 
            // btnCreateTicketType
            // 
            btnCreateTicketType.Location = new Point(19, 227);
            btnCreateTicketType.Margin = new Padding(3, 4, 3, 4);
            btnCreateTicketType.Name = "btnCreateTicketType";
            btnCreateTicketType.Size = new Size(128, 31);
            btnCreateTicketType.TabIndex = 17;
            btnCreateTicketType.Text = "Create new ticket";
            btnCreateTicketType.UseVisualStyleBackColor = true;
            btnCreateTicketType.Click += btnCreateTicketType_Click;
            // 
            // lstBoxTicket
            // 
            lstBoxTicket.FormattingEnabled = true;
            lstBoxTicket.Location = new Point(168, 180);
            lstBoxTicket.Name = "lstBoxTicket";
            lstBoxTicket.Size = new Size(121, 84);
            lstBoxTicket.TabIndex = 18;
            lstBoxTicket.DisplayMember = "TicketCategory";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 565);
            Controls.Add(lstBoxTicket);
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
            Name = "Create Event";
            Text = "Create Event";
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
        private ListBox lstBoxTicket;
    }
}
