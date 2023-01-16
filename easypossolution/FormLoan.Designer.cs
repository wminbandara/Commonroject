namespace easyPOSSolution
{
    partial class FormLoan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLoan));
            this.label46 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtLoanName = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtloanamount = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtInterest = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxPayble = new System.Windows.Forms.TextBox();
            this.dateTimePickerPayDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.StatusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ToolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblUserId = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBoxRemarks = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.textBoxPayAmount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxLoan = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.textBoxLoanTotal = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxPayTotal = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxBalance = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.StatusStrip1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label46
            // 
            this.label46.BackColor = System.Drawing.Color.CornflowerBlue;
            this.label46.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label46.Font = new System.Drawing.Font("Tahoma", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label46.ForeColor = System.Drawing.Color.White;
            this.label46.Location = new System.Drawing.Point(3, 9);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(634, 32);
            this.label46.TabIndex = 708;
            this.label46.Text = "LOAN";
            this.label46.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(10, 15);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(74, 14);
            this.label15.TabIndex = 712;
            this.label15.Text = "Loan Name";
            // 
            // txtLoanName
            // 
            this.txtLoanName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtLoanName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtLoanName.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLoanName.Location = new System.Drawing.Point(6, 32);
            this.txtLoanName.Name = "txtLoanName";
            this.txtLoanName.Size = new System.Drawing.Size(263, 25);
            this.txtLoanName.TabIndex = 709;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(280, 14);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(91, 14);
            this.label13.TabIndex = 711;
            this.label13.Text = "Loan Amount";
            // 
            // txtloanamount
            // 
            this.txtloanamount.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtloanamount.ForeColor = System.Drawing.Color.Black;
            this.txtloanamount.Location = new System.Drawing.Point(277, 31);
            this.txtloanamount.Name = "txtloanamount";
            this.txtloanamount.Size = new System.Drawing.Size(97, 26);
            this.txtloanamount.TabIndex = 710;
            this.txtloanamount.Text = "0.00";
            this.txtloanamount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtloanamount.TextChanged += new System.EventHandler(this.txtloanamount_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(381, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(111, 14);
            this.label8.TabIndex = 714;
            this.label8.Text = "Interest Amount";
            // 
            // txtInterest
            // 
            this.txtInterest.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInterest.Location = new System.Drawing.Point(380, 32);
            this.txtInterest.Name = "txtInterest";
            this.txtInterest.Size = new System.Drawing.Size(112, 25);
            this.txtInterest.TabIndex = 713;
            this.txtInterest.Text = "0.00";
            this.txtInterest.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtInterest.TextChanged += new System.EventHandler(this.txtInterest_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(507, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 14);
            this.label1.TabIndex = 716;
            this.label1.Text = "Payble Amount";
            // 
            // textBoxPayble
            // 
            this.textBoxPayble.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPayble.Location = new System.Drawing.Point(504, 32);
            this.textBoxPayble.Name = "textBoxPayble";
            this.textBoxPayble.ReadOnly = true;
            this.textBoxPayble.Size = new System.Drawing.Size(115, 25);
            this.textBoxPayble.TabIndex = 715;
            this.textBoxPayble.Text = "0.00";
            this.textBoxPayble.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dateTimePickerPayDate
            // 
            this.dateTimePickerPayDate.CustomFormat = "yyyy-MM-dd";
            this.dateTimePickerPayDate.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold);
            this.dateTimePickerPayDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerPayDate.Location = new System.Drawing.Point(359, 32);
            this.dateTimePickerPayDate.Name = "dateTimePickerPayDate";
            this.dateTimePickerPayDate.Size = new System.Drawing.Size(130, 25);
            this.dateTimePickerPayDate.TabIndex = 721;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(362, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 14);
            this.label3.TabIndex = 722;
            this.label3.Text = "Payment Date";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.button1.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(625, 24);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 33);
            this.button1.TabIndex = 723;
            this.button1.Text = "&Save Loan";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.txtloanamount);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.txtLoanName);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.txtInterest);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBoxPayble);
            this.groupBox1.Location = new System.Drawing.Point(3, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(755, 67);
            this.groupBox1.TabIndex = 724;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView2);
            this.groupBox2.Location = new System.Drawing.Point(3, 223);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(619, 251);
            this.groupBox2.TabIndex = 725;
            this.groupBox2.TabStop = false;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(3, 16);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(613, 232);
            this.dataGridView2.TabIndex = 1;
            // 
            // StatusStrip1
            // 
            this.StatusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripStatusLabel1,
            this.lblUser,
            this.lblUserId,
            this.ToolStripStatusLabel3});
            this.StatusStrip1.Location = new System.Drawing.Point(0, 477);
            this.StatusStrip1.Name = "StatusStrip1";
            this.StatusStrip1.Size = new System.Drawing.Size(770, 22);
            this.StatusStrip1.TabIndex = 726;
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
            this.ToolStripStatusLabel3.Size = new System.Drawing.Size(524, 17);
            this.ToolStripStatusLabel3.Spring = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBoxRemarks);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.textBoxPayAmount);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.comboBoxLoan);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.dateTimePickerPayDate);
            this.groupBox3.Location = new System.Drawing.Point(3, 111);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(755, 106);
            this.groupBox3.TabIndex = 727;
            this.groupBox3.TabStop = false;
            // 
            // textBoxRemarks
            // 
            this.textBoxRemarks.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBoxRemarks.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxRemarks.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRemarks.Location = new System.Drawing.Point(70, 66);
            this.textBoxRemarks.Name = "textBoxRemarks";
            this.textBoxRemarks.Size = new System.Drawing.Size(549, 25);
            this.textBoxRemarks.TabIndex = 727;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(10, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 14);
            this.label4.TabIndex = 726;
            this.label4.Text = "Remarks";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.button2.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(625, 25);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(124, 66);
            this.button2.TabIndex = 725;
            this.button2.Text = "&Save Payment";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBoxPayAmount
            // 
            this.textBoxPayAmount.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPayAmount.ForeColor = System.Drawing.Color.Black;
            this.textBoxPayAmount.Location = new System.Drawing.Point(501, 32);
            this.textBoxPayAmount.Name = "textBoxPayAmount";
            this.textBoxPayAmount.Size = new System.Drawing.Size(118, 26);
            this.textBoxPayAmount.TabIndex = 723;
            this.textBoxPayAmount.Text = "0.00";
            this.textBoxPayAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(504, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 14);
            this.label2.TabIndex = 724;
            this.label2.Text = "Payment Amount";
            // 
            // comboBoxLoan
            // 
            this.comboBoxLoan.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold);
            this.comboBoxLoan.FormattingEnabled = true;
            this.comboBoxLoan.Location = new System.Drawing.Point(6, 32);
            this.comboBoxLoan.Name = "comboBoxLoan";
            this.comboBoxLoan.Size = new System.Drawing.Size(337, 25);
            this.comboBoxLoan.TabIndex = 183;
            this.comboBoxLoan.SelectedIndexChanged += new System.EventHandler(this.comboBoxLoan_SelectedIndexChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label18.Location = new System.Drawing.Point(10, 15);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(74, 14);
            this.label18.TabIndex = 182;
            this.label18.Text = "Loan Name";
            // 
            // textBoxLoanTotal
            // 
            this.textBoxLoanTotal.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxLoanTotal.ForeColor = System.Drawing.Color.Black;
            this.textBoxLoanTotal.Location = new System.Drawing.Point(634, 292);
            this.textBoxLoanTotal.Name = "textBoxLoanTotal";
            this.textBoxLoanTotal.Size = new System.Drawing.Size(118, 26);
            this.textBoxLoanTotal.TabIndex = 728;
            this.textBoxLoanTotal.Text = "0.00";
            this.textBoxLoanTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(637, 275);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 14);
            this.label5.TabIndex = 729;
            this.label5.Text = "Loan Amount";
            // 
            // textBoxPayTotal
            // 
            this.textBoxPayTotal.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPayTotal.ForeColor = System.Drawing.Color.Black;
            this.textBoxPayTotal.Location = new System.Drawing.Point(634, 354);
            this.textBoxPayTotal.Name = "textBoxPayTotal";
            this.textBoxPayTotal.Size = new System.Drawing.Size(118, 26);
            this.textBoxPayTotal.TabIndex = 730;
            this.textBoxPayTotal.Text = "0.00";
            this.textBoxPayTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(637, 337);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 14);
            this.label6.TabIndex = 731;
            this.label6.Text = "Payment Total";
            // 
            // textBoxBalance
            // 
            this.textBoxBalance.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxBalance.ForeColor = System.Drawing.Color.Red;
            this.textBoxBalance.Location = new System.Drawing.Point(634, 414);
            this.textBoxBalance.Name = "textBoxBalance";
            this.textBoxBalance.Size = new System.Drawing.Size(118, 26);
            this.textBoxBalance.TabIndex = 732;
            this.textBoxBalance.Text = "0.00";
            this.textBoxBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(637, 397);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 14);
            this.label7.TabIndex = 733;
            this.label7.Text = "Balance Amount";
            // 
            // FormLoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(770, 499);
            this.Controls.Add(this.textBoxBalance);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxPayTotal);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxLoanTotal);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.StatusStrip1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label46);
            this.Name = "FormLoan";
            this.Text = "FormLoan";
            this.Load += new System.EventHandler(this.FormLoan_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.StatusStrip1.ResumeLayout(false);
            this.StatusStrip1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtLoanName;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtloanamount;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtInterest;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxPayble;
        private System.Windows.Forms.DateTimePicker dateTimePickerPayDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.StatusStrip StatusStrip1;
        internal System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel1;
        internal System.Windows.Forms.ToolStripStatusLabel lblUser;
        internal System.Windows.Forms.ToolStripStatusLabel lblUserId;
        internal System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBoxPayAmount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxLoan;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox textBoxRemarks;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBoxLoanTotal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxPayTotal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxBalance;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dataGridView2;
    }
}