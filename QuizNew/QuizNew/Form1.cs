using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuizNew.EF;

namespace QuizNew
{
    public partial class Form1 : Form
    {
        private DataModel db;
        private int? selectedCustomerId = null;
        private int? selectedOrderId = null;

        public Form1()
        {
            InitializeComponent();

            // Initialize Entity Framework context
            db = new DataModel();

            // Configure readonly fields
            textID.ReadOnly = true;
            textID.BackColor = SystemColors.Control;
            txtOrderId.ReadOnly = true;
            txtOrderId.BackColor = SystemColors.Control;

            // Set default order date to today
            dtpOrderDate.Value = DateTime.Now;

            // Wire up event handlers
            this.Load += CombinedManagementForm_Load;

            // Customer tab events
            btnAdd.Click += BtnCustomerAdd_Click;
            btnUpdate.Click += BtnCustomerUpdate_Click;
            btnDelete.Click += BtnCustomerDelete_Click;
            btnRefresh.Click += BtnCustomerRefresh_Click;
            dataGridView1.SelectionChanged += DataGridViewCustomers_SelectionChanged;

            // Order tab events
            btnAdd1.Click += BtnOrderAdd_Click;
            btnUpdate1.Click += BtnOrderUpdate_Click;
            btnDelete1.Click += BtnOrderDelete_Click;
            btnRefresh1.Click += BtnOrderRefresh_Click;
            dataGridViewOrders.SelectionChanged += DataGridViewOrders_SelectionChanged;
            cmbCustomer.SelectedIndexChanged += CmbCustomer_SelectedIndexChanged;

            // Tab change event
            tabControl.SelectedIndexChanged += TabControl_SelectedIndexChanged;
        }

        private void CombinedManagementForm_Load(object sender, EventArgs e)
        {
            LoadCustomers();
            LoadCustomersComboBox();
            LoadOrders();
            ResetCustomerForm();
            ResetOrderForm();
        }

        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Refresh data when switching tabs
            if (tabControl.SelectedIndex == 0) // Customer tab
            {
                LoadCustomers();
            }
            else if (tabControl.SelectedIndex == 1) // Order tab
            {
                LoadCustomersComboBox();
                LoadOrders();
            }
        }

        #region Customer Management

