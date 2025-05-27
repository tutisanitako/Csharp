namespace QuizNew
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
        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageCustomers = new System.Windows.Forms.TabPage();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtCountry = new System.Windows.Forms.TextBox();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPageOrders = new System.Windows.Forms.TabPage();
            this.groupBoxOrderList = new System.Windows.Forms.GroupBox();
            this.dataGridViewOrders = new System.Windows.Forms.DataGridView();
            this.groupBoxOrderDetails = new System.Windows.Forms.GroupBox();
            this.lblOrderId = new System.Windows.Forms.Label();
            this.btnRefresh1 = new System.Windows.Forms.Button();
            this.txtOrderId = new System.Windows.Forms.TextBox();
            this.btnDelete1 = new System.Windows.Forms.Button();
            this.lblOrderNumber = new System.Windows.Forms.Label();
            this.btnUpdate1 = new System.Windows.Forms.Button();
            this.txtOrderNumber = new System.Windows.Forms.TextBox();
            this.btnAdd1 = new System.Windows.Forms.Button();
            this.lblOrderDate = new System.Windows.Forms.Label();
            this.nudTotalAmount = new System.Windows.Forms.NumericUpDown();
            this.dtpOrderDate = new System.Windows.Forms.DateTimePicker();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabPageCustomers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPageOrders.SuspendLayout();
            this.groupBoxOrderList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrders)).BeginInit();
            this.groupBoxOrderDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTotalAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageCustomers);
            this.tabControl.Controls.Add(this.tabPageOrders);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(820, 480);
            this.tabControl.TabIndex = 0;
            // 
            // tabPageCustomers
            // 
            this.tabPageCustomers.Controls.Add(this.txtPhone);
            this.tabPageCustomers.Controls.Add(this.txtCountry);
            this.tabPageCustomers.Controls.Add(this.txtCity);
            this.tabPageCustomers.Controls.Add(this.txtLastName);
            this.tabPageCustomers.Controls.Add(this.txtFirstName);
            this.tabPageCustomers.Controls.Add(this.dataGridView1);
            this.tabPageCustomers.Controls.Add(this.btnRefresh);
            this.tabPageCustomers.Controls.Add(this.btnDelete);
            this.tabPageCustomers.Controls.Add(this.btnUpdate);
            this.tabPageCustomers.Controls.Add(this.btnAdd);
            this.tabPageCustomers.Controls.Add(this.label6);
            this.tabPageCustomers.Controls.Add(this.label5);
            this.tabPageCustomers.Controls.Add(this.label4);
            this.tabPageCustomers.Controls.Add(this.label3);
            this.tabPageCustomers.Controls.Add(this.label2);
            this.tabPageCustomers.Controls.Add(this.textID);
            this.tabPageCustomers.Controls.Add(this.label1);
            this.tabPageCustomers.Location = new System.Drawing.Point(4, 22);
            this.tabPageCustomers.Name = "tabPageCustomers";
            this.tabPageCustomers.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCustomers.Size = new System.Drawing.Size(812, 454);
            this.tabPageCustomers.TabIndex = 0;
            this.tabPageCustomers.Text = "Customers";
            this.tabPageCustomers.UseVisualStyleBackColor = true;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(142, 232);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(100, 20);
            this.txtPhone.TabIndex = 25;
            // 
            // txtCountry
            // 
            this.txtCountry.Location = new System.Drawing.Point(142, 193);
            this.txtCountry.Name = "txtCountry";
            this.txtCountry.Size = new System.Drawing.Size(100, 20);
            this.txtCountry.TabIndex = 24;
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(142, 155);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(100, 20);
            this.txtCity.TabIndex = 23;
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(142, 118);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(100, 20);
            this.txtLastName.TabIndex = 22;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(142, 80);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(100, 20);
            this.txtFirstName.TabIndex = 21;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(299, 12);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(507, 436);
            this.dataGridView1.TabIndex = 20;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(186, 340);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 30);
            this.btnRefresh.TabIndex = 18;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(63, 340);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 30);
            this.btnDelete.TabIndex = 19;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(63, 289);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 30);
            this.btnAdd.TabIndex = 16;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(60, 235);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Phone";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(60, 196);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Country";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(60, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "City";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "LastName";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "FirstName";
            // 
            // textID
            // 
            this.textID.Location = new System.Drawing.Point(142, 45);
            this.textID.Name = "textID";
            this.textID.Size = new System.Drawing.Size(100, 20);
            this.textID.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "CustomerID";
            // 
            // tabPageOrders
            // 
            this.tabPageOrders.Controls.Add(this.groupBoxOrderList);
            this.tabPageOrders.Controls.Add(this.groupBoxOrderDetails);
            this.tabPageOrders.Location = new System.Drawing.Point(4, 22);
            this.tabPageOrders.Name = "tabPageOrders";
            this.tabPageOrders.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageOrders.Size = new System.Drawing.Size(812, 454);
            this.tabPageOrders.TabIndex = 1;
            this.tabPageOrders.Text = "Orders";
            this.tabPageOrders.UseVisualStyleBackColor = true;
            // 
            // groupBoxOrderList
            // 
            this.groupBoxOrderList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxOrderList.Controls.Add(this.dataGridViewOrders);
            this.groupBoxOrderList.Location = new System.Drawing.Point(6, 168);
            this.groupBoxOrderList.Name = "groupBoxOrderList";
            this.groupBoxOrderList.Size = new System.Drawing.Size(800, 280);
            this.groupBoxOrderList.TabIndex = 18;
            this.groupBoxOrderList.TabStop = false;
            this.groupBoxOrderList.Text = "Orders List";
            // 
            // dataGridViewOrders
            // 
            this.dataGridViewOrders.AllowUserToAddRows = false;
            this.dataGridViewOrders.AllowUserToDeleteRows = false;
            this.dataGridViewOrders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOrders.Location = new System.Drawing.Point(6, 19);
            this.dataGridViewOrders.MultiSelect = false;
            this.dataGridViewOrders.Name = "dataGridViewOrders";
            this.dataGridViewOrders.ReadOnly = true;
            this.dataGridViewOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewOrders.Size = new System.Drawing.Size(788, 255);
            this.dataGridViewOrders.TabIndex = 0;
            // 
            // groupBoxOrderDetails
            // 
            this.groupBoxOrderDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxOrderDetails.Controls.Add(this.lblOrderId);
            this.groupBoxOrderDetails.Controls.Add(this.btnRefresh1);
            this.groupBoxOrderDetails.Controls.Add(this.txtOrderId);
            this.groupBoxOrderDetails.Controls.Add(this.btnDelete1);
            this.groupBoxOrderDetails.Controls.Add(this.lblOrderNumber);
            this.groupBoxOrderDetails.Controls.Add(this.btnUpdate1);
            this.groupBoxOrderDetails.Controls.Add(this.txtOrderNumber);
            this.groupBoxOrderDetails.Controls.Add(this.btnAdd1);
            this.groupBoxOrderDetails.Controls.Add(this.lblOrderDate);
            this.groupBoxOrderDetails.Controls.Add(this.nudTotalAmount);
            this.groupBoxOrderDetails.Controls.Add(this.dtpOrderDate);
            this.groupBoxOrderDetails.Controls.Add(this.lblTotalAmount);
            this.groupBoxOrderDetails.Controls.Add(this.lblCustomer);
            this.groupBoxOrderDetails.Controls.Add(this.cmbCustomer);
            this.groupBoxOrderDetails.Location = new System.Drawing.Point(6, 6);
            this.groupBoxOrderDetails.Name = "groupBoxOrderDetails";
            this.groupBoxOrderDetails.Size = new System.Drawing.Size(800, 156);
            this.groupBoxOrderDetails.TabIndex = 17;
            this.groupBoxOrderDetails.TabStop = false;
            this.groupBoxOrderDetails.Text = "Order Details";
            // 
            // lblOrderId
            // 
            this.lblOrderId.AutoSize = true;
            this.lblOrderId.Location = new System.Drawing.Point(6, 25);
            this.lblOrderId.Name = "lblOrderId";
            this.lblOrderId.Size = new System.Drawing.Size(50, 13);
            this.lblOrderId.TabIndex = 1;
            this.lblOrderId.Text = "Order ID:";
            // 
            // btnRefresh1
            // 
            this.btnRefresh1.Location = new System.Drawing.Point(343, 110);
            this.btnRefresh1.Name = "btnRefresh1";
            this.btnRefresh1.Size = new System.Drawing.Size(75, 30);
            this.btnRefresh1.TabIndex = 14;
            this.btnRefresh1.Text = "Refresh";
            this.btnRefresh1.UseVisualStyleBackColor = true;
            // 
            // txtOrderId
            // 
            this.txtOrderId.Location = new System.Drawing.Point(100, 22);
            this.txtOrderId.Name = "txtOrderId";
            this.txtOrderId.Size = new System.Drawing.Size(100, 20);
            this.txtOrderId.TabIndex = 2;
            // 
            // btnDelete1
            // 
            this.btnDelete1.Location = new System.Drawing.Point(262, 110);
            this.btnDelete1.Name = "btnDelete1";
            this.btnDelete1.Size = new System.Drawing.Size(75, 30);
            this.btnDelete1.TabIndex = 13;
            this.btnDelete1.Text = "Delete";
            this.btnDelete1.UseVisualStyleBackColor = true;
            // 
            // lblOrderNumber
            // 
            this.lblOrderNumber.AutoSize = true;
            this.lblOrderNumber.Location = new System.Drawing.Point(6, 51);
            this.lblOrderNumber.Name = "lblOrderNumber";
            this.lblOrderNumber.Size = new System.Drawing.Size(76, 13);
            this.lblOrderNumber.TabIndex = 3;
            this.lblOrderNumber.Text = "Order Number:";
            // 
            // btnUpdate1
            // 
            this.btnUpdate1.Location = new System.Drawing.Point(181, 110);
            this.btnUpdate1.Name = "btnUpdate1";
            this.btnUpdate1.Size = new System.Drawing.Size(75, 30);
            this.btnUpdate1.TabIndex = 12;
            this.btnUpdate1.Text = "Update";
            this.btnUpdate1.UseVisualStyleBackColor = true;
            // 
            // txtOrderNumber
            // 
            this.txtOrderNumber.Location = new System.Drawing.Point(100, 48);
            this.txtOrderNumber.MaxLength = 10;
            this.txtOrderNumber.Name = "txtOrderNumber";
            this.txtOrderNumber.Size = new System.Drawing.Size(150, 20);
            this.txtOrderNumber.TabIndex = 4;
            // 
            // btnAdd1
            // 
            this.btnAdd1.Location = new System.Drawing.Point(100, 110);
            this.btnAdd1.Name = "btnAdd1";
            this.btnAdd1.Size = new System.Drawing.Size(75, 30);
            this.btnAdd1.TabIndex = 11;
            this.btnAdd1.Text = "Add";
            this.btnAdd1.UseVisualStyleBackColor = true;
            // 
            // lblOrderDate
            // 
            this.lblOrderDate.AutoSize = true;
            this.lblOrderDate.Location = new System.Drawing.Point(6, 77);
            this.lblOrderDate.Name = "lblOrderDate";
            this.lblOrderDate.Size = new System.Drawing.Size(62, 13);
            this.lblOrderDate.TabIndex = 5;
            this.lblOrderDate.Text = "Order Date:";
            // 
            // nudTotalAmount
            // 
            this.nudTotalAmount.DecimalPlaces = 2;
            this.nudTotalAmount.Location = new System.Drawing.Point(370, 48);
            this.nudTotalAmount.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nudTotalAmount.Name = "nudTotalAmount";
            this.nudTotalAmount.Size = new System.Drawing.Size(150, 20);
            this.nudTotalAmount.TabIndex = 10;
            this.nudTotalAmount.ThousandsSeparator = true;
            // 
            // dtpOrderDate
            // 
            this.dtpOrderDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpOrderDate.Location = new System.Drawing.Point(100, 74);
            this.dtpOrderDate.Name = "dtpOrderDate";
            this.dtpOrderDate.Size = new System.Drawing.Size(150, 20);
            this.dtpOrderDate.TabIndex = 6;
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Location = new System.Drawing.Point(300, 51);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(73, 13);
            this.lblTotalAmount.TabIndex = 9;
            this.lblTotalAmount.Text = "Total Amount:";
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(300, 25);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(54, 13);
            this.lblCustomer.TabIndex = 7;
            this.lblCustomer.Text = "Customer:";
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Location = new System.Drawing.Point(370, 22);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(300, 21);
            this.cmbCustomer.TabIndex = 8;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(186, 289);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 30);
            this.btnUpdate.TabIndex = 17;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 480);
            this.Controls.Add(this.tabControl);
            this.MinimumSize = new System.Drawing.Size(836, 519);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer & Order Management";
            this.tabControl.ResumeLayout(false);
            this.tabPageCustomers.ResumeLayout(false);
            this.tabPageCustomers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPageOrders.ResumeLayout(false);
            this.groupBoxOrderList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrders)).EndInit();
            this.groupBoxOrderDetails.ResumeLayout(false);
            this.groupBoxOrderDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTotalAmount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageCustomers;
        private System.Windows.Forms.TabPage tabPageOrders;

        // Customer controls
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtCountry;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textID;
        private System.Windows.Forms.Label label1;

        // Order controls
        private System.Windows.Forms.GroupBox groupBoxOrderList;
        private System.Windows.Forms.DataGridView dataGridViewOrders;
        private System.Windows.Forms.GroupBox groupBoxOrderDetails;
        private System.Windows.Forms.Label lblOrderId;
        private System.Windows.Forms.Button btnRefresh1;
        private System.Windows.Forms.TextBox txtOrderId;
        private System.Windows.Forms.Button btnDelete1;
        private System.Windows.Forms.Label lblOrderNumber;
        private System.Windows.Forms.Button btnUpdate1;
        private System.Windows.Forms.TextBox txtOrderNumber;
        private System.Windows.Forms.Button btnAdd1;
        private System.Windows.Forms.Label lblOrderDate;
        private System.Windows.Forms.NumericUpDown nudTotalAmount;
        private System.Windows.Forms.DateTimePicker dtpOrderDate;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.ComboBox cmbCustomer;
        private System.Windows.Forms.Button btnUpdate;
    }
}