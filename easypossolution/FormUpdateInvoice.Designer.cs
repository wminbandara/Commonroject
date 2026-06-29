namespace easyPOSSolution
{
    partial class FormUpdateInvoice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormUpdateInvoice));
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.simpleButtonReturn = new DevExpress.XtraEditors.SimpleButton();
            this.textBoxChargesPer = new System.Windows.Forms.TextBox();
            this.textBoxChargesAmount = new System.Windows.Forms.TextBox();
            this.label70 = new System.Windows.Forms.Label();
            this.lblNetTotal = new System.Windows.Forms.TextBox();
            this.lblGrossTot = new System.Windows.Forms.TextBox();
            this.textBoxTotDiscPerc = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.txtTotDiscRate = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.StatusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ToolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblUserId = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblBranchID = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxCustomer = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxBillNo = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.StatusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.simpleButton1.Location = new System.Drawing.Point(13, 8);
            this.simpleButton1.Margin = new System.Windows.Forms.Padding(4);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(371, 39);
            this.simpleButton1.TabIndex = 722;
            this.simpleButton1.Text = "U P D A T E   I N V O I C E";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.simpleButtonReturn);
            this.groupBox2.Controls.Add(this.textBoxChargesPer);
            this.groupBox2.Controls.Add(this.textBoxChargesAmount);
            this.groupBox2.Controls.Add(this.label70);
            this.groupBox2.Controls.Add(this.lblNetTotal);
            this.groupBox2.Controls.Add(this.lblGrossTot);
            this.groupBox2.Controls.Add(this.textBoxTotDiscPerc);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this.label28);
            this.groupBox2.Controls.Add(this.txtTotDiscRate);
            this.groupBox2.Controls.Add(this.label36);
            this.groupBox2.Location = new System.Drawing.Point(13, 205);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(371, 244);
            this.groupBox2.TabIndex = 723;
            this.groupBox2.TabStop = false;
            // 
            // simpleButtonReturn
            // 
            this.simpleButtonReturn.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.simpleButtonReturn.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.simpleButtonReturn.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButtonReturn.Appearance.Options.UseBackColor = true;
            this.simpleButtonReturn.Appearance.Options.UseFont = true;
            this.simpleButtonReturn.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.simpleButtonReturn.Location = new System.Drawing.Point(24, 192);
            this.simpleButtonReturn.Margin = new System.Windows.Forms.Padding(4);
            this.simpleButtonReturn.Name = "simpleButtonReturn";
            this.simpleButtonReturn.Size = new System.Drawing.Size(311, 34);
            this.simpleButtonReturn.TabIndex = 735;
            this.simpleButtonReturn.Text = "Update Invoice";
            this.simpleButtonReturn.Click += new System.EventHandler(this.simpleButtonReturn_Click);
            // 
            // textBoxChargesPer
            // 
            this.textBoxChargesPer.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxChargesPer.Location = new System.Drawing.Point(188, 93);
            this.textBoxChargesPer.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxChargesPer.MaxLength = 3;
            this.textBoxChargesPer.Name = "textBoxChargesPer";
            this.textBoxChargesPer.Size = new System.Drawing.Size(39, 26);
            this.textBoxChargesPer.TabIndex = 734;
            this.textBoxChargesPer.Text = "0";
            this.textBoxChargesPer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxChargesPer.TextChanged += new System.EventHandler(this.textBoxChargesPer_TextChanged);
            // 
            // textBoxChargesAmount
            // 
            this.textBoxChargesAmount.BackColor = System.Drawing.Color.White;
            this.textBoxChargesAmount.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxChargesAmount.ForeColor = System.Drawing.Color.Black;
            this.textBoxChargesAmount.Location = new System.Drawing.Point(231, 93);
            this.textBoxChargesAmount.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxChargesAmount.MaxLength = 10;
            this.textBoxChargesAmount.Name = "textBoxChargesAmount";
            this.textBoxChargesAmount.Size = new System.Drawing.Size(104, 26);
            this.textBoxChargesAmount.TabIndex = 733;
            this.textBoxChargesAmount.Text = "0.00";
            this.textBoxChargesAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxChargesAmount.TextChanged += new System.EventHandler(this.textBoxChargesAmount_TextChanged);
            // 
            // label70
            // 
            this.label70.AutoSize = true;
            this.label70.BackColor = System.Drawing.Color.Transparent;
            this.label70.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label70.ForeColor = System.Drawing.Color.Black;
            this.label70.Location = new System.Drawing.Point(92, 96);
            this.label70.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(90, 21);
            this.label70.TabIndex = 732;
            this.label70.Text = "Charges :";
            // 
            // lblNetTotal
            // 
            this.lblNetTotal.BackColor = System.Drawing.Color.White;
            this.lblNetTotal.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNetTotal.ForeColor = System.Drawing.Color.Red;
            this.lblNetTotal.Location = new System.Drawing.Point(151, 127);
            this.lblNetTotal.Margin = new System.Windows.Forms.Padding(4);
            this.lblNetTotal.MaxLength = 10;
            this.lblNetTotal.Name = "lblNetTotal";
            this.lblNetTotal.ReadOnly = true;
            this.lblNetTotal.Size = new System.Drawing.Size(184, 35);
            this.lblNetTotal.TabIndex = 701;
            this.lblNetTotal.Text = "0.00";
            this.lblNetTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblGrossTot
            // 
            this.lblGrossTot.BackColor = System.Drawing.Color.White;
            this.lblGrossTot.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrossTot.ForeColor = System.Drawing.Color.Black;
            this.lblGrossTot.Location = new System.Drawing.Point(188, 24);
            this.lblGrossTot.Margin = new System.Windows.Forms.Padding(4);
            this.lblGrossTot.MaxLength = 10;
            this.lblGrossTot.Name = "lblGrossTot";
            this.lblGrossTot.ReadOnly = true;
            this.lblGrossTot.Size = new System.Drawing.Size(147, 26);
            this.lblGrossTot.TabIndex = 698;
            this.lblGrossTot.Text = "0.00";
            this.lblGrossTot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxTotDiscPerc
            // 
            this.textBoxTotDiscPerc.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTotDiscPerc.Location = new System.Drawing.Point(188, 59);
            this.textBoxTotDiscPerc.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxTotDiscPerc.MaxLength = 3;
            this.textBoxTotDiscPerc.Name = "textBoxTotDiscPerc";
            this.textBoxTotDiscPerc.Size = new System.Drawing.Size(39, 26);
            this.textBoxTotDiscPerc.TabIndex = 697;
            this.textBoxTotDiscPerc.Text = "0";
            this.textBoxTotDiscPerc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxTotDiscPerc.TextChanged += new System.EventHandler(this.textBoxTotDiscPerc_TextChanged);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label22.ForeColor = System.Drawing.Color.Black;
            this.label22.Location = new System.Drawing.Point(64, 64);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(108, 18);
            this.label22.TabIndex = 167;
            this.label22.Text = "Disc for Tot. :";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.BackColor = System.Drawing.Color.Transparent;
            this.label28.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.Color.Black;
            this.label28.Location = new System.Drawing.Point(19, 131);
            this.label28.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(123, 28);
            this.label28.TabIndex = 173;
            this.label28.Text = "Net Total :";
            // 
            // txtTotDiscRate
            // 
            this.txtTotDiscRate.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotDiscRate.Location = new System.Drawing.Point(231, 59);
            this.txtTotDiscRate.Margin = new System.Windows.Forms.Padding(4);
            this.txtTotDiscRate.MaxLength = 10;
            this.txtTotDiscRate.Name = "txtTotDiscRate";
            this.txtTotDiscRate.Size = new System.Drawing.Size(104, 26);
            this.txtTotDiscRate.TabIndex = 676;
            this.txtTotDiscRate.Text = "0.00";
            this.txtTotDiscRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotDiscRate.TextChanged += new System.EventHandler(this.txtTotDiscRate_TextChanged);
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.BackColor = System.Drawing.Color.Transparent;
            this.label36.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.ForeColor = System.Drawing.Color.Black;
            this.label36.Location = new System.Drawing.Point(66, 27);
            this.label36.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(118, 21);
            this.label36.TabIndex = 680;
            this.label36.Text = "Gross Total :";
            // 
            // StatusStrip1
            // 
            this.StatusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.StatusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripStatusLabel1,
            this.lblUser,
            this.ToolStripStatusLabel3,
            this.lblUserId,
            this.lblBranchID});
            this.StatusStrip1.Location = new System.Drawing.Point(0, 462);
            this.StatusStrip1.Name = "StatusStrip1";
            this.StatusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.StatusStrip1.Size = new System.Drawing.Size(410, 26);
            this.StatusStrip1.TabIndex = 724;
            this.StatusStrip1.Text = "StatusStrip1";
            // 
            // ToolStripStatusLabel1
            // 
            this.ToolStripStatusLabel1.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToolStripStatusLabel1.ForeColor = System.Drawing.Color.Black;
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
            // ToolStripStatusLabel3
            // 
            this.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3";
            this.ToolStripStatusLabel3.Size = new System.Drawing.Size(10, 21);
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
            // lblBranchID
            // 
            this.lblBranchID.Name = "lblBranchID";
            this.lblBranchID.Size = new System.Drawing.Size(86, 21);
            this.lblBranchID.Text = "lblBranchID";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxCustomer);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBoxBillNo);
            this.groupBox1.Controls.Add(this.label24);
            this.groupBox1.Location = new System.Drawing.Point(13, 55);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(371, 135);
            this.groupBox1.TabIndex = 725;
            this.groupBox1.TabStop = false;
            // 
            // textBoxCustomer
            // 
            this.textBoxCustomer.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxCustomer.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCustomer.Location = new System.Drawing.Point(8, 82);
            this.textBoxCustomer.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxCustomer.Name = "textBoxCustomer";
            this.textBoxCustomer.ReadOnly = true;
            this.textBoxCustomer.Size = new System.Drawing.Size(355, 25);
            this.textBoxCustomer.TabIndex = 172;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 61);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 17);
            this.label2.TabIndex = 171;
            this.label2.Text = "Customer :";
            // 
            // textBoxBillNo
            // 
            this.textBoxBillNo.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxBillNo.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxBillNo.Location = new System.Drawing.Point(76, 23);
            this.textBoxBillNo.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxBillNo.Name = "textBoxBillNo";
            this.textBoxBillNo.Size = new System.Drawing.Size(149, 25);
            this.textBoxBillNo.TabIndex = 169;
            this.textBoxBillNo.TextChanged += new System.EventHandler(this.textBoxBillNo_TextChanged);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(12, 26);
            this.label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(57, 17);
            this.label24.TabIndex = 170;
            this.label24.Text = "Bill No.:";
            // 
            // FormUpdateInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 488);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.StatusStrip1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.simpleButton1);
            this.Name = "FormUpdateInvoice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormUpdateInvoice";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.StatusStrip1.ResumeLayout(false);
            this.StatusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBoxChargesPer;
        private System.Windows.Forms.TextBox textBoxChargesAmount;
        private System.Windows.Forms.Label label70;
        private System.Windows.Forms.TextBox lblNetTotal;
        private System.Windows.Forms.TextBox lblGrossTot;
        private System.Windows.Forms.TextBox textBoxTotDiscPerc;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox txtTotDiscRate;
        private System.Windows.Forms.Label label36;
        private DevExpress.XtraEditors.SimpleButton simpleButtonReturn;
        internal System.Windows.Forms.StatusStrip StatusStrip1;
        internal System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel1;
        internal System.Windows.Forms.ToolStripStatusLabel lblUser;
        internal System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel3;
        internal System.Windows.Forms.ToolStripStatusLabel lblUserId;
        public System.Windows.Forms.ToolStripStatusLabel lblBranchID;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.TextBox textBoxBillNo;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox textBoxCustomer;
    }
}