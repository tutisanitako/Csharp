using System.Drawing;
using System.Windows.Forms;
using System;

namespace Homework3
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblRules1;
        private System.Windows.Forms.Label lblRules2;
        private System.Windows.Forms.Label lblDailyInfo;
        private System.Windows.Forms.Label lblEmailInfo;
        private System.Windows.Forms.Label lblLinkStats;
        private System.Windows.Forms.LinkLabel lnkSignUp;
        private System.Windows.Forms.LinkLabel lnkAccount;
        private System.Windows.Forms.Panel pnlSeparator;
        private System.Windows.Forms.Panel pnlAccountLink;
        private System.Windows.Forms.Panel pnlDescription;
        private System.Windows.Forms.Label lblDescriptionTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lblWelcomeUser;
        private System.Windows.Forms.Label lblExamples;
        private System.Windows.Forms.Button btnLoginRegister;
        private System.Windows.Forms.Panel pnlLogin;
        private System.Windows.Forms.LinkLabel lnkCreateAccount;
        private System.Windows.Forms.Label lblLoginError;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtLoginPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtLoginEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblLoginTitle;
        private System.Windows.Forms.Button btnCancelLogin;
        private System.Windows.Forms.Panel pnlRegister;
        private System.Windows.Forms.TextBox txtRegisterUsername;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel lnkBackToLogin;
        private System.Windows.Forms.Label lblRegisterError;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.TextBox txtRegisterPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRegisterEmail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblRegisterTitle;
        private System.Windows.Forms.Button btnCancelRegister;
        private System.Windows.Forms.Panel pnlStatistics;
        private System.Windows.Forms.Label lblStatsTitle;
        private System.Windows.Forms.Label lblPlayedLabel;
        private System.Windows.Forms.Label lblPlayed;
        private System.Windows.Forms.Label lblWinPercentLabel;
        private System.Windows.Forms.Label lblWinPercent;
        private System.Windows.Forms.Label lblCurrentStreakLabel;
        private System.Windows.Forms.Label lblCurrentStreak;
        private System.Windows.Forms.Label lblMaxStreakLabel;
        private System.Windows.Forms.Label lblMaxStreak;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnStatsBack;
        private System.Windows.Forms.Panel pnlGame;
        private System.Windows.Forms.Label lblGameTitle;
        private System.Windows.Forms.Button btnGameBack;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlDescription = new System.Windows.Forms.Panel();
            this.pnlAccountLink = new System.Windows.Forms.Panel();
            this.lblLinkStats = new System.Windows.Forms.Label();
            this.lnkAccount = new System.Windows.Forms.LinkLabel();
            this.pnlSeparator = new System.Windows.Forms.Panel();
            this.lblEmailInfo = new System.Windows.Forms.Label();
            this.lnkSignUp = new System.Windows.Forms.LinkLabel();
            this.lblDailyInfo = new System.Windows.Forms.Label();
            this.lblRules2 = new System.Windows.Forms.Label();
            this.lblRules1 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDescriptionTitle = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lblWelcomeUser = new System.Windows.Forms.Label();
            this.lblExamples = new System.Windows.Forms.Label();
            this.btnLoginRegister = new System.Windows.Forms.Button();
            this.pnlLogin = new System.Windows.Forms.Panel();
            this.lnkCreateAccount = new System.Windows.Forms.LinkLabel();
            this.lblLoginError = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtLoginPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtLoginEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblLoginTitle = new System.Windows.Forms.Label();
            this.btnCancelLogin = new System.Windows.Forms.Button();
            this.pnlRegister = new System.Windows.Forms.Panel();
            this.txtRegisterUsername = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lnkBackToLogin = new System.Windows.Forms.LinkLabel();
            this.lblRegisterError = new System.Windows.Forms.Label();
            this.btnRegister = new System.Windows.Forms.Button();
            this.txtRegisterPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRegisterEmail = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblRegisterTitle = new System.Windows.Forms.Label();
            this.btnCancelRegister = new System.Windows.Forms.Button();
            this.pnlStatistics = new System.Windows.Forms.Panel();
            this.btnStatsBack = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.lblMaxStreak = new System.Windows.Forms.Label();
            this.lblMaxStreakLabel = new System.Windows.Forms.Label();
            this.lblCurrentStreak = new System.Windows.Forms.Label();
            this.lblCurrentStreakLabel = new System.Windows.Forms.Label();
            this.lblWinPercent = new System.Windows.Forms.Label();
            this.lblWinPercentLabel = new System.Windows.Forms.Label();
            this.lblPlayed = new System.Windows.Forms.Label();
            this.lblPlayedLabel = new System.Windows.Forms.Label();
            this.lblStatsTitle = new System.Windows.Forms.Label();
            this.pnlGame = new System.Windows.Forms.Panel();
            this.btnGameBack = new System.Windows.Forms.Button();
            this.lblGameTitle = new System.Windows.Forms.Label();
            this.pnlDescription.SuspendLayout();
            this.pnlAccountLink.SuspendLayout();
            this.pnlLogin.SuspendLayout();
            this.pnlRegister.SuspendLayout();
            this.pnlStatistics.SuspendLayout();
            this.pnlGame.SuspendLayout();
            this.SuspendLayout();

            // pnlDescription
            this.pnlDescription.BackColor = System.Drawing.Color.White;
            this.pnlDescription.Controls.Add(this.pnlAccountLink);
            this.pnlDescription.Controls.Add(this.pnlSeparator);
            this.pnlDescription.Controls.Add(this.lblEmailInfo);
            this.pnlDescription.Controls.Add(this.lnkSignUp);
            this.pnlDescription.Controls.Add(this.lblDailyInfo);
            this.pnlDescription.Controls.Add(this.lblRules2);
            this.pnlDescription.Controls.Add(this.lblRules1);
            this.pnlDescription.Controls.Add(this.label1);
            this.pnlDescription.Controls.Add(this.lblDescriptionTitle);
            this.pnlDescription.Controls.Add(this.btnLogout);
            this.pnlDescription.Controls.Add(this.lblWelcomeUser);
            this.pnlDescription.Controls.Add(this.lblExamples);
            this.pnlDescription.Controls.Add(this.btnLoginRegister);
            this.pnlDescription.Location = new System.Drawing.Point(12, 12);
            this.pnlDescription.Name = "pnlDescription";
            this.pnlDescription.Size = new System.Drawing.Size(632, 547);
            this.pnlDescription.TabIndex = 0;

            // pnlAccountLink
            this.pnlAccountLink.Controls.Add(this.lblLinkStats);
            this.pnlAccountLink.Controls.Add(this.lnkAccount);
            this.pnlAccountLink.Location = new System.Drawing.Point(15, 445);
            this.pnlAccountLink.Name = "pnlAccountLink";
            this.pnlAccountLink.Size = new System.Drawing.Size(550, 30);
            this.pnlAccountLink.TabIndex = 19;

            // lblLinkStats
            this.lblLinkStats.AutoSize = true;
            this.lblLinkStats.Font = new System.Drawing.Font("Arial", 12F);
            this.lblLinkStats.Location = new System.Drawing.Point(286, 5);
            this.lblLinkStats.Name = "lblLinkStats";
            this.lblLinkStats.Size = new System.Drawing.Size(126, 18);
            this.lblLinkStats.TabIndex = 2;
            this.lblLinkStats.Text = " to link your stats.";

            // lnkAccount
            this.lnkAccount.AutoSize = true;
            this.lnkAccount.Font = new System.Drawing.Font("Arial", 12F);
            this.lnkAccount.Location = new System.Drawing.Point(11, 5);
            this.lnkAccount.Name = "lnkAccount";
            this.lnkAccount.Size = new System.Drawing.Size(252, 18);
            this.lnkAccount.TabIndex = 1;
            this.lnkAccount.TabStop = true;
            this.lnkAccount.Text = "Log in or create a free NYT account";
            this.lnkAccount.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAccount_LinkClicked);

            // pnlSeparator
            this.pnlSeparator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSeparator.Location = new System.Drawing.Point(15, 475);
            this.pnlSeparator.Name = "pnlSeparator";
            this.pnlSeparator.Size = new System.Drawing.Size(550, 1);
            this.pnlSeparator.TabIndex = 18;

            // lblEmailInfo
            this.lblEmailInfo.Font = new System.Drawing.Font("Arial", 12F);
            this.lblEmailInfo.Location = new System.Drawing.Point(460, 495);
            this.lblEmailInfo.Name = "lblEmailInfo";
            this.lblEmailInfo.Size = new System.Drawing.Size(200, 20);
            this.lblEmailInfo.TabIndex = 17;
            this.lblEmailInfo.Text = " for our daily reminder email.";

            // lnkSignUp
            this.lnkSignUp.Font = new System.Drawing.Font("Arial", 12F);
            this.lnkSignUp.Location = new System.Drawing.Point(406, 495);
            this.lnkSignUp.Name = "lnkSignUp";
            this.lnkSignUp.Size = new System.Drawing.Size(70, 20);
            this.lnkSignUp.TabIndex = 16;
            this.lnkSignUp.TabStop = true;
            this.lnkSignUp.Text = "sign up";
            this.lnkSignUp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSignUp_LinkClicked);

            // lblDailyInfo
            this.lblDailyInfo.Font = new System.Drawing.Font("Arial", 12F);
            this.lblDailyInfo.Location = new System.Drawing.Point(15, 495);
            this.lblDailyInfo.Name = "lblDailyInfo";
            this.lblDailyInfo.Size = new System.Drawing.Size(411, 40);
            this.lblDailyInfo.TabIndex = 15;
            this.lblDailyInfo.Text = "A new puzzle is released daily at midnight. If you haven\'t already, you can";

            // lblRules2
            this.lblRules2.AutoSize = true;
            this.lblRules2.Font = new System.Drawing.Font("Arial", 12F);
            this.lblRules2.Location = new System.Drawing.Point(23, 125);
            this.lblRules2.Name = "lblRules2";
            this.lblRules2.Size = new System.Drawing.Size(561, 18);
            this.lblRules2.TabIndex = 14;
            this.lblRules2.Text = "• The color of the tiles will change to show how close your guess was to the word.";

            // lblRules1
            this.lblRules1.AutoSize = true;
            this.lblRules1.Font = new System.Drawing.Font("Arial", 12F);
            this.lblRules1.Location = new System.Drawing.Point(23, 100);
            this.lblRules1.Name = "lblRules1";
            this.lblRules1.Size = new System.Drawing.Size(302, 18);
            this.lblRules1.TabIndex = 13;
            this.lblRules1.Text = "• Each guess must be a valid 5-letter word.";

            // label1
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14F);
            this.label1.Location = new System.Drawing.Point(23, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(245, 22);
            this.label1.TabIndex = 12;
            this.label1.Text = "Guess the Wordle in 6 tries.";

            // lblDescriptionTitle
            this.lblDescriptionTitle.AutoSize = true;
            this.lblDescriptionTitle.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold);
            this.lblDescriptionTitle.Location = new System.Drawing.Point(23, 20);
            this.lblDescriptionTitle.Name = "lblDescriptionTitle";
            this.lblDescriptionTitle.Size = new System.Drawing.Size(203, 37);
            this.lblDescriptionTitle.TabIndex = 11;
            this.lblDescriptionTitle.Text = "How To Play";

            // btnLogout
            this.btnLogout.Location = new System.Drawing.Point(488, 13);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(95, 28);
            this.btnLogout.TabIndex = 10;
            this.btnLogout.Text = "Log Out";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);

            // lblWelcomeUser
            this.lblWelcomeUser.AutoSize = true;
            this.lblWelcomeUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcomeUser.Location = new System.Drawing.Point(336, 19);
            this.lblWelcomeUser.Name = "lblWelcomeUser";
            this.lblWelcomeUser.Size = new System.Drawing.Size(126, 15);
            this.lblWelcomeUser.TabIndex = 9;
            this.lblWelcomeUser.Text = "Welcome, Username!";

            // lblExamples
            this.lblExamples.AutoSize = true;
            this.lblExamples.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExamples.Location = new System.Drawing.Point(23, 160);
            this.lblExamples.Name = "lblExamples";
            this.lblExamples.Size = new System.Drawing.Size(84, 19);
            this.lblExamples.TabIndex = 8;
            this.lblExamples.Text = "Examples";

            // btnLoginRegister
            this.btnLoginRegister.Location = new System.Drawing.Point(250, 400);
            this.btnLoginRegister.Name = "btnLoginRegister";
            this.btnLoginRegister.Size = new System.Drawing.Size(150, 30);
            this.btnLoginRegister.TabIndex = 20;
            this.btnLoginRegister.Text = "Login / Register";
            this.btnLoginRegister.UseVisualStyleBackColor = true;
            this.btnLoginRegister.Click += new System.EventHandler(this.btnLoginRegister_Click);

            // pnlLogin
            this.pnlLogin.Controls.Add(this.lnkCreateAccount);
            this.pnlLogin.Controls.Add(this.lblLoginError);
            this.pnlLogin.Controls.Add(this.btnLogin);
            this.pnlLogin.Controls.Add(this.txtLoginPassword);
            this.pnlLogin.Controls.Add(this.lblPassword);
            this.pnlLogin.Controls.Add(this.txtLoginEmail);
            this.pnlLogin.Controls.Add(this.lblEmail);
            this.pnlLogin.Controls.Add(this.lblLoginTitle);
            this.pnlLogin.Controls.Add(this.btnCancelLogin);
            this.pnlLogin.Location = new System.Drawing.Point(12, 12);
            this.pnlLogin.Name = "pnlLogin";
            this.pnlLogin.Size = new System.Drawing.Size(632, 547);
            this.pnlLogin.TabIndex = 1;

            // lnkCreateAccount
            this.lnkCreateAccount.AutoSize = true;
            this.lnkCreateAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkCreateAccount.Location = new System.Drawing.Point(237, 391);
            this.lnkCreateAccount.Name = "lnkCreateAccount";
            this.lnkCreateAccount.Size = new System.Drawing.Size(180, 15);
            this.lnkCreateAccount.TabIndex = 8;
            this.lnkCreateAccount.TabStop = true;
            this.lnkCreateAccount.Text = "Don\'t have an account? Sign up";
            this.lnkCreateAccount.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCreateAccount_Click);

            // lblLoginError
            this.lblLoginError.AutoSize = true;
            this.lblLoginError.ForeColor = System.Drawing.Color.Red;
            this.lblLoginError.Location = new System.Drawing.Point(181, 280);
            this.lblLoginError.Name = "lblLoginError";
            this.lblLoginError.Size = new System.Drawing.Size(139, 13);
            this.lblLoginError.TabIndex = 7;
            this.lblLoginError.Text = "Error message appears here";
            this.lblLoginError.Visible = false;

            // btnLogin
            this.btnLogin.BackColor = System.Drawing.Color.Black;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(181, 306);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(284, 40);
            this.btnLogin.TabIndex = 6;
            this.btnLogin.Text = "Continue";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);

            // txtLoginPassword
            this.txtLoginPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLoginPassword.Location = new System.Drawing.Point(181, 245);
            this.txtLoginPassword.Name = "txtLoginPassword";
            this.txtLoginPassword.PasswordChar = '*';
            this.txtLoginPassword.Size = new System.Drawing.Size(284, 23);
            this.txtLoginPassword.TabIndex = 5;

            // lblPassword
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(181, 225);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(69, 17);
            this.lblPassword.TabIndex = 4;
            this.lblPassword.Text = "Password";

            // txtLoginEmail
            this.txtLoginEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLoginEmail.Location = new System.Drawing.Point(181, 195);
            this.txtLoginEmail.Name = "txtLoginEmail";
            this.txtLoginEmail.Size = new System.Drawing.Size(284, 23);
            this.txtLoginEmail.TabIndex = 3;

            // lblEmail
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(181, 175);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(98, 17);
            this.lblEmail.TabIndex = 2;
            this.lblEmail.Text = "Email Address";

            // lblLoginTitle
            this.lblLoginTitle.AutoSize = true;
            this.lblLoginTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoginTitle.Location = new System.Drawing.Point(180, 117);
            this.lblLoginTitle.Name = "lblLoginTitle";
            this.lblLoginTitle.Size = new System.Drawing.Size(266, 24);
            this.lblLoginTitle.TabIndex = 1;
            this.lblLoginTitle.Text = "Log in or create an account";

            // btnCancelLogin
            this.btnCancelLogin.Location = new System.Drawing.Point(587, 14);
            this.btnCancelLogin.Name = "btnCancelLogin";
            this.btnCancelLogin.Size = new System.Drawing.Size(35, 23);
            this.btnCancelLogin.TabIndex = 0;
            this.btnCancelLogin.Text = "X";
            this.btnCancelLogin.UseVisualStyleBackColor = true;
            this.btnCancelLogin.Click += new System.EventHandler(this.btnCancel_Click);

            // pnlRegister
            this.pnlRegister.Controls.Add(this.txtRegisterUsername);
            this.pnlRegister.Controls.Add(this.label2);
            this.pnlRegister.Controls.Add(this.lnkBackToLogin);
            this.pnlRegister.Controls.Add(this.lblRegisterError);
            this.pnlRegister.Controls.Add(this.btnRegister);
            this.pnlRegister.Controls.Add(this.txtRegisterPassword);
            this.pnlRegister.Controls.Add(this.label3);
            this.pnlRegister.Controls.Add(this.txtRegisterEmail);
            this.pnlRegister.Controls.Add(this.label4);
            this.pnlRegister.Controls.Add(this.lblRegisterTitle);
            this.pnlRegister.Controls.Add(this.btnCancelRegister);
            this.pnlRegister.Location = new System.Drawing.Point(12, 12);
            this.pnlRegister.Name = "pnlRegister";
            this.pnlRegister.Size = new System.Drawing.Size(632, 541);
            this.pnlRegister.TabIndex = 9;

            // txtRegisterUsername
            this.txtRegisterUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRegisterUsername.Location = new System.Drawing.Point(178, 187);
            this.txtRegisterUsername.Name = "txtRegisterUsername";
            this.txtRegisterUsername.Size = new System.Drawing.Size(284, 23);
            this.txtRegisterUsername.TabIndex = 10;

            // label2
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(178, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Username";

            // lnkBackToLogin
            this.lnkBackToLogin.AutoSize = true;
            this.lnkBackToLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkBackToLogin.Location = new System.Drawing.Point(234, 412);
            this.lnkBackToLogin.Name = "lnkBackToLogin";
            this.lnkBackToLogin.Size = new System.Drawing.Size(183, 15);
            this.lnkBackToLogin.TabIndex = 10;
            this.lnkBackToLogin.TabStop = true;
            this.lnkBackToLogin.Text = "Already have an account? Log in";
            this.lnkBackToLogin.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkBackToLogin_Click);

            // lblRegisterError
            this.lblRegisterError.AutoSize = true;
            this.lblRegisterError.ForeColor = System.Drawing.Color.Red;
            this.lblRegisterError.Location = new System.Drawing.Point(178, 320);
            this.lblRegisterError.Name = "lblRegisterError";
            this.lblRegisterError.Size = new System.Drawing.Size(139, 13);
            this.lblRegisterError.TabIndex = 7;
            this.lblRegisterError.Text = "Error message appears here";
            this.lblRegisterError.Visible = false;

            // btnRegister
            this.btnRegister.BackColor = System.Drawing.Color.Black;
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegister.ForeColor = System.Drawing.Color.White;
            this.btnRegister.Location = new System.Drawing.Point(178, 346);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(284, 40);
            this.btnRegister.TabIndex = 6;
            this.btnRegister.Text = "Create Account";
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);

            // txtRegisterPassword
            this.txtRegisterPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRegisterPassword.Location = new System.Drawing.Point(178, 285);
            this.txtRegisterPassword.Name = "txtRegisterPassword";
            this.txtRegisterPassword.PasswordChar = '*';
            this.txtRegisterPassword.Size = new System.Drawing.Size(284, 23);
            this.txtRegisterPassword.TabIndex = 5;

            // label3
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(178, 265);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Password";

            // txtRegisterEmail
            this.txtRegisterEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRegisterEmail.Location = new System.Drawing.Point(178, 236);
            this.txtRegisterEmail.Name = "txtRegisterEmail";
            this.txtRegisterEmail.Size = new System.Drawing.Size(284, 23);
            this.txtRegisterEmail.TabIndex = 3;

            // label4
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(178, 216);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "Email Address";

            // lblRegisterTitle
            this.lblRegisterTitle.AutoSize = true;
            this.lblRegisterTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegisterTitle.Location = new System.Drawing.Point(177, 95);
            this.lblRegisterTitle.Name = "lblRegisterTitle";
            this.lblRegisterTitle.Size = new System.Drawing.Size(240, 24);
            this.lblRegisterTitle.TabIndex = 1;
            this.lblRegisterTitle.Text = "Create your free account";

            // btnCancelRegister
            this.btnCancelRegister.Location = new System.Drawing.Point(587, 9);
            this.btnCancelRegister.Name = "btnCancelRegister";
            this.btnCancelRegister.Size = new System.Drawing.Size(35, 23);
            this.btnCancelRegister.TabIndex = 0;
            this.btnCancelRegister.Text = "X";
            this.btnCancelRegister.UseVisualStyleBackColor = true;
            this.btnCancelRegister.Click += new System.EventHandler(this.btnCancel_Click);

            // pnlStatistics
            this.pnlStatistics.Controls.Add(this.btnStatsBack);
            this.pnlStatistics.Controls.Add(this.btnPlay);
            this.pnlStatistics.Controls.Add(this.lblMaxStreak);
            this.pnlStatistics.Controls.Add(this.lblMaxStreakLabel);
            this.pnlStatistics.Controls.Add(this.lblCurrentStreak);
            this.pnlStatistics.Controls.Add(this.lblCurrentStreakLabel);
            this.pnlStatistics.Controls.Add(this.lblWinPercent);
            this.pnlStatistics.Controls.Add(this.lblWinPercentLabel);
            this.pnlStatistics.Controls.Add(this.lblPlayed);
            this.pnlStatistics.Controls.Add(this.lblPlayedLabel);
            this.pnlStatistics.Controls.Add(this.lblStatsTitle);
            this.pnlStatistics.Location = new System.Drawing.Point(12, 12);
            this.pnlStatistics.Name = "pnlStatistics";
            this.pnlStatistics.Size = new System.Drawing.Size(632, 547);
            this.pnlStatistics.TabIndex = 10;

            // btnStatsBack
            this.btnStatsBack.Location = new System.Drawing.Point(587, 14);
            this.btnStatsBack.Name = "btnStatsBack";
            this.btnStatsBack.Size = new System.Drawing.Size(35, 23);
            this.btnStatsBack.TabIndex = 10;
            this.btnStatsBack.Text = "X";
            this.btnStatsBack.UseVisualStyleBackColor = true;
            this.btnStatsBack.Click += new System.EventHandler(this.btnStatsBack_Click);

            // btnPlay
            this.btnPlay.Location = new System.Drawing.Point(250, 400);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(150, 30);
            this.btnPlay.TabIndex = 9;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);

            // lblMaxStreak
            this.lblMaxStreak.AutoSize = true;
            this.lblMaxStreak.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold);
            this.lblMaxStreak.Location = new System.Drawing.Point(500, 150);
            this.lblMaxStreak.Name = "lblMaxStreak";
            this.lblMaxStreak.Size = new System.Drawing.Size(30, 37);
            this.lblMaxStreak.TabIndex = 8;
            this.lblMaxStreak.Text = "0";

            // lblMaxStreakLabel
            this.lblMaxStreakLabel.AutoSize = true;
            this.lblMaxStreakLabel.Font = new System.Drawing.Font("Arial", 12F);
            this.lblMaxStreakLabel.Location = new System.Drawing.Point(480, 190);
            this.lblMaxStreakLabel.Name = "lblMaxStreakLabel";
            this.lblMaxStreakLabel.Size = new System.Drawing.Size(81, 18);
            this.lblMaxStreakLabel.TabIndex = 7;
            this.lblMaxStreakLabel.Text = "Max Streak";

            // lblCurrentStreak
            this.lblCurrentStreak.AutoSize = true;
            this.lblCurrentStreak.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold);
            this.lblCurrentStreak.Location = new System.Drawing.Point(350, 150);
            this.lblCurrentStreak.Name = "lblCurrentStreak";
            this.lblCurrentStreak.Size = new System.Drawing.Size(30, 37);
            this.lblCurrentStreak.TabIndex = 6;
            this.lblCurrentStreak.Text = "0";

            // lblCurrentStreakLabel
            this.lblCurrentStreakLabel.AutoSize = true;
            this.lblCurrentStreakLabel.Font = new System.Drawing.Font("Arial", 12F);
            this.lblCurrentStreakLabel.Location = new System.Drawing.Point(330, 190);
            this.lblCurrentStreakLabel.Name = "lblCurrentStreakLabel";
            this.lblCurrentStreakLabel.Size = new System.Drawing.Size(88, 18);
            this.lblCurrentStreakLabel.TabIndex = 5;
            this.lblCurrentStreakLabel.Text = "Current Streak";

            // lblWinPercent
            this.lblWinPercent.AutoSize = true;
            this.lblWinPercent.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold);
            this.lblWinPercent.Location = new System.Drawing.Point(200, 150);
            this.lblWinPercent.Name = "lblWinPercent";
            this.lblWinPercent.Size = new System.Drawing.Size(30, 37);
            this.lblWinPercent.TabIndex = 4;
            this.lblWinPercent.Text = "0";

            // lblWinPercentLabel
            this.lblWinPercentLabel.AutoSize = true;
            this.lblWinPercentLabel.Font = new System.Drawing.Font("Arial", 12F);
            this.lblWinPercentLabel.Location = new System.Drawing.Point(190, 190);
            this.lblWinPercentLabel.Name = "lblWinPercentLabel";
            this.lblWinPercentLabel.Size = new System.Drawing.Size(61, 18);
            this.lblWinPercentLabel.TabIndex = 3;
            this.lblWinPercentLabel.Text = "Win %";

            // lblPlayed
            this.lblPlayed.AutoSize = true;
            this.lblPlayed.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold);
            this.lblPlayed.Location = new System.Drawing.Point(70, 150);
            this.lblPlayed.Name = "lblPlayed";
            this.lblPlayed.Size = new System.Drawing.Size(30, 37);
            this.lblPlayed.TabIndex = 2;
            this.lblPlayed.Text = "0";

            // lblPlayedLabel
            this.lblPlayedLabel.AutoSize = true;
            this.lblPlayedLabel.Font = new System.Drawing.Font("Arial", 12F);
            this.lblPlayedLabel.Location = new System.Drawing.Point(60, 190);
            this.lblPlayedLabel.Name = "lblPlayedLabel";
            this.lblPlayedLabel.Size = new System.Drawing.Size(53, 18);
            this.lblPlayedLabel.TabIndex = 1;
            this.lblPlayedLabel.Text = "Played";

            // lblStatsTitle
            this.lblStatsTitle.AutoSize = true;
            this.lblStatsTitle.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold);
            this.lblStatsTitle.Location = new System.Drawing.Point(250, 50);
            this.lblStatsTitle.Name = "lblStatsTitle";
            this.lblStatsTitle.Size = new System.Drawing.Size(150, 37);
            this.lblStatsTitle.TabIndex = 0;
            this.lblStatsTitle.Text = "Statistics";

            // pnlGame
            this.pnlGame.Controls.Add(this.btnGameBack);
            this.pnlGame.Controls.Add(this.lblGameTitle);
            this.pnlGame.Location = new System.Drawing.Point(12, 12);
            this.pnlGame.Name = "pnlGame";
            this.pnlGame.Size = new System.Drawing.Size(632, 547);
            this.pnlGame.TabIndex = 11;

            // btnGameBack
            this.btnGameBack.Location = new System.Drawing.Point(587, 14);
            this.btnGameBack.Name = "btnGameBack";
            this.btnGameBack.Size = new System.Drawing.Size(35, 23);
            this.btnGameBack.TabIndex = 1;
            this.btnGameBack.Text = "X";
            this.btnGameBack.UseVisualStyleBackColor = true;
            this.btnGameBack.Click += new System.EventHandler(this.btnGameBack_Click);

            // lblGameTitle
            this.lblGameTitle.AutoSize = true;
            this.lblGameTitle.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold);
            this.lblGameTitle.Location = new System.Drawing.Point(250, 20);
            this.lblGameTitle.Name = "lblGameTitle";
            this.lblGameTitle.Size = new System.Drawing.Size(120, 37);
            this.lblGameTitle.TabIndex = 0;
            this.lblGameTitle.Text = "Wordle";

            // Game Grid
            int tileSize = 50;
            int spacing = 5;
            int startX = 200;
            int startY = 70;
            for (int row = 0; row < 6; row++)
            {
                for (int col = 0; col < 5; col++)
                {
                    Panel tile = new Panel();
                    tile.Size = new Size(tileSize, tileSize);
                    tile.Location = new Point(startX + col * (tileSize + spacing), startY + row * (tileSize + spacing));
                    tile.BorderStyle = BorderStyle.FixedSingle;
                    tile.BackColor = Color.White;

                    Label lblLetter = new Label();
                    lblLetter.Font = new Font("Arial", 16, FontStyle.Bold);
                    lblLetter.AutoSize = false;
                    lblLetter.Size = new Size(tileSize, tileSize);
                    lblLetter.TextAlign = ContentAlignment.MiddleCenter;
                    lblLetter.BackColor = Color.Transparent;

                    tile.Controls.Add(lblLetter);
                    this.pnlGame.Controls.Add(tile);
                    _gridLabels.Add(lblLetter);
                }
            }

            // Keyboard
            string[] rows = new string[] { "QWERTYUIOP", "ASDFGHJKL", "ZXCVBNM" };
            int keyboardStartY = 400;
            int keySize = 40;
            int keySpacing = 5;
            for (int row = 0; row < rows.Length; row++)
            {
                int rowLength = rows[row].Length;
                int rowStartX = 200 + (10 - rowLength) * (keySize + keySpacing) / 2;
                for (int col = 0; col < rowLength; col++)
                {
                    Button btn = new Button();
                    btn.Size = new Size(keySize, keySize);
                    btn.Location = new Point(rowStartX + col * (keySize + keySpacing), keyboardStartY + row * (keySize + keySpacing));
                    btn.Text = rows[row][col].ToString();
                    btn.Font = new Font("Arial", 12, FontStyle.Bold);
                    btn.Click += new EventHandler(this.KeyboardButton_Click);
                    this.pnlGame.Controls.Add(btn);
                    _keyboardButtons.Add(rows[row][col], btn);
                }
            }

            // Enter and Backspace Buttons
            Button btnEnter = new Button();
            btnEnter.Size = new Size(60, keySize);
            btnEnter.Location = new Point(120, keyboardStartY + 2 * (keySize + keySpacing));
            btnEnter.Text = "ENTER";
            btnEnter.Font = new Font("Arial", 10, FontStyle.Bold);
            btnEnter.Click += new EventHandler(this.KeyboardButton_Click);
            this.pnlGame.Controls.Add(btnEnter);

            Button btnBackspace = new Button();
            btnBackspace.Size = new Size(60, keySize);
            btnBackspace.Location = new Point(500, keyboardStartY + 2 * (keySize + keySpacing));
            btnBackspace.Text = "⌫";
            btnBackspace.Font = new Font("Arial", 12, FontStyle.Bold);
            btnBackspace.Click += new EventHandler(this.KeyboardButton_Click);
            this.pnlGame.Controls.Add(btnBackspace);

            // Form1
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 565);
            this.Controls.Add(this.pnlGame);
            this.Controls.Add(this.pnlStatistics);
            this.Controls.Add(this.pnlRegister);
            this.Controls.Add(this.pnlLogin);
            this.Controls.Add(this.pnlDescription);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Wordle Game";
            this.pnlDescription.ResumeLayout(false);
            this.pnlDescription.PerformLayout();
            this.pnlAccountLink.ResumeLayout(false);
            this.pnlAccountLink.PerformLayout();
            this.pnlLogin.ResumeLayout(false);
            this.pnlLogin.PerformLayout();
            this.pnlRegister.ResumeLayout(false);
            this.pnlRegister.PerformLayout();
            this.pnlStatistics.ResumeLayout(false);
            this.pnlStatistics.PerformLayout();
            this.pnlGame.ResumeLayout(false);
            this.pnlGame.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}