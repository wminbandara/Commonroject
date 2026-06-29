namespace easyPOSSolution
{
    partial class FormEmployeeLeave
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEmployeeLeave));
            this.label46 = new System.Windows.Forms.Label();
            this.StatusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ToolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblUserId = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxLeaveReason = new System.Windows.Forms.TextBox();
            this.buttonDayEnd = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxLeaveEffectCount = new System.Windows.Forms.TextBox();
            this.LeaveDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.EmployeeName = new System.Windows.Forms.ComboBox();
            this.StatusStrip1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label46
            // 
            this.label46.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label46.BackColor = System.Drawing.Color.CornflowerBlue;
            this.label46.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label46.Font = new System.Drawing.Font("Tahoma", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label46.ForeColor = System.Drawing.Color.White;
            this.label46.Location = new System.Drawing.Point(4, 11);
            this.label46.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(1034, 39);
            this.label46.TabIndex = 712;
            this.label46.Text = "EMPLOYEE  LEAVE";
            this.label46.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StatusStrip1
            // 
            this.StatusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.StatusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripStatusLabel1,
            this.lblUser,
            this.lblUserId,
            this.ToolStripStatusLabel3});
            this.StatusStrip1.Location = new System.Drawing.Point(0, 575);
            this.StatusStrip1.Name = "StatusStrip1";
            this.StatusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.StatusStrip1.Size = new System.Drawing.Size(1055, 26);
            this.StatusStrip1.TabIndex = 713;
            this.StatusStrip1.Text = "StatusStrip1";
            // 
            // ToolStripStatusLabel1
            // 
            this.ToolStripStatusLabel1.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.ToolStripStatusLabel3.Size = new System.Drawing.Size(741, 21);
            this.ToolStripStatusLabel3.Spring = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.gridControl1);
            this.groupBox4.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(4, 197);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox4.Size = new System.Drawing.Size(1035, 373);
            this.groupBox4.TabIndex = 714;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Employee Leave Record";
            // 
            // gridControl1
            // 
            this.gridControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gridControl1.Location = new System.Drawing.Point(4, 28);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1027, 341);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView1_RowClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBoxLeaveReason);
            this.groupBox1.Controls.Add(this.buttonDayEnd);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBoxLeaveEffectCount);
            this.groupBox1.Controls.Add(this.LeaveDate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.EmployeeName);
            this.groupBox1.Location = new System.Drawing.Point(8, 55);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(1031, 134);
            this.groupBox1.TabIndex = 715;
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 89);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 23);
            this.label3.TabIndex = 717;
            this.label3.Text = "Leave Reason";
            // 
            // textBoxLeaveReason
            // 
            this.textBoxLeaveReason.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxLeaveReason.Location = new System.Drawing.Point(139, 85);
            this.textBoxLeaveReason.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxLeaveReason.Name = "textBoxLeaveReason";
            this.textBoxLeaveReason.Size = new System.Drawing.Size(701, 27);
            this.textBoxLeaveReason.TabIndex = 716;
            // 
            // buttonDayEnd
            // 
            this.buttonDayEnd.BackColor = System.Drawing.Color.CornflowerBlue;
            this.buttonDayEnd.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDayEnd.Location = new System.Drawing.Point(871, 33);
            this.buttonDayEnd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonDayEnd.Name = "buttonDayEnd";
            this.buttonDayEnd.Size = new System.Drawing.Size(151, 78);
            this.buttonDayEnd.TabIndex = 715;
            this.buttonDayEnd.Text = "&Save";
            this.buttonDayEnd.UseVisualStyleBackColor = false;
            this.buttonDayEnd.Click += new System.EventHandler(this.buttonDayEnd_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(680, 20);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 23);
            this.label2.TabIndex = 34;
            this.label2.Text = "Leave Effect Count";
            // 
            // textBoxLeaveEffectCount
            // 
            this.textBoxLeaveEffectCount.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold);
            this.textBoxLeaveEffectCount.Location = new System.Drawing.Point(679, 46);
            this.textBoxLeaveEffectCount.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxLeaveEffectCount.Multiline = true;
            this.textBoxLeaveEffectCount.Name = "textBoxLeaveEffectCount";
            this.textBoxLeaveEffectCount.Size = new System.Drawing.Size(160, 27);
            this.textBoxLeaveEffectCount.TabIndex = 33;
            this.textBoxLeaveEffectCount.Text = "1";
            this.textBoxLeaveEffectCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // LeaveDate
            // 
            this.LeaveDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LeaveDate.CustomFormat = "yyyy/MM/dd";
            this.LeaveDate.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold);
            this.LeaveDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.LeaveDate.Location = new System.Drawing.Point(476, 46);
            this.LeaveDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LeaveDate.Name = "LeaveDate";
            this.LeaveDate.Size = new System.Drawing.Size(187, 29);
            this.LeaveDate.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(480, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 23);
            this.label1.TabIndex = 9;
            this.label1.Text = "Leave Date";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(15, 20);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(134, 23);
            this.label6.TabIndex = 8;
            this.label6.Text = "Employee Name";
            // 
            // EmployeeName
            // 
            this.EmployeeName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.EmployeeName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.EmployeeName.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmployeeName.FormattingEnabled = true;
            this.EmployeeName.Location = new System.Drawing.Point(12, 46);
            this.EmployeeName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.EmployeeName.Name = "EmployeeName";
            this.EmployeeName.Size = new System.Drawing.Size(455, 30);
            this.EmployeeName.TabIndex = 7;
            this.EmployeeName.SelectedIndexChanged += new System.EventHandler(this.EmployeeName_SelectedIndexChanged);
            // 
            // FormEmployeeLeave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1055, 601);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.StatusStrip1);
            this.Controls.Add(this.label46);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormEmployeeLeave";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormEmployeeLeave";
            this.Load += new System.EventHandler(this.FormEmployeeLeave_Load);
            this.StatusStrip1.ResumeLayout(false);
            this.StatusStrip1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label46;
        internal System.Windows.Forms.StatusStrip StatusStrip1;
        internal System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel1;
        internal System.Windows.Forms.ToolStripStatusLabel lblUser;
        internal System.Windows.Forms.ToolStripStatusLabel lblUserId;
        internal System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel3;
        private System.Windows.Forms.GroupBox groupBox4;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.DateTimePicker LeaveDate;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.ComboBox EmployeeName;
        private System.Windows.Forms.Button buttonDayEnd;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox textBoxLeaveEffectCount;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox textBoxLeaveReason;
    }
}