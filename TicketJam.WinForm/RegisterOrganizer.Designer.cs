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
            txtEmailReadOnly.Location = new Point(12, 36);
            txtEmailReadOnly.Name = "txtEmailReadOnly";
            txtEmailReadOnly.ReadOnly = true;
            txtEmailReadOnly.Size = new Size(125, 27);
            txtEmailReadOnly.TabIndex = 0;
            txtEmailReadOnly.Text = "Email";
            // 
            // txtEmailWrite
            // 
            txtEmailWrite.Location = new Point(12, 69);
            txtEmailWrite.Name = "txtEmailWrite";
            txtEmailWrite.Size = new Size(125, 27);
            txtEmailWrite.TabIndex = 1;
            // 
            // txtPhoneNoReadOnly
            // 
            txtPhoneNoReadOnly.Location = new Point(12, 117);
            txtPhoneNoReadOnly.Name = "txtPhoneNoReadOnly";
            txtPhoneNoReadOnly.ReadOnly = true;
            txtPhoneNoReadOnly.Size = new Size(125, 27);
            txtPhoneNoReadOnly.TabIndex = 2;
            txtPhoneNoReadOnly.Text = "Phone number";
            // 
            // txtPhoneNoWrite
            // 
            txtPhoneNoWrite.Location = new Point(12, 150);
            txtPhoneNoWrite.Name = "txtPhoneNoWrite";
            txtPhoneNoWrite.Size = new Size(125, 27);
            txtPhoneNoWrite.TabIndex = 3;
            // 
            // txtPasswordWrite
            // 
            txtPasswordWrite.Location = new Point(12, 237);
            txtPasswordWrite.Name = "txtPasswordWrite";
            txtPasswordWrite.Size = new Size(125, 27);
            txtPasswordWrite.TabIndex = 4;
            // 
            // txtPasswordReadOnly
            // 
            txtPasswordReadOnly.Location = new Point(12, 204);
            txtPasswordReadOnly.Name = "txtPasswordReadOnly";
            txtPasswordReadOnly.ReadOnly = true;
            txtPasswordReadOnly.Size = new Size(125, 27);
            txtPasswordReadOnly.TabIndex = 5;
            txtPasswordReadOnly.Text = "Password";
            // 
            // btnSubmit
            // 
            btnSubmit.Location = new Point(361, 165);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(94, 29);
            btnSubmit.TabIndex = 6;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = true;
            // 
            // RegisterOrganizer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSubmit);
            Controls.Add(txtPasswordReadOnly);
            Controls.Add(txtPasswordWrite);
            Controls.Add(txtPhoneNoWrite);
            Controls.Add(txtPhoneNoReadOnly);
            Controls.Add(txtEmailWrite);
            Controls.Add(txtEmailReadOnly);
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