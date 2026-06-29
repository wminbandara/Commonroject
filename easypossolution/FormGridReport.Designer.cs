namespace easyPOSSolution
{
    partial class FormGridReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGridReport));
            this.StatusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ToolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblUserId = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblBranchID = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.button13 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.gridControl5 = new DevExpress.XtraGrid.GridControl();
            this.gridView5 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.StatusStrip1.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).BeginInit();
            this.SuspendLayout();
            // 
            // StatusStrip1
            // 
            this.StatusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripStatusLabel1,
            this.lblUser,
            this.lblUserId,
            this.ToolStripStatusLabel3,
            this.lblBranchID});
            this.StatusStrip1.Location = new System.Drawing.Point(0, 635);
            this.StatusStrip1.Name = "StatusStrip1";
            this.StatusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.StatusStrip1.Size = new System.Drawing.Size(1034, 22);
            this.StatusStrip1.TabIndex = 190;
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
            this.ToolStripStatusLabel3.Size = new System.Drawing.Size(718, 17);
            this.ToolStripStatusLabel3.Spring = true;
            // 
            // lblBranchID
            // 
            this.lblBranchID.Name = "lblBranchID";
            this.lblBranchID.Size = new System.Drawing.Size(68, 17);
            this.lblBranchID.Text = "lblBranchID";
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.button13);
            this.groupBox10.Controls.Add(this.button15);
            this.groupBox10.Location = new System.Drawing.Point(7, 3);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(1022, 53);
            this.groupBox10.TabIndex = 191;
            this.groupBox10.TabStop = false;
            // 
            // button13
            // 
            this.button13.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button13.Location = new System.Drawing.Point(883, 13);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(112, 29);
            this.button13.TabIndex = 114;
            this.button13.Text = "&Export Excell";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // button15
            // 
            this.button15.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button15.Location = new System.Drawing.Point(762, 14);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(112, 29);
            this.button15.TabIndex = 113;
            this.button15.Text = "&Exit";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.button15_Click);
            // 
            // groupBox9
            // 
            this.groupBox9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox9.Controls.Add(this.gridControl5);
            this.groupBox9.Location = new System.Drawing.Point(7, 58);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(1022, 570);
            this.groupBox9.TabIndex = 192;
            this.groupBox9.TabStop = false;
            // 
            // gridControl5
            // 
            this.gridControl5.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl5.Location = new System.Drawing.Point(3, 16);
            this.gridControl5.MainView = this.gridView5;
            this.gridControl5.Name = "gridControl5";
            this.gridControl5.Size = new System.Drawing.Size(1016, 551);
            this.gridControl5.TabIndex = 5;
            this.gridControl5.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView5});
            // 
            // gridView5
            // 
            this.gridView5.GridControl = this.gridControl5;
            this.gridView5.Name = "gridView5";
            this.gridView5.OptionsFind.AlwaysVisible = true;
            this.gridView5.OptionsView.ShowFooter = true;
            // 
            // FormGridReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 657);
            this.Controls.Add(this.groupBox9);
            this.Controls.Add(this.groupBox10);
            this.Controls.Add(this.StatusStrip1);
            this.Name = "FormGridReport";
            this.Text = "FormGridReport";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.StatusStrip1.ResumeLayout(false);
            this.StatusStrip1.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.StatusStrip StatusStrip1;
        internal System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel1;
        internal System.Windows.Forms.ToolStripStatusLabel lblUser;
        internal System.Windows.Forms.ToolStripStatusLabel lblUserId;
        internal System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel3;
        public System.Windows.Forms.ToolStripStatusLabel lblBranchID;
        private System.Windows.Forms.GroupBox groupBox10;
        internal System.Windows.Forms.Button button13;
        internal System.Windows.Forms.Button button15;
        private System.Windows.Forms.GroupBox groupBox9;
        public DevExpress.XtraGrid.GridControl gridControl5;
        public DevExpress.XtraGrid.Views.Grid.GridView gridView5;
    }
}