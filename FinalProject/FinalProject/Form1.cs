using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using FinalProject.EF;
using System.Data.Entity;
using System.Collections.Generic;

namespace FinalProject
{
    public partial class Form1 : Form
    {
        private AppDbContext db;
        private BindingSource employeeBindingSource;
        private BindingSource salaryBindingSource;
        private BindingSource positionBindingSource;
        private int currentSalaryPage = 1;
        private const int SalariesPerPage = 10;

        public Form1()
        {
            InitializeComponent();
            InitializeDatabase();
            InitializePanels();
            SetupEventHandlers();
            ShowLoginPanel();
        }

        private void InitializeDatabase()
        {
            db = new AppDbContext();
            employeeBindingSource = new BindingSource();
            salaryBindingSource = new BindingSource();
            positionBindingSource = new BindingSource();
            currentSalaryPage = 1;

            // Add test data if database is empty
            if (!db.Positions.Any())
            {
                db.Positions.Add(new Position { Title = "Manager", BonusPercent = 20 });
                db.SaveChanges();
            }
            if (!db.Employees.Any())
            {
                db.Employees.Add(new Employee { FullName = "John Doe", PositionId = 1, BaseSalary = 50000 });
                db.SaveChanges();
            }
            if (!db.Salaries.Any())
            {
                db.Salaries.Add(new Salary { EmployeeId = 1, Month = 1, Year = 2024, TotalSalary = 60000 });
                db.Salaries.Add(new Salary { EmployeeId = 1, Month = 1, Year = 2025, TotalSalary = 65000 });
                db.SaveChanges();
            }
        }

        private void InitializePanels()
        {
            InitializeEmployeePanel();
            InitializeSalaryPanel();
            InitializePositionPanel();
            InitializeAnalysisPanel();
            if (!panelCRUD.Controls.Contains(panelAnalysis))
            {
                MessageBox.Show("panelAnalysis was not added to panelCRUD!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void InitializeEmployeePanel()
        {
            // Event handlers for employee operations
            btnAddEmployee.Click += (s, e) => AddEmployee();
            btnEditEmployee.Click += (s, e) => EditEmployee();
            btnDeleteEmployee.Click += (s, e) => DeleteEmployee();
            btnRefreshEmployee.Click += (s, e) => { ClearEmployeeForm(); LoadEmployees(); };
            dgvEmployees.SelectionChanged += (s, e) => LoadSelectedEmployee();
            btnSeeGraph.Click += (s, e) => ShowEmployeeGraph();

            // Set DataGridView properties not easily set in Designer
            dgvEmployees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEmployees.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEmployees.MultiSelect = false;
            dgvEmployees.ReadOnly = true;
        }

        private void InitializeSalaryPanel()
        {
            // Event handlers for salary operations
            btnAddSalary.Click += (s, e) => AddSalary();
            btnEditSalary.Click += (s, e) => EditSalary();
            btnDeleteSalary.Click += (s, e) => DeleteSalary();
            btnRefreshSalary.Click += (s, e) => { ClearSalaryForm(); LoadSalaries(); };
            btnCalculateSalary.Click += (s, e) => CalculateTotalSalary();
            btnPrevious.Click += (s, e) =>
            {
                if (currentSalaryPage > 1)
                {
                    currentSalaryPage--;
                    LoadSalaries();
                }
            };
            btnNext.Click += (s, e) =>
            {
                var yearFilter = panelSalaryCRUD.Controls["cmbYearFilter"] as ComboBox;
                var query = db.Salaries.Include("Employee").AsQueryable();
                if (yearFilter.SelectedItem != null && yearFilter.SelectedItem.ToString() != "All")
                {
                    if (int.TryParse(yearFilter.SelectedItem.ToString(), out int selectedYear))
                    {
                        query = query.Where(salary => salary.Year == selectedYear);
                    }
                }
                var totalSalaries = query.Count();
                var totalPages = totalSalaries > 0 ? (int)Math.Ceiling((double)totalSalaries / SalariesPerPage) : 1;

                if (currentSalaryPage < totalPages)
                {
                    currentSalaryPage++;
                    LoadSalaries();
                }
            };
            cmbYearFilter.SelectedIndexChanged += (s, e) => { currentSalaryPage = 1; LoadSalaries(); };
            dgvSalaries.SelectionChanged += (s, e) => LoadSelectedSalary();

            // Set DataGridView properties
            dgvSalaries.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSalaries.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSalaries.MultiSelect = false;
            dgvSalaries.ReadOnly = true;

            // Load year filter options
            cmbYearFilter.Items.Add("All");
            cmbYearFilter.Items.AddRange(Enumerable.Range(DateTime.Now.Year - 5, 10).Select(y => y.ToString()).ToArray());
            cmbYearFilter.SelectedItem = "All";
        }

        private void InitializePositionPanel()
        {
            // Event handlers for position operations
            btnAddPosition.Click += (s, e) => AddPosition();
            btnEditPosition.Click += (s, e) => EditPosition();
            btnDeletePosition.Click += (s, e) => DeletePosition();
            btnRefreshPosition.Click += (s, e) => { ClearPositionForm(); LoadPositions(); };
            dgvPositions.SelectionChanged += (s, e) => LoadSelectedPosition();

            // Set DataGridView properties
            dgvPositions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPositions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPositions.MultiSelect = false;
            dgvPositions.ReadOnly = true;
        }

        private void InitializeAnalysisPanel()
        {
            // Event handlers
            btnShowGraph.Click += (s, e) => ShowSalaryGraph();

            // Configure chart properties not easily set in Designer
            chartSalary.ChartAreas.Add(new System.Windows.Forms.DataVisualization.Charting.ChartArea("MainArea"));
            chartSalary.Series.Add(new System.Windows.Forms.DataVisualization.Charting.Series("AnnualSalary")
            {
                ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column,
                XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String,
                YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double
            });
        }

        private void ShowSalaryGraph()
        {
            var cmbEmployee = panelAnalysis.Controls["cmbAnalysisEmployee"] as ComboBox;
            if (cmbEmployee.SelectedValue == null)
            {
                MessageBox.Show("Please select an employee!", "No Employee Selected",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int employeeId = (int)cmbEmployee.SelectedValue;
            ShowGraphWindow(employeeId);
        }

        private void SetupEventHandlers()
        {
            LogInbutton.Click += LogInbutton_Click;
            btnEmployeeTab.Click += (s, e) => ShowEmployeePanel();
            btnSalaryTab.Click += (s, e) => ShowSalaryPanel();
            btnPositionTab.Click += (s, e) => ShowPositionPanel();
            btnAnalysisTab.Click += (s, e) => ShowAnalysisPanel();
        }

        private void LogInbutton_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "hr" && txtPassword.Text == "1234")
            {
                ShowCRUDPanel();
                LoadAllData();
            }
            else
            {
                MessageBox.Show("Invalid credentials!", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowLoginPanel()
        {
            panelLogin.Visible = true;
            panelCRUD.Visible = false;
        }

        private void ShowCRUDPanel()
        {
            panelLogin.Visible = false;
            panelCRUD.Visible = true;
            ShowEmployeePanel();
        }

        private void ShowEmployeePanel()
        {
            panelEmployeeCRUD.Visible = true;
            panelSalaryCRUD.Visible = false;
            panelPositionCRUD.Visible = false;
            panelAnalysis.Visible = false;
            LoadEmployees();
        }

        private void ShowSalaryPanel()
        {
            panelEmployeeCRUD.Visible = false;
            panelSalaryCRUD.Visible = true;
            panelPositionCRUD.Visible = false;
            panelAnalysis.Visible = false;
            LoadSalaries();
        }

        private void ShowPositionPanel()
        {
            panelEmployeeCRUD.Visible = false;
            panelSalaryCRUD.Visible = false;
            panelPositionCRUD.Visible = true;
            panelAnalysis.Visible = false;
            LoadPositions();
        }

        private void ShowAnalysisPanel()
        {
            panelEmployeeCRUD.Visible = false;
            panelSalaryCRUD.Visible = false;
            panelPositionCRUD.Visible = false;
            panelAnalysis.Visible = true;
            LoadAnalysisComboBox();
        }

        private void LoadAllData()
        {
            LoadPositions();
            LoadEmployees();
            LoadSalaries();
            LoadComboBoxes();
            LoadAnalysisComboBox();
        }

        private void LoadComboBoxes()
        {
            cmbPosition.DataSource = db.Positions.ToList();
            cmbPosition.DisplayMember = "Title";
            cmbPosition.ValueMember = "Id";

            cmbEmployee.DataSource = db.Employees.Include("Position").ToList();
            cmbEmployee.DisplayMember = "FullName";
            cmbEmployee.ValueMember = "Id";
        }

        private void LoadAnalysisComboBox()
        {
            if (db == null)
            {
                MessageBox.Show("Database context (db) is null!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (panelAnalysis == null)
            {
                MessageBox.Show("panelAnalysis is null!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cmbAnalysisEmployee == null)
            {
                MessageBox.Show("ComboBox 'cmbAnalysisEmployee' not found in panelAnalysis!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Clear existing items first
                cmbAnalysisEmployee.DataSource = null;
                cmbAnalysisEmployee.Items.Clear();

                // Load fresh data
                var employees = db.Employees.ToList();

                if (employees.Any())
                {
                    cmbAnalysisEmployee.DataSource = employees;
                    cmbAnalysisEmployee.DisplayMember = "FullName";
                    cmbAnalysisEmployee.ValueMember = "Id";
                    cmbAnalysisEmployee.SelectedIndex = -1; // No selection initially
                }
                else
                {
                    MessageBox.Show("No employees found in database!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading employees: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Employee CRUD Operations
        private void LoadEmployees()
        {
            var employees = db.Employees.Include("Position").Select(e => new
            {
                e.Id,
                e.FullName,
                Position = e.Position.Title,
                e.BaseSalary
            }).ToList();

            employeeBindingSource.DataSource = employees;
            dgvEmployees.DataSource = employeeBindingSource;
        }

        private void AddEmployee()
        {
            try
            {
                if (string.IsNullOrEmpty(txtEmployeeName.Text) || cmbPosition.SelectedValue == null || string.IsNullOrEmpty(txtBaseSalary.Text))
                {
                    MessageBox.Show("Please fill all fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var employee = new Employee
                {
                    FullName = txtEmployeeName.Text,
                    PositionId = (int)cmbPosition.SelectedValue,
                    BaseSalary = decimal.Parse(txtBaseSalary.Text)
                };

                db.Employees.Add(employee);
                db.SaveChanges();
                LoadEmployees();
                LoadComboBoxes();
                ClearEmployeeForm();
                MessageBox.Show("Employee added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding employee: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditEmployee()
        {
            if (dgvEmployees.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an employee to edit!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var selectedId = (int)dgvEmployees.SelectedRows[0].Cells["Id"].Value;
                var employee = db.Employees.Find(selectedId);

                if (string.IsNullOrEmpty(txtEmployeeName.Text) || cmbPosition.SelectedValue == null || string.IsNullOrEmpty(txtBaseSalary.Text))
                {
                    MessageBox.Show("Please fill all fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                employee.FullName = txtEmployeeName.Text;
                employee.PositionId = (int)cmbPosition.SelectedValue;
                employee.BaseSalary = decimal.Parse(txtBaseSalary.Text);

                db.SaveChanges();
                LoadEmployees();
                LoadComboBoxes();
                ClearEmployeeForm();
                MessageBox.Show("Employee updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating employee: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteEmployee()
        {
            if (dgvEmployees.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an employee to delete!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this employee?", "Confirm Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    var selectedId = (int)dgvEmployees.SelectedRows[0].Cells["Id"].Value;
                    var employee = db.Employees.Find(selectedId);
                    db.Employees.Remove(employee);
                    db.SaveChanges();
                    LoadEmployees();
                    LoadComboBoxes();
                    ClearEmployeeForm();
                    MessageBox.Show("Employee deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting employee: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadSelectedEmployee()
        {
            if (dgvEmployees.SelectedRows.Count > 0)
            {
                var selectedId = (int)dgvEmployees.SelectedRows[0].Cells["Id"].Value;
                var employee = db.Employees.Find(selectedId);

                txtEmployeeName.Text = employee.FullName;
                cmbPosition.SelectedValue = employee.PositionId;
                txtBaseSalary.Text = employee.BaseSalary.ToString();
            }
        }

        private void ClearEmployeeForm()
        {
            txtEmployeeName.Clear();
            cmbPosition.SelectedIndex = -1;
            txtBaseSalary.Clear();
        }

        // Salary CRUD Operations
        private void LoadSalaries()
        {
            try
            {
                // Base query
                var query = db.Salaries.Include("Employee").AsQueryable();

                // Apply year filter
                if (cmbYearFilter.SelectedItem != null && cmbYearFilter.SelectedItem.ToString() != "All")
                {
                    if (int.TryParse(cmbYearFilter.SelectedItem.ToString(), out int selectedYear))
                    {
                        query = query.Where(s => s.Year == selectedYear);
                    }
                }

                // Get total count
                var totalSalaries = query.Count();
                var totalPages = totalSalaries > 0 ? (int)Math.Ceiling((double)totalSalaries / SalariesPerPage) : 1;

                // Validate current page
                if (currentSalaryPage < 1) currentSalaryPage = 1;
                if (currentSalaryPage > totalPages && totalPages > 0) currentSalaryPage = totalPages;

                // Get paginated data
                var salaries = query
                    .OrderBy(s => s.Year).ThenBy(s => s.Month).ThenBy(s => s.Id)
                    .Skip((currentSalaryPage - 1) * SalariesPerPage)
                    .Take(SalariesPerPage)
                    .Select(s => new
                    {
                        s.Id,
                        Employee = s.Employee.FullName,
                        s.Month,
                        s.Year,
                        s.TotalSalary
                    })
                    .ToList();

                // Update UI
                salaryBindingSource.DataSource = salaries;
                dgvSalaries.DataSource = salaryBindingSource;

                // Update pagination controls
                lblPage.Text = totalSalaries == 0
                    ? "No records found"
                    : $"Page {currentSalaryPage} of {totalPages} ({totalSalaries} total records)";

                // Update button states
                btnPrevious.Enabled = currentSalaryPage > 1;
                btnNext.Enabled = currentSalaryPage < totalPages;

                // Debugging: Log the state for troubleshooting
                Console.WriteLine($"LoadSalaries: totalSalaries={totalSalaries}, totalPages={totalPages}, currentSalaryPage={currentSalaryPage}, btnPrevious.Enabled={btnPrevious.Enabled}, btnNext.Enabled={btnNext.Enabled}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading salaries: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnPrevious.Enabled = false;
                btnNext.Enabled = false;
                lblPage.Text = "Error loading data";
            }
        }

        private void AddSalary()
        {
            try
            {
                if (cmbEmployee.SelectedValue == null || string.IsNullOrEmpty(txtMonth.Text) ||
                    string.IsNullOrEmpty(txtYear.Text) || string.IsNullOrEmpty(txtTotalSalary.Text))
                {
                    MessageBox.Show("Please fill all fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var salary = new Salary
                {
                    EmployeeId = (int)cmbEmployee.SelectedValue,
                    Month = int.Parse(txtMonth.Text),
                    Year = int.Parse(txtYear.Text),
                    TotalSalary = decimal.Parse(txtTotalSalary.Text)
                };

                db.Salaries.Add(salary);
                db.SaveChanges();
                LoadSalaries();
                ClearSalaryForm();
                MessageBox.Show("Salary added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding salary: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditSalary()
        {
            if (dgvSalaries.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a salary record to edit!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var selectedId = (int)dgvSalaries.SelectedRows[0].Cells["Id"].Value;
                var salary = db.Salaries.Find(selectedId);

                if (cmbEmployee.SelectedValue == null || string.IsNullOrEmpty(txtMonth.Text) ||
                    string.IsNullOrEmpty(txtYear.Text) || string.IsNullOrEmpty(txtTotalSalary.Text))
                {
                    MessageBox.Show("Please fill all fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                salary.EmployeeId = (int)cmbEmployee.SelectedValue;
                salary.Month = int.Parse(txtMonth.Text);
                salary.Year = int.Parse(txtYear.Text);
                salary.TotalSalary = decimal.Parse(txtTotalSalary.Text);

                db.SaveChanges();
                LoadSalaries();
                ClearSalaryForm();
                MessageBox.Show("Salary updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating salary: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteSalary()
        {
            if (dgvSalaries.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a salary record to delete!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this salary record?", "Confirm Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    var selectedId = (int)dgvSalaries.SelectedRows[0].Cells["Id"].Value;
                    var salary = db.Salaries.Find(selectedId);
                    db.Salaries.Remove(salary);
                    db.SaveChanges();
                    LoadSalaries();
                    ClearSalaryForm();
                    MessageBox.Show("Salary deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting salary: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadSelectedSalary()
        {
            if (dgvSalaries.SelectedRows.Count > 0)
            {
                var selectedId = (int)dgvSalaries.SelectedRows[0].Cells["Id"].Value;
                var salary = db.Salaries.Find(selectedId);

                cmbEmployee.SelectedValue = salary.EmployeeId;
                txtMonth.Text = salary.Month.ToString();
                txtYear.Text = salary.Year.ToString();
                txtTotalSalary.Text = salary.TotalSalary.ToString();
            }
        }

        private void ClearSalaryForm()
        {
            cmbEmployee.SelectedIndex = -1;
            txtMonth.Clear();
            txtYear.Clear();
            txtTotalSalary.Clear();
        }

        private void CalculateTotalSalary()
        {
            try
            {
                if (cmbEmployee.SelectedValue == null)
                {
                    MessageBox.Show("Please select an employee!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var employeeId = (int)cmbEmployee.SelectedValue;
                var employee = db.Employees.Include(e => e.Position).FirstOrDefault(e => e.Id == employeeId);
                if (employee == null)
                {
                    MessageBox.Show("Employee not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var totalSalary = SalaryCalculator.CalculateTotalSalary(employee.BaseSalary, employee.Position.BonusPercent);
                txtTotalSalary.Text = totalSalary.ToString("F2");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error calculating salary: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Position CRUD Operations
        private void LoadPositions()
        {
            var positions = db.Positions.Select(p => new
            {
                p.Id,
                p.Title,
                p.BonusPercent
            }).ToList();

            positionBindingSource.DataSource = positions;
            dgvPositions.DataSource = positionBindingSource;
        }

        private void AddPosition()
        {
            try
            {
                if (string.IsNullOrEmpty(txtTitle.Text) || string.IsNullOrEmpty(txtBonusPercent.Text))
                {
                    MessageBox.Show("Please fill all fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!decimal.TryParse(txtBonusPercent.Text, out decimal bonusPercent))
                {
                    MessageBox.Show("Invalid bonus percentage!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!SalaryCalculator.ValidateBonusPercent(bonusPercent))
                {
                    MessageBox.Show("Bonus percentage must be between 0 and 100!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var position = new Position
                {
                    Title = txtTitle.Text,
                    BonusPercent = bonusPercent
                };

                db.Positions.Add(position);
                db.SaveChanges();
                LoadPositions();
                LoadComboBoxes();
                ClearPositionForm();
                MessageBox.Show("Position added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding position: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditPosition()
        {
            if (dgvPositions.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a position to edit!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var selectedId = (int)dgvPositions.SelectedRows[0].Cells["Id"].Value;
                var position = db.Positions.Find(selectedId);

                if (string.IsNullOrEmpty(txtTitle.Text) || string.IsNullOrEmpty(txtBonusPercent.Text))
                {
                    MessageBox.Show("Please fill all fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!decimal.TryParse(txtBonusPercent.Text, out decimal bonusPercent))
                {
                    MessageBox.Show("Invalid bonus percentage!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!SalaryCalculator.ValidateBonusPercent(bonusPercent))
                {
                    MessageBox.Show("Bonus percentage must be between 0 and 100!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                position.Title = txtTitle.Text;
                position.BonusPercent = bonusPercent;

                db.SaveChanges();
                LoadPositions();
                LoadComboBoxes();
                ClearPositionForm();
                MessageBox.Show("Position updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating position: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeletePosition()
        {
            if (dgvPositions.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a position to delete!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this position?", "Confirm Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    var selectedId = (int)dgvPositions.SelectedRows[0].Cells["Id"].Value;
                    var position = db.Positions.Find(selectedId);

                    if (db.Employees.Any(e => e.PositionId == selectedId))
                    {
                        MessageBox.Show("Cannot delete position as it is assigned to one or more employees!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    db.Positions.Remove(position);
                    db.SaveChanges();
                    LoadPositions();
                    LoadComboBoxes();
                    ClearPositionForm();
                    MessageBox.Show("Position deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting position: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadSelectedPosition()
        {
            if (dgvPositions.SelectedRows.Count > 0)
            {
                var selectedId = (int)dgvPositions.SelectedRows[0].Cells["Id"].Value;
                var position = db.Positions.Find(selectedId);

                txtTitle.Text = position.Title;
                txtBonusPercent.Text = position.BonusPercent.ToString();
            }
        }

        private void ClearPositionForm()
        {
            txtTitle.Clear();
            txtBonusPercent.Clear();
        }

        private void ShowEmployeeGraph()
        {
            if (string.IsNullOrEmpty(txtEmployeeName.Text))
            {
                MessageBox.Show("Please select an employee first!", "No Employee Selected",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvEmployees.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an employee from the list!", "No Employee Selected",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedId = (int)dgvEmployees.SelectedRows[0].Cells["Id"].Value;
            ShowGraphWindow(selectedId);
        }

        private void ShowGraphWindow(int employeeId)
        {
            try
            {
                var employee = db.Employees.Find(employeeId);

                var salaries = db.Salaries
                    .Where(s => s.EmployeeId == employeeId)
                    .GroupBy(s => s.Year)
                    .Select(g => new
                    {
                        Year = g.Key,
                        TotalSalary = g.Sum(s => s.TotalSalary)
                    })
                    .OrderBy(g => g.Year)
                    .ToList();

                if (!salaries.Any())
                {
                    MessageBox.Show("No salary data available for this employee!", "Info",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var graphForm = new Form
                {
                    Text = $"Salary Graph - {employee.FullName}",
                    Size = new System.Drawing.Size(800, 600),
                    StartPosition = FormStartPosition.CenterParent
                };

                var chart = new System.Windows.Forms.DataVisualization.Charting.Chart
                {
                    Dock = DockStyle.Fill
                };

                chart.ChartAreas.Add(new System.Windows.Forms.DataVisualization.Charting.ChartArea("MainArea"));
                chart.Series.Add(new System.Windows.Forms.DataVisualization.Charting.Series("AnnualSalary")
                {
                    ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column,
                    XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String,
                    YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double
                });

                foreach (var salary in salaries)
                {
                    chart.Series["AnnualSalary"].Points.AddXY(salary.Year.ToString(), (double)salary.TotalSalary);
                }

                chart.ChartAreas["MainArea"].AxisX.Title = "Year";
                chart.ChartAreas["MainArea"].AxisY.Title = "Total Salary ($)";
                chart.ChartAreas["MainArea"].AxisY.Minimum = 0;
                chart.Titles.Add(new System.Windows.Forms.DataVisualization.Charting.Title("Employee Annual Salary"));

                graphForm.Controls.Add(chart);
                graphForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating graph: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db?.Dispose();
                components?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}