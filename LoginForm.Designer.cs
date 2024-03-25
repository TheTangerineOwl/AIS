using System.Windows.Forms;

namespace AIS
{
    partial class LoginForm
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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Panel versionPanel;
            System.Windows.Forms.Panel appnamePanel;
            System.Windows.Forms.Panel panel2;
            this.versionLabel = new System.Windows.Forms.Label();
            this.appLabel = new System.Windows.Forms.Label();
            this.loginBox = new System.Windows.Forms.TextBox();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.capsStatus = new System.Windows.Forms.Label();
            this.languageLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            versionPanel = new System.Windows.Forms.Panel();
            appnamePanel = new System.Windows.Forms.Panel();
            panel2 = new System.Windows.Forms.Panel();
            versionPanel.SuspendLayout();
            appnamePanel.SuspendLayout();
            panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(11, 139);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(153, 20);
            label1.TabIndex = 0;
            label1.Text = "Имя пользователя";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(11, 192);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(67, 20);
            label2.TabIndex = 2;
            label2.Text = "Пароль";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(192, 8);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(294, 20);
            label3.TabIndex = 4;
            label3.Text = "Введите имя пользователя и пароль";
            label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(21, 8);
            label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(99, 20);
            label6.TabIndex = 10;
            label6.Text = "Язык ввода";
            // 
            // versionPanel
            // 
            versionPanel.BackColor = System.Drawing.Color.Yellow;
            versionPanel.Controls.Add(this.versionLabel);
            versionPanel.Location = new System.Drawing.Point(78, 40);
            versionPanel.Margin = new System.Windows.Forms.Padding(4);
            versionPanel.Name = "versionPanel";
            versionPanel.Size = new System.Drawing.Size(424, 28);
            versionPanel.TabIndex = 13;
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.Location = new System.Drawing.Point(308, 8);
            this.versionLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(116, 20);
            this.versionLabel.TabIndex = 5;
            this.versionLabel.Text = "Версия 1.0.0.0";
            this.versionLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // appnamePanel
            // 
            appnamePanel.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            appnamePanel.Controls.Add(this.appLabel);
            appnamePanel.Location = new System.Drawing.Point(78, 4);
            appnamePanel.Margin = new System.Windows.Forms.Padding(4);
            appnamePanel.Name = "appnamePanel";
            appnamePanel.Size = new System.Drawing.Size(424, 28);
            appnamePanel.TabIndex = 14;
            // 
            // appLabel
            // 
            this.appLabel.AutoSize = true;
            this.appLabel.Location = new System.Drawing.Point(382, 8);
            this.appLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.appLabel.Name = "appLabel";
            this.appLabel.Size = new System.Drawing.Size(42, 20);
            this.appLabel.TabIndex = 6;
            this.appLabel.Text = "АИС";
            this.appLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // panel2
            // 
            panel2.BackColor = System.Drawing.Color.FloralWhite;
            panel2.Controls.Add(label3);
            panel2.Location = new System.Drawing.Point(16, 76);
            panel2.Margin = new System.Windows.Forms.Padding(4);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(486, 28);
            panel2.TabIndex = 14;
            // 
            // loginBox
            // 
            this.loginBox.Location = new System.Drawing.Point(183, 133);
            this.loginBox.Margin = new System.Windows.Forms.Padding(4);
            this.loginBox.Name = "loginBox";
            this.loginBox.Size = new System.Drawing.Size(319, 26);
            this.loginBox.TabIndex = 1;
            this.loginBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CapsStatus_OnKeyDown);
            // 
            // passwordBox
            // 
            this.passwordBox.Location = new System.Drawing.Point(183, 186);
            this.passwordBox.Margin = new System.Windows.Forms.Padding(4);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.PasswordChar = '*';
            this.passwordBox.Size = new System.Drawing.Size(319, 26);
            this.passwordBox.TabIndex = 3;
            this.passwordBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CapsStatus_OnKeyDown);
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(39, 233);
            this.loginButton.Margin = new System.Windows.Forms.Padding(4);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(96, 31);
            this.loginButton.TabIndex = 7;
            this.loginButton.Text = "Вход";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(406, 233);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(4);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(96, 31);
            this.cancelButton.TabIndex = 8;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.capsStatus);
            this.panel1.Controls.Add(this.languageLabel);
            this.panel1.Controls.Add(label6);
            this.panel1.Location = new System.Drawing.Point(-8, 272);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(526, 51);
            this.panel1.TabIndex = 9;
            // 
            // capsStatus
            // 
            this.capsStatus.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.capsStatus.Cursor = System.Windows.Forms.Cursors.Default;
            this.capsStatus.Location = new System.Drawing.Point(308, 9);
            this.capsStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.capsStatus.Name = "capsStatus";
            this.capsStatus.Size = new System.Drawing.Size(214, 19);
            this.capsStatus.TabIndex = 12;
            // 
            // languageLabel
            // 
            this.languageLabel.AutoSize = true;
            this.languageLabel.Location = new System.Drawing.Point(118, 8);
            this.languageLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.languageLabel.Name = "languageLabel";
            this.languageLabel.Size = new System.Drawing.Size(147, 20);
            this.languageLabel.TabIndex = 11;
            this.languageLabel.Text = "Английский (США)";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::AIS.Properties.Resources.keypic;
            this.pictureBox1.Location = new System.Drawing.Point(15, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(63, 65);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(519, 312);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(panel2);
            this.Controls.Add(appnamePanel);
            this.Controls.Add(versionPanel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.passwordBox);
            this.Controls.Add(label2);
            this.Controls.Add(this.loginBox);
            this.Controls.Add(label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "LoginForm";
            this.Text = "Вход";
            this.InputLanguageChanged += new System.Windows.Forms.InputLanguageChangedEventHandler(this.LanguageLabel_InputLanguageChanged);
            versionPanel.ResumeLayout(false);
            versionPanel.PerformLayout();
            appnamePanel.ResumeLayout(false);
            appnamePanel.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private TextBox loginBox;
        private TextBox passwordBox;
        private Label versionLabel;
        private Label appLabel;
        private Button loginButton;
        private Button cancelButton;
        private Panel panel1;
        private Label capsStatus;
        private Label languageLabel;
        private PictureBox pictureBox1;
    }
}