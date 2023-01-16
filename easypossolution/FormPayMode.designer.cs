namespace easyPOSSolution
{
    partial class FormPayMode
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxCardType = new System.Windows.Forms.ComboBox();
            this.textBoxChequeNo = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.comboBoxBank = new System.Windows.Forms.ComboBox();
            this.label27 = new System.Windows.Forms.Label();
            this.dateTimePickerChqExpDate = new System.Windows.Forms.DateTimePicker();
            this.label21 = new System.Windows.Forms.Label();
            this.comboBoxPayMode = new System.Windows.Forms.ComboBox();
            this.simpleButtonEsc = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonEnter = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBoxCardType);
            this.groupBox1.Controls.Add(this.textBoxChequeNo);
            this.groupBox1.Controls.Add(this.label23);
            this.groupBox1.Controls.Add(this.label25);
            this.groupBox1.Controls.Add(this.comboBoxBank);
            this.groupBox1.Controls.Add(this.label27);
            this.groupBox1.Controls.Add(this.dateTimePickerChqExpDate);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.comboBoxPayMode);
            this.groupBox1.Location = new System.Drawing.Point(9, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(340, 196);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // comboBoxCardType
            // 
            this.comboBoxCardType.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxCardType.FormattingEnabled = true;
            this.comboBoxCardType.Items.AddRange(new object[] {
            "Visa",
            "Master",
            "Amex"});
            this.comboBoxCardType.Location = new System.Drawing.Point(125, 157);
            this.comboBoxCardType.Name = "comboBoxCardType";
            this.comboBoxCardType.Size = new System.Drawing.Size(192, 30);
            this.comboBoxCardType.TabIndex = 697;
            this.comboBoxCardType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBoxCardType_KeyDown);
            // 
            // textBoxChequeNo
            // 
            this.textBoxChequeNo.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxChequeNo.Location = new System.Drawing.Point(125, 61);
            this.textBoxChequeNo.Name = "textBoxChequeNo";
            this.textBoxChequeNo.Size = new System.Drawing.Size(194, 30);
            this.textBoxChequeNo.TabIndex = 691;
            this.textBoxChequeNo.Visible = false;
            this.textBoxChequeNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxChequeNo_KeyDown);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.Color.Transparent;
            this.label23.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.Black;
            this.label23.Location = new System.Drawing.Point(13, 65);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(108, 19);
            this.label23.TabIndex = 692;
            this.label23.Text = "Cheque No :";
            this.label23.Visible = false;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.BackColor = System.Drawing.Color.Transparent;
            this.label25.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.Black;
            this.label25.Location = new System.Drawing.Point(60, 114);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(61, 19);
            this.label25.TabIndex = 693;
            this.label25.Text = "Bank :";
            this.label25.Visible = false;
            // 
            // comboBoxBank
            // 
            this.comboBoxBank.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxBank.FormattingEnabled = true;
            this.comboBoxBank.Items.AddRange(new object[] {
            "BOC",
            "Peoples Bank",
            "Commercial",
            "HNB",
            "NTB",
            "HSBC",
            "Sampath",
            "NSB",
            "NDB"});
            this.comboBoxBank.Location = new System.Drawing.Point(125, 109);
            this.comboBoxBank.Name = "comboBoxBank";
            this.comboBoxBank.Size = new System.Drawing.Size(194, 30);
            this.comboBoxBank.TabIndex = 694;
            this.comboBoxBank.Visible = false;
            this.comboBoxBank.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBoxBank_KeyDown);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.BackColor = System.Drawing.Color.Transparent;
            this.label27.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.Color.Black;
            this.label27.Location = new System.Drawing.Point(22, 163);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(99, 19);
            this.label27.TabIndex = 695;
            this.label27.Text = "Exp. Date :";
            this.label27.Visible = false;
            // 
            // dateTimePickerChqExpDate
            // 
            this.dateTimePickerChqExpDate.CustomFormat = "yyyy-MM-dd";
            this.dateTimePickerChqExpDate.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerChqExpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerChqExpDate.Location = new System.Drawing.Point(125, 157);
            this.dateTimePickerChqExpDate.Name = "dateTimePickerChqExpDate";
            this.dateTimePickerChqExpDate.Size = new System.Drawing.Size(203, 30);
            this.dateTimePickerChqExpDate.TabIndex = 696;
            this.dateTimePickerChqExpDate.Visible = false;
            this.dateTimePickerChqExpDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dateTimePickerChqExpDate_KeyDown);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.Black;
            this.label21.Location = new System.Drawing.Point(22, 17);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(99, 19);
            this.label21.TabIndex = 196;
            this.label21.Text = "Pay Mode :";
            // 
            // comboBoxPayMode
            // 
            this.comboBoxPayMode.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxPayMode.FormattingEnabled = true;
            this.comboBoxPayMode.Location = new System.Drawing.Point(125, 13);
            this.comboBoxPayMode.Name = "comboBoxPayMode";
            this.comboBoxPayMode.Size = new System.Drawing.Size(194, 30);
            this.comboBoxPayMode.TabIndex = 197;
            this.comboBoxPayMode.SelectedIndexChanged += new System.EventHandler(this.comboBoxPayMode_SelectedIndexChanged);
            this.comboBoxPayMode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBoxPayMode_KeyDown);
            // 
            // simpleButtonEsc
            // 
            this.simpleButtonEsc.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButtonEsc.Appearance.Options.UseFont = true;
            this.simpleButtonEsc.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.simpleButtonEsc.Location = new System.Drawing.Point(12, 206);
            this.simpleButtonEsc.Name = "simpleButtonEsc";
            this.simpleButtonEsc.Size = new System.Drawing.Size(160, 37);
            this.simpleButtonEsc.TabIndex = 742;
            this.simpleButtonEsc.Text = "Esc";
            this.simpleButtonEsc.Click += new System.EventHandler(this.simpleButtonEsc_Click);
            // 
            // simpleButtonEnter
            // 
            this.simpleButtonEnter.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButtonEnter.Appearance.Options.UseFont = true;
            this.simpleButtonEnter.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.simpleButtonEnter.Location = new System.Drawing.Point(184, 206);
            this.simpleButtonEnter.Name = "simpleButtonEnter";
            this.simpleButtonEnter.Size = new System.Drawing.Size(160, 37);
            this.simpleButtonEnter.TabIndex = 743;
            this.simpleButtonEnter.Text = "Enter";
            this.simpleButtonEnter.Click += new System.EventHandler(this.simpleButtonEnter_Click);
            // 
            // FormPayMode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(356, 255);
            this.Controls.Add(this.simpleButtonEnter);
            this.Controls.Add(this.simpleButtonEsc);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "FormPayMode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormPayMode";
            this.Load += new System.EventHandler(this.FormPayMode_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormPayMode_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox comboBoxPayMode;
        private System.Windows.Forms.ComboBox comboBoxCardType;
        private System.Windows.Forms.TextBox textBoxChequeNo;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.ComboBox comboBoxBank;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.DateTimePicker dateTimePickerChqExpDate;
        private DevExpress.XtraEditors.SimpleButton simpleButtonEsc;
        private DevExpress.XtraEditors.SimpleButton simpleButtonEnter;
    }
}