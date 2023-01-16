namespace easyPOSSolution
{
    partial class EmployeeRegistration
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeeRegistration));
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.Delete = new System.Windows.Forms.Button();
            this.Update_Record = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.NewRecord = new System.Windows.Forms.Button();
            this.Button1 = new System.Windows.Forms.Button();
            this.EmployeeID = new System.Windows.Forms.TextBox();
            this.BasicWorkingTime = new System.Windows.Forms.MaskedTextBox();
            this.Label12 = new System.Windows.Forms.Label();
            this.EmployeeName = new System.Windows.Forms.TextBox();
            this.Designation = new System.Windows.Forms.ComboBox();
            this.Label11 = new System.Windows.Forms.Label();
            this.DateOfJoining = new System.Windows.Forms.DateTimePicker();
            this.Salary = new System.Windows.Forms.TextBox();
            this.BloodGroup = new System.Windows.Forms.ComboBox();
            this.Email = new System.Windows.Forms.TextBox();
            this.MobileNo = new System.Windows.Forms.MaskedTextBox();
            this.Address = new System.Windows.Forms.TextBox();
            this.Label10 = new System.Windows.Forms.Label();
            this.Label9 = new System.Windows.Forms.Label();
            this.Label8 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxOTRate = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBoxHourlyRate = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label21 = new System.Windows.Forms.Label();
            this.StatusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ToolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblUserId = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBoxNewDesignation = new System.Windows.Forms.TextBox();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.dateTimePickerDOB = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.textBoxLeaveDeduction = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.GroupBox2.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.StatusStrip1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // GroupBox2
            // 
            this.GroupBox2.BackColor = System.Drawing.Color.Transparent;
            this.GroupBox2.Controls.Add(this.Delete);
            this.GroupBox2.Controls.Add(this.Update_Record);
            this.GroupBox2.Controls.Add(this.Save);
            this.GroupBox2.Controls.Add(this.NewRecord);
            this.GroupBox2.Location = new System.Drawing.Point(281, 8);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(381, 47);
            this.GroupBox2.TabIndex = 52;
            this.GroupBox2.TabStop = false;
            // 
            // Delete
            // 
            this.Delete.Enabled = false;
            this.Delete.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Delete.Location = new System.Drawing.Point(288, 12);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(81, 29);
            this.Delete.TabIndex = 3;
            this.Delete.Text = "&Delete";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // Update_Record
            // 
            this.Update_Record.Enabled = false;
            this.Update_Record.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Update_Record.Location = new System.Drawing.Point(196, 12);
            this.Update_Record.Name = "Update_Record";
            this.Update_Record.Size = new System.Drawing.Size(81, 29);
            this.Update_Record.TabIndex = 2;
            this.Update_Record.Text = "&Update";
            this.Update_Record.UseVisualStyleBackColor = true;
            this.Update_Record.Click += new System.EventHandler(this.Update_Record_Click);
            // 
            // Save
            // 
            this.Save.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Save.Location = new System.Drawing.Point(104, 12);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(81, 29);
            this.Save.TabIndex = 1;
            this.Save.Text = "&Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // NewRecord
            // 
            this.NewRecord.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewRecord.Location = new System.Drawing.Point(12, 12);
            this.NewRecord.Name = "NewRecord";
            this.NewRecord.Size = new System.Drawing.Size(81, 29);
            this.NewRecord.TabIndex = 0;
            this.NewRecord.Text = "&New";
            this.NewRecord.UseVisualStyleBackColor = true;
            this.NewRecord.Click += new System.EventHandler(this.NewRecord_Click);
            // 
            // Button1
            // 
            this.Button1.Location = new System.Drawing.Point(314, 32);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(34, 23);
            this.Button1.TabIndex = 30;
            this.Button1.Text = ">";
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // EmployeeID
            // 
            this.EmployeeID.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmployeeID.Location = new System.Drawing.Point(134, 32);
            this.EmployeeID.Name = "EmployeeID";
            this.EmployeeID.ReadOnly = true;
            this.EmployeeID.Size = new System.Drawing.Size(163, 23);
            this.EmployeeID.TabIndex = 29;
            // 
            // BasicWorkingTime
            // 
            this.BasicWorkingTime.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BasicWorkingTime.Location = new System.Drawing.Point(134, 61);
            this.BasicWorkingTime.Name = "BasicWorkingTime";
            this.BasicWorkingTime.Size = new System.Drawing.Size(163, 23);
            this.BasicWorkingTime.TabIndex = 0;
            this.BasicWorkingTime.ValidatingType = typeof(System.DateTime);
            this.BasicWorkingTime.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BasicWorkingTime_KeyDown);
            // 
            // Label12
            // 
            this.Label12.AutoSize = true;
            this.Label12.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label12.Location = new System.Drawing.Point(12, 64);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(113, 18);
            this.Label12.TabIndex = 28;
            this.Label12.Text = "* Employee Code";
            // 
            // EmployeeName
            // 
            this.EmployeeName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmployeeName.Location = new System.Drawing.Point(134, 90);
            this.EmployeeName.Name = "EmployeeName";
            this.EmployeeName.Size = new System.Drawing.Size(383, 23);
            this.EmployeeName.TabIndex = 1;
            this.EmployeeName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EmployeeName_KeyDown);
            // 
            // Designation
            // 
            this.Designation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.Designation.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.Designation.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Designation.FormattingEnabled = true;
            this.Designation.Location = new System.Drawing.Point(134, 238);
            this.Designation.Name = "Designation";
            this.Designation.Size = new System.Drawing.Size(254, 23);
            this.Designation.TabIndex = 6;
            this.Designation.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Designation_KeyDown);
            // 
            // Label11
            // 
            this.Label11.AutoSize = true;
            this.Label11.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label11.Location = new System.Drawing.Point(36, 241);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(89, 18);
            this.Label11.TabIndex = 27;
            this.Label11.Text = "*Designation";
            // 
            // DateOfJoining
            // 
            this.DateOfJoining.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateOfJoining.CustomFormat = "yyyy/MM/dd";
            this.DateOfJoining.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateOfJoining.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateOfJoining.Location = new System.Drawing.Point(506, 208);
            this.DateOfJoining.Name = "DateOfJoining";
            this.DateOfJoining.Size = new System.Drawing.Size(137, 23);
            this.DateOfJoining.TabIndex = 7;
            this.DateOfJoining.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DateOfJoining_KeyDown);
            // 
            // Salary
            // 
            this.Salary.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Salary.Location = new System.Drawing.Point(134, 304);
            this.Salary.Multiline = true;
            this.Salary.Name = "Salary";
            this.Salary.Size = new System.Drawing.Size(102, 23);
            this.Salary.TabIndex = 8;
            this.Salary.Text = "0.00";
            this.Salary.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Salary.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Salary_KeyDown);
            // 
            // BloodGroup
            // 
            this.BloodGroup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.BloodGroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.BloodGroup.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BloodGroup.FormattingEnabled = true;
            this.BloodGroup.Items.AddRange(new object[] {
            "A+",
            "B+",
            "AB+",
            "O+",
            "A-",
            "B-",
            "AB-",
            "O-"});
            this.BloodGroup.Location = new System.Drawing.Point(134, 207);
            this.BloodGroup.Name = "BloodGroup";
            this.BloodGroup.Size = new System.Drawing.Size(52, 23);
            this.BloodGroup.TabIndex = 5;
            this.BloodGroup.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BloodGroup_KeyDown);
            // 
            // Email
            // 
            this.Email.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Email.Location = new System.Drawing.Point(134, 178);
            this.Email.Multiline = true;
            this.Email.Name = "Email";
            this.Email.Size = new System.Drawing.Size(254, 23);
            this.Email.TabIndex = 4;
            this.Email.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Email_KeyDown);
            // 
            // MobileNo
            // 
            this.MobileNo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MobileNo.Location = new System.Drawing.Point(134, 151);
            this.MobileNo.Name = "MobileNo";
            this.MobileNo.Size = new System.Drawing.Size(163, 23);
            this.MobileNo.TabIndex = 3;
            this.MobileNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MobileNo_KeyDown);
            // 
            // Address
            // 
            this.Address.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Address.Location = new System.Drawing.Point(134, 120);
            this.Address.Multiline = true;
            this.Address.Name = "Address";
            this.Address.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.Address.Size = new System.Drawing.Size(383, 23);
            this.Address.TabIndex = 2;
            this.Address.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Address_KeyDown);
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label10.Location = new System.Drawing.Point(74, 179);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(51, 18);
            this.Label10.TabIndex = 9;
            this.Label10.Text = " E-Mail";
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label9.Location = new System.Drawing.Point(31, 33);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(94, 18);
            this.Label9.TabIndex = 8;
            this.Label9.Text = "*Employee ID";
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label8.Location = new System.Drawing.Point(35, 305);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(90, 18);
            this.Label8.TabIndex = 7;
            this.Label8.Text = "* Basic Salary";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.Location = new System.Drawing.Point(34, 208);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(91, 18);
            this.Label5.TabIndex = 4;
            this.Label5.Text = " Blood Group";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.Location = new System.Drawing.Point(61, 119);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(64, 18);
            this.Label4.TabIndex = 3;
            this.Label4.Text = "*Address";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.Location = new System.Drawing.Point(39, 150);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(86, 18);
            this.Label3.TabIndex = 2;
            this.Label3.Text = "*Contact No.";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(10, 90);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(115, 18);
            this.Label1.TabIndex = 1;
            this.Label1.Text = "*Employee Name";
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label7.Location = new System.Drawing.Point(390, 211);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(107, 18);
            this.Label7.TabIndex = 6;
            this.Label7.Text = "*Date of Joining";
            // 
            // GroupBox1
            // 
            this.GroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.GroupBox1.Controls.Add(this.textBoxLeaveDeduction);
            this.GroupBox1.Controls.Add(this.label15);
            this.GroupBox1.Controls.Add(this.dateTimePickerDOB);
            this.GroupBox1.Controls.Add(this.label14);
            this.GroupBox1.Controls.Add(this.textBoxOTRate);
            this.GroupBox1.Controls.Add(this.label13);
            this.GroupBox1.Controls.Add(this.textBoxHourlyRate);
            this.GroupBox1.Controls.Add(this.label6);
            this.GroupBox1.Controls.Add(this.Button1);
            this.GroupBox1.Controls.Add(this.EmployeeID);
            this.GroupBox1.Controls.Add(this.BasicWorkingTime);
            this.GroupBox1.Controls.Add(this.Label12);
            this.GroupBox1.Controls.Add(this.EmployeeName);
            this.GroupBox1.Controls.Add(this.Designation);
            this.GroupBox1.Controls.Add(this.Label11);
            this.GroupBox1.Controls.Add(this.DateOfJoining);
            this.GroupBox1.Controls.Add(this.Salary);
            this.GroupBox1.Controls.Add(this.BloodGroup);
            this.GroupBox1.Controls.Add(this.Email);
            this.GroupBox1.Controls.Add(this.MobileNo);
            this.GroupBox1.Controls.Add(this.Address);
            this.GroupBox1.Controls.Add(this.Label10);
            this.GroupBox1.Controls.Add(this.Label9);
            this.GroupBox1.Controls.Add(this.Label8);
            this.GroupBox1.Controls.Add(this.Label7);
            this.GroupBox1.Controls.Add(this.Label5);
            this.GroupBox1.Controls.Add(this.Label4);
            this.GroupBox1.Controls.Add(this.Label3);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox1.Location = new System.Drawing.Point(3, 80);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(659, 350);
            this.GroupBox1.TabIndex = 51;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Employee Details";
            // 
            // textBoxOTRate
            // 
            this.textBoxOTRate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxOTRate.Location = new System.Drawing.Point(506, 269);
            this.textBoxOTRate.Multiline = true;
            this.textBoxOTRate.Name = "textBoxOTRate";
            this.textBoxOTRate.Size = new System.Drawing.Size(137, 23);
            this.textBoxOTRate.TabIndex = 34;
            this.textBoxOTRate.Text = "0.00";
            this.textBoxOTRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxOTRate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxOTRate_KeyDown);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(437, 271);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(67, 18);
            this.label13.TabIndex = 33;
            this.label13.Text = "* OT Rate";
            // 
            // textBoxHourlyRate
            // 
            this.textBoxHourlyRate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxHourlyRate.Location = new System.Drawing.Point(134, 269);
            this.textBoxHourlyRate.Multiline = true;
            this.textBoxHourlyRate.Name = "textBoxHourlyRate";
            this.textBoxHourlyRate.Size = new System.Drawing.Size(102, 23);
            this.textBoxHourlyRate.TabIndex = 32;
            this.textBoxHourlyRate.Text = "0.00";
            this.textBoxHourlyRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxHourlyRate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxHourlyRate_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(41, 271);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 18);
            this.label6.TabIndex = 31;
            this.label6.Text = "* Hourly Rate";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label21);
            this.panel1.Location = new System.Drawing.Point(3, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(272, 45);
            this.panel1.TabIndex = 53;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.SteelBlue;
            this.label21.Location = new System.Drawing.Point(14, 7);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(224, 28);
            this.label21.TabIndex = 50;
            this.label21.Text = "Employee Registration";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StatusStrip1
            // 
            this.StatusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripStatusLabel1,
            this.lblUser,
            this.lblUserId,
            this.ToolStripStatusLabel3});
            this.StatusStrip1.Location = new System.Drawing.Point(0, 518);
            this.StatusStrip1.Name = "StatusStrip1";
            this.StatusStrip1.Size = new System.Drawing.Size(674, 22);
            this.StatusStrip1.TabIndex = 181;
            this.StatusStrip1.Text = "StatusStrip1";
            // 
            // ToolStripStatusLabel1
            // 
            this.ToolStripStatusLabel1.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1";
            this.ToolStripStatusLabel1.Size = new System.Drawing.Size(86, 17);
            this.ToolStripStatusLabel1.Text = "Logged in As :";
            // 
            // lblUser
            // 
            this.lblUser.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.ForeColor = System.Drawing.Color.Red;
            this.lblUser.Image = ((System.Drawing.Image)(resources.GetObject("lblUser.Image")));
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(145, 17);
            this.lblUser.Text = "ToolStripStatusLabel2";
            // 
            // lblUserId
            // 
            this.lblUserId.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserId.ForeColor = System.Drawing.Color.Red;
            this.lblUserId.Image = ((System.Drawing.Image)(resources.GetObject("lblUserId.Image")));
            this.lblUserId.Name = "lblUserId";
            this.lblUserId.Size = new System.Drawing.Size(145, 17);
            this.lblUserId.Text = "ToolStripStatusLabel2";
            this.lblUserId.Visible = false;
            // 
            // ToolStripStatusLabel3
            // 
            this.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3";
            this.ToolStripStatusLabel3.Size = new System.Drawing.Size(428, 17);
            this.ToolStripStatusLabel3.Spring = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBoxNewDesignation);
            this.groupBox3.Controls.Add(this.buttonCreate);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(3, 434);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(659, 78);
            this.groupBox3.TabIndex = 182;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Create Designation";
            // 
            // textBoxNewDesignation
            // 
            this.textBoxNewDesignation.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNewDesignation.Location = new System.Drawing.Point(183, 32);
            this.textBoxNewDesignation.Multiline = true;
            this.textBoxNewDesignation.Name = "textBoxNewDesignation";
            this.textBoxNewDesignation.Size = new System.Drawing.Size(254, 23);
            this.textBoxNewDesignation.TabIndex = 31;
            // 
            // buttonCreate
            // 
            this.buttonCreate.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCreate.Location = new System.Drawing.Point(443, 32);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(97, 25);
            this.buttonCreate.TabIndex = 30;
            this.buttonCreate.Text = "&Create";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(63, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 18);
            this.label2.TabIndex = 29;
            this.label2.Text = "New Designation";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // dateTimePickerDOB
            // 
            this.dateTimePickerDOB.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerDOB.CustomFormat = "yyyy/MM/dd";
            this.dateTimePickerDOB.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerDOB.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerDOB.Location = new System.Drawing.Point(506, 179);
            this.dateTimePickerDOB.Name = "dateTimePickerDOB";
            this.dateTimePickerDOB.Size = new System.Drawing.Size(137, 23);
            this.dateTimePickerDOB.TabIndex = 197;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(412, 182);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(92, 18);
            this.label14.TabIndex = 196;
            this.label14.Text = "*Date of Birth";
            // 
            // textBoxLeaveDeduction
            // 
            this.textBoxLeaveDeduction.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxLeaveDeduction.Location = new System.Drawing.Point(506, 305);
            this.textBoxLeaveDeduction.Multiline = true;
            this.textBoxLeaveDeduction.Name = "textBoxLeaveDeduction";
            this.textBoxLeaveDeduction.Size = new System.Drawing.Size(137, 23);
            this.textBoxLeaveDeduction.TabIndex = 199;
            this.textBoxLeaveDeduction.Text = "0.00";
            this.textBoxLeaveDeduction.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(336, 306);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(168, 18);
            this.label15.TabIndex = 198;
            this.label15.Text = "* Leave Deduction per day";
            // 
            // EmployeeRegistration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(674, 540);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.StatusStrip1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.GroupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "EmployeeRegistration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EmployeeRegistration";
            this.Load += new System.EventHandler(this.EmployeeRegistration_Load);
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.StatusStrip1.ResumeLayout(false);
            this.StatusStrip1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.Button Delete;
        internal System.Windows.Forms.Button Update_Record;
        internal System.Windows.Forms.Button Save;
        internal System.Windows.Forms.Button NewRecord;
        internal System.Windows.Forms.Button Button1;
        internal System.Windows.Forms.TextBox EmployeeID;
        internal System.Windows.Forms.MaskedTextBox BasicWorkingTime;
        internal System.Windows.Forms.Label Label12;
        internal System.Windows.Forms.TextBox EmployeeName;
        internal System.Windows.Forms.ComboBox Designation;
        internal System.Windows.Forms.Label Label11;
        internal System.Windows.Forms.DateTimePicker DateOfJoining;
        internal System.Windows.Forms.TextBox Salary;
        internal System.Windows.Forms.ComboBox BloodGroup;
        internal System.Windows.Forms.TextBox Email;
        internal System.Windows.Forms.MaskedTextBox MobileNo;
        internal System.Windows.Forms.TextBox Address;
        internal System.Windows.Forms.Label Label10;
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.GroupBox GroupBox1;
        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.Label label21;
        internal System.Windows.Forms.StatusStrip StatusStrip1;
        internal System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel1;
        internal System.Windows.Forms.ToolStripStatusLabel lblUser;
        internal System.Windows.Forms.ToolStripStatusLabel lblUserId;
        internal System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel3;
        private System.Windows.Forms.GroupBox groupBox3;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Button buttonCreate;
        internal System.Windows.Forms.TextBox textBoxNewDesignation;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        internal System.Windows.Forms.TextBox textBoxHourlyRate;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.TextBox textBoxOTRate;
        internal System.Windows.Forms.Label label13;
        internal System.Windows.Forms.DateTimePicker dateTimePickerDOB;
        internal System.Windows.Forms.Label label14;
        internal System.Windows.Forms.TextBox textBoxLeaveDeduction;
        internal System.Windows.Forms.Label label15;
    }
}