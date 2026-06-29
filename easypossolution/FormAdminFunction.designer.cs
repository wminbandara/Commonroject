namespace easyPOSSolution
{
    partial class FormAdminFunction
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAdminFunction));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.simpleButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.comboBoxBranch = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.label21 = new System.Windows.Forms.Label();
            this.comboBoxUser = new System.Windows.Forms.ComboBox();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.label27 = new System.Windows.Forms.Label();
            this.dateTimePickerChqExpDate = new System.Windows.Forms.DateTimePicker();
            this.StatusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ToolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblUserId = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.simpleButtonReturn = new DevExpress.XtraEditors.SimpleButton();
            this.textBoxPOID = new System.Windows.Forms.TextBox();
            this.simpleButton5 = new DevExpress.XtraEditors.SimpleButton();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxTotGrosse = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgView = new System.Windows.Forms.DataGridView();
            this.CashAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NetAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CashCollectionId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.StatusStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgView)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxPOID);
            this.groupBox1.Controls.Add(this.simpleButton5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBoxTotGrosse);
            this.groupBox1.Controls.Add(this.simpleButton4);
            this.groupBox1.Controls.Add(this.simpleButton3);
            this.groupBox1.Controls.Add(this.comboBoxBranch);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.simpleButton2);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.comboBoxUser);
            this.groupBox1.Controls.Add(this.simpleButton1);
            this.groupBox1.Controls.Add(this.label27);
            this.groupBox1.Controls.Add(this.dateTimePickerChqExpDate);
            this.groupBox1.Location = new System.Drawing.Point(4, 55);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(785, 237);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DAY END";
            // 
            // simpleButton4
            // 
            this.simpleButton4.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton4.Appearance.Options.UseFont = true;
            this.simpleButton4.Location = new System.Drawing.Point(288, 117);
            this.simpleButton4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.simpleButton4.Name = "simpleButton4";
            this.simpleButton4.Size = new System.Drawing.Size(485, 37);
            this.simpleButton4.TabIndex = 212;
            this.simpleButton4.Text = "PRINT DAY END STOCK SUMMARY";
            this.simpleButton4.Click += new System.EventHandler(this.simpleButton4_Click);
            // 
            // simpleButton3
            // 
            this.simpleButton3.Location = new System.Drawing.Point(511, 25);
            this.simpleButton3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(100, 28);
            this.simpleButton3.TabIndex = 211;
            this.simpleButton3.Text = "Clear";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // comboBoxBranch
            // 
            this.comboBoxBranch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboBoxBranch.Font = new System.Drawing.Font("Cambria", 11.25F);
            this.comboBoxBranch.FormattingEnabled = true;
            this.comboBoxBranch.Location = new System.Drawing.Point(87, 23);
            this.comboBoxBranch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxBranch.Name = "comboBoxBranch";
            this.comboBoxBranch.Size = new System.Drawing.Size(415, 30);
            this.comboBoxBranch.TabIndex = 210;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(4, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 21);
            this.label1.TabIndex = 209;
            this.label1.Text = "Branch :";
            // 
            // simpleButton2
            // 
            this.simpleButton2.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton2.Appearance.Options.UseFont = true;
            this.simpleButton2.Location = new System.Drawing.Point(532, 73);
            this.simpleButton2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(241, 37);
            this.simpleButton2.TabIndex = 208;
            this.simpleButton2.Text = "PRINT SALES SUMMARY";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.Black;
            this.label21.Location = new System.Drawing.Point(16, 128);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(65, 21);
            this.label21.TabIndex = 205;
            this.label21.Text = "User : ";
            // 
            // comboBoxUser
            // 
            this.comboBoxUser.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxUser.FormattingEnabled = true;
            this.comboBoxUser.Location = new System.Drawing.Point(87, 123);
            this.comboBoxUser.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxUser.Name = "comboBoxUser";
            this.comboBoxUser.Size = new System.Drawing.Size(192, 30);
            this.comboBoxUser.TabIndex = 206;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.Location = new System.Drawing.Point(288, 73);
            this.simpleButton1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(215, 37);
            this.simpleButton1.TabIndex = 204;
            this.simpleButton1.Text = "PRINT DAY END";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.BackColor = System.Drawing.Color.Transparent;
            this.label27.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.Color.Black;
            this.label27.Location = new System.Drawing.Point(19, 81);
            this.label27.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(61, 21);
            this.label27.TabIndex = 202;
            this.label27.Text = "Date :";
            // 
            // dateTimePickerChqExpDate
            // 
            this.dateTimePickerChqExpDate.CustomFormat = "yyyy-MM-dd";
            this.dateTimePickerChqExpDate.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerChqExpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerChqExpDate.Location = new System.Drawing.Point(87, 76);
            this.dateTimePickerChqExpDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dateTimePickerChqExpDate.Name = "dateTimePickerChqExpDate";
            this.dateTimePickerChqExpDate.Size = new System.Drawing.Size(192, 29);
            this.dateTimePickerChqExpDate.TabIndex = 203;
            // 
            // StatusStrip1
            // 
            this.StatusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.StatusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripStatusLabel1,
            this.lblUser,
            this.lblUserId,
            this.ToolStripStatusLabel3});
            this.StatusStrip1.Location = new System.Drawing.Point(0, 757);
            this.StatusStrip1.Name = "StatusStrip1";
            this.StatusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.StatusStrip1.Size = new System.Drawing.Size(800, 26);
            this.StatusStrip1.TabIndex = 189;
            this.StatusStrip1.Text = "StatusStrip1";
            // 
            // ToolStripStatusLabel1
            // 
            this.ToolStripStatusLabel1.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToolStripStatusLabel1.ForeColor = System.Drawing.Color.White;
            this.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1";
            this.ToolStripStatusLabel1.Size = new System.Drawing.Size(108, 21);
            this.ToolStripStatusLabel1.Text = "Logged in As :";
            // 
            // lblUser
            // 
            this.lblUser.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.ForeColor = System.Drawing.Color.Red;
            this.lblUser.Image = ((System.Drawing.Image)(resources.GetObject("lblUser.Image")));
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(186, 21);
            this.lblUser.Text = "ToolStripStatusLabel2";
            // 
            // lblUserId
            // 
            this.lblUserId.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserId.ForeColor = System.Drawing.Color.Red;
            this.lblUserId.Image = ((System.Drawing.Image)(resources.GetObject("lblUserId.Image")));
            this.lblUserId.Name = "lblUserId";
            this.lblUserId.Size = new System.Drawing.Size(186, 21);
            this.lblUserId.Text = "ToolStripStatusLabel2";
            this.lblUserId.Visible = false;
            this.lblUserId.TextChanged += new System.EventHandler(this.lblUserId_TextChanged);
            // 
            // ToolStripStatusLabel3
            // 
            this.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3";
            this.ToolStripStatusLabel3.Size = new System.Drawing.Size(486, 21);
            this.ToolStripStatusLabel3.Spring = true;
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Location = new System.Drawing.Point(378, 15);
            this.crystalReportViewer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(93, 44);
            this.crystalReportViewer1.TabIndex = 190;
            this.crystalReportViewer1.ToolPanelWidth = 267;
            this.crystalReportViewer1.Visible = false;
            // 
            // simpleButtonReturn
            // 
            this.simpleButtonReturn.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.simpleButtonReturn.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.simpleButtonReturn.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButtonReturn.Appearance.Options.UseBackColor = true;
            this.simpleButtonReturn.Appearance.Options.UseFont = true;
            this.simpleButtonReturn.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.simpleButtonReturn.Location = new System.Drawing.Point(515, 15);
            this.simpleButtonReturn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.simpleButtonReturn.Name = "simpleButtonReturn";
            this.simpleButtonReturn.Size = new System.Drawing.Size(263, 37);
            this.simpleButtonReturn.TabIndex = 723;
            this.simpleButtonReturn.Text = "COMPLETE DAY END";
            this.simpleButtonReturn.Click += new System.EventHandler(this.simpleButtonReturn_Click);
            // 
            // textBoxPOID
            // 
            this.textBoxPOID.BackColor = System.Drawing.SystemColors.Info;
            this.textBoxPOID.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPOID.Location = new System.Drawing.Point(9, 191);
            this.textBoxPOID.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxPOID.Name = "textBoxPOID";
            this.textBoxPOID.ReadOnly = true;
            this.textBoxPOID.Size = new System.Drawing.Size(130, 25);
            this.textBoxPOID.TabIndex = 729;
            this.textBoxPOID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxPOID.Visible = false;
            // 
            // simpleButton5
            // 
            this.simpleButton5.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.simpleButton5.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.simpleButton5.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton5.Appearance.Options.UseBackColor = true;
            this.simpleButton5.Appearance.Options.UseFont = true;
            this.simpleButton5.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.simpleButton5.Location = new System.Drawing.Point(489, 187);
            this.simpleButton5.Margin = new System.Windows.Forms.Padding(4);
            this.simpleButton5.Name = "simpleButton5";
            this.simpleButton5.Size = new System.Drawing.Size(198, 32);
            this.simpleButton5.TabIndex = 728;
            this.simpleButton5.Text = "Update Cash Return";
            this.simpleButton5.Click += new System.EventHandler(this.simpleButton5_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(170, 195);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 21);
            this.label2.TabIndex = 727;
            this.label2.Text = "Cash Total : ";
            // 
            // textBoxTotGrosse
            // 
            this.textBoxTotGrosse.BackColor = System.Drawing.SystemColors.Info;
            this.textBoxTotGrosse.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.textBoxTotGrosse.Location = new System.Drawing.Point(288, 190);
            this.textBoxTotGrosse.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxTotGrosse.Name = "textBoxTotGrosse";
            this.textBoxTotGrosse.ReadOnly = true;
            this.textBoxTotGrosse.Size = new System.Drawing.Size(193, 29);
            this.textBoxTotGrosse.TabIndex = 726;
            this.textBoxTotGrosse.Text = "0.00";
            this.textBoxTotGrosse.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.dgView);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(4, 299);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(785, 443);
            this.groupBox2.TabIndex = 725;
            this.groupBox2.TabStop = false;
            // 
            // dgView
            // 
            this.dgView.AllowUserToAddRows = false;
            this.dgView.AllowUserToDeleteRows = false;
            this.dgView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CashAmount,
            this.Quantity,
            this.NetAmount,
            this.CashCollectionId});
            this.dgView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgView.Location = new System.Drawing.Point(3, 26);
            this.dgView.Margin = new System.Windows.Forms.Padding(4);
            this.dgView.Name = "dgView";
            this.dgView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgView.Size = new System.Drawing.Size(779, 414);
            this.dgView.TabIndex = 194;
            this.dgView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgView_CellValueChanged);
            // 
            // CashAmount
            // 
            this.CashAmount.HeaderText = "Amount";
            this.CashAmount.Name = "CashAmount";
            this.CashAmount.ReadOnly = true;
            this.CashAmount.Width = 109;
            // 
            // Quantity
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Quantity.DefaultCellStyle = dataGridViewCellStyle3;
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.Name = "Quantity";
            this.Quantity.Width = 114;
            // 
            // NetAmount
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.NetAmount.DefaultCellStyle = dataGridViewCellStyle4;
            this.NetAmount.HeaderText = "Total";
            this.NetAmount.Name = "NetAmount";
            this.NetAmount.ReadOnly = true;
            this.NetAmount.Width = 85;
            // 
            // CashCollectionId
            // 
            this.CashCollectionId.HeaderText = "CashCollectionId";
            this.CashCollectionId.Name = "CashCollectionId";
            this.CashCollectionId.ReadOnly = true;
            this.CashCollectionId.Visible = false;
            this.CashCollectionId.Width = 190;
            // 
            // FormAdminFunction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(800, 783);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.simpleButtonReturn);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.StatusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormAdminFunction";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormAdminFunction";
            this.Load += new System.EventHandler(this.FormAdminFunction_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.StatusStrip1.ResumeLayout(false);
            this.StatusStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label27;
        public System.Windows.Forms.DateTimePicker dateTimePickerChqExpDate;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        internal System.Windows.Forms.StatusStrip StatusStrip1;
        internal System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel1;
        internal System.Windows.Forms.ToolStripStatusLabel lblUser;
        internal System.Windows.Forms.ToolStripStatusLabel lblUserId;
        internal System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel3;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.Label label21;
        public System.Windows.Forms.ComboBox comboBoxUser;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxBranch;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraEditors.SimpleButton simpleButton4;
        private DevExpress.XtraEditors.SimpleButton simpleButtonReturn;
        public System.Windows.Forms.TextBox textBoxPOID;
        private DevExpress.XtraEditors.SimpleButton simpleButton5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxTotGrosse;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgView;
        private System.Windows.Forms.DataGridViewTextBoxColumn CashAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn NetAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn CashCollectionId;
    }
}