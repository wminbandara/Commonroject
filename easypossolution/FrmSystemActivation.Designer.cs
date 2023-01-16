namespace easyPOSSolution
{
    partial class FrmSystemActivation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSystemActivation));
            this.textBoxCompName = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonActivation = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Label8 = new System.Windows.Forms.Label();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxActivationType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxActStatus = new System.Windows.Forms.ComboBox();
            this.textBoxActBillNo = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxCompName
            // 
            this.textBoxCompName.Location = new System.Drawing.Point(151, 63);
            this.textBoxCompName.Name = "textBoxCompName";
            this.textBoxCompName.ReadOnly = true;
            this.textBoxCompName.Size = new System.Drawing.Size(230, 25);
            this.textBoxCompName.TabIndex = 100;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonActivation);
            this.groupBox2.Controls.Add(this.buttonExit);
            this.groupBox2.Controls.Add(this.buttonSave);
            this.groupBox2.Location = new System.Drawing.Point(10, 301);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(420, 49);
            this.groupBox2.TabIndex = 202;
            this.groupBox2.TabStop = false;
            // 
            // buttonActivation
            // 
            this.buttonActivation.Enabled = false;
            this.buttonActivation.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonActivation.Location = new System.Drawing.Point(25, 13);
            this.buttonActivation.Name = "buttonActivation";
            this.buttonActivation.Size = new System.Drawing.Size(113, 31);
            this.buttonActivation.TabIndex = 5;
            this.buttonActivation.Text = "&Dev Activate";
            this.buttonActivation.UseVisualStyleBackColor = true;
            this.buttonActivation.Visible = false;
            this.buttonActivation.Click += new System.EventHandler(this.buttonActivation_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExit.Location = new System.Drawing.Point(282, 13);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(113, 31);
            this.buttonExit.TabIndex = 4;
            this.buttonExit.Text = "&Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Enabled = false;
            this.buttonSave.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSave.Location = new System.Drawing.Point(159, 13);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(113, 31);
            this.buttonSave.TabIndex = 3;
            this.buttonSave.Text = "&Activate";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.White;
            this.Label1.Location = new System.Drawing.Point(42, 67);
            this.Label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(107, 18);
            this.Label1.TabIndex = 43;
            this.Label1.Text = "Company Name";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.Color.White;
            this.Label2.Location = new System.Drawing.Point(10, 112);
            this.Label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(139, 18);
            this.Label2.TabIndex = 44;
            this.Label2.Text = "Service Activation No";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.SteelBlue;
            this.label21.Location = new System.Drawing.Point(18, 6);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(333, 25);
            this.label21.TabIndex = 50;
            this.label21.Text = "A C T I V A T E    T H E    S Y S T E M";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label21);
            this.panel1.Location = new System.Drawing.Point(10, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(420, 40);
            this.panel1.TabIndex = 200;
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label8.ForeColor = System.Drawing.Color.White;
            this.Label8.Location = new System.Drawing.Point(39, 158);
            this.Label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(110, 18);
            this.Label8.TabIndex = 53;
            this.Label8.Text = "Activation Status";
            // 
            // GroupBox1
            // 
            this.GroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.GroupBox1.Controls.Add(this.comboBoxActivationType);
            this.GroupBox1.Controls.Add(this.label4);
            this.GroupBox1.Controls.Add(this.textBoxPassword);
            this.GroupBox1.Controls.Add(this.label3);
            this.GroupBox1.Controls.Add(this.comboBoxActStatus);
            this.GroupBox1.Controls.Add(this.textBoxActBillNo);
            this.GroupBox1.Controls.Add(this.textBoxCompName);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Controls.Add(this.Label8);
            this.GroupBox1.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox1.ForeColor = System.Drawing.Color.White;
            this.GroupBox1.Location = new System.Drawing.Point(10, 56);
            this.GroupBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.GroupBox1.Size = new System.Drawing.Size(420, 239);
            this.GroupBox1.TabIndex = 199;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Activation Details";
            // 
            // comboBoxActivationType
            // 
            this.comboBoxActivationType.Enabled = false;
            this.comboBoxActivationType.FormattingEnabled = true;
            this.comboBoxActivationType.Items.AddRange(new object[] {
            "1 Month",
            "1 Year",
            "Life time"});
            this.comboBoxActivationType.Location = new System.Drawing.Point(151, 201);
            this.comboBoxActivationType.Name = "comboBoxActivationType";
            this.comboBoxActivationType.Size = new System.Drawing.Size(121, 26);
            this.comboBoxActivationType.TabIndex = 104;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(45, 206);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 18);
            this.label4.TabIndex = 105;
            this.label4.Text = "Activation Type";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(151, 18);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(230, 25);
            this.textBoxPassword.TabIndex = 0;
            this.textBoxPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxPassword_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(82, 21);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 18);
            this.label3.TabIndex = 103;
            this.label3.Text = "Password";
            // 
            // comboBoxActStatus
            // 
            this.comboBoxActStatus.Enabled = false;
            this.comboBoxActStatus.FormattingEnabled = true;
            this.comboBoxActStatus.Items.AddRange(new object[] {
            "Activate",
            "Deactivate"});
            this.comboBoxActStatus.Location = new System.Drawing.Point(151, 153);
            this.comboBoxActStatus.Name = "comboBoxActStatus";
            this.comboBoxActStatus.Size = new System.Drawing.Size(121, 26);
            this.comboBoxActStatus.TabIndex = 2;
            // 
            // textBoxActBillNo
            // 
            this.textBoxActBillNo.Location = new System.Drawing.Point(151, 108);
            this.textBoxActBillNo.MaxLength = 4;
            this.textBoxActBillNo.Name = "textBoxActBillNo";
            this.textBoxActBillNo.PasswordChar = '*';
            this.textBoxActBillNo.ReadOnly = true;
            this.textBoxActBillNo.Size = new System.Drawing.Size(230, 25);
            this.textBoxActBillNo.TabIndex = 1;
            // 
            // FrmSystemActivation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(442, 359);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.GroupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmSystemActivation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "System Activation";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmSystemActivation_FormClosing);
            this.Load += new System.EventHandler(this.FrmSystemActivation_Load);
            this.groupBox2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxCompName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonSave;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label label21;
        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.GroupBox GroupBox1;
        private System.Windows.Forms.ComboBox comboBoxActStatus;
        private System.Windows.Forms.TextBox textBoxActBillNo;
        private System.Windows.Forms.TextBox textBoxPassword;
        internal System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxActivationType;
        internal System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonActivation;
    }
}