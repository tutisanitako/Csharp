namespace FinalProject
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LogInbutton = new System.Windows.Forms.Button();
            this.panelLogin = new System.Windows.Forms.Panel();
            this.panelCRUD = new System.Windows.Forms.Panel();
            this.btnPositionTab = new System.Windows.Forms.Button();
            this.btnSalaryTab = new System.Windows.Forms.Button();
            this.btnEmployeeTab = new System.Windows.Forms.Button();
            this.panelPositionCRUD = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblBonusPercent = new System.Windows.Forms.Label();
            this.txtBonusPercent = new System.Windows.Forms.TextBox();
            this.btnAddPosition = new System.Windows.Forms.Button();
            this.btnEditPosition = new System.Windows.Forms.Button();
            this.btnDeletePosition = new System.Windows.Forms.Button();
            this.btnRefreshPosition = new System.Windows.Forms.Button();
            this.dgvPositions = new System.Windows.Forms.DataGridView();
            this.panelSalaryCRUD = new System.Windows.Forms.Panel();
            this.lblEmployee = new System.Windows.Forms.Label();
            this.cmbEmployee = new System.Windows.Forms.ComboBox();
            this.lblMonth = new System.Windows.Forms.Label();
            this.txtMonth = new System.Windows.Forms.TextBox();
            this.lblYear = new System.Windows.Forms.Label();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.lblTotalSalary = new System.Windows.Forms.Label();
            this.txtTotalSalary = new System.Windows.Forms.TextBox();
            this.btnCalculateSalary = new System.Windows.Forms.Button();
            this.lblYearFilter = new System.Windows.Forms.Label();
            this.cmbYearFilter = new System.Windows.Forms.ComboBox();
            this.btnAddSalary = new System.Windows.Forms.Button();
            this.btnEditSalary = new System.Windows.Forms.Button();
            this.btnDeleteSalary = new System.Windows.Forms.Button();
            this.btnRefreshSalary = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.lblPage = new System.Windows.Forms.Label();
            this.dgvSalaries = new System.Windows.Forms.DataGridView();
            this.panelEmployeeCRUD = new System.Windows.Forms.Panel();
            this.lblEmployeeName = new System.Windows.Forms.Label();
            this.txtEmployeeName = new System.Windows.Forms.TextBox();
            this.lblPosition = new System.Windows.Forms.Label();
            this.cmbPosition = new System.Windows.Forms.ComboBox();
            this.lblBaseSalary = new System.Windows.Forms.Label();
            this.txtBaseSalary = new System.Windows.Forms.TextBox();
            this.btnAddEmployee = new System.Windows.Forms.Button();
            this.btnEditEmployee = new System.Windows.Forms.Button();
            this.btnDeleteEmployee = new System.Windows.Forms.Button();
            this.btnRefreshEmployee = new System.Windows.Forms.Button();
            this.btnSeeGraph = new System.Windows.Forms.Button();
            this.dgvEmployees = new System.Windows.Forms.DataGridView();
            this.panelAnalysis = new System.Windows.Forms.Panel();
            this.lblAnalysisEmployee = new System.Windows.Forms.Label();
            this.cmbAnalysisEmployee = new System.Windows.Forms.ComboBox();
            this.btnShowGraph = new System.Windows.Forms.Button();
            this.chartSalary = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnAnalysisTab = new System.Windows.Forms.Button();
            this.panelLogin.SuspendLayout();
            this.panelCRUD.SuspendLayout();
            this.panelPositionCRUD.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPositions)).BeginInit();
            this.panelSalaryCRUD.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalaries)).BeginInit();
            this.panelEmployeeCRUD.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).BeginInit();
            this.panelAnalysis.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartSalary)).BeginInit();
            this.SuspendLayout();
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(345, 163);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(100, 20);
            this.txtUsername.TabIndex = 0;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(345, 206);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(100, 20);
            this.txtPassword.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(265, 170);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(267, 213);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Password";
            // 
            // LogInbutton
            // 
            this.LogInbutton.Location = new System.Drawing.Point(308, 277);
            this.LogInbutton.Name = "LogInbutton";
            this.LogInbutton.Size = new System.Drawing.Size(75, 23);
            this.LogInbutton.TabIndex = 3;
            this.LogInbutton.Text = "Log In";
            this.LogInbutton.UseVisualStyleBackColor = true;
            // 
            // panelLogin
            // 
            this.panelLogin.Controls.Add(this.LogInbutton);
            this.panelLogin.Controls.Add(this.label2);
            this.panelLogin.Controls.Add(this.label1);
            this.panelLogin.Controls.Add(this.txtPassword);
            this.panelLogin.Controls.Add(this.txtUsername);
            this.panelLogin.Location = new System.Drawing.Point(0, 0);
            this.panelLogin.Name = "panelLogin";
            this.panelLogin.Size = new System.Drawing.Size(800, 450);
            this.panelLogin.TabIndex = 4;
            // 
            // panelCRUD
            // 
            this.panelCRUD.Controls.Add(this.btnPositionTab);
            this.panelCRUD.Controls.Add(this.btnSalaryTab);
            this.panelCRUD.Controls.Add(this.btnEmployeeTab);
            this.panelCRUD.Controls.Add(this.panelPositionCRUD);
            this.panelCRUD.Controls.Add(this.panelSalaryCRUD);
            this.panelCRUD.Controls.Add(this.panelEmployeeCRUD);
            this.panelCRUD.Controls.Add(this.panelAnalysis);
            this.panelCRUD.Location = new System.Drawing.Point(0, 0);
            this.panelCRUD.Name = "panelCRUD";
            this.panelCRUD.Size = new System.Drawing.Size(800, 506);
            this.panelCRUD.TabIndex = 5;
            // 
            // btnPositionTab
            // 
            this.btnPositionTab.Location = new System.Drawing.Point(230, 10);
            this.btnPositionTab.Name = "btnPositionTab";
            this.btnPositionTab.Size = new System.Drawing.Size(100, 30);
            this.btnPositionTab.TabIndex = 5;
            this.btnPositionTab.Text = "Positions";
            this.btnPositionTab.UseVisualStyleBackColor = true;
            // 
            // btnSalaryTab
            // 
            this.btnSalaryTab.Location = new System.Drawing.Point(120, 10);
            this.btnSalaryTab.Name = "btnSalaryTab";
            this.btnSalaryTab.Size = new System.Drawing.Size(100, 30);
            this.btnSalaryTab.TabIndex = 4;
            this.btnSalaryTab.Text = "Salaries";
            this.btnSalaryTab.UseVisualStyleBackColor = true;
            // 
            // btnEmployeeTab
            // 
            this.btnEmployeeTab.Location = new System.Drawing.Point(10, 10);
            this.btnEmployeeTab.Name = "btnEmployeeTab";
            this.btnEmployeeTab.Size = new System.Drawing.Size(100, 30);
            this.btnEmployeeTab.TabIndex = 3;
            this.btnEmployeeTab.Text = "Employees";
            this.btnEmployeeTab.UseVisualStyleBackColor = true;
            // 
            // panelPositionCRUD
            // 
            this.panelPositionCRUD.Controls.Add(this.lblTitle);
            this.panelPositionCRUD.Controls.Add(this.txtTitle);
            this.panelPositionCRUD.Controls.Add(this.lblBonusPercent);
            this.panelPositionCRUD.Controls.Add(this.txtBonusPercent);
            this.panelPositionCRUD.Controls.Add(this.btnAddPosition);
            this.panelPositionCRUD.Controls.Add(this.btnEditPosition);
            this.panelPositionCRUD.Controls.Add(this.btnDeletePosition);
            this.panelPositionCRUD.Controls.Add(this.btnRefreshPosition);
            this.panelPositionCRUD.Controls.Add(this.dgvPositions);
            this.panelPositionCRUD.Location = new System.Drawing.Point(10, 50);
            this.panelPositionCRUD.Name = "panelPositionCRUD";
            this.panelPositionCRUD.Size = new System.Drawing.Size(780, 446);
            this.panelPositionCRUD.TabIndex = 2;
            // 
            // lblTitle
            // 
            this.lblTitle.Location = new System.Drawing.Point(10, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(80, 20);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Title:";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(100, 18);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(200, 20);
            this.txtTitle.TabIndex = 1;
            // 
            // lblBonusPercent
            // 
            this.lblBonusPercent.Location = new System.Drawing.Point(10, 50);
            this.lblBonusPercent.Name = "lblBonusPercent";
            this.lblBonusPercent.Size = new System.Drawing.Size(80, 20);
            this.lblBonusPercent.TabIndex = 2;
            this.lblBonusPercent.Text = "Bonus %:";
            // 
            // txtBonusPercent
            // 
            this.txtBonusPercent.Location = new System.Drawing.Point(100, 48);
            this.txtBonusPercent.Name = "txtBonusPercent";
            this.txtBonusPercent.Size = new System.Drawing.Size(200, 20);
            this.txtBonusPercent.TabIndex = 3;
            // 
            // btnAddPosition
            // 
            this.btnAddPosition.Location = new System.Drawing.Point(10, 90);
            this.btnAddPosition.Name = "btnAddPosition";
            this.btnAddPosition.Size = new System.Drawing.Size(75, 30);
            this.btnAddPosition.TabIndex = 4;
            this.btnAddPosition.Text = "Add";
            // 
            // btnEditPosition
            // 
            this.btnEditPosition.Location = new System.Drawing.Point(95, 90);
            this.btnEditPosition.Name = "btnEditPosition";
            this.btnEditPosition.Size = new System.Drawing.Size(75, 30);
            this.btnEditPosition.TabIndex = 5;
            this.btnEditPosition.Text = "Edit";
            // 
            // btnDeletePosition
            // 
            this.btnDeletePosition.Location = new System.Drawing.Point(180, 90);
            this.btnDeletePosition.Name = "btnDeletePosition";
            this.btnDeletePosition.Size = new System.Drawing.Size(75, 30);
            this.btnDeletePosition.TabIndex = 6;
            this.btnDeletePosition.Text = "Delete";
            // 
            // btnRefreshPosition
            // 
            this.btnRefreshPosition.Location = new System.Drawing.Point(265, 90);
            this.btnRefreshPosition.Name = "btnRefreshPosition";
            this.btnRefreshPosition.Size = new System.Drawing.Size(75, 30);
            this.btnRefreshPosition.TabIndex = 7;
            this.btnRefreshPosition.Text = "Refresh";
            // 
            // dgvPositions
            // 
            this.dgvPositions.Location = new System.Drawing.Point(10, 140);
            this.dgvPositions.Name = "dgvPositions";
            this.dgvPositions.Size = new System.Drawing.Size(750, 289);
            this.dgvPositions.TabIndex = 8;
            // 
            // panelSalaryCRUD
            // 
            this.panelSalaryCRUD.Controls.Add(this.lblEmployee);
            this.panelSalaryCRUD.Controls.Add(this.cmbEmployee);
            this.panelSalaryCRUD.Controls.Add(this.lblMonth);
            this.panelSalaryCRUD.Controls.Add(this.txtMonth);
            this.panelSalaryCRUD.Controls.Add(this.lblYear);
            this.panelSalaryCRUD.Controls.Add(this.txtYear);
            this.panelSalaryCRUD.Controls.Add(this.lblTotalSalary);
            this.panelSalaryCRUD.Controls.Add(this.txtTotalSalary);
            this.panelSalaryCRUD.Controls.Add(this.btnCalculateSalary);
            this.panelSalaryCRUD.Controls.Add(this.lblYearFilter);
            this.panelSalaryCRUD.Controls.Add(this.cmbYearFilter);
            this.panelSalaryCRUD.Controls.Add(this.btnAddSalary);
            this.panelSalaryCRUD.Controls.Add(this.btnEditSalary);
            this.panelSalaryCRUD.Controls.Add(this.btnDeleteSalary);
            this.panelSalaryCRUD.Controls.Add(this.btnRefreshSalary);
            this.panelSalaryCRUD.Controls.Add(this.btnPrevious);
            this.panelSalaryCRUD.Controls.Add(this.btnNext);
            this.panelSalaryCRUD.Controls.Add(this.lblPage);
            this.panelSalaryCRUD.Controls.Add(this.dgvSalaries);
            this.panelSalaryCRUD.Location = new System.Drawing.Point(10, 50);
            this.panelSalaryCRUD.Name = "panelSalaryCRUD";
            this.panelSalaryCRUD.Size = new System.Drawing.Size(780, 390);
            this.panelSalaryCRUD.TabIndex = 1;
            // 
            // lblEmployee
            // 
            this.lblEmployee.Location = new System.Drawing.Point(10, 20);
            this.lblEmployee.Name = "lblEmployee";
            this.lblEmployee.Size = new System.Drawing.Size(80, 20);
            this.lblEmployee.TabIndex = 0;
            this.lblEmployee.Text = "Employee:";
            // 
            // cmbEmployee
            // 
            this.cmbEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmployee.Location = new System.Drawing.Point(100, 18);
            this.cmbEmployee.Name = "cmbEmployee";
            this.cmbEmployee.Size = new System.Drawing.Size(200, 21);
            this.cmbEmployee.TabIndex = 1;
            // 
            // lblMonth
            // 
            this.lblMonth.Location = new System.Drawing.Point(10, 50);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(80, 20);
            this.lblMonth.TabIndex = 2;
            this.lblMonth.Text = "Month:";
            // 
            // txtMonth
            // 
            this.txtMonth.Location = new System.Drawing.Point(100, 48);
            this.txtMonth.Name = "txtMonth";
            this.txtMonth.Size = new System.Drawing.Size(200, 20);
            this.txtMonth.TabIndex = 3;
            // 
            // lblYear
            // 
            this.lblYear.Location = new System.Drawing.Point(10, 80);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(80, 20);
            this.lblYear.TabIndex = 4;
            this.lblYear.Text = "Year:";
            // 
            // txtYear
            // 
            this.txtYear.Location = new System.Drawing.Point(100, 78);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(200, 20);
            this.txtYear.TabIndex = 5;
            // 
            // lblTotalSalary
            // 
            this.lblTotalSalary.Location = new System.Drawing.Point(10, 110);
            this.lblTotalSalary.Name = "lblTotalSalary";
            this.lblTotalSalary.Size = new System.Drawing.Size(80, 20);
            this.lblTotalSalary.TabIndex = 6;
            this.lblTotalSalary.Text = "Total Salary:";
            // 
            // txtTotalSalary
            // 
            this.txtTotalSalary.Location = new System.Drawing.Point(100, 108);
            this.txtTotalSalary.Name = "txtTotalSalary";
            this.txtTotalSalary.ReadOnly = true;
            this.txtTotalSalary.Size = new System.Drawing.Size(200, 20);
            this.txtTotalSalary.TabIndex = 7;
            // 
            // btnCalculateSalary
            // 
            this.btnCalculateSalary.Location = new System.Drawing.Point(310, 108);
            this.btnCalculateSalary.Name = "btnCalculateSalary";
            this.btnCalculateSalary.Size = new System.Drawing.Size(75, 20);
            this.btnCalculateSalary.TabIndex = 8;
            this.btnCalculateSalary.Text = "Calculate";
            // 
            // lblYearFilter
            // 
            this.lblYearFilter.Location = new System.Drawing.Point(10, 140);
            this.lblYearFilter.Name = "lblYearFilter";
            this.lblYearFilter.Size = new System.Drawing.Size(80, 20);
            this.lblYearFilter.TabIndex = 9;
            this.lblYearFilter.Text = "Filter Year:";
            // 
            // cmbYearFilter
            // 
            this.cmbYearFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYearFilter.Location = new System.Drawing.Point(100, 138);
            this.cmbYearFilter.Name = "cmbYearFilter";
            this.cmbYearFilter.Size = new System.Drawing.Size(100, 21);
            this.cmbYearFilter.TabIndex = 10;
            // 
            // btnAddSalary
            // 
            this.btnAddSalary.Location = new System.Drawing.Point(10, 170);
            this.btnAddSalary.Name = "btnAddSalary";
            this.btnAddSalary.Size = new System.Drawing.Size(75, 30);
            this.btnAddSalary.TabIndex = 11;
            this.btnAddSalary.Text = "Add";
            // 
            // btnEditSalary
            // 
            this.btnEditSalary.Location = new System.Drawing.Point(95, 170);
            this.btnEditSalary.Name = "btnEditSalary";
            this.btnEditSalary.Size = new System.Drawing.Size(75, 30);
            this.btnEditSalary.TabIndex = 12;
            this.btnEditSalary.Text = "Edit";
            // 
            // btnDeleteSalary
            // 
            this.btnDeleteSalary.Location = new System.Drawing.Point(180, 170);
            this.btnDeleteSalary.Name = "btnDeleteSalary";
            this.btnDeleteSalary.Size = new System.Drawing.Size(75, 30);
            this.btnDeleteSalary.TabIndex = 13;
            this.btnDeleteSalary.Text = "Delete";
            // 
            // btnRefreshSalary
            // 
            this.btnRefreshSalary.Location = new System.Drawing.Point(265, 170);
            this.btnRefreshSalary.Name = "btnRefreshSalary";
            this.btnRefreshSalary.Size = new System.Drawing.Size(75, 30);
            this.btnRefreshSalary.TabIndex = 14;
            this.btnRefreshSalary.Text = "Refresh";
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(10, 370);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(75, 20);
            this.btnPrevious.TabIndex = 15;
            this.btnPrevious.Text = "Previous";
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(95, 370);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 20);
            this.btnNext.TabIndex = 16;
            this.btnNext.Text = "Next";
            // 
            // lblPage
            // 
            this.lblPage.Location = new System.Drawing.Point(180, 370);
            this.lblPage.Name = "lblPage";
            this.lblPage.Size = new System.Drawing.Size(100, 20);
            this.lblPage.TabIndex = 17;
            this.lblPage.Text = "Page 1";
            // 
            // dgvSalaries
            // 
            this.dgvSalaries.Location = new System.Drawing.Point(10, 200);
            this.dgvSalaries.Name = "dgvSalaries";
            this.dgvSalaries.Size = new System.Drawing.Size(750, 170);
            this.dgvSalaries.TabIndex = 18;
            // 
            // panelEmployeeCRUD
            // 
            this.panelEmployeeCRUD.Controls.Add(this.lblEmployeeName);
            this.panelEmployeeCRUD.Controls.Add(this.txtEmployeeName);
            this.panelEmployeeCRUD.Controls.Add(this.lblPosition);
            this.panelEmployeeCRUD.Controls.Add(this.cmbPosition);
            this.panelEmployeeCRUD.Controls.Add(this.lblBaseSalary);
            this.panelEmployeeCRUD.Controls.Add(this.txtBaseSalary);
            this.panelEmployeeCRUD.Controls.Add(this.btnAddEmployee);
            this.panelEmployeeCRUD.Controls.Add(this.btnEditEmployee);
            this.panelEmployeeCRUD.Controls.Add(this.btnDeleteEmployee);
            this.panelEmployeeCRUD.Controls.Add(this.btnRefreshEmployee);
            this.panelEmployeeCRUD.Controls.Add(this.btnSeeGraph);
            this.panelEmployeeCRUD.Controls.Add(this.dgvEmployees);
            this.panelEmployeeCRUD.Location = new System.Drawing.Point(10, 50);
            this.panelEmployeeCRUD.Name = "panelEmployeeCRUD";
            this.panelEmployeeCRUD.Size = new System.Drawing.Size(780, 390);
            this.panelEmployeeCRUD.TabIndex = 0;
            // 
            // lblEmployeeName
            // 
            this.lblEmployeeName.Location = new System.Drawing.Point(10, 20);
            this.lblEmployeeName.Name = "lblEmployeeName";
            this.lblEmployeeName.Size = new System.Drawing.Size(80, 20);
            this.lblEmployeeName.TabIndex = 0;
            this.lblEmployeeName.Text = "Full Name:";
            // 
            // txtEmployeeName
            // 
            this.txtEmployeeName.Location = new System.Drawing.Point(100, 18);
            this.txtEmployeeName.Name = "txtEmployeeName";
            this.txtEmployeeName.Size = new System.Drawing.Size(200, 20);
            this.txtEmployeeName.TabIndex = 1;
            // 
            // lblPosition
            // 
            this.lblPosition.Location = new System.Drawing.Point(10, 50);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(80, 20);
            this.lblPosition.TabIndex = 2;
            this.lblPosition.Text = "Position:";
            // 
            // cmbPosition
            // 
            this.cmbPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPosition.Location = new System.Drawing.Point(100, 48);
            this.cmbPosition.Name = "cmbPosition";
            this.cmbPosition.Size = new System.Drawing.Size(200, 21);
            this.cmbPosition.TabIndex = 3;
            // 
            // lblBaseSalary
            // 
            this.lblBaseSalary.Location = new System.Drawing.Point(10, 80);
            this.lblBaseSalary.Name = "lblBaseSalary";
            this.lblBaseSalary.Size = new System.Drawing.Size(80, 20);
            this.lblBaseSalary.TabIndex = 4;
            this.lblBaseSalary.Text = "Base Salary:";
            // 
            // txtBaseSalary
            // 
            this.txtBaseSalary.Location = new System.Drawing.Point(100, 78);
            this.txtBaseSalary.Name = "txtBaseSalary";
            this.txtBaseSalary.Size = new System.Drawing.Size(200, 20);
            this.txtBaseSalary.TabIndex = 5;
            // 
            // btnAddEmployee
            // 
            this.btnAddEmployee.Location = new System.Drawing.Point(10, 120);
            this.btnAddEmployee.Name = "btnAddEmployee";
            this.btnAddEmployee.Size = new System.Drawing.Size(75, 30);
            this.btnAddEmployee.TabIndex = 6;
            this.btnAddEmployee.Text = "Add";
            // 
            // btnEditEmployee
            // 
            this.btnEditEmployee.Location = new System.Drawing.Point(95, 120);
            this.btnEditEmployee.Name = "btnEditEmployee";
            this.btnEditEmployee.Size = new System.Drawing.Size(75, 30);
            this.btnEditEmployee.TabIndex = 7;
            this.btnEditEmployee.Text = "Edit";
            // 
            // btnDeleteEmployee
            // 
            this.btnDeleteEmployee.Location = new System.Drawing.Point(180, 120);
            this.btnDeleteEmployee.Name = "btnDeleteEmployee";
            this.btnDeleteEmployee.Size = new System.Drawing.Size(75, 30);
            this.btnDeleteEmployee.TabIndex = 8;
            this.btnDeleteEmployee.Text = "Delete";
            // 
            // btnRefreshEmployee
            // 
            this.btnRefreshEmployee.Location = new System.Drawing.Point(265, 120);
            this.btnRefreshEmployee.Name = "btnRefreshEmployee";
            this.btnRefreshEmployee.Size = new System.Drawing.Size(75, 30);
            this.btnRefreshEmployee.TabIndex = 9;
            this.btnRefreshEmployee.Text = "Refresh";
            // 
            // btnSeeGraph
            // 
            this.btnSeeGraph.Location = new System.Drawing.Point(350, 120);
            this.btnSeeGraph.Name = "btnSeeGraph";
            this.btnSeeGraph.Size = new System.Drawing.Size(75, 30);
            this.btnSeeGraph.TabIndex = 10;
            this.btnSeeGraph.Text = "See Graph";
            // 
            // dgvEmployees
            // 
            this.dgvEmployees.Location = new System.Drawing.Point(10, 170);
            this.dgvEmployees.Name = "dgvEmployees";
            this.dgvEmployees.Size = new System.Drawing.Size(750, 200);
            this.dgvEmployees.TabIndex = 11;
            // 
            // panelAnalysis
            // 
            this.panelAnalysis.Controls.Add(this.lblAnalysisEmployee);
            this.panelAnalysis.Controls.Add(this.cmbAnalysisEmployee);
            this.panelAnalysis.Controls.Add(this.btnShowGraph);
            this.panelAnalysis.Controls.Add(this.chartSalary);
            this.panelAnalysis.Location = new System.Drawing.Point(10, 50);
            this.panelAnalysis.Name = "panelAnalysis";
            this.panelAnalysis.Size = new System.Drawing.Size(780, 390);
            this.panelAnalysis.TabIndex = 6;
            // 
            // lblAnalysisEmployee
            // 
            this.lblAnalysisEmployee.Location = new System.Drawing.Point(10, 10);
            this.lblAnalysisEmployee.Name = "lblAnalysisEmployee";
            this.lblAnalysisEmployee.Size = new System.Drawing.Size(100, 20);
            this.lblAnalysisEmployee.TabIndex = 0;
            this.lblAnalysisEmployee.Text = "Select Employee:";
            // 
            // cmbAnalysisEmployee
            // 
            this.cmbAnalysisEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAnalysisEmployee.Location = new System.Drawing.Point(120, 10);
            this.cmbAnalysisEmployee.Name = "cmbAnalysisEmployee";
            this.cmbAnalysisEmployee.Size = new System.Drawing.Size(200, 21);
            this.cmbAnalysisEmployee.TabIndex = 1;
            // 
            // btnShowGraph
            // 
            this.btnShowGraph.Location = new System.Drawing.Point(330, 10);
            this.btnShowGraph.Name = "btnShowGraph";
            this.btnShowGraph.Size = new System.Drawing.Size(100, 20);
            this.btnShowGraph.TabIndex = 2;
            this.btnShowGraph.Text = "Show Graph";
            // 
            // chartSalary
            // 
            this.chartSalary.Location = new System.Drawing.Point(10, 40);
            this.chartSalary.Name = "chartSalary";
            this.chartSalary.Size = new System.Drawing.Size(760, 340);
            this.chartSalary.TabIndex = 3;
            // 
            // btnAnalysisTab
            // 
            this.btnAnalysisTab.Location = new System.Drawing.Point(340, 10);
            this.btnAnalysisTab.Name = "btnAnalysisTab";
            this.btnAnalysisTab.Size = new System.Drawing.Size(100, 30);
            this.btnAnalysisTab.TabIndex = 6;
            this.btnAnalysisTab.Text = "Analysis";
            this.btnAnalysisTab.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 506);
            this.Controls.Add(this.panelCRUD);
            this.Controls.Add(this.panelLogin);
            this.Name = "Form1";
            this.Text = "Employee Compensation System";
            this.panelLogin.ResumeLayout(false);
            this.panelLogin.PerformLayout();
            this.panelCRUD.ResumeLayout(false);
            this.panelPositionCRUD.ResumeLayout(false);
            this.panelPositionCRUD.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPositions)).EndInit();
            this.panelSalaryCRUD.ResumeLayout(false);
            this.panelSalaryCRUD.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalaries)).EndInit();
            this.panelEmployeeCRUD.ResumeLayout(false);
            this.panelEmployeeCRUD.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).EndInit();
            this.panelAnalysis.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartSalary)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button LogInbutton;
        private System.Windows.Forms.Panel panelLogin;
        private System.Windows.Forms.Panel panelCRUD;
        private System.Windows.Forms.Panel panelEmployeeCRUD;
        private System.Windows.Forms.Panel panelSalaryCRUD;
        private System.Windows.Forms.Panel panelPositionCRUD;
        private System.Windows.Forms.Panel panelAnalysis;
        private System.Windows.Forms.Button btnEmployeeTab;
        private System.Windows.Forms.Button btnSalaryTab;
        private System.Windows.Forms.Button btnPositionTab;
        private System.Windows.Forms.Button btnAnalysisTab;
        private System.Windows.Forms.Label lblEmployeeName;
        private System.Windows.Forms.TextBox txtEmployeeName;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.ComboBox cmbPosition;
        private System.Windows.Forms.Label lblBaseSalary;
        private System.Windows.Forms.TextBox txtBaseSalary;
        private System.Windows.Forms.Button btnAddEmployee;
        private System.Windows.Forms.Button btnEditEmployee;
        private System.Windows.Forms.Button btnDeleteEmployee;
        private System.Windows.Forms.Button btnRefreshEmployee;
        private System.Windows.Forms.Button btnSeeGraph;
        private System.Windows.Forms.DataGridView dgvEmployees;
        private System.Windows.Forms.Label lblEmployee;
        private System.Windows.Forms.ComboBox cmbEmployee;
        private System.Windows.Forms.Label lblMonth;
        private System.Windows.Forms.TextBox txtMonth;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.Label lblTotalSalary;
        private System.Windows.Forms.TextBox txtTotalSalary;
        private System.Windows.Forms.Button btnCalculateSalary;
        private System.Windows.Forms.Label lblYearFilter;
        private System.Windows.Forms.ComboBox cmbYearFilter;
        private System.Windows.Forms.Button btnAddSalary;
        private System.Windows.Forms.Button btnEditSalary;
        private System.Windows.Forms.Button btnDeleteSalary;
        private System.Windows.Forms.Button btnRefreshSalary;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label lblPage;
        private System.Windows.Forms.DataGridView dgvSalaries;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblBonusPercent;
        private System.Windows.Forms.TextBox txtBonusPercent;
        private System.Windows.Forms.Button btnAddPosition;
        private System.Windows.Forms.Button btnEditPosition;
        private System.Windows.Forms.Button btnDeletePosition;
        private System.Windows.Forms.Button btnRefreshPosition;
        private System.Windows.Forms.DataGridView dgvPositions;
        //private System.Windows.Forms.Panel panelAnalysis;
        private System.Windows.Forms.Label lblAnalysisEmployee;
        private System.Windows.Forms.ComboBox cmbAnalysisEmployee;
        private System.Windows.Forms.Button btnShowGraph;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSalary;
    }
}