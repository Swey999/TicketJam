namespace TicketJam.WinForm
{
    partial class RegisterOrganizer
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
            txtEmailReadOnly = new TextBox();
            txtEmailWrite = new TextBox();
            txtPhoneNoReadOnly = new TextBox();
            txtPhoneNoWrite = new TextBox();
            txtPasswordWrite = new TextBox();
            txtPasswordReadOnly = new TextBox();
            btnSubmit = new Button();
            SuspendLayout();
            // 
            // txtEmailReadOnly
            // 
            txtEmailReadOnly.Location = new Point(10, 27);
            txtEmailReadOnly.Margin = new Padding(3, 2, 3, 2);
            txtEmailReadOnly.Name = "txtEmailReadOnly";
            txtEmailReadOnly.ReadOnly = true;
            txtEmailReadOnly.Size = new Size(110, 23);
            txtEmailReadOnly.TabIndex = 0;
            txtEmailReadOnly.Text = "Email";
            // 
            // txtEmailWrite
            // 
            txtEmailWrite.Location = new Point(10, 52);
            txtEmailWrite.Margin = new Padding(3, 2, 3, 2);
            txtEmailWrite.Name = "txtEmailWrite";
            txtEmailWrite.Size = new Size(110, 23);
            txtEmailWrite.TabIndex = 1;
            txtEmailWrite.TextChanged += txtEmailWrite_TextChanged;
            // 
            // txtPhoneNoReadOnly
            // 
            txtPhoneNoReadOnly.Location = new Point(10, 88);
            txtPhoneNoReadOnly.Margin = new Padding(3, 2, 3, 2);
            txtPhoneNoReadOnly.Name = "txtPhoneNoReadOnly";
            txtPhoneNoReadOnly.ReadOnly = true;
            txtPhoneNoReadOnly.Size = new Size(110, 23);
            txtPhoneNoReadOnly.TabIndex = 2;
            txtPhoneNoReadOnly.Text = "Phone number";
            // 
            // txtPhoneNoWrite
            // 
            txtPhoneNoWrite.Location = new Point(10, 112);
            txtPhoneNoWrite.Margin = new Padding(3, 2, 3, 2);
            txtPhoneNoWrite.Name = "txtPhoneNoWrite";
            txtPhoneNoWrite.Size = new Size(110, 23);
            txtPhoneNoWrite.TabIndex = 3;
            // 
            // txtPasswordWrite
            // 
            txtPasswordWrite.Location = new Point(10, 178);
            txtPasswordWrite.Margin = new Padding(3, 2, 3, 2);
            txtPasswordWrite.Name = "txtPasswordWrite";
            txtPasswordWrite.Size = new Size(110, 23);
            txtPasswordWrite.TabIndex = 4;
            // 
            // txtPasswordReadOnly
            // 
            txtPasswordReadOnly.Location = new Point(10, 153);
            txtPasswordReadOnly.Margin = new Padding(3, 2, 3, 2);
            txtPasswordReadOnly.Name = "txtPasswordReadOnly";
            txtPasswordReadOnly.ReadOnly = true;
            txtPasswordReadOnly.Size = new Size(110, 23);
            txtPasswordReadOnly.TabIndex = 5;
            txtPasswordReadOnly.Text = "Password";
            // 
            // btnSubmit
            // 
            btnSubmit.Location = new Point(316, 124);
            btnSubmit.Margin = new Padding(3, 2, 3, 2);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(82, 22);
            btnSubmit.TabIndex = 6;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = true;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // RegisterOrganizer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(btnSubmit);
            Controls.Add(txtPasswordReadOnly);
            Controls.Add(txtPasswordWrite);
            Controls.Add(txtPhoneNoWrite);
            Controls.Add(txtPhoneNoReadOnly);
            Controls.Add(txtEmailWrite);
            Controls.Add(txtEmailReadOnly);
            Margin = new Padding(3, 2, 3, 2);
            Name = "RegisterOrganizer";
            Text = "RegisterOrganizer";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtEmailReadOnly;
        private TextBox txtEmailWrite;
        private TextBox txtPhoneNoReadOnly;
        private TextBox txtPhoneNoWrite;
        private TextBox txtPasswordWrite;
        private TextBox txtPasswordReadOnly;
        private Button btnSubmit;
    }
}