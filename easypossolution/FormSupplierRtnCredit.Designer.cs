namespace easyPOSSolution
{
    partial class FormSupplierRtnCredit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSupplierRtnCredit));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.ToolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblUserId = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusStrip1 = new System.Windows.Forms.StatusStrip();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.textBoxReturn = new System.Windows.Forms.TextBox();
            this.buttonPay = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.textBoxPayTotal = new System.Windows.Forms.TextBox();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBoxHDId = new System.Windows.Forms.TextBox();
            this.textBoxOutofBalance = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BillNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreditDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreditAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaymentAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SuppCreditId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 302);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 17);
            this.label1.TabIndex = 195;
            this.label1.Text = "Return Total :";
            // 
            // ToolStripStatusLabel3
            // 
            this.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3";
            this.ToolStripStatusLabel3.Size = new System.Drawing.Size(473, 21);
            this.ToolStripStatusLabel3.Spring = true;
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
            // ToolStripStatusLabel1
            // 
            this.ToolStripStatusLabel1.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1";
            this.ToolStripStatusLabel1.Size = new System.Drawing.Size(108, 21);
            this.ToolStripStatusLabel1.Text = "Logged in As :";
            // 
            // StatusStrip1
            // 
            this.StatusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.StatusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripStatusLabel1,
            this.lblUser,
            this.lblUserId,
            this.ToolStripStatusLabel3});
            this.StatusStrip1.Location = new System.Drawing.Point(0, 342);
            this.StatusStrip1.Name = "StatusStrip1";
            this.StatusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.StatusStrip1.Size = new System.Drawing.Size(787, 26);
            this.StatusStrip1.TabIndex = 193;
            this.StatusStrip1.Text = "StatusStrip1";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // textBoxReturn
            // 
            this.textBoxReturn.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxReturn.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxReturn.Location = new System.Drawing.Point(123, 297);
            this.textBoxReturn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxReturn.Name = "textBoxReturn";
            this.textBoxReturn.ReadOnly = true;
            this.textBoxReturn.Size = new System.Drawing.Size(156, 25);
            this.textBoxReturn.TabIndex = 194;
            this.textBoxReturn.Text = "0.00";
            this.textBoxReturn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxReturn.TextChanged += new System.EventHandler(this.textBoxReturn_TextChanged);
            // 
            // buttonPay
            // 
            this.buttonPay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(160)))));
            this.buttonPay.Font = new System.Drawing.Font("Cambria", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPay.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonPay.Location = new System.Drawing.Point(588, 292);
            this.buttonPay.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonPay.Name = "buttonPay";
            this.buttonPay.Size = new System.Drawing.Size(157, 44);
            this.buttonPay.TabIndex = 192;
            this.buttonPay.Text = "&Pay";
            this.buttonPay.UseVisualStyleBackColor = false;
            this.buttonPay.Click += new System.EventHandler(this.buttonPay_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(469, 261);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(100, 17);
            this.label13.TabIndex = 187;
            this.label13.Text = "Total Amount :";
            // 
            // textBoxPayTotal
            // 
            this.textBoxPayTotal.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxPayTotal.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPayTotal.Location = new System.Drawing.Point(583, 256);
            this.textBoxPayTotal.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxPayTotal.Name = "textBoxPayTotal";
            this.textBoxPayTotal.ReadOnly = true;
            this.textBoxPayTotal.Size = new System.Drawing.Size(156, 25);
            this.textBoxPayTotal.TabIndex = 186;
            this.textBoxPayTotal.Text = "0.00";
            this.textBoxPayTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxPayTotal.TextChanged += new System.EventHandler(this.textBoxPayTotal_TextChanged);
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToAddRows = false;
            this.dataGridView3.AllowUserToDeleteRows = false;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            this.dataGridView3.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridView3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView3.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView3.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dataGridView3.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView3.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BillNo,
            this.CreditDate,
            this.CreditAmount,
            this.PaymentAmount,
            this.SuppCreditId});
            this.dataGridView3.GridColor = System.Drawing.Color.White;
            this.dataGridView3.Location = new System.Drawing.Point(9, 27);
            this.dataGridView3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView3.RowHeadersDefaultCellStyle = dataGridViewCellStyle13;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView3.RowsDefaultCellStyle = dataGridViewCellStyle14;
            this.dataGridView3.Size = new System.Drawing.Size(757, 224);
            this.dataGridView3.TabIndex = 55;
            this.dataGridView3.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView3_CellClick);
            this.dataGridView3.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView3_CellValueChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.textBoxPayTotal);
            this.groupBox4.Controls.Add(this.dataGridView3);
            this.groupBox4.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(5, 1);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox4.Size = new System.Drawing.Size(775, 286);
            this.groupBox4.TabIndex = 191;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Credit Details";
            // 
            // textBoxHDId
            // 
            this.textBoxHDId.Font = new System.Drawing.Font("Cambria", 9F);
            this.textBoxHDId.Location = new System.Drawing.Point(510, 302);
            this.textBoxHDId.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxHDId.Name = "textBoxHDId";
            this.textBoxHDId.Size = new System.Drawing.Size(64, 25);
            this.textBoxHDId.TabIndex = 694;
            this.textBoxHDId.Text = "0";
            this.textBoxHDId.Visible = false;
            // 
            // textBoxOutofBalance
            // 
            this.textBoxOutofBalance.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxOutofBalance.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxOutofBalance.Location = new System.Drawing.Point(386, 299);
            this.textBoxOutofBalance.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxOutofBalance.Name = "textBoxOutofBalance";
            this.textBoxOutofBalance.ReadOnly = true;
            this.textBoxOutofBalance.Size = new System.Drawing.Size(156, 25);
            this.textBoxOutofBalance.TabIndex = 695;
            this.textBoxOutofBalance.Text = "0.00";
            this.textBoxOutofBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(312, 302);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 17);
            this.label2.TabIndex = 696;
            this.label2.Text = "Balance :";
            // 
            // BillNo
            // 
            this.BillNo.HeaderText = "BillNo";
            this.BillNo.Name = "BillNo";
            this.BillNo.ReadOnly = true;
            this.BillNo.Width = 84;
            // 
            // CreditDate
            // 
            dataGridViewCellStyle10.NullValue = null;
            this.CreditDate.DefaultCellStyle = dataGridViewCellStyle10;
            this.CreditDate.HeaderText = "CreditDate";
            this.CreditDate.Name = "CreditDate";
            this.CreditDate.ReadOnly = true;
            this.CreditDate.Width = 116;
            // 
            // CreditAmount
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.CreditAmount.DefaultCellStyle = dataGridViewCellStyle11;
            this.CreditAmount.HeaderText = "CreditAmount";
            this.CreditAmount.Name = "CreditAmount";
            this.CreditAmount.ReadOnly = true;
            this.CreditAmount.Width = 141;
            // 
            // PaymentAmount
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.Format = "N2";
            dataGridViewCellStyle12.NullValue = "0";
            this.PaymentAmount.DefaultCellStyle = dataGridViewCellStyle12;
            this.PaymentAmount.HeaderText = "PaymentAmount";
            this.PaymentAmount.Name = "PaymentAmount";
            this.PaymentAmount.Width = 160;
            // 
            // SuppCreditId
            // 
            this.SuppCreditId.HeaderText = "SuppCreditId";
            this.SuppCreditId.Name = "SuppCreditId";
            this.SuppCreditId.Visible = false;
            this.SuppCreditId.Width = 133;
            // 
            // FormSupplierRtnCredit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 368);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxOutofBalance);
            this.Controls.Add(this.textBoxHDId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.StatusStrip1);
            this.Controls.Add(this.textBoxReturn);
            this.Controls.Add(this.buttonPay);
            this.Controls.Add(this.groupBox4);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormSupplierRtnCredit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormSupplierRtnCredit";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSupplierRtnCredit_FormClosing);
            this.Load += new System.EventHandler(this.FormSupplierRtnCredit_Load);
            this.StatusStrip1.ResumeLayout(false);
            this.StatusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel3;
        internal System.Windows.Forms.ToolStripStatusLabel lblUserId;
        internal System.Windows.Forms.ToolStripStatusLabel lblUser;
        internal System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel1;
        internal System.Windows.Forms.StatusStrip StatusStrip1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        public System.Windows.Forms.TextBox textBoxReturn;
        private System.Windows.Forms.Button buttonPay;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label13;
        public System.Windows.Forms.TextBox textBoxPayTotal;
        public System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.TextBox textBoxHDId;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox textBoxOutofBalance;
        private System.Windows.Forms.DataGridViewTextBoxColumn BillNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreditDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreditAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaymentAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn SuppCreditId;
    }
}