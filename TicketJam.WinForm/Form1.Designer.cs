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
            components = new System.ComponentModel.Container();
            txtVenueReadText = new TextBox();
            btnCreateNewVenue = new Button();
            comboBoxVenueList = new ComboBox();
            venueBindingSource1 = new BindingSource(components);
            venueBindingSource = new BindingSource(components);
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
            ((System.ComponentModel.ISupportInitialize)venueBindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)venueBindingSource).BeginInit();
            SuspendLayout();
            // 
            // txtVenueReadText
            // 
            txtVenueReadText.Location = new Point(12, 114);
            txtVenueReadText.Name = "txtVenueReadText";
            txtVenueReadText.ReadOnly = true;
            txtVenueReadText.Size = new Size(50, 27);
            txtVenueReadText.TabIndex = 0;
            txtVenueReadText.Text = "Venue";
            // 
            // btnCreateNewVenue
            // 
            btnCreateNewVenue.Location = new Point(68, 113);
            btnCreateNewVenue.Name = "btnCreateNewVenue";
            btnCreateNewVenue.Size = new Size(94, 29);
            btnCreateNewVenue.TabIndex = 1;
            btnCreateNewVenue.Text = "Create new venue";
            btnCreateNewVenue.UseVisualStyleBackColor = true;
            // 
            // comboBoxVenueList
            // 
            comboBoxVenueList.FormattingEnabled = true;
            comboBoxVenueList.Items.AddRange(new object[] { "Gigantium" });
            comboBoxVenueList.Location = new Point(168, 114);
            comboBoxVenueList.Name = "comboBoxVenueList";
            comboBoxVenueList.Size = new Size(151, 28);
            comboBoxVenueList.TabIndex = 2;
            comboBoxVenueList.SelectedIndexChanged += comboBoxVenueList_SelectedIndexChanged;
            comboBoxVenueList.DataSource = VenueStub.list;
            // 
            // txtDescriptionWrite
            // 
            txtDescriptionWrite.Location = new Point(104, 160);
            txtDescriptionWrite.Name = "txtDescriptionWrite";
            txtDescriptionWrite.Size = new Size(215, 27);
            txtDescriptionWrite.TabIndex = 3;
            // 
            // txtDescriptionRead
            // 
            txtDescriptionRead.Location = new Point(12, 160);
            txtDescriptionRead.Name = "txtDescriptionRead";
            txtDescriptionRead.ReadOnly = true;
            txtDescriptionRead.Size = new Size(86, 27);
            txtDescriptionRead.TabIndex = 4;
            txtDescriptionRead.Text = "Description";
            // 
            // txtTicketAmountRead
            // 
            txtTicketAmountRead.Location = new Point(12, 207);
            txtTicketAmountRead.Name = "txtTicketAmountRead";
            txtTicketAmountRead.ReadOnly = true;
            txtTicketAmountRead.Size = new Size(165, 27);
            txtTicketAmountRead.TabIndex = 5;
            txtTicketAmountRead.Text = "Total Amount of Tickets";
            // 
            // txtTicketAmountWrite
            // 
            txtTicketAmountWrite.Location = new Point(12, 240);
            txtTicketAmountWrite.Name = "txtTicketAmountWrite";
            txtTicketAmountWrite.Size = new Size(125, 27);
            txtTicketAmountWrite.TabIndex = 6;
            // 
            // dateTimePickerStartDateWrite
            // 
            dateTimePickerStartDateWrite.Location = new Point(12, 303);
            dateTimePickerStartDateWrite.Name = "dateTimePickerStartDateWrite";
            dateTimePickerStartDateWrite.Size = new Size(250, 27);
            dateTimePickerStartDateWrite.TabIndex = 7;
            // 
            // dateTimePickerEndDateWrite
            // 
            dateTimePickerEndDateWrite.Location = new Point(12, 371);
            dateTimePickerEndDateWrite.Name = "dateTimePickerEndDateWrite";
            dateTimePickerEndDateWrite.Size = new Size(250, 27);
            dateTimePickerEndDateWrite.TabIndex = 8;
            // 
            // txtStartDateRead
            // 
            txtStartDateRead.Location = new Point(12, 273);
            txtStartDateRead.Name = "txtStartDateRead";
            txtStartDateRead.ReadOnly = true;
            txtStartDateRead.Size = new Size(125, 27);
            txtStartDateRead.TabIndex = 9;
            txtStartDateRead.Text = "Start Date";
            // 
            // txtEndDateRead
            // 
            txtEndDateRead.Location = new Point(12, 338);
            txtEndDateRead.Name = "txtEndDateRead";
            txtEndDateRead.ReadOnly = true;
            txtEndDateRead.Size = new Size(125, 27);
            txtEndDateRead.TabIndex = 10;
            txtEndDateRead.Text = "End Date";
            txtEndDateRead.UseWaitCursor = true;
            // 
            // txtLoggedInAsRead
            // 
            txtLoggedInAsRead.Location = new Point(444, 12);
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
            txtLoggedInAsResult.Text = OrganizerStub.Organizer.ToString();
            // 
            // btnSubmitEvent
            // 
            btnSubmitEvent.Location = new Point(645, 359);
            btnSubmitEvent.Name = "btnSubmitEvent";
            btnSubmitEvent.Size = new Size(94, 29);
            btnSubmitEvent.TabIndex = 13;
            btnSubmitEvent.Text = "Submit";
            btnSubmitEvent.UseVisualStyleBackColor = true;
            btnSubmitEvent.Click += btnSubmitEvent_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)venueBindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)venueBindingSource).EndInit();
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
    }
}