        private void LoadCustomers()
        {
            try
            {
                var customers = db.Customers.ToList();
                dataGridView1.DataSource = customers;

                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                btnAdd.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading customers: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearCustomerForm()
        {
            textID.Clear();
            txtFirstName.Clear();
            txtLastName.Clear();
            txtCity.Clear();
            txtCountry.Clear();
            txtPhone.Clear();
            selectedCustomerId = null;
        }

        private void ResetCustomerForm()
        {
            ClearCustomerForm();
            btnAdd.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void DataGridViewCustomers_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    Customer selectedCustomer = (Customer)dataGridView1.SelectedRows[0].DataBoundItem;

                    if (selectedCustomer != null)
                    {
                        selectedCustomerId = selectedCustomer.Id;

                        textID.Text = selectedCustomer.Id.ToString();
                        txtFirstName.Text = selectedCustomer.FirstName ?? "";
                        txtLastName.Text = selectedCustomer.LastName ?? "";
                        txtCity.Text = selectedCustomer.City ?? "";
                        txtCountry.Text = selectedCustomer.Country ?? "";
                        txtPhone.Text = selectedCustomer.Phone ?? "";

                        btnAdd.Enabled = false;
                        btnUpdate.Enabled = true;
                        btnDelete.Enabled = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error selecting customer: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnCustomerAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateCustomerData())
                {
                    return;
                }

                Customer newCustomer = new Customer
                {
                    FirstName = txtFirstName.Text.Trim(),
                    LastName = txtLastName.Text.Trim(),
                    City = txtCity.Text.Trim(),
                    Country = txtCountry.Text.Trim(),
                    Phone = txtPhone.Text.Trim()
                };

                db.Customers.Add(newCustomer);
                db.SaveChanges();

                LoadCustomers();
                LoadCustomersComboBox(); // Refresh order tab combo box
                ResetCustomerForm();

                MessageBox.Show("Customer added successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding customer: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCustomerUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedCustomerId == null)
                {
                    MessageBox.Show("Please select a customer to update!", "Selection Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!ValidateCustomerData())
                {
                    return;
                }

                Customer customerToUpdate = db.Customers.Find(selectedCustomerId.Value);

                if (customerToUpdate != null)
                {
                    customerToUpdate.FirstName = txtFirstName.Text.Trim();
                    customerToUpdate.LastName = txtLastName.Text.Trim();
                    customerToUpdate.City = txtCity.Text.Trim();
                    customerToUpdate.Country = txtCountry.Text.Trim();
                    customerToUpdate.Phone = txtPhone.Text.Trim();

                    db.SaveChanges();

                    LoadCustomers();
                    LoadCustomersComboBox(); // Refresh order tab combo box
                    ResetCustomerForm();

                    MessageBox.Show("Customer updated successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Customer not found!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating customer: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCustomerDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedCustomerId == null)
                {
                    MessageBox.Show("Please select a customer to delete!", "Selection Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult result = MessageBox.Show(
                    "Are you sure you want to delete this customer?\n\nThis action cannot be undone.",
                    "Confirm Deletion",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    Customer customerToDelete = db.Customers.Find(selectedCustomerId.Value);

                    if (customerToDelete != null)
                    {
                        bool hasOrders = db.Orders.Any(o => o.CustomerId == selectedCustomerId.Value);

                        if (hasOrders)
                        {
                            MessageBox.Show(
                                "Cannot delete this customer because they have associated orders.\n" +
                                "Please delete the related orders first or contact your administrator.",
                                "Deletion Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                            return;
                        }

                        db.Customers.Remove(customerToDelete);
                        db.SaveChanges();

                        LoadCustomers();
                        LoadCustomersComboBox(); // Refresh order tab combo box
                        ResetCustomerForm();

                        MessageBox.Show("Customer deleted successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Customer not found!", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting customer: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCustomerRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                LoadCustomers();
                ResetCustomerForm();

                MessageBox.Show("Customer data refreshed successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error refreshing customer data: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateCustomerData()
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                MessageBox.Show("First Name is required!", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFirstName.Focus();
                return false;
            }

            if (txtFirstName.Text.Length > 40)
            {
                MessageBox.Show("First Name cannot exceed 40 characters!", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFirstName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("Last Name is required!", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLastName.Focus();
                return false;
            }

            if (txtLastName.Text.Length > 40)
            {
                MessageBox.Show("Last Name cannot exceed 40 characters!", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLastName.Focus();
                return false;
            }

            if (txtCity.Text.Length > 40)
            {
                MessageBox.Show("City cannot exceed 40 characters!", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCity.Focus();
                return false;
            }

            if (txtCountry.Text.Length > 40)
            {
                MessageBox.Show("Country cannot exceed 40 characters!", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCountry.Focus();
                return false;
            }

            if (!string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                string phone = txtPhone.Text.Trim();
                if (phone.Length != 9 || !phone.All(char.IsDigit))
                {
                    MessageBox.Show("Phone number must be exactly 9 digits!", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPhone.Focus();
                    return false;
                }
            }

            return true;
        }

        #endregion

        #region Order Management

        private void LoadCustomersComboBox()
        {
            try
            {
                var customers = db.Customers
                    .Select(c => new
                    {
                        Id = c.Id,
                        DisplayName = c.FirstName + " " + c.LastName + " (ID: " + c.Id + ")"
                    })
                    .OrderBy(c => c.DisplayName)
                    .ToList();

                cmbCustomer.DataSource = customers;
                cmbCustomer.DisplayMember = "DisplayName";
                cmbCustomer.ValueMember = "Id";
                cmbCustomer.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading customers: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadOrders()
        {
            try
            {
                var orders = db.Orders
                    .Select(o => new
                    {
                        Id = o.Id,
                        OrderNumber = o.OrderNumber,
                        OrderDate = o.OrderDate,
                        CustomerName = o.Customer.FirstName + " " + o.Customer.LastName,
                        CustomerId = o.CustomerId,
                        TotalAmount = o.TotalAmount
                    })
                    .OrderByDescending(o => o.OrderDate)
                    .ToList();

                dataGridViewOrders.DataSource = orders;

                if (dataGridViewOrders.Columns["TotalAmount"] != null)
                {
                    dataGridViewOrders.Columns["TotalAmount"].DefaultCellStyle.Format = "C2";
                }

                if (dataGridViewOrders.Columns["OrderDate"] != null)
                {
                    dataGridViewOrders.Columns["OrderDate"].DefaultCellStyle.Format = "MM/dd/yyyy";
                }

                btnUpdate1.Enabled = false;
                btnDelete1.Enabled = false;
                btnAdd1.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading orders: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearOrderForm()
        {
            txtOrderId.Clear();
            txtOrderNumber.Clear();
            dtpOrderDate.Value = DateTime.Now;
            cmbCustomer.SelectedIndex = -1;
            nudTotalAmount.Value = 0;
            selectedOrderId = null;
        }

        private void ResetOrderForm()
        {
            ClearOrderForm();
            btnAdd1.Enabled = true;
            btnUpdate1.Enabled = false;
            btnDelete1.Enabled = false;
        }

        private void DataGridViewOrders_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewOrders.SelectedRows.Count > 0)
            {
                try
                {
                    var selectedRow = dataGridViewOrders.SelectedRows[0];
                    int orderId = Convert.ToInt32(selectedRow.Cells["Id"].Value);

                    Order selectedOrder = db.Orders.Find(orderId);

                    if (selectedOrder != null)
                    {
                        selectedOrderId = orderId;

                        txtOrderId.Text = selectedOrder.Id.ToString();
                        txtOrderNumber.Text = selectedOrder.OrderNumber ?? "";
                        dtpOrderDate.Value = selectedOrder.OrderDate;
                        nudTotalAmount.Value = selectedOrder.TotalAmount;

                        cmbCustomer.SelectedValue = selectedOrder.CustomerId;

                        btnAdd1.Enabled = false;
                        btnUpdate1.Enabled = true;
                        btnDelete1.Enabled = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error selecting order: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCustomer.SelectedIndex >= 0 && selectedOrderId == null)
            {
                GenerateOrderNumber();
            }
        }

        private void GenerateOrderNumber()
        {
            try
            {
                string datePrefix = DateTime.Now.ToString("yyyyMMdd");
                int sequenceNumber = db.Orders.Count(o => o.OrderNumber.StartsWith(datePrefix)) + 1;
                string orderNumber = datePrefix + sequenceNumber.ToString("D3");

                txtOrderNumber.Text = orderNumber;
            }
            catch (Exception ex)
            {
                txtOrderNumber.Text = DateTime.Now.ToString("yyyyMMddHHmmss");
            }
        }

        private void BtnOrderAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateOrderData())
                {
                    return;
                }

                Order newOrder = new Order
                {
                    OrderNumber = txtOrderNumber.Text.Trim(),
                    OrderDate = dtpOrderDate.Value.Date,
                    CustomerId = Convert.ToInt32(cmbCustomer.SelectedValue),
                    TotalAmount = nudTotalAmount.Value
                };

                db.Orders.Add(newOrder);
                db.SaveChanges();

                LoadOrders();
                ResetOrderForm();

                MessageBox.Show("Order added successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding order: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnOrderUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedOrderId == null)
                {
                    MessageBox.Show("Please select an order to update!", "Selection Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!ValidateOrderData())
                {
                    return;
                }

                Order orderToUpdate = db.Orders.Find(selectedOrderId.Value);

                if (orderToUpdate != null)
                {
                    orderToUpdate.OrderNumber = txtOrderNumber.Text.Trim();
                    orderToUpdate.OrderDate = dtpOrderDate.Value.Date;
                    orderToUpdate.CustomerId = Convert.ToInt32(cmbCustomer.SelectedValue);
                    orderToUpdate.TotalAmount = nudTotalAmount.Value;

                    db.SaveChanges();

                    LoadOrders();
                    ResetOrderForm();

                    MessageBox.Show("Order updated successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Order not found!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating order: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnOrderDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedOrderId == null)
                {
                    MessageBox.Show("Please select an order to delete!", "Selection Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult result = MessageBox.Show(
                    "Are you sure you want to delete this order?\n\nThis action cannot be undone.",
                    "Confirm Deletion",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    Order orderToDelete = db.Orders.Find(selectedOrderId.Value);

                    if (orderToDelete != null)
                    {
                        bool hasOrderItems = db.OrderItems.Any(oi => oi.OrderId == selectedOrderId.Value);

                        if (hasOrderItems)
                        {
                            MessageBox.Show(
                                "Cannot delete this order because it has associated order items.\n" +
                                "Please delete the related order items first or contact your administrator.",
                                "Deletion Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                            return;
                        }

                        db.Orders.Remove(orderToDelete);
                        db.SaveChanges();

                        LoadOrders();
                        ResetOrderForm();

                        MessageBox.Show("Order deleted successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Order not found!", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting order: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnOrderRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                LoadCustomersComboBox();
                LoadOrders();
                ResetOrderForm();

                MessageBox.Show("Order data refreshed successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error refreshing order data: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateOrderData()
        {
            if (string.IsNullOrWhiteSpace(txtOrderNumber.Text))
            {
                MessageBox.Show("Order Number is required!", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtOrderNumber.Focus();
                return false;
            }

            if (txtOrderNumber.Text.Length > 10)
            {
                MessageBox.Show("Order Number cannot exceed 10 characters!", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtOrderNumber.Focus();
                return false;
            }

            var existingOrder = db.Orders.FirstOrDefault(o => o.OrderNumber == txtOrderNumber.Text.Trim());
            if (existingOrder != null && (selectedOrderId == null || existingOrder.Id != selectedOrderId.Value))
            {
                MessageBox.Show("Order Number already exists! Please use a different number.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtOrderNumber.Focus();
                return false;
            }

            if (cmbCustomer.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a customer!", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCustomer.Focus();
                return false;
            }

            if (dtpOrderDate.Value.Date > DateTime.Now.Date)
            {
                MessageBox.Show("Order Date cannot be in the future!", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpOrderDate.Focus();
                return false;
            }

            if (nudTotalAmount.Value < 0)
            {
                MessageBox.Show("Total Amount cannot be negative!", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nudTotalAmount.Focus();
                return false;
            }

            return true;
        }

        #endregion

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            try
            {
                if (db != null)
                {
                    db.Dispose();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error disposing database context: " + ex.Message);
            }

            base.OnFormClosing(e);
        }
    }
}