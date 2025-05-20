using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using quiz1Forms.entity;

namespace quiz1Forms
{
    public partial class Form1 : Form
    {
        private Model1Container db;
        private bool isUpdateMode = false;
        private int? currentCustomerId = null;

        public Form1()
        {
            InitializeComponent();

            db = new Model1Container();

            textID.ReadOnly = true;
            textID.BackColor = SystemColors.Control;

            ConfigureDataGridView();

            this.Load += Form1_Load;
            btnAdd.Click += BtnAdd_Click;
            btnUpdate.Click += BtnUpdate_Click;
            btnDelete.Click += BtnDelete_Click;
            btnRefresh.Click += BtnRefresh_Click;
            dataGridView1.CellClick += DataGridView1_CellClick;

            txtFirstName.KeyPress += TxtAlphabetOnly_KeyPress;
            txtLastName.KeyPress += TxtAlphabetOnly_KeyPress;
            txtPhone.KeyPress += TxtPhone_KeyPress;
        }

        private void ConfigureDataGridView()
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                LoadCustomers();

                UpdateButtonStates(false);

                this.Text = "Customer Management System";
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Error loading data", ex);
            }
        }

        private void LoadCustomers()
        {
            try
            {
                var customers = db.CustomerSet
                    .OrderBy(c => c.Id)
                    .ToList();

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = customers;

                if (dataGridView1.Columns.Count > 0)
                {
                    dataGridView1.Columns["Id"].HeaderText = "Customer ID";
                    dataGridView1.Columns["FirstName"].HeaderText = "First Name";
                    dataGridView1.Columns["LastName"].HeaderText = "Last Name";
                    dataGridView1.Columns["Phone"].HeaderText = "Phone Number";
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Failed to load customers", ex);
            }
        }

        private void ClearTextBoxes()
        {
            textID.Clear();
            txtFirstName.Clear();
            txtLastName.Clear();
            txtCity.Clear();
            txtCountry.Clear();
            txtPhone.Clear();

            currentCustomerId = null;
        }

        private void UpdateButtonStates(bool rowSelected)
        {
            isUpdateMode = rowSelected;
            btnAdd.Enabled = !rowSelected;
            btnUpdate.Enabled = rowSelected;
            btnDelete.Enabled = rowSelected;
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
                {
                    var row = dataGridView1.Rows[e.RowIndex];
                    Customer selectedCustomer = row.DataBoundItem as Customer;

                    if (selectedCustomer != null)
                    {
                        currentCustomerId = selectedCustomer.Id;

                        textID.Text = selectedCustomer.Id.ToString();
                        txtFirstName.Text = selectedCustomer.FirstName;
                        txtLastName.Text = selectedCustomer.LastName;
                        txtCity.Text = selectedCustomer.City;
                        txtCountry.Text = selectedCustomer.Country;
                        txtPhone.Text = selectedCustomer.Phone;

                        UpdateButtonStates(true);
                    }
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Error selecting customer", ex);
            }
        }

        private bool ValidateCustomerInput()
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                errors.AppendLine("• First name cannot be empty");
            }
            else if (txtFirstName.Text.Trim().Length < 2)
            {
                errors.AppendLine("• First name must be at least 2 characters");
            }

            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                errors.AppendLine("• Last name cannot be empty");
            }
            else if (txtLastName.Text.Trim().Length < 2)
            {
                errors.AppendLine("• Last name must be at least 2 characters");
            }

            if (string.IsNullOrWhiteSpace(txtCity.Text))
            {
                errors.AppendLine("• City cannot be empty");
            }

            if (string.IsNullOrWhiteSpace(txtCountry.Text))
            {
                errors.AppendLine("• Country cannot be empty");
            }

            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                errors.AppendLine("• Phone number cannot be empty");
            }
            else if (!IsValidPhoneNumber(txtPhone.Text))
            {
                errors.AppendLine("• Invalid phone number format");
            }

            if (errors.Length > 0)
            {
                MessageBox.Show(
                    $"Please correct the following errors:\n{errors.ToString()}",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return false;
            }

            return true;
        }

        private bool IsValidPhoneNumber(string phoneNumber)
        {
            return Regex.IsMatch(phoneNumber, @"^[\d\s\(\)\-\.]+$");
        }

        private void TxtAlphabetOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TxtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) &&
                e.KeyChar != '-' && e.KeyChar != '(' && e.KeyChar != ')' &&
                e.KeyChar != '+' && e.KeyChar != ' ' && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateCustomerInput())
                {
                    return;
                }

                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        Customer newCustomer = new Customer
                        {
                            FirstName = txtFirstName.Text.Trim(),
                            LastName = txtLastName.Text.Trim(),
                            City = txtCity.Text.Trim(),
                            Country = txtCountry.Text.Trim(),
                            Phone = txtPhone.Text.Trim()
                        };

                        db.CustomerSet.Add(newCustomer);
                        db.SaveChanges();

                        transaction.Commit();

                        LoadCustomers();

                        ClearTextBoxes();

                        MessageBox.Show(
                            $"Customer '{newCustomer.FirstName} {newCustomer.LastName}' added successfully!",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder validationErrors = new StringBuilder();
                foreach (var error in ex.EntityValidationErrors.SelectMany(x => x.ValidationErrors))
                {
                    validationErrors.AppendLine($"• {error.PropertyName}: {error.ErrorMessage}");
                }

                MessageBox.Show(
                    $"Validation errors occurred:\n{validationErrors.ToString()}",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Error adding customer", ex);
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!currentCustomerId.HasValue)
                {
                    MessageBox.Show(
                        "Please select a customer to update",
                        "Selection Required",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                if (!ValidateCustomerInput())
                {
                    return;
                }

                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        Customer customerToUpdate = db.CustomerSet.Find(currentCustomerId);

                        if (customerToUpdate != null)
                        {
                            string originalName = $"{customerToUpdate.FirstName} {customerToUpdate.LastName}";

                            customerToUpdate.FirstName = txtFirstName.Text.Trim();
                            customerToUpdate.LastName = txtLastName.Text.Trim();
                            customerToUpdate.City = txtCity.Text.Trim();
                            customerToUpdate.Country = txtCountry.Text.Trim();
                            customerToUpdate.Phone = txtPhone.Text.Trim();

                            db.SaveChanges();

                            transaction.Commit();

                            LoadCustomers();

                            ClearTextBoxes();
                            UpdateButtonStates(false);

                            MessageBox.Show(
                                $"Customer '{originalName}' updated successfully!",
                                "Success",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information
                            );
                        }
                        else
                        {
                            MessageBox.Show(
                                "Customer not found. The record may have been deleted by another user.",
                                "Record Not Found",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning
                            );
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder validationErrors = new StringBuilder();
                foreach (var error in ex.EntityValidationErrors.SelectMany(x => x.ValidationErrors))
                {
                    validationErrors.AppendLine($"• {error.PropertyName}: {error.ErrorMessage}");
                }

                MessageBox.Show(
                    $"Validation errors occurred:\n{validationErrors.ToString()}",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Error updating customer", ex);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (!currentCustomerId.HasValue)
                {
                    MessageBox.Show(
                        "Please select a customer to delete",
                        "Selection Required",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                Customer customerToDelete = db.CustomerSet.Find(currentCustomerId);

                if (customerToDelete != null)
                {
                    string customerName = $"{customerToDelete.FirstName} {customerToDelete.LastName}";

                    int orderCount = db.OrderSet.Count(o => o.Customer.Id == currentCustomerId);

                    if (orderCount > 0)
                    {
                        MessageBox.Show(
                            $"Cannot delete customer '{customerName}' because they have {orderCount} related orders. " +
                            "Delete the related orders first or use the update function instead.",
                            "Deletion Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                        return;
                    }

                    DialogResult result = MessageBox.Show(
                        $"Are you sure you want to delete customer '{customerName}'?",
                        "Confirm Deletion",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    if (result == DialogResult.Yes)
                    {
                        using (var transaction = db.Database.BeginTransaction())
                        {
                            try
                            {
                                db.CustomerSet.Remove(customerToDelete);
                                db.SaveChanges();

                                transaction.Commit();

                                LoadCustomers();

                                ClearTextBoxes();
                                UpdateButtonStates(false);

                                MessageBox.Show(
                                    $"Customer '{customerName}' deleted successfully!",
                                    "Success",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information
                                );
                            }
                            catch (Exception ex)
                            {
                                transaction.Rollback();
                                throw ex;
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show(
                        "Customer not found. The record may have been deleted by another user.",
                        "Record Not Found",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Error deleting customer", ex);
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                ClearTextBoxes();

                UpdateButtonStates(false);

                LoadCustomers();

                db.Dispose();
                db = new Model1Container();
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Error refreshing data", ex);
            }
        }

        private void ShowErrorMessage(string operation, Exception ex)
        {
            Console.WriteLine($"Error in {operation}: {ex.Message}");
            Console.WriteLine($"Stack trace: {ex.StackTrace}");

            string innerExceptionDetails = "";
            if (ex.InnerException != null)
            {
                innerExceptionDetails = $"\n\nDetails: {ex.InnerException.Message}";
            }

            MessageBox.Show(
                $"{operation} failed.\n\nError: {ex.Message}{innerExceptionDetails}",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }

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
                Console.WriteLine($"Error disposing database context: {ex.Message}");
            }
            finally
            {
                base.OnFormClosing(e);
            }
        }
    }
}
