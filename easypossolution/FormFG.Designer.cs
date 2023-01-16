namespace easyPOSSolution
{
    partial class FormFG
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFG));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.buttonExit = new System.Windows.Forms.Button();
            this.textBoxTotGrosse = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.StatusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ToolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblUserId = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ButtonSave = new System.Windows.Forms.Button();
            this.buttonNew1 = new System.Windows.Forms.Button();
            this.ButtonAdd = new System.Windows.Forms.Button();
            this.ButtonDeleteLine = new System.Windows.Forms.Button();
            this.label35 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.textBoxQty = new System.Windows.Forms.TextBox();
            this.textBoxUnitCostPrice = new System.Windows.Forms.TextBox();
            this.textBoxItemId = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.dgView = new System.Windows.Forms.DataGridView();
            this.ItemCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PurchaseQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PurchasePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SellingPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NetAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemsId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label21 = new System.Windows.Forms.Label();
            this.textBoxItemName = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonNew = new System.Windows.Forms.Button();
            this.textBoxNetAmount = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.textBoxItemCode = new System.Windows.Forms.TextBox();
            this.picPurchase = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBoxSellingPrice = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxRemarks = new System.Windows.Forms.TextBox();
            this.textBoxPOID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxBranch = new System.Windows.Forms.ComboBox();
            this.label34 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.StatusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.picPurchase.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(160)))));
            this.buttonExit.Font = new System.Drawing.Font("Cambria", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExit.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonExit.Location = new System.Drawing.Point(223, 13);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(98, 38);
            this.buttonExit.TabIndex = 26;
            this.buttonExit.Text = "&Exit";
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // textBoxTotGrosse
            // 
            this.textBoxTotGrosse.BackColor = System.Drawing.SystemColors.Info;
            this.textBoxTotGrosse.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTotGrosse.Location = new System.Drawing.Point(603, 240);
            this.textBoxTotGrosse.Name = "textBoxTotGrosse";
            this.textBoxTotGrosse.ReadOnly = true;
            this.textBoxTotGrosse.Size = new System.Drawing.Size(104, 23);
            this.textBoxTotGrosse.TabIndex = 184;
            this.textBoxTotGrosse.Text = "0.00";
            this.textBoxTotGrosse.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(536, 244);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(62, 15);
            this.label16.TabIndex = 183;
            this.label16.Text = "Total Cost";
            // 
            // StatusStrip1
            // 
            this.StatusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripStatusLabel1,
            this.lblUser,
            this.lblUserId,
            this.ToolStripStatusLabel3});
            this.StatusStrip1.Location = new System.Drawing.Point(0, 529);
            this.StatusStrip1.Name = "StatusStrip1";
            this.StatusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.StatusStrip1.Size = new System.Drawing.Size(742, 22);
            this.StatusStrip1.TabIndex = 201;
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
            this.ToolStripStatusLabel3.Size = new System.Drawing.Size(494, 17);
            this.ToolStripStatusLabel3.Spring = true;
            // 
            // ButtonSave
            // 
            this.ButtonSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(160)))));
            this.ButtonSave.Font = new System.Drawing.Font("Cambria", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonSave.ForeColor = System.Drawing.SystemColors.Window;
            this.ButtonSave.Location = new System.Drawing.Point(113, 11);
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(98, 38);
            this.ButtonSave.TabIndex = 21;
            this.ButtonSave.Text = "&Save";
            this.ButtonSave.UseVisualStyleBackColor = false;
            this.ButtonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // buttonNew1
            // 
            this.buttonNew1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(160)))));
            this.buttonNew1.Font = new System.Drawing.Font("Cambria", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNew1.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonNew1.Location = new System.Drawing.Point(646, 10);
            this.buttonNew1.Name = "buttonNew1";
            this.buttonNew1.Size = new System.Drawing.Size(69, 27);
            this.buttonNew1.TabIndex = 20;
            this.buttonNew1.Text = "&New";
            this.buttonNew1.UseVisualStyleBackColor = false;
            this.buttonNew1.Click += new System.EventHandler(this.buttonNew1_Click);
            // 
            // ButtonAdd
            // 
            this.ButtonAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(160)))));
            this.ButtonAdd.Font = new System.Drawing.Font("Cambria", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonAdd.ForeColor = System.Drawing.SystemColors.Window;
            this.ButtonAdd.Location = new System.Drawing.Point(646, 41);
            this.ButtonAdd.Name = "ButtonAdd";
            this.ButtonAdd.Size = new System.Drawing.Size(69, 27);
            this.ButtonAdd.TabIndex = 19;
            this.ButtonAdd.Text = "&Add";
            this.ButtonAdd.UseVisualStyleBackColor = false;
            this.ButtonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // ButtonDeleteLine
            // 
            this.ButtonDeleteLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(160)))));
            this.ButtonDeleteLine.Font = new System.Drawing.Font("Cambria", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonDeleteLine.ForeColor = System.Drawing.SystemColors.Window;
            this.ButtonDeleteLine.Location = new System.Drawing.Point(646, 72);
            this.ButtonDeleteLine.Name = "ButtonDeleteLine";
            this.ButtonDeleteLine.Size = new System.Drawing.Size(69, 27);
            this.ButtonDeleteLine.TabIndex = 170;
            this.ButtonDeleteLine.Text = "&Delete";
            this.ButtonDeleteLine.UseVisualStyleBackColor = false;
            this.ButtonDeleteLine.Click += new System.EventHandler(this.ButtonDeleteLine_Click);
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.Location = new System.Drawing.Point(275, 13);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(84, 14);
            this.label35.TabIndex = 182;
            this.label35.Text = "Purchase Price";
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
            // textBoxQty
            // 
            this.textBoxQty.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxQty.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxQty.Location = new System.Drawing.Point(192, 29);
            this.textBoxQty.Name = "textBoxQty";
            this.textBoxQty.Size = new System.Drawing.Size(74, 22);
            this.textBoxQty.TabIndex = 14;
            this.textBoxQty.Text = "0";
            this.textBoxQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxQty.TextChanged += new System.EventHandler(this.textBoxQty_TextChanged);
            this.textBoxQty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxQty_KeyDown);
            // 
            // textBoxUnitCostPrice
            // 
            this.textBoxUnitCostPrice.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxUnitCostPrice.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxUnitCostPrice.Location = new System.Drawing.Point(275, 29);
            this.textBoxUnitCostPrice.Name = "textBoxUnitCostPrice";
            this.textBoxUnitCostPrice.Size = new System.Drawing.Size(106, 22);
            this.textBoxUnitCostPrice.TabIndex = 181;
            this.textBoxUnitCostPrice.Text = "0.00";
            this.textBoxUnitCostPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxUnitCostPrice.TextChanged += new System.EventHandler(this.textBoxUnitCostPrice_TextChanged);
            this.textBoxUnitCostPrice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxUnitCostPrice_KeyDown);
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
            this.textBoxItemId.Size = new System.Drawing.Size(49, 22);
            this.textBoxItemId.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(194, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(25, 14);
            this.label8.TabIndex = 18;
            this.label8.Text = "Qty";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(525, 13);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(69, 14);
            this.label13.TabIndex = 28;
            this.label13.Text = "Net Amount";
            // 
            // dgView
            // 
            this.dgView.AllowUserToAddRows = false;
            this.dgView.AllowUserToDeleteRows = false;
            this.dgView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemCode,
            this.ItemName,
            this.PurchaseQty,
            this.PurchasePrice,
            this.SellingPrice,
            this.NetAmount,
            this.ItemsId});
            this.dgView.Location = new System.Drawing.Point(9, 16);
            this.dgView.Name = "dgView";
            this.dgView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgView.Size = new System.Drawing.Size(706, 220);
            this.dgView.TabIndex = 193;
            // 
            // ItemCode
            // 
            this.ItemCode.HeaderText = "Item No./ Barcode";
            this.ItemCode.Name = "ItemCode";
            this.ItemCode.ReadOnly = true;
            this.ItemCode.Width = 115;
            // 
            // ItemName
            // 
            this.ItemName.HeaderText = "Item Name[English]";
            this.ItemName.Name = "ItemName";
            this.ItemName.ReadOnly = true;
            this.ItemName.Width = 123;
            // 
            // PurchaseQty
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.PurchaseQty.DefaultCellStyle = dataGridViewCellStyle1;
            this.PurchaseQty.HeaderText = "Quantity";
            this.PurchaseQty.Name = "PurchaseQty";
            this.PurchaseQty.Width = 77;
            // 
            // PurchasePrice
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.PurchasePrice.DefaultCellStyle = dataGridViewCellStyle2;
            this.PurchasePrice.HeaderText = "PurchasePrice";
            this.PurchasePrice.Name = "PurchasePrice";
            this.PurchasePrice.Width = 106;
            // 
            // SellingPrice
            // 
            this.SellingPrice.HeaderText = "SellingPrice";
            this.SellingPrice.Name = "SellingPrice";
            this.SellingPrice.Width = 92;
            // 
            // NetAmount
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.NetAmount.DefaultCellStyle = dataGridViewCellStyle3;
            this.NetAmount.HeaderText = "Net Amount";
            this.NetAmount.Name = "NetAmount";
            this.NetAmount.ReadOnly = true;
            this.NetAmount.Width = 87;
            // 
            // ItemsId
            // 
            this.ItemsId.HeaderText = "ItemsId";
            this.ItemsId.Name = "ItemsId";
            this.ItemsId.ReadOnly = true;
            this.ItemsId.Visible = false;
            this.ItemsId.Width = 66;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxTotGrosse);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.dgView);
            this.groupBox1.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(6, 250);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(724, 269);
            this.groupBox1.TabIndex = 202;
            this.groupBox1.TabStop = false;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(12, 58);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(64, 14);
            this.label21.TabIndex = 32;
            this.label21.Text = "Item Name";
            // 
            // textBoxItemName
            // 
            this.textBoxItemName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBoxItemName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxItemName.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxItemName.Location = new System.Drawing.Point(7, 75);
            this.textBoxItemName.Name = "textBoxItemName";
            this.textBoxItemName.Size = new System.Drawing.Size(629, 22);
            this.textBoxItemName.TabIndex = 10;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonNew);
            this.groupBox2.Controls.Add(this.buttonExit);
            this.groupBox2.Controls.Add(this.ButtonSave);
            this.groupBox2.Location = new System.Drawing.Point(397, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(328, 57);
            this.groupBox2.TabIndex = 200;
            this.groupBox2.TabStop = false;
            // 
            // buttonNew
            // 
            this.buttonNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(160)))));
            this.buttonNew.Font = new System.Drawing.Font("Cambria", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNew.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonNew.Location = new System.Drawing.Point(5, 11);
            this.buttonNew.Name = "buttonNew";
            this.buttonNew.Size = new System.Drawing.Size(98, 38);
            this.buttonNew.TabIndex = 27;
            this.buttonNew.Text = "&New";
            this.buttonNew.UseVisualStyleBackColor = false;
            this.buttonNew.Click += new System.EventHandler(this.buttonNew_Click);
            // 
            // textBoxNetAmount
            // 
            this.textBoxNetAmount.BackColor = System.Drawing.SystemColors.Info;
            this.textBoxNetAmount.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNetAmount.Location = new System.Drawing.Point(521, 29);
            this.textBoxNetAmount.Name = "textBoxNetAmount";
            this.textBoxNetAmount.ReadOnly = true;
            this.textBoxNetAmount.Size = new System.Drawing.Size(116, 22);
            this.textBoxNetAmount.TabIndex = 29;
            this.textBoxNetAmount.Text = "0.00";
            this.textBoxNetAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(69, 12);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(86, 14);
            this.label20.TabIndex = 30;
            this.label20.Text = "Item Code (F2)";
            // 
            // textBoxItemCode
            // 
            this.textBoxItemCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBoxItemCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxItemCode.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxItemCode.Location = new System.Drawing.Point(65, 29);
            this.textBoxItemCode.Name = "textBoxItemCode";
            this.textBoxItemCode.Size = new System.Drawing.Size(121, 22);
            this.textBoxItemCode.TabIndex = 9;
            this.textBoxItemCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxItemCode_KeyDown);
            // 
            // picPurchase
            // 
            this.picPurchase.Controls.Add(this.label14);
            this.picPurchase.Controls.Add(this.textBoxSellingPrice);
            this.picPurchase.Controls.Add(this.buttonNew1);
            this.picPurchase.Controls.Add(this.ButtonAdd);
            this.picPurchase.Controls.Add(this.ButtonDeleteLine);
            this.picPurchase.Controls.Add(this.label35);
            this.picPurchase.Controls.Add(this.label25);
            this.picPurchase.Controls.Add(this.textBoxQty);
            this.picPurchase.Controls.Add(this.textBoxUnitCostPrice);
            this.picPurchase.Controls.Add(this.textBoxItemId);
            this.picPurchase.Controls.Add(this.label8);
            this.picPurchase.Controls.Add(this.label21);
            this.picPurchase.Controls.Add(this.label13);
            this.picPurchase.Controls.Add(this.textBoxItemName);
            this.picPurchase.Controls.Add(this.textBoxNetAmount);
            this.picPurchase.Controls.Add(this.label20);
            this.picPurchase.Controls.Add(this.textBoxItemCode);
            this.picPurchase.Location = new System.Drawing.Point(6, 147);
            this.picPurchase.Name = "picPurchase";
            this.picPurchase.Size = new System.Drawing.Size(724, 103);
            this.picPurchase.TabIndex = 199;
            this.picPurchase.TabStop = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(391, 13);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(70, 14);
            this.label14.TabIndex = 184;
            this.label14.Text = "Selling Price";
            // 
            // textBoxSellingPrice
            // 
            this.textBoxSellingPrice.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxSellingPrice.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSellingPrice.Location = new System.Drawing.Point(387, 29);
            this.textBoxSellingPrice.Name = "textBoxSellingPrice";
            this.textBoxSellingPrice.Size = new System.Drawing.Size(125, 22);
            this.textBoxSellingPrice.TabIndex = 183;
            this.textBoxSellingPrice.Text = "0.00";
            this.textBoxSellingPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxSellingPrice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxSellingPrice_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 14);
            this.label5.TabIndex = 197;
            this.label5.Text = "Remarks :";
            // 
            // textBoxRemarks
            // 
            this.textBoxRemarks.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRemarks.Location = new System.Drawing.Point(63, 52);
            this.textBoxRemarks.Multiline = true;
            this.textBoxRemarks.Name = "textBoxRemarks";
            this.textBoxRemarks.Size = new System.Drawing.Size(634, 22);
            this.textBoxRemarks.TabIndex = 196;
            // 
            // textBoxPOID
            // 
            this.textBoxPOID.BackColor = System.Drawing.SystemColors.Info;
            this.textBoxPOID.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPOID.Location = new System.Drawing.Point(63, 19);
            this.textBoxPOID.Name = "textBoxPOID";
            this.textBoxPOID.ReadOnly = true;
            this.textBoxPOID.Size = new System.Drawing.Size(132, 22);
            this.textBoxPOID.TabIndex = 194;
            this.textBoxPOID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 14);
            this.label1.TabIndex = 195;
            this.label1.Text = "BOM ID:";
            // 
            // comboBoxBranch
            // 
            this.comboBoxBranch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboBoxBranch.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxBranch.FormattingEnabled = true;
            this.comboBoxBranch.Location = new System.Drawing.Point(308, 18);
            this.comboBoxBranch.Name = "comboBoxBranch";
            this.comboBoxBranch.Size = new System.Drawing.Size(389, 22);
            this.comboBoxBranch.TabIndex = 189;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.Location = new System.Drawing.Point(237, 22);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(65, 14);
            this.label34.TabIndex = 190;
            this.label34.Text = "Warehouse";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.textBoxRemarks);
            this.groupBox5.Controls.Add(this.textBoxPOID);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.comboBoxBranch);
            this.groupBox5.Controls.Add(this.label34);
            this.groupBox5.Location = new System.Drawing.Point(6, 57);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(724, 87);
            this.groupBox5.TabIndex = 198;
            this.groupBox5.TabStop = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.SteelBlue;
            this.label12.Location = new System.Drawing.Point(92, 8);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(198, 28);
            this.label12.TabIndex = 50;
            this.label12.Text = "FINISHED GOODS";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.label12);
            this.panel2.Location = new System.Drawing.Point(6, 8);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(381, 47);
            this.panel2.TabIndex = 197;
            // 
            // FormFG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(742, 551);
            this.Controls.Add(this.StatusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.picPurchase);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "FormFG";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormFG";
            this.Load += new System.EventHandler(this.FormFG_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormFG_KeyDown);
            this.StatusStrip1.ResumeLayout(false);
            this.StatusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.picPurchase.ResumeLayout(false);
            this.picPurchase.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.TextBox textBoxTotGrosse;
        private System.Windows.Forms.Label label16;
        internal System.Windows.Forms.StatusStrip StatusStrip1;
        internal System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel1;
        internal System.Windows.Forms.ToolStripStatusLabel lblUser;
        internal System.Windows.Forms.ToolStripStatusLabel lblUserId;
        internal System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel3;
        public System.Windows.Forms.Button ButtonSave;
        public System.Windows.Forms.Button buttonNew1;
        public System.Windows.Forms.Button ButtonAdd;
        public System.Windows.Forms.Button ButtonDeleteLine;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label25;
        public System.Windows.Forms.TextBox textBoxQty;
        public System.Windows.Forms.TextBox textBoxUnitCostPrice;
        public System.Windows.Forms.TextBox textBoxItemId;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridView dgView;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label21;
        public System.Windows.Forms.TextBox textBoxItemName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonNew;
        public System.Windows.Forms.TextBox textBoxNetAmount;
        private System.Windows.Forms.Label label20;
        public System.Windows.Forms.TextBox textBoxItemCode;
        private System.Windows.Forms.GroupBox picPurchase;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxRemarks;
        public System.Windows.Forms.TextBox textBoxPOID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxBranch;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.GroupBox groupBox5;
        internal System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label14;
        public System.Windows.Forms.TextBox textBoxSellingPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PurchaseQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn PurchasePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn SellingPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn NetAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemsId;
    }
}