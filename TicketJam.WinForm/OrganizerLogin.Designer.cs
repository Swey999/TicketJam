namespace TicketJam.WinForm
{
    partial class OrganizerLogin
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
            txtUsernameReadOnly = new TextBox();
            txtUsernameWrite = new TextBox();
            txtPasswordReadOnly = new TextBox();
            txtPasswordWrite = new TextBox();
            btnLogin = new Button();
            btnNotAlreadyRegistered = new Button();
            SuspendLayout();
            // 
            // txtUsernameReadOnly
            // 
            txtUsernameReadOnly.Location = new Point(331, 99);
            txtUsernameReadOnly.Name = "txtUsernameReadOnly";
            txtUsernameReadOnly.ReadOnly = true;
            txtUsernameReadOnly.Size = new Size(125, 27);
            txtUsernameReadOnly.TabIndex = 0;
            txtUsernameReadOnly.Text = "Username";
            // 
            // txtUsernameWrite
            // 
            txtUsernameWrite.Location = new Point(331, 132);
            txtUsernameWrite.Name = "txtUsernameWrite";
            txtUsernameWrite.Size = new Size(125, 27);
            txtUsernameWrite.TabIndex = 1;
            // 
            // txtPasswordReadOnly
            // 
            txtPasswordReadOnly.Location = new Point(331, 177);
            txtPasswordReadOnly.Name = "txtPasswordReadOnly";
            txtPasswordReadOnly.ReadOnly = true;
            txtPasswordReadOnly.Size = new Size(125, 27);
            txtPasswordReadOnly.TabIndex = 2;
            txtPasswordReadOnly.Text = "Password";
            // 
            // txtPasswordWrite
            // 
            txtPasswordWrite.Location = new Point(331, 210);
            txtPasswordWrite.Name = "txtPasswordWrite";
            txtPasswordWrite.Size = new Size(125, 27);
            txtPasswordWrite.TabIndex = 3;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(344, 243);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(94, 29);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnNotAlreadyRegistered
            // 
            btnNotAlreadyRegistered.Location = new Point(316, 306);
            btnNotAlreadyRegistered.Name = "btnNotAlreadyRegistered";
            btnNotAlreadyRegistered.Size = new Size(150, 48);
            btnNotAlreadyRegistered.TabIndex = 5;
            btnNotAlreadyRegistered.Text = "Not already registered?";
            btnNotAlreadyRegistered.UseVisualStyleBackColor = true;
            btnNotAlreadyRegistered.Click += btnNotAlreadyRegistered_Click;
            // 
            // OrganizerLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnNotAlreadyRegistered);
            Controls.Add(btnLogin);
            Controls.Add(txtPasswordWrite);
            Controls.Add(txtPasswordReadOnly);
            Controls.Add(txtUsernameWrite);
            Controls.Add(txtUsernameReadOnly);
            Name = "OrganizerLogin";
            Text = "OrganizerLogin";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtUsernameReadOnly;
        private TextBox txtUsernameWrite;
        private TextBox txtPasswordReadOnly;
        private TextBox txtPasswordWrite;
        private Button btnLogin;
        private Button btnNotAlreadyRegistered;
    }
}