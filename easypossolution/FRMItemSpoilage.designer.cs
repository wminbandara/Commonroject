namespace easyPOSSolution
{
    partial class FRMItemSpoilage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRMItemSpoilage));
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBoxItemNameS = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.dateTimePickerTranDate = new System.Windows.Forms.DateTimePicker();
            this.comboBoxItemMode = new System.Windows.Forms.ComboBox();
            this.textBoxItemId = new System.Windows.Forms.TextBox();
            this.textBoxDiscount = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxId = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.textBoxQty = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.StatusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ToolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblUserId = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxRemarks = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.textBoxItemCode = new System.Windows.Forms.TextBox();
            this.textBoxItemName = new System.Windows.Forms.TextBox();
            this.comboBoxBranch = new System.Windows.Forms.ComboBox();
            this.label34 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.comboBoxItemCategory = new System.Windows.Forms.ComboBox();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.StatusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.textBoxId);
            this.panel2.Controls.Add(this.textBoxItemNameS);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.dateTimePickerTranDate);
            this.panel2.Controls.Add(this.comboBoxItemMode);
            this.panel2.Controls.Add(this.textBoxItemId);
            this.panel2.Controls.Add(this.textBoxDiscount);
            this.panel2.Location = new System.Drawing.Point(2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(718, 40);
            this.panel2.TabIndex = 165;
            // 
            // textBoxItemNameS
            // 
            this.textBoxItemNameS.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBoxItemNameS.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxItemNameS.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxItemNameS.Location = new System.Drawing.Point(853, 8);
            this.textBoxItemNameS.Name = "textBoxItemNameS";
            this.textBoxItemNameS.Size = new System.Drawing.Size(25, 24);
            this.textBoxItemNameS.TabIndex = 6;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.SteelBlue;
            this.label12.Location = new System.Drawing.Point(220, 4);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(214, 28);
            this.label12.TabIndex = 50;
            this.label12.Text = "I T E M   D A M A G E";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dateTimePickerTranDate
            // 
            this.dateTimePickerTranDate.CustomFormat = "yyyy-MM-dd";
            this.dateTimePickerTranDate.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerTranDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerTranDate.Location = new System.Drawing.Point(794, 10);
            this.dateTimePickerTranDate.Name = "dateTimePickerTranDate";
            this.dateTimePickerTranDate.Size = new System.Drawing.Size(33, 22);
            this.dateTimePickerTranDate.TabIndex = 0;
            this.dateTimePickerTranDate.Visible = false;
            // 
            // comboBoxItemMode
            // 
            this.comboBoxItemMode.AutoCompleteCustomSource.AddRange(new string[] {
            "Assets",
            "Liabilities",
            "Stock"});
            this.comboBoxItemMode.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxItemMode.FormattingEnabled = true;
            this.comboBoxItemMode.Items.AddRange(new object[] {
            "COMMON STOCK",
            "CASH",
            "ACCOUNTS RECEIVABLE",
            "PREPAID RENT",
            "INVENTORY",
            "LEASEHOLD IMPROVEMENTS",
            "ACCUMULATED DEPRECIATION",
            "ACCOUNTS PAYABLE",
            "ACCRUED EXPENSES",
            "UNEARNED REVENUE",
            "LONG TERM LIABILITIES",
            "RETAINED EARNINGS",
            ""});
            this.comboBoxItemMode.Location = new System.Drawing.Point(735, 8);
            this.comboBoxItemMode.Name = "comboBoxItemMode";
            this.comboBoxItemMode.Size = new System.Drawing.Size(25, 22);
            this.comboBoxItemMode.TabIndex = 2;
            this.comboBoxItemMode.Text = "COMMON STOCK";
            this.comboBoxItemMode.Visible = false;
            // 
            // textBoxItemId
            // 
            this.textBoxItemId.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBoxItemId.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxItemId.BackColor = System.Drawing.SystemColors.Info;
            this.textBoxItemId.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxItemId.Location = new System.Drawing.Point(694, 4);
            this.textBoxItemId.Name = "textBoxItemId";
            this.textBoxItemId.ReadOnly = true;
            this.textBoxItemId.Size = new System.Drawing.Size(22, 22);
            this.textBoxItemId.TabIndex = 30;
            this.textBoxItemId.Visible = false;
            // 
            // textBoxDiscount
            // 
            this.textBoxDiscount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBoxDiscount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxDiscount.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDiscount.Location = new System.Drawing.Point(911, 10);
            this.textBoxDiscount.Name = "textBoxDiscount";
            this.textBoxDiscount.Size = new System.Drawing.Size(22, 22);
            this.textBoxDiscount.TabIndex = 7;
            this.textBoxDiscount.Text = "0.00";
            this.textBoxDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(220, 59);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(64, 14);
            this.label21.TabIndex = 171;
            this.label21.Text = "Item Name";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.comboBoxItemCategory);
            this.groupBox1.Controls.Add(this.comboBoxBranch);
            this.groupBox1.Controls.Add(this.label34);
            this.groupBox1.Controls.Add(this.textBoxItemName);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.textBoxItemCode);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBoxRemarks);
            this.groupBox1.Controls.Add(this.buttonSave);
            this.groupBox1.Controls.Add(this.textBoxQty);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Location = new System.Drawing.Point(2, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(718, 170);
            this.groupBox1.TabIndex = 173;
            this.groupBox1.TabStop = false;
            // 
            // textBoxId
            // 
            this.textBoxId.Location = new System.Drawing.Point(318, 6);
            this.textBoxId.Name = "textBoxId";
            this.textBoxId.Size = new System.Drawing.Size(84, 20);
            this.textBoxId.TabIndex = 177;
            this.textBoxId.Visible = false;
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(160)))));
            this.buttonSave.Font = new System.Drawing.Font("Cambria", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSave.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonSave.Location = new System.Drawing.Point(581, 124);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(131, 33);
            this.buttonSave.TabIndex = 176;
            this.buttonSave.Text = "&Save";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // textBoxQty
            // 
            this.textBoxQty.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxQty.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxQty.Location = new System.Drawing.Point(483, 131);
            this.textBoxQty.Name = "textBoxQty";
            this.textBoxQty.Size = new System.Drawing.Size(92, 22);
            this.textBoxQty.TabIndex = 175;
            this.textBoxQty.Text = "0";
            this.textBoxQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(486, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 14);
            this.label3.TabIndex = 174;
            this.label3.Text = "Damage Qty";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Location = new System.Drawing.Point(2, 224);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(397, 16);
            this.groupBox2.TabIndex = 174;
            this.groupBox2.TabStop = false;
            this.groupBox2.Visible = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 14);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(385, 0);
            this.dataGridView1.TabIndex = 2;
            // 
            // StatusStrip1
            // 
            this.StatusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripStatusLabel1,
            this.lblUser,
            this.lblUserId,
            this.ToolStripStatusLabel3});
            this.StatusStrip1.Location = new System.Drawing.Point(0, 241);
            this.StatusStrip1.Name = "StatusStrip1";
            this.StatusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.StatusStrip1.Size = new System.Drawing.Size(733, 22);
            this.StatusStrip1.TabIndex = 179;
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
            this.ToolStripStatusLabel3.Size = new System.Drawing.Size(485, 17);
            this.ToolStripStatusLabel3.Spring = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(14, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 14);
            this.label5.TabIndex = 178;
            this.label5.Text = "Remarks :";
            // 
            // textBoxRemarks
            // 
            this.textBoxRemarks.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRemarks.Location = new System.Drawing.Point(11, 131);
            this.textBoxRemarks.Multiline = true;
            this.textBoxRemarks.Name = "textBoxRemarks";
            this.textBoxRemarks.Size = new System.Drawing.Size(456, 22);
            this.textBoxRemarks.TabIndex = 177;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(381, 18);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(86, 14);
            this.label20.TabIndex = 180;
            this.label20.Text = "Item Code (F2)";
            // 
            // textBoxItemCode
            // 
            this.textBoxItemCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBoxItemCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxItemCode.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxItemCode.Location = new System.Drawing.Point(473, 13);
            this.textBoxItemCode.Name = "textBoxItemCode";
            this.textBoxItemCode.Size = new System.Drawing.Size(239, 22);
            this.textBoxItemCode.TabIndex = 179;
            this.textBoxItemCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxItemCode_KeyDown);
            // 
            // textBoxItemName
            // 
            this.textBoxItemName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBoxItemName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxItemName.Enabled = false;
            this.textBoxItemName.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxItemName.Location = new System.Drawing.Point(216, 76);
            this.textBoxItemName.Name = "textBoxItemName";
            this.textBoxItemName.Size = new System.Drawing.Size(496, 22);
            this.textBoxItemName.TabIndex = 181;
            // 
            // comboBoxBranch
            // 
            this.comboBoxBranch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboBoxBranch.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxBranch.FormattingEnabled = true;
            this.comboBoxBranch.Location = new System.Drawing.Point(86, 13);
            this.comboBoxBranch.Name = "comboBoxBranch";
            this.comboBoxBranch.Size = new System.Drawing.Size(255, 22);
            this.comboBoxBranch.TabIndex = 191;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.Location = new System.Drawing.Point(14, 18);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(65, 14);
            this.label34.TabIndex = 192;
            this.label34.Text = "Warehouse";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(14, 60);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(80, 14);
            this.label22.TabIndex = 194;
            this.label22.Text = "Item Category";
            // 
            // comboBoxItemCategory
            // 
            this.comboBoxItemCategory.Enabled = false;
            this.comboBoxItemCategory.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxItemCategory.FormattingEnabled = true;
            this.comboBoxItemCategory.Location = new System.Drawing.Point(11, 76);
            this.comboBoxItemCategory.Name = "comboBoxItemCategory";
            this.comboBoxItemCategory.Size = new System.Drawing.Size(199, 22);
            this.comboBoxItemCategory.TabIndex = 193;
            // 
            // FRMItemSpoilage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(733, 263);
            this.Controls.Add(this.StatusStrip1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "FRMItemSpoilage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Item Spoilage";
            this.Load += new System.EventHandler(this.FRMItemSpoilage_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FRMItemSpoilage_KeyDown);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.StatusStrip1.ResumeLayout(false);
            this.StatusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.TextBox textBoxItemNameS;
        internal System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker dateTimePickerTranDate;
        private System.Windows.Forms.ComboBox comboBoxItemMode;
        public System.Windows.Forms.TextBox textBoxItemId;
        public System.Windows.Forms.TextBox textBoxDiscount;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.TextBox textBoxQty;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.TextBox textBoxId;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        internal System.Windows.Forms.StatusStrip StatusStrip1;
        internal System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel1;
        internal System.Windows.Forms.ToolStripStatusLabel lblUser;
        internal System.Windows.Forms.ToolStripStatusLabel lblUserId;
        internal System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxRemarks;
        private System.Windows.Forms.Label label20;
        public System.Windows.Forms.TextBox textBoxItemCode;
        public System.Windows.Forms.TextBox textBoxItemName;
        private System.Windows.Forms.ComboBox comboBoxBranch;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ComboBox comboBoxItemCategory;
    }
}