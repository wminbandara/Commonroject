namespace easyPOSSolution
{
    partial class FormMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMenu));
            this.ToolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonNew1 = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.textBoxItemId = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.StatusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblUserId = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.textBoxSellingPrice = new System.Windows.Forms.TextBox();
            this.comboBoxItemCategory = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.textBoxItemName = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.textBoxItemCode = new System.Windows.Forms.TextBox();
            this.ButtonSave = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxUnitCostPrice = new System.Windows.Forms.TextBox();
            this.picPurchase = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxPortion = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonExpCatSave = new System.Windows.Forms.Button();
            this.textBoxCategory = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.StatusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.picPurchase.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolStripStatusLabel1
            // 
            this.ToolStripStatusLabel1.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1";
            this.ToolStripStatusLabel1.Size = new System.Drawing.Size(86, 17);
            this.ToolStripStatusLabel1.Text = "Logged in As :";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(11, 19);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(953, 348);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
            // 
            // buttonDelete
            // 
            this.buttonDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(160)))));
            this.buttonDelete.Font = new System.Drawing.Font("Cambria", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDelete.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonDelete.Location = new System.Drawing.Point(870, 76);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(89, 30);
            this.buttonDelete.TabIndex = 9;
            this.buttonDelete.Text = "&Delete";
            this.buttonDelete.UseVisualStyleBackColor = false;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonNew1
            // 
            this.buttonNew1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(160)))));
            this.buttonNew1.Font = new System.Drawing.Font("Cambria", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNew1.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonNew1.Location = new System.Drawing.Point(870, 10);
            this.buttonNew1.Name = "buttonNew1";
            this.buttonNew1.Size = new System.Drawing.Size(89, 30);
            this.buttonNew1.TabIndex = 8;
            this.buttonNew1.Text = "&New";
            this.buttonNew1.UseVisualStyleBackColor = false;
            this.buttonNew1.Click += new System.EventHandler(this.buttonNew1_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(699, 62);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(70, 14);
            this.label14.TabIndex = 166;
            this.label14.Text = "Selling Price";
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
            this.textBoxItemId.TabIndex = 0;
            this.textBoxItemId.Text = "0";
            this.textBoxItemId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(11, 62);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(80, 14);
            this.label22.TabIndex = 162;
            this.label22.Text = "Item Category";
            // 
            // StatusStrip1
            // 
            this.StatusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripStatusLabel1,
            this.lblUser,
            this.lblUserId,
            this.ToolStripStatusLabel3});
            this.StatusStrip1.Location = new System.Drawing.Point(0, 584);
            this.StatusStrip1.Name = "StatusStrip1";
            this.StatusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.StatusStrip1.Size = new System.Drawing.Size(984, 22);
            this.StatusStrip1.TabIndex = 178;
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
            // ToolStripStatusLabel3
            // 
            this.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3";
            this.ToolStripStatusLabel3.Size = new System.Drawing.Size(736, 17);
            this.ToolStripStatusLabel3.Spring = true;
            // 
            // textBoxSellingPrice
            // 
            this.textBoxSellingPrice.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxSellingPrice.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSellingPrice.Location = new System.Drawing.Point(695, 79);
            this.textBoxSellingPrice.Name = "textBoxSellingPrice";
            this.textBoxSellingPrice.Size = new System.Drawing.Size(132, 22);
            this.textBoxSellingPrice.TabIndex = 6;
            this.textBoxSellingPrice.Text = "0.00";
            this.textBoxSellingPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // comboBoxItemCategory
            // 
            this.comboBoxItemCategory.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxItemCategory.FormattingEnabled = true;
            this.comboBoxItemCategory.Location = new System.Drawing.Point(7, 79);
            this.comboBoxItemCategory.Name = "comboBoxItemCategory";
            this.comboBoxItemCategory.Size = new System.Drawing.Size(268, 22);
            this.comboBoxItemCategory.TabIndex = 3;
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
            this.textBoxItemName.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxItemName.Location = new System.Drawing.Point(294, 29);
            this.textBoxItemName.Name = "textBoxItemName";
            this.textBoxItemName.Size = new System.Drawing.Size(533, 22);
            this.textBoxItemName.TabIndex = 2;
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
            // textBoxItemCode
            // 
            this.textBoxItemCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBoxItemCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxItemCode.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxItemCode.Location = new System.Drawing.Point(94, 29);
            this.textBoxItemCode.Name = "textBoxItemCode";
            this.textBoxItemCode.Size = new System.Drawing.Size(181, 22);
            this.textBoxItemCode.TabIndex = 1;
            this.textBoxItemCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxItemCode_KeyDown);
            this.textBoxItemCode.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxItemCode_Validating);
            // 
            // ButtonSave
            // 
            this.ButtonSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(160)))));
            this.ButtonSave.Font = new System.Drawing.Font("Cambria", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonSave.ForeColor = System.Drawing.SystemColors.Window;
            this.ButtonSave.Location = new System.Drawing.Point(870, 43);
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(89, 30);
            this.ButtonSave.TabIndex = 7;
            this.ButtonSave.Text = "&Save";
            this.ButtonSave.UseVisualStyleBackColor = false;
            this.ButtonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(509, 62);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 14);
            this.label9.TabIndex = 21;
            this.label9.Text = "Cost Price";
            // 
            // textBoxUnitCostPrice
            // 
            this.textBoxUnitCostPrice.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxUnitCostPrice.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxUnitCostPrice.Location = new System.Drawing.Point(506, 79);
            this.textBoxUnitCostPrice.Name = "textBoxUnitCostPrice";
            this.textBoxUnitCostPrice.Size = new System.Drawing.Size(161, 22);
            this.textBoxUnitCostPrice.TabIndex = 5;
            this.textBoxUnitCostPrice.Text = "0.00";
            this.textBoxUnitCostPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // picPurchase
            // 
            this.picPurchase.Controls.Add(this.label1);
            this.picPurchase.Controls.Add(this.comboBoxPortion);
            this.picPurchase.Controls.Add(this.buttonDelete);
            this.picPurchase.Controls.Add(this.buttonNew1);
            this.picPurchase.Controls.Add(this.label14);
            this.picPurchase.Controls.Add(this.textBoxSellingPrice);
            this.picPurchase.Controls.Add(this.label25);
            this.picPurchase.Controls.Add(this.textBoxItemId);
            this.picPurchase.Controls.Add(this.label22);
            this.picPurchase.Controls.Add(this.comboBoxItemCategory);
            this.picPurchase.Controls.Add(this.label21);
            this.picPurchase.Controls.Add(this.textBoxItemName);
            this.picPurchase.Controls.Add(this.label20);
            this.picPurchase.Controls.Add(this.textBoxItemCode);
            this.picPurchase.Controls.Add(this.ButtonSave);
            this.picPurchase.Controls.Add(this.label9);
            this.picPurchase.Controls.Add(this.textBoxUnitCostPrice);
            this.picPurchase.Location = new System.Drawing.Point(5, 48);
            this.picPurchase.Name = "picPurchase";
            this.picPurchase.Size = new System.Drawing.Size(973, 109);
            this.picPurchase.TabIndex = 176;
            this.picPurchase.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(298, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 14);
            this.label1.TabIndex = 175;
            this.label1.Text = "Portion";
            // 
            // comboBoxPortion
            // 
            this.comboBoxPortion.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxPortion.FormattingEnabled = true;
            this.comboBoxPortion.Items.AddRange(new object[] {
            "Small",
            "Medium",
            "Large"});
            this.comboBoxPortion.Location = new System.Drawing.Point(294, 79);
            this.comboBoxPortion.Name = "comboBoxPortion";
            this.comboBoxPortion.Size = new System.Drawing.Size(186, 22);
            this.comboBoxPortion.TabIndex = 4;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.SteelBlue;
            this.label12.Location = new System.Drawing.Point(404, 4);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(107, 28);
            this.label12.TabIndex = 50;
            this.label12.Text = "M  E  N  U";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox4.Controls.Add(this.dataGridView1);
            this.groupBox4.Location = new System.Drawing.Point(5, 207);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(973, 372);
            this.groupBox4.TabIndex = 177;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Item Detail";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.label12);
            this.panel2.Location = new System.Drawing.Point(5, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(973, 40);
            this.panel2.TabIndex = 175;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.buttonExpCatSave);
            this.groupBox3.Controls.Add(this.textBoxCategory);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.ForeColor = System.Drawing.Color.Maroon;
            this.groupBox3.Location = new System.Drawing.Point(11, 161);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(583, 47);
            this.groupBox3.TabIndex = 179;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Insert New Item Category";
            // 
            // buttonExpCatSave
            // 
            this.buttonExpCatSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(160)))));
            this.buttonExpCatSave.Font = new System.Drawing.Font("Cambria", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExpCatSave.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonExpCatSave.Location = new System.Drawing.Point(471, 15);
            this.buttonExpCatSave.Name = "buttonExpCatSave";
            this.buttonExpCatSave.Size = new System.Drawing.Size(93, 26);
            this.buttonExpCatSave.TabIndex = 9;
            this.buttonExpCatSave.Text = "&Save Category";
            this.buttonExpCatSave.UseVisualStyleBackColor = false;
            this.buttonExpCatSave.Click += new System.EventHandler(this.buttonExpCatSave_Click);
            // 
            // textBoxCategory
            // 
            this.textBoxCategory.Location = new System.Drawing.Point(110, 19);
            this.textBoxCategory.Name = "textBoxCategory";
            this.textBoxCategory.Size = new System.Drawing.Size(348, 20);
            this.textBoxCategory.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(7, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 18);
            this.label4.TabIndex = 5;
            this.label4.Text = "Item Category : ";
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(984, 606);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.StatusStrip1);
            this.Controls.Add(this.picPurchase);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMenu";
            this.Text = "Menu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.StatusStrip1.ResumeLayout(false);
            this.StatusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.picPurchase.ResumeLayout(false);
            this.picPurchase.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        public System.Windows.Forms.Button buttonDelete;
        public System.Windows.Forms.Button buttonNew1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label25;
        public System.Windows.Forms.TextBox textBoxItemId;
        private System.Windows.Forms.Label label22;
        internal System.Windows.Forms.StatusStrip StatusStrip1;
        internal System.Windows.Forms.ToolStripStatusLabel lblUser;
        internal System.Windows.Forms.ToolStripStatusLabel lblUserId;
        internal System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel3;
        public System.Windows.Forms.TextBox textBoxSellingPrice;
        private System.Windows.Forms.ComboBox comboBoxItemCategory;
        private System.Windows.Forms.Label label21;
        public System.Windows.Forms.TextBox textBoxItemName;
        private System.Windows.Forms.Label label20;
        public System.Windows.Forms.TextBox textBoxItemCode;
        public System.Windows.Forms.Button ButtonSave;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.GroupBox picPurchase;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.TextBox textBoxUnitCostPrice;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Panel panel2;
        internal System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxPortion;
        private System.Windows.Forms.GroupBox groupBox3;
        public System.Windows.Forms.Button buttonExpCatSave;
        private System.Windows.Forms.TextBox textBoxCategory;
        private System.Windows.Forms.Label label4;
    }
}