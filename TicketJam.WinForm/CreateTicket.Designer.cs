using TicketJam.WinForm.DTO;
using TicketJam.WinForm.Stubs;

namespace TicketJam.WinForm
{
    partial class cboxTicketCategory
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            TicketDto ticketDto1 = new TicketDto();
            TicketDto ticketDto2 = new TicketDto();
            TicketDto ticketDto3 = new TicketDto();
            lblTitle = new Label();
            lblTicketDescription = new Label();
            lblTicketCategory = new Label();
            lblPrice = new Label();
            txtTicketDescription = new TextBox();
            txtPrice = new TextBox();
            comboBoxTicketCategory = new ComboBox();
            btnSubmitTicket = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Segoe UI", 16F);
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(262, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "CREATE NEW TICKET";
            lblTitle.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblTicketDescription
            // 
            lblTicketDescription.AutoSize = true;
            lblTicketDescription.Font = new Font("Segoe UI", 13F);
            lblTicketDescription.Location = new Point(19, 93);
            lblTicketDescription.Name = "lblTicketDescription";
            lblTicketDescription.Size = new Size(139, 30);
            lblTicketDescription.TabIndex = 1;
            lblTicketDescription.Text = "Ticket Name:";
            // 
            // lblTicketCategory
            // 
            lblTicketCategory.AutoSize = true;
            lblTicketCategory.Font = new Font("Segoe UI", 13F);
            lblTicketCategory.Location = new Point(19, 219);
            lblTicketCategory.Name = "lblTicketCategory";
            lblTicketCategory.Size = new Size(170, 30);
            lblTicketCategory.TabIndex = 2;
            lblTicketCategory.Text = "Ticket Category:";
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Font = new Font("Segoe UI", 13F);
            lblPrice.Location = new Point(19, 364);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(65, 30);
            lblPrice.TabIndex = 3;
            lblPrice.Text = "Price:";
            // 
            // txtTicketDescription
            // 
            txtTicketDescription.Location = new Point(34, 131);
            txtTicketDescription.Margin = new Padding(3, 4, 3, 4);
            txtTicketDescription.Name = "txtTicketDescription";
            txtTicketDescription.Size = new Size(114, 27);
            txtTicketDescription.TabIndex = 4;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(34, 401);
            txtPrice.Margin = new Padding(3, 4, 3, 4);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(114, 27);
            txtPrice.TabIndex = 5;
            // 
            // comboBoxTicketCategory
            // 
            comboBoxTicketCategory.DisplayMember = "TicketCategory";
            comboBoxTicketCategory.FormattingEnabled = true;
            ticketDto1.Description = null;
            ticketDto1.Price = new decimal(new int[] { 0, 0, 0, 0 });
            ticketDto1.TicketCategory = "VIP";
            ticketDto1.TimeCreated = new DateTime(0L);
            ticketDto2.Description = null;
            ticketDto2.Price = new decimal(new int[] { 0, 0, 0, 0 });
            ticketDto2.TicketCategory = "Seated";
            ticketDto2.TimeCreated = new DateTime(0L);
            ticketDto3.Description = null;
            ticketDto3.Price = new decimal(new int[] { 0, 0, 0, 0 });
            ticketDto3.TicketCategory = "Standing";
            ticketDto3.TimeCreated = new DateTime(0L);
            comboBoxTicketCategory.Items.AddRange(new object[] { ticketDto1, ticketDto2, ticketDto3 });
            comboBoxTicketCategory.Location = new Point(34, 256);
            comboBoxTicketCategory.Margin = new Padding(3, 4, 3, 4);
            comboBoxTicketCategory.Name = "comboBoxTicketCategory";
            comboBoxTicketCategory.Size = new Size(138, 28);
            comboBoxTicketCategory.TabIndex = 6;
            comboBoxTicketCategory.ValueMember = "Id";
            // 
            // btnSubmitTicket
            // 
            btnSubmitTicket.Font = new Font("Segoe UI", 13F);
            btnSubmitTicket.Location = new Point(722, 491);
            btnSubmitTicket.Margin = new Padding(3, 4, 3, 4);
            btnSubmitTicket.Name = "btnSubmitTicket";
            btnSubmitTicket.Size = new Size(136, 49);
            btnSubmitTicket.TabIndex = 7;
            btnSubmitTicket.Text = "Submit";
            btnSubmitTicket.UseVisualStyleBackColor = true;
            btnSubmitTicket.Click += btnSubmitTicket_Click;
            // 
            // cboxTicketCategory
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(btnSubmitTicket);
            Controls.Add(comboBoxTicketCategory);
            Controls.Add(txtPrice);
            Controls.Add(txtTicketDescription);
            Controls.Add(lblPrice);
            Controls.Add(lblTicketCategory);
            Controls.Add(lblTicketDescription);
            Controls.Add(lblTitle);
            Margin = new Padding(3, 4, 3, 4);
            Name = "cboxTicketCategory";
            Text = "CreateTicket";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblTicketDescription;
        private Label lblTicketCategory;
        private Label lblPrice;
        private TextBox txtTicketDescription;
        private TextBox txtPrice;
        private ComboBox comboBoxTicketCategory;
        private Button btnSubmitTicket;
    }
}