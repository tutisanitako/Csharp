namespace CinemaForms
{
    partial class Form1
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
        /// 
        private void InitializeComponent()
        {
            this.IDTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.updateButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.deleteButton = new System.Windows.Forms.Button();
            this.createButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TicketsTextBox = new System.Windows.Forms.TextBox();
            this.UserComboBox = new System.Windows.Forms.ComboBox();
            this.ShowtimeComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.MovieTextBox = new System.Windows.Forms.TextBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.ClearButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // IDTextBox
            // 
            this.IDTextBox.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 11.25F);
            this.IDTextBox.Location = new System.Drawing.Point(45, 118);
            this.IDTextBox.Name = "IDTextBox";
            this.IDTextBox.Size = new System.Drawing.Size(121, 26);
            this.IDTextBox.TabIndex = 48;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 11.25F);
            this.label4.Location = new System.Drawing.Point(42, 339);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 18);
            this.label4.TabIndex = 46;
            this.label4.Text = "Tickets";
            // 
            // updateButton
            // 
            this.updateButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(108)))), ((int)(((byte)(187)))));
            this.updateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.updateButton.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.updateButton.Location = new System.Drawing.Point(221, 198);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(135, 38);
            this.updateButton.TabIndex = 44;
            this.updateButton.Text = "Modify Booking";
            this.updateButton.UseVisualStyleBackColor = false;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(108)))), ((int)(((byte)(187)))));
            this.dataGridView1.Location = new System.Drawing.Point(412, 86);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(443, 251);
            this.dataGridView1.TabIndex = 43;
            // 
            // deleteButton
            // 
            this.deleteButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(108)))), ((int)(((byte)(187)))));
            this.deleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteButton.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 12F);
            this.deleteButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.deleteButton.Location = new System.Drawing.Point(221, 254);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(135, 38);
            this.deleteButton.TabIndex = 42;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = false;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // createButton
            // 
            this.createButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(108)))), ((int)(((byte)(187)))));
            this.createButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createButton.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 12F);
            this.createButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.createButton.Location = new System.Drawing.Point(221, 145);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(135, 38);
            this.createButton.TabIndex = 41;
            this.createButton.Text = "Book";
            this.createButton.UseVisualStyleBackColor = false;
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(42, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 18);
            this.label3.TabIndex = 40;
            this.label3.Text = "BookingID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 11.25F);
            this.label2.Location = new System.Drawing.Point(42, 217);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 18);
            this.label2.TabIndex = 39;
            this.label2.Text = "Showtimes";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 11.25F);
            this.label1.Location = new System.Drawing.Point(42, 158);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 18);
            this.label1.TabIndex = 38;
            this.label1.Text = "User";
            // 
            // TicketsTextBox
            // 
            this.TicketsTextBox.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 11.25F);
            this.TicketsTextBox.Location = new System.Drawing.Point(45, 360);
            this.TicketsTextBox.Name = "TicketsTextBox";
            this.TicketsTextBox.Size = new System.Drawing.Size(121, 26);
            this.TicketsTextBox.TabIndex = 36;
            // 
            // UserComboBox
            // 
            this.UserComboBox.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 11.25F);
            this.UserComboBox.FormattingEnabled = true;
            this.UserComboBox.Location = new System.Drawing.Point(45, 177);
            this.UserComboBox.Name = "UserComboBox";
            this.UserComboBox.Size = new System.Drawing.Size(121, 26);
            this.UserComboBox.TabIndex = 49;
            // 
            // ShowtimeComboBox
            // 
            this.ShowtimeComboBox.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 11.25F);
            this.ShowtimeComboBox.FormattingEnabled = true;
            this.ShowtimeComboBox.Location = new System.Drawing.Point(45, 238);
            this.ShowtimeComboBox.Name = "ShowtimeComboBox";
            this.ShowtimeComboBox.Size = new System.Drawing.Size(121, 26);
            this.ShowtimeComboBox.TabIndex = 50;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 11.25F);
            this.label5.Location = new System.Drawing.Point(42, 278);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 18);
            this.label5.TabIndex = 53;
            this.label5.Text = "Movie Title";
            // 
            // MovieTextBox
            // 
            this.MovieTextBox.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 11.25F);
            this.MovieTextBox.Location = new System.Drawing.Point(45, 299);
            this.MovieTextBox.Name = "MovieTextBox";
            this.MovieTextBox.Size = new System.Drawing.Size(121, 26);
            this.MovieTextBox.TabIndex = 54;
            // 
            // dataGridView2
            // 
            this.dataGridView2.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(108)))), ((int)(((byte)(187)))));
            this.dataGridView2.Location = new System.Drawing.Point(184, 52);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(543, 45);
            this.dataGridView2.TabIndex = 55;
            // 
            // ClearButton
            // 
            this.ClearButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(108)))), ((int)(((byte)(187)))));
            this.ClearButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClearButton.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 12F);
            this.ClearButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClearButton.Location = new System.Drawing.Point(221, 308);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(135, 38);
            this.ClearButton.TabIndex = 56;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = false;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(403, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 23);
            this.label6.TabIndex = 57;
            this.label6.Text = "About Movie:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(378, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(175, 29);
            this.label7.TabIndex = 57;
            this.label7.Text = "Manage Bookings";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(189)))), ((int)(((byte)(225)))));
            this.panel1.Controls.Add(this.dataGridView2);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(-12, 461);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(926, 202);
            this.panel1.TabIndex = 58;
            // 
            // dataGridView3
            // 
            this.dataGridView3.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(108)))), ((int)(((byte)(187)))));
            this.dataGridView3.Location = new System.Drawing.Point(412, 219);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.Size = new System.Drawing.Size(443, 203);
            this.dataGridView3.TabIndex = 59;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(894, 594);
            this.Controls.Add(this.dataGridView3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.MovieTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ShowtimeComboBox);
            this.Controls.Add(this.UserComboBox);
            this.Controls.Add(this.IDTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TicketsTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox IDTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TicketsTextBox;
        private System.Windows.Forms.ComboBox UserComboBox;
        private System.Windows.Forms.ComboBox ShowtimeComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox MovieTextBox;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView3;
    }
}

