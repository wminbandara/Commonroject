namespace easyPOSSolution
{
    partial class FormSalesReturn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSalesReturn));
            this.textBoxNetAmount = new System.Windows.Forms.TextBox();
            this.textBoxItemCode = new System.Windows.Forms.TextBox();
            this.ButtonReturn = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxItemCategory = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.textBoxItemName = new System.Windows.Forms.TextBox();
            this.textBoxSOID = new System.Windows.Forms.TextBox();
            this.textBoxBillNo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.textBoxItemId = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.picPurchase = new System.Windows.Forms.GroupBox();
            this.labelSODT = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.textBoxRtnReason = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxQty = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxSalesPrice = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePickerSalesDate = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonExit = new System.Windows.Forms.Button();
            this.ButtonNew = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBoxCustomer = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.ToolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblUserId = new System.Windows.Forms.ToolStripStatusLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxFree = new System.Windows.Forms.TextBox();
            this.picPurchase.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.StatusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxNetAmount
            // 
            this.textBoxNetAmount.BackColor = System.Drawing.SystemColors.Info;
            this.textBoxNetAmount.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNetAmount.Location = new System.Drawing.Point(839, 79);
            this.textBoxNetAmount.Name = "textBoxNetAmount";
            this.textBoxNetAmount.ReadOnly = true;
            this.textBoxNetAmount.Size = new System.Drawing.Size(118, 22);
            this.textBoxNetAmount.TabIndex = 29;
            this.textBoxNetAmount.Text = "0.00";
            this.textBoxNetAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxItemCode
            // 
            this.textBoxItemCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBoxItemCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxItemCode.BackColor = System.Drawing.SystemColors.Info;
            this.textBoxItemCode.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxItemCode.Location = new System.Drawing.Point(94, 29);
            this.textBoxItemCode.Name = "textBoxItemCode";
            this.textBoxItemCode.ReadOnly = true;
            this.textBoxItemCode.Size = new System.Drawing.Size(181, 22);
            this.textBoxItemCode.TabIndex = 10;
            // 
            // ButtonReturn
            // 
            this.ButtonReturn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(160)))));
            this.ButtonReturn.Font = new System.Drawing.Font("Cambria", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonReturn.ForeColor = System.Drawing.SystemColors.Window;
            this.ButtonReturn.Location = new System.Drawing.Point(978, 35);
            this.ButtonReturn.Name = "ButtonReturn";
            this.ButtonReturn.Size = new System.Drawing.Size(89, 55);
            this.ButtonReturn.TabIndex = 2;
            this.ButtonReturn.Text = "&Return";
            this.ButtonReturn.UseVisualStyleBackColor = false;
            this.ButtonReturn.Click += new System.EventHandler(this.ButtonReturn_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(10, 61);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 14);
            this.label7.TabIndex = 16;
            this.label7.Text = "Reason For Return";
            // 
            // comboBoxItemCategory
            // 
            this.comboBoxItemCategory.BackColor = System.Drawing.SystemColors.Info;
            this.comboBoxItemCategory.Enabled = false;
            this.comboBoxItemCategory.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxItemCategory.FormattingEnabled = true;
            this.comboBoxItemCategory.Location = new System.Drawing.Point(732, 28);
            this.comboBoxItemCategory.Name = "comboBoxItemCategory";
            this.comboBoxItemCategory.Size = new System.Drawing.Size(225, 22);
            this.comboBoxItemCategory.TabIndex = 12;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(299, 12);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(64, 14);
            this.label21.TabIndex = 32;
            this.label21.Text = "Item Name";
            // 
            // textBoxItemName
            // 
            this.textBoxItemName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBoxItemName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxItemName.BackColor = System.Drawing.SystemColors.Info;
            this.textBoxItemName.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxItemName.Location = new System.Drawing.Point(294, 29);
            this.textBoxItemName.Name = "textBoxItemName";
            this.textBoxItemName.ReadOnly = true;
            this.textBoxItemName.Size = new System.Drawing.Size(411, 22);
            this.textBoxItemName.TabIndex = 10;
            // 
            // textBoxSOID
            // 
            this.textBoxSOID.BackColor = System.Drawing.SystemColors.Info;
            this.textBoxSOID.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSOID.Location = new System.Drawing.Point(542, 9);
            this.textBoxSOID.Name = "textBoxSOID";
            this.textBoxSOID.ReadOnly = true;
            this.textBoxSOID.Size = new System.Drawing.Size(102, 22);
            this.textBoxSOID.TabIndex = 100;
            this.textBoxSOID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxSOID.Visible = false;
            // 
            // textBoxBillNo
            // 
            this.textBoxBillNo.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxBillNo.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxBillNo.Location = new System.Drawing.Point(57, 11);
            this.textBoxBillNo.Name = "textBoxBillNo";
            this.textBoxBillNo.Size = new System.Drawing.Size(113, 22);
            this.textBoxBillNo.TabIndex = 0;
            this.textBoxBillNo.TextChanged += new System.EventHandler(this.textBoxBillNo_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(690, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 14);
            this.label6.TabIndex = 133;
            this.label6.Text = "Sales Date:";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(9, 14);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(45, 14);
            this.label24.TabIndex = 168;
            this.label24.Text = "Bill No.:";
            // 
            // textBoxItemId
            // 
            this.textBoxItemId.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBoxItemId.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxItemId.BackColor = System.Drawing.SystemColors.Info;
            this.textBoxItemId.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxItemId.Location = new System.Drawing.Point(7, 29);
            this.textBoxItemId.Name = "textBoxItemId";
            this.textBoxItemId.ReadOnly = true;
            this.textBoxItemId.Size = new System.Drawing.Size(72, 22);
            this.textBoxItemId.TabIndex = 8;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(98, 12);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(60, 14);
            this.label20.TabIndex = 30;
            this.label20.Text = "Item Code";
            // 
            // picPurchase
            // 
            this.picPurchase.Controls.Add(this.label3);
            this.picPurchase.Controls.Add(this.textBoxFree);
            this.picPurchase.Controls.Add(this.labelSODT);
            this.picPurchase.Controls.Add(this.label25);
            this.picPurchase.Controls.Add(this.textBoxItemId);
            this.picPurchase.Controls.Add(this.label22);
            this.picPurchase.Controls.Add(this.comboBoxItemCategory);
            this.picPurchase.Controls.Add(this.label21);
            this.picPurchase.Controls.Add(this.textBoxItemName);
            this.picPurchase.Controls.Add(this.label20);
            this.picPurchase.Controls.Add(this.textBoxItemCode);
            this.picPurchase.Controls.Add(this.ButtonReturn);
            this.picPurchase.Controls.Add(this.label7);
            this.picPurchase.Controls.Add(this.textBoxNetAmount);
            this.picPurchase.Controls.Add(this.textBoxRtnReason);
            this.picPurchase.Controls.Add(this.label13);
            this.picPurchase.Controls.Add(this.label8);
            this.picPurchase.Controls.Add(this.textBoxQty);
            this.picPurchase.Controls.Add(this.label9);
            this.picPurchase.Controls.Add(this.textBoxSalesPrice);
            this.picPurchase.Location = new System.Drawing.Point(3, 98);
            this.picPurchase.Name = "picPurchase";
            this.picPurchase.Size = new System.Drawing.Size(1079, 109);
            this.picPurchase.TabIndex = 183;
            this.picPurchase.TabStop = false;
            // 
            // labelSODT
            // 
            this.labelSODT.AutoSize = true;
            this.labelSODT.Location = new System.Drawing.Point(159, 60);
            this.labelSODT.Name = "labelSODT";
            this.labelSODT.Size = new System.Drawing.Size(13, 13);
            this.labelSODT.TabIndex = 165;
            this.labelSODT.Text = "0";
            this.labelSODT.Visible = false;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(10, 12);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(46, 14);
            this.label25.TabIndex = 164;
            this.label25.Text = "Item ID";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(737, 11);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(80, 14);
            this.label22.TabIndex = 162;
            this.label22.Text = "Item Category";
            // 
            // textBoxRtnReason
            // 
            this.textBoxRtnReason.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBoxRtnReason.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxRtnReason.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRtnReason.Location = new System.Drawing.Point(7, 79);
            this.textBoxRtnReason.Name = "textBoxRtnReason";
            this.textBoxRtnReason.Size = new System.Drawing.Size(496, 22);
            this.textBoxRtnReason.TabIndex = 0;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(845, 61);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(69, 14);
            this.label13.TabIndex = 28;
            this.label13.Text = "Net Amount";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(623, 62);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(25, 14);
            this.label8.TabIndex = 18;
            this.label8.Text = "Qty";
            // 
            // textBoxQty
            // 
            this.textBoxQty.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxQty.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxQty.Location = new System.Drawing.Point(617, 79);
            this.textBoxQty.Name = "textBoxQty";
            this.textBoxQty.Size = new System.Drawing.Size(88, 22);
            this.textBoxQty.TabIndex = 1;
            this.textBoxQty.Text = "0";
            this.textBoxQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxQty.TextChanged += new System.EventHandler(this.textBoxQty_TextChanged);
            this.textBoxQty.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxQty_Validating);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(729, 61);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 14);
            this.label9.TabIndex = 21;
            this.label9.Text = "Sales Price";
            // 
            // textBoxSalesPrice
            // 
            this.textBoxSalesPrice.BackColor = System.Drawing.SystemColors.Info;
            this.textBoxSalesPrice.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSalesPrice.Location = new System.Drawing.Point(725, 79);
            this.textBoxSalesPrice.Name = "textBoxSalesPrice";
            this.textBoxSalesPrice.ReadOnly = true;
            this.textBoxSalesPrice.Size = new System.Drawing.Size(93, 22);
            this.textBoxSalesPrice.TabIndex = 16;
            this.textBoxSalesPrice.Text = "0.00";
            this.textBoxSalesPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 207);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1079, 276);
            this.groupBox1.TabIndex = 182;
            this.groupBox1.TabStop = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(7, 18);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1059, 245);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(492, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 14);
            this.label1.TabIndex = 122;
            this.label1.Text = "SO ID:";
            this.label1.Visible = false;
            // 
            // dateTimePickerSalesDate
            // 
            this.dateTimePickerSalesDate.CustomFormat = "yyyy-MM-dd";
            this.dateTimePickerSalesDate.Enabled = false;
            this.dateTimePickerSalesDate.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerSalesDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerSalesDate.Location = new System.Drawing.Point(756, 11);
            this.dateTimePickerSalesDate.Name = "dateTimePickerSalesDate";
            this.dateTimePickerSalesDate.Size = new System.Drawing.Size(104, 22);
            this.dateTimePickerSalesDate.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.crystalReportViewer1);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.textBoxSOID);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(5, 7);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(769, 40);
            this.panel2.TabIndex = 184;
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Location = new System.Drawing.Point(5, -2);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(118, 40);
            this.crystalReportViewer1.TabIndex = 51;
            this.crystalReportViewer1.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.SteelBlue;
            this.label12.Location = new System.Drawing.Point(235, 4);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(234, 28);
            this.label12.TabIndex = 50;
            this.label12.Text = "S A L E S     R E T U R N";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonExit);
            this.groupBox2.Controls.Add(this.ButtonNew);
            this.groupBox2.Location = new System.Drawing.Point(792, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(290, 50);
            this.groupBox2.TabIndex = 185;
            this.groupBox2.TabStop = false;
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(160)))));
            this.buttonExit.Font = new System.Drawing.Font("Cambria", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExit.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonExit.Location = new System.Drawing.Point(144, 12);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(126, 32);
            this.buttonExit.TabIndex = 26;
            this.buttonExit.Text = "&Exit";
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // ButtonNew
            // 
            this.ButtonNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(160)))));
            this.ButtonNew.Font = new System.Drawing.Font("Cambria", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonNew.ForeColor = System.Drawing.SystemColors.Window;
            this.ButtonNew.Location = new System.Drawing.Point(12, 11);
            this.ButtonNew.Name = "ButtonNew";
            this.ButtonNew.Size = new System.Drawing.Size(126, 32);
            this.ButtonNew.TabIndex = 22;
            this.ButtonNew.Text = "&New";
            this.ButtonNew.UseVisualStyleBackColor = false;
            this.ButtonNew.Click += new System.EventHandler(this.ButtonNew_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBoxCustomer);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.textBoxBillNo);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label24);
            this.groupBox3.Controls.Add(this.dateTimePickerSalesDate);
            this.groupBox3.Location = new System.Drawing.Point(5, 50);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1078, 44);
            this.groupBox3.TabIndex = 186;
            this.groupBox3.TabStop = false;
            // 
            // textBoxCustomer
            // 
            this.textBoxCustomer.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxCustomer.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCustomer.Location = new System.Drawing.Point(280, 11);
            this.textBoxCustomer.Name = "textBoxCustomer";
            this.textBoxCustomer.Size = new System.Drawing.Size(372, 22);
            this.textBoxCustomer.TabIndex = 169;
            this.textBoxCustomer.TextChanged += new System.EventHandler(this.textBoxVehicleNo_TextChanged);
            this.textBoxCustomer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxVehicleNo_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(215, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 170;
            this.label2.Text = "Customer :";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ToolStripStatusLabel3
            // 
            this.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3";
            this.ToolStripStatusLabel3.Size = new System.Drawing.Size(842, 17);
            this.ToolStripStatusLabel3.Spring = true;
            // 
            // ToolStripStatusLabel1
            // 
            this.ToolStripStatusLabel1.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1";
            this.ToolStripStatusLabel1.Size = new System.Drawing.Size(86, 17);
            this.ToolStripStatusLabel1.Text = "Logged in As :";
            // 
            // StatusStrip1
            // 
            this.StatusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripStatusLabel1,
            this.lblUser,
            this.lblUserId,
            this.ToolStripStatusLabel3});
            this.StatusStrip1.Location = new System.Drawing.Point(0, 486);
            this.StatusStrip1.Name = "StatusStrip1";
            this.StatusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.StatusStrip1.Size = new System.Drawing.Size(1090, 22);
            this.StatusStrip1.TabIndex = 187;
            this.StatusStrip1.Text = "StatusStrip1";
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(523, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 14);
            this.label3.TabIndex = 169;
            this.label3.Text = "Free Issue";
            // 
            // textBoxFree
            // 
            this.textBoxFree.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxFree.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxFree.Location = new System.Drawing.Point(517, 79);
            this.textBoxFree.Name = "textBoxFree";
            this.textBoxFree.Size = new System.Drawing.Size(88, 22);
            this.textBoxFree.TabIndex = 168;
            this.textBoxFree.Text = "0";
            this.textBoxFree.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // FormSalesReturn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(1090, 508);
            this.Controls.Add(this.picPurchase);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.StatusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormSalesReturn";
            this.Text = "Sales Return";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormSalesReturn_Load);
            this.picPurchase.ResumeLayout(false);
            this.picPurchase.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.StatusStrip1.ResumeLayout(false);
            this.StatusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox textBoxNetAmount;
        public System.Windows.Forms.TextBox textBoxItemCode;
        public System.Windows.Forms.Button ButtonReturn;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBoxItemCategory;
        private System.Windows.Forms.Label label21;
        public System.Windows.Forms.TextBox textBoxItemName;
        public System.Windows.Forms.TextBox textBoxSOID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label24;
        public System.Windows.Forms.TextBox textBoxItemId;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.GroupBox picPurchase;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label22;
        public System.Windows.Forms.TextBox textBoxRtnReason;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.TextBox textBoxQty;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.TextBox textBoxSalesPrice;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePickerSalesDate;
        internal System.Windows.Forms.ToolStripStatusLabel lblUser;
        private System.Windows.Forms.Panel panel2;
        internal System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button ButtonNew;
        private System.Windows.Forms.GroupBox groupBox3;
        internal System.Windows.Forms.ToolStripStatusLabel lblUserId;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        internal System.Windows.Forms.StatusStrip StatusStrip1;
        internal System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel1;
        internal System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel3;
        private System.Windows.Forms.Label labelSODT;
        public System.Windows.Forms.TextBox textBoxBillNo;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        public System.Windows.Forms.TextBox textBoxCustomer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox textBoxFree;
    }
}