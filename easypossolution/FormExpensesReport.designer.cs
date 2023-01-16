namespace easyPOSSolution
{
    partial class FormExpensesReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormExpensesReport));
            this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonViewReport1 = new System.Windows.Forms.Button();
            this.ButtonExit1 = new System.Windows.Forms.Button();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.TabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.buttonViewReport3 = new System.Windows.Forms.Button();
            this.buttonExit3 = new System.Windows.Forms.Button();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.dateTimePickerTo3 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerFrom3 = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.crystalReportViewer3 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.comboBoxExpensesCat = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox16 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.buttonViewCustomer = new System.Windows.Forms.Button();
            this.buttonExitCustomer = new System.Windows.Forms.Button();
            this.groupBox17 = new System.Windows.Forms.GroupBox();
            this.dateTimePickerToCust = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerFromCust = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox18 = new System.Windows.Forms.GroupBox();
            this.gridControl4 = new DevExpress.XtraGrid.GridControl();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.TabPage1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.TabControl1.SuspendLayout();
            this.TabPage2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox16.SuspendLayout();
            this.groupBox17.SuspendLayout();
            this.groupBox18.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.CustomFormat = "yyyy/MM/dd";
            this.dateTimePickerTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerTo.Location = new System.Drawing.Point(195, 42);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(120, 23);
            this.dateTimePickerTo.TabIndex = 107;
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.CustomFormat = "yyyy/MM/dd";
            this.dateTimePickerFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerFrom.Location = new System.Drawing.Point(24, 42);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(120, 23);
            this.dateTimePickerFrom.TabIndex = 106;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.Location = new System.Drawing.Point(20, 18);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(47, 21);
            this.Label3.TabIndex = 9;
            this.Label3.Text = "From";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.Location = new System.Drawing.Point(191, 18);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(28, 21);
            this.Label4.TabIndex = 10;
            this.Label4.Text = "To";
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.groupBox5);
            this.TabPage1.Controls.Add(this.GroupBox2);
            this.TabPage1.Controls.Add(this.GroupBox1);
            this.TabPage1.Location = new System.Drawing.Point(4, 24);
            this.TabPage1.Name = "TabPage1";
            this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage1.Size = new System.Drawing.Size(1011, 636);
            this.TabPage1.TabIndex = 0;
            this.TabPage1.Text = "By Expense Date";
            this.TabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.crystalReportViewer1);
            this.groupBox5.Location = new System.Drawing.Point(9, 94);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(993, 535);
            this.groupBox5.TabIndex = 22;
            this.groupBox5.TabStop = false;
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(3, 19);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(987, 513);
            this.crystalReportViewer1.TabIndex = 0;
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.buttonViewReport1);
            this.GroupBox2.Controls.Add(this.ButtonExit1);
            this.GroupBox2.Location = new System.Drawing.Point(692, 6);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(314, 87);
            this.GroupBox2.TabIndex = 19;
            this.GroupBox2.TabStop = false;
            // 
            // buttonViewReport1
            // 
            this.buttonViewReport1.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonViewReport1.Location = new System.Drawing.Point(18, 26);
            this.buttonViewReport1.Name = "buttonViewReport1";
            this.buttonViewReport1.Size = new System.Drawing.Size(112, 40);
            this.buttonViewReport1.TabIndex = 0;
            this.buttonViewReport1.Text = "&View Report";
            this.buttonViewReport1.UseVisualStyleBackColor = true;
            this.buttonViewReport1.Click += new System.EventHandler(this.buttonViewReport1_Click);
            // 
            // ButtonExit1
            // 
            this.ButtonExit1.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonExit1.Location = new System.Drawing.Point(181, 26);
            this.ButtonExit1.Name = "ButtonExit1";
            this.ButtonExit1.Size = new System.Drawing.Size(112, 40);
            this.ButtonExit1.TabIndex = 1;
            this.ButtonExit1.Text = "&Exit";
            this.ButtonExit1.UseVisualStyleBackColor = true;
            this.ButtonExit1.Click += new System.EventHandler(this.ButtonExit1_Click);
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.dateTimePickerTo);
            this.GroupBox1.Controls.Add(this.dateTimePickerFrom);
            this.GroupBox1.Controls.Add(this.Label3);
            this.GroupBox1.Controls.Add(this.Label4);
            this.GroupBox1.Location = new System.Drawing.Point(8, 6);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(350, 87);
            this.GroupBox1.TabIndex = 18;
            this.GroupBox1.TabStop = false;
            // 
            // TabControl1
            // 
            this.TabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabControl1.Controls.Add(this.TabPage1);
            this.TabControl1.Controls.Add(this.TabPage2);
            this.TabControl1.Controls.Add(this.tabPage3);
            this.TabControl1.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabControl1.Location = new System.Drawing.Point(8, 5);
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            this.TabControl1.Size = new System.Drawing.Size(1019, 664);
            this.TabControl1.TabIndex = 5;
            // 
            // TabPage2
            // 
            this.TabPage2.Controls.Add(this.groupBox6);
            this.TabPage2.Controls.Add(this.groupBox9);
            this.TabPage2.Controls.Add(this.groupBox10);
            this.TabPage2.Controls.Add(this.groupBox12);
            this.TabPage2.Location = new System.Drawing.Point(4, 24);
            this.TabPage2.Name = "TabPage2";
            this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage2.Size = new System.Drawing.Size(1067, 570);
            this.TabPage2.TabIndex = 4;
            this.TabPage2.Text = "By Expense Category";
            this.TabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.buttonViewReport3);
            this.groupBox6.Controls.Add(this.buttonExit3);
            this.groupBox6.Location = new System.Drawing.Point(730, 6);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(285, 87);
            this.groupBox6.TabIndex = 35;
            this.groupBox6.TabStop = false;
            // 
            // buttonViewReport3
            // 
            this.buttonViewReport3.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonViewReport3.Location = new System.Drawing.Point(18, 26);
            this.buttonViewReport3.Name = "buttonViewReport3";
            this.buttonViewReport3.Size = new System.Drawing.Size(112, 40);
            this.buttonViewReport3.TabIndex = 0;
            this.buttonViewReport3.Text = "&View Report";
            this.buttonViewReport3.UseVisualStyleBackColor = true;
            this.buttonViewReport3.Click += new System.EventHandler(this.buttonViewReport3_Click);
            // 
            // buttonExit3
            // 
            this.buttonExit3.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExit3.Location = new System.Drawing.Point(145, 26);
            this.buttonExit3.Name = "buttonExit3";
            this.buttonExit3.Size = new System.Drawing.Size(112, 40);
            this.buttonExit3.TabIndex = 1;
            this.buttonExit3.Text = "&Exit";
            this.buttonExit3.UseVisualStyleBackColor = true;
            this.buttonExit3.Click += new System.EventHandler(this.buttonExit3_Click);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.dateTimePickerTo3);
            this.groupBox9.Controls.Add(this.dateTimePickerFrom3);
            this.groupBox9.Controls.Add(this.label7);
            this.groupBox9.Controls.Add(this.label8);
            this.groupBox9.Location = new System.Drawing.Point(15, 6);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(350, 87);
            this.groupBox9.TabIndex = 34;
            this.groupBox9.TabStop = false;
            // 
            // dateTimePickerTo3
            // 
            this.dateTimePickerTo3.CustomFormat = "yyyy/MM/dd";
            this.dateTimePickerTo3.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerTo3.Location = new System.Drawing.Point(195, 42);
            this.dateTimePickerTo3.Name = "dateTimePickerTo3";
            this.dateTimePickerTo3.Size = new System.Drawing.Size(120, 23);
            this.dateTimePickerTo3.TabIndex = 107;
            // 
            // dateTimePickerFrom3
            // 
            this.dateTimePickerFrom3.CustomFormat = "yyyy/MM/dd";
            this.dateTimePickerFrom3.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerFrom3.Location = new System.Drawing.Point(24, 42);
            this.dateTimePickerFrom3.Name = "dateTimePickerFrom3";
            this.dateTimePickerFrom3.Size = new System.Drawing.Size(120, 23);
            this.dateTimePickerFrom3.TabIndex = 106;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(20, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 21);
            this.label7.TabIndex = 9;
            this.label7.Text = "From";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(191, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 21);
            this.label8.TabIndex = 10;
            this.label8.Text = "To";
            // 
            // groupBox10
            // 
            this.groupBox10.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox10.Controls.Add(this.crystalReportViewer3);
            this.groupBox10.Location = new System.Drawing.Point(9, 96);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(1049, 536);
            this.groupBox10.TabIndex = 31;
            this.groupBox10.TabStop = false;
            // 
            // crystalReportViewer3
            // 
            this.crystalReportViewer3.ActiveViewIndex = -1;
            this.crystalReportViewer3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer3.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer3.Location = new System.Drawing.Point(3, 19);
            this.crystalReportViewer3.Name = "crystalReportViewer3";
            this.crystalReportViewer3.Size = new System.Drawing.Size(1043, 514);
            this.crystalReportViewer3.TabIndex = 0;
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.comboBoxExpensesCat);
            this.groupBox12.Controls.Add(this.label6);
            this.groupBox12.Location = new System.Drawing.Point(378, 5);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(340, 87);
            this.groupBox12.TabIndex = 30;
            this.groupBox12.TabStop = false;
            // 
            // comboBoxExpensesCat
            // 
            this.comboBoxExpensesCat.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboBoxExpensesCat.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxExpensesCat.FormattingEnabled = true;
            this.comboBoxExpensesCat.Location = new System.Drawing.Point(24, 45);
            this.comboBoxExpensesCat.Name = "comboBoxExpensesCat";
            this.comboBoxExpensesCat.Size = new System.Drawing.Size(301, 23);
            this.comboBoxExpensesCat.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(28, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 18);
            this.label6.TabIndex = 9;
            this.label6.Text = "Expenses Category";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox18);
            this.tabPage3.Controls.Add(this.groupBox16);
            this.tabPage3.Controls.Add(this.groupBox17);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1011, 636);
            this.tabPage3.TabIndex = 5;
            this.tabPage3.Text = "SalaryAdvance";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox16
            // 
            this.groupBox16.Controls.Add(this.button4);
            this.groupBox16.Controls.Add(this.buttonViewCustomer);
            this.groupBox16.Controls.Add(this.buttonExitCustomer);
            this.groupBox16.Location = new System.Drawing.Point(570, 6);
            this.groupBox16.Name = "groupBox16";
            this.groupBox16.Size = new System.Drawing.Size(436, 87);
            this.groupBox16.TabIndex = 46;
            this.groupBox16.TabStop = false;
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(275, 25);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(112, 40);
            this.button4.TabIndex = 6;
            this.button4.Text = "&Export Excell";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // buttonViewCustomer
            // 
            this.buttonViewCustomer.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonViewCustomer.Location = new System.Drawing.Point(18, 26);
            this.buttonViewCustomer.Name = "buttonViewCustomer";
            this.buttonViewCustomer.Size = new System.Drawing.Size(112, 40);
            this.buttonViewCustomer.TabIndex = 0;
            this.buttonViewCustomer.Text = "&View Report";
            this.buttonViewCustomer.UseVisualStyleBackColor = true;
            this.buttonViewCustomer.Click += new System.EventHandler(this.buttonViewCustomer_Click);
            // 
            // buttonExitCustomer
            // 
            this.buttonExitCustomer.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExitCustomer.Location = new System.Drawing.Point(145, 26);
            this.buttonExitCustomer.Name = "buttonExitCustomer";
            this.buttonExitCustomer.Size = new System.Drawing.Size(112, 40);
            this.buttonExitCustomer.TabIndex = 1;
            this.buttonExitCustomer.Text = "&Exit";
            this.buttonExitCustomer.UseVisualStyleBackColor = true;
            // 
            // groupBox17
            // 
            this.groupBox17.Controls.Add(this.dateTimePickerToCust);
            this.groupBox17.Controls.Add(this.dateTimePickerFromCust);
            this.groupBox17.Controls.Add(this.label12);
            this.groupBox17.Controls.Add(this.label13);
            this.groupBox17.Location = new System.Drawing.Point(6, 6);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Size = new System.Drawing.Size(292, 87);
            this.groupBox17.TabIndex = 45;
            this.groupBox17.TabStop = false;
            // 
            // dateTimePickerToCust
            // 
            this.dateTimePickerToCust.CustomFormat = "yyyy/MM/dd";
            this.dateTimePickerToCust.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerToCust.Location = new System.Drawing.Point(157, 42);
            this.dateTimePickerToCust.Name = "dateTimePickerToCust";
            this.dateTimePickerToCust.Size = new System.Drawing.Size(120, 23);
            this.dateTimePickerToCust.TabIndex = 107;
            // 
            // dateTimePickerFromCust
            // 
            this.dateTimePickerFromCust.CustomFormat = "yyyy/MM/dd";
            this.dateTimePickerFromCust.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerFromCust.Location = new System.Drawing.Point(15, 42);
            this.dateTimePickerFromCust.Name = "dateTimePickerFromCust";
            this.dateTimePickerFromCust.Size = new System.Drawing.Size(120, 23);
            this.dateTimePickerFromCust.TabIndex = 106;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(11, 18);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(47, 21);
            this.label12.TabIndex = 9;
            this.label12.Text = "From";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(153, 18);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(28, 21);
            this.label13.TabIndex = 10;
            this.label13.Text = "To";
            // 
            // groupBox18
            // 
            this.groupBox18.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox18.Controls.Add(this.gridControl4);
            this.groupBox18.Location = new System.Drawing.Point(6, 99);
            this.groupBox18.Name = "groupBox18";
            this.groupBox18.Size = new System.Drawing.Size(999, 531);
            this.groupBox18.TabIndex = 47;
            this.groupBox18.TabStop = false;
            // 
            // gridControl4
            // 
            this.gridControl4.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl4.Location = new System.Drawing.Point(3, 19);
            this.gridControl4.MainView = this.gridView4;
            this.gridControl4.Name = "gridControl4";
            this.gridControl4.Size = new System.Drawing.Size(993, 509);
            this.gridControl4.TabIndex = 4;
            this.gridControl4.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView4});
            // 
            // gridView4
            // 
            this.gridView4.GridControl = this.gridControl4;
            this.gridView4.Name = "gridView4";
            this.gridView4.OptionsFind.AlwaysVisible = true;
            this.gridView4.OptionsView.ShowFooter = true;
            // 
            // FormExpensesReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 672);
            this.Controls.Add(this.TabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormExpensesReport";
            this.Text = "FormExpensesReport";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormExpensesReport_Load);
            this.TabPage1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.TabControl1.ResumeLayout(false);
            this.TabPage2.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.groupBox16.ResumeLayout(false);
            this.groupBox17.ResumeLayout(false);
            this.groupBox17.PerformLayout();
            this.groupBox18.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.DateTimePicker dateTimePickerTo;
        internal System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.TabPage TabPage1;
        private System.Windows.Forms.GroupBox groupBox5;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.Button buttonViewReport1;
        internal System.Windows.Forms.Button ButtonExit1;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.TabControl TabControl1;
        internal System.Windows.Forms.TabPage TabPage2;
        internal System.Windows.Forms.GroupBox groupBox6;
        internal System.Windows.Forms.Button buttonViewReport3;
        internal System.Windows.Forms.Button buttonExit3;
        internal System.Windows.Forms.GroupBox groupBox9;
        internal System.Windows.Forms.DateTimePicker dateTimePickerTo3;
        internal System.Windows.Forms.DateTimePicker dateTimePickerFrom3;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox10;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer3;
        internal System.Windows.Forms.GroupBox groupBox12;
        internal System.Windows.Forms.ComboBox comboBoxExpensesCat;
        internal System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabPage tabPage3;
        internal System.Windows.Forms.GroupBox groupBox16;
        internal System.Windows.Forms.Button button4;
        internal System.Windows.Forms.Button buttonViewCustomer;
        internal System.Windows.Forms.Button buttonExitCustomer;
        internal System.Windows.Forms.GroupBox groupBox17;
        internal System.Windows.Forms.DateTimePicker dateTimePickerToCust;
        internal System.Windows.Forms.DateTimePicker dateTimePickerFromCust;
        internal System.Windows.Forms.Label label12;
        internal System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox18;
        private DevExpress.XtraGrid.GridControl gridControl4;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;

    }
}