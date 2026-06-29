namespace easyPOSSolution
{
    partial class FormSearchSalesOrder
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSearchSalesOrder));
            this.allCustomerInvoiceTableAdapter = new easyPOSSolution.easyposelpitiyaDataSetTableAdapters.AllCustomerInvoiceTableAdapter();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.txtReprint = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonExit = new System.Windows.Forms.Button();
            this.ButtonNew = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.easyposelpitiyaDataSet = new easyPOSSolution.easyposelpitiyaDataSet();
            this.allCustomerInvoiceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ToolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblUserId = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.checkBoxA4Print = new System.Windows.Forms.CheckBox();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.easyposelpitiyaDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.allCustomerInvoiceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.StatusStrip1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // allCustomerInvoiceTableAdapter
            // 
            this.allCustomerInvoiceTableAdapter.ClearBeforeFill = true;
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(4, 19);
            this.crystalReportViewer1.Margin = new System.Windows.Forms.Padding(4);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(800, 503);
            this.crystalReportViewer1.TabIndex = 0;
            this.crystalReportViewer1.ToolPanelWidth = 267;
            // 
            // txtReprint
            // 
            this.txtReprint.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReprint.Location = new System.Drawing.Point(647, 21);
            this.txtReprint.Margin = new System.Windows.Forms.Padding(4);
            this.txtReprint.Name = "txtReprint";
            this.txtReprint.Size = new System.Drawing.Size(143, 26);
            this.txtReprint.TabIndex = 687;
            this.txtReprint.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.label12);
            this.panel2.Location = new System.Drawing.Point(7, 9);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(537, 48);
            this.panel2.TabIndex = 211;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.SteelBlue;
            this.label12.Location = new System.Drawing.Point(29, 4);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(471, 35);
            this.label12.TabIndex = 50;
            this.label12.Text = "S E A R C H    S A L E S   O R D E R S";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonExit);
            this.groupBox2.Controls.Add(this.ButtonNew);
            this.groupBox2.Location = new System.Drawing.Point(973, 0);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(385, 62);
            this.groupBox2.TabIndex = 212;
            this.groupBox2.TabStop = false;
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(160)))));
            this.buttonExit.Font = new System.Drawing.Font("Cambria", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExit.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonExit.Location = new System.Drawing.Point(193, 15);
            this.buttonExit.Margin = new System.Windows.Forms.Padding(4);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(168, 39);
            this.buttonExit.TabIndex = 26;
            this.buttonExit.Text = "&Exit";
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // ButtonNew
            // 
            this.ButtonNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(160)))));
            this.ButtonNew.Font = new System.Drawing.Font("Cambria", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonNew.ForeColor = System.Drawing.SystemColors.Window;
            this.ButtonNew.Location = new System.Drawing.Point(16, 14);
            this.ButtonNew.Margin = new System.Windows.Forms.Padding(4);
            this.ButtonNew.Name = "ButtonNew";
            this.ButtonNew.Size = new System.Drawing.Size(168, 39);
            this.ButtonNew.TabIndex = 22;
            this.ButtonNew.Text = "&Refresh";
            this.ButtonNew.UseVisualStyleBackColor = false;
            this.ButtonNew.Click += new System.EventHandler(this.ButtonNew_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // easyposelpitiyaDataSet
            // 
            this.easyposelpitiyaDataSet.DataSetName = "easyposelpitiyaDataSet";
            this.easyposelpitiyaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // allCustomerInvoiceBindingSource
            // 
            this.allCustomerInvoiceBindingSource.DataMember = "AllCustomerInvoice";
            this.allCustomerInvoiceBindingSource.DataSource = this.easyposelpitiyaDataSet;
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView1_RowClick);
            // 
            // gridControl1
            // 
            this.gridControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            gridLevelNode1.RelationName = "Level1";
            this.gridControl1.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridControl1.Location = new System.Drawing.Point(4, 22);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(532, 503);
            this.gridControl1.TabIndex = 2;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.gridControl1);
            this.groupBox1.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(4, 65);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(540, 529);
            this.groupBox1.TabIndex = 210;
            this.groupBox1.TabStop = false;
            // 
            // ToolStripStatusLabel3
            // 
            this.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3";
            this.ToolStripStatusLabel3.Size = new System.Drawing.Size(1057, 21);
            this.ToolStripStatusLabel3.Spring = true;
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
            this.StatusStrip1.Location = new System.Drawing.Point(0, 599);
            this.StatusStrip1.Name = "StatusStrip1";
            this.StatusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 21, 0);
            this.StatusStrip1.Size = new System.Drawing.Size(1373, 26);
            this.StatusStrip1.TabIndex = 213;
            this.StatusStrip1.Text = "StatusStrip1";
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
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.crystalReportViewer1);
            this.groupBox4.Location = new System.Drawing.Point(552, 65);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(808, 526);
            this.groupBox4.TabIndex = 209;
            this.groupBox4.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(551, 25);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 21);
            this.label9.TabIndex = 688;
            this.label9.Text = "Order Id.";
            // 
            // checkBoxA4Print
            // 
            this.checkBoxA4Print.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxA4Print.Font = new System.Drawing.Font("Century", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxA4Print.ForeColor = System.Drawing.Color.Brown;
            this.checkBoxA4Print.Location = new System.Drawing.Point(802, 11);
            this.checkBoxA4Print.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxA4Print.Name = "checkBoxA4Print";
            this.checkBoxA4Print.Size = new System.Drawing.Size(134, 43);
            this.checkBoxA4Print.TabIndex = 744;
            this.checkBoxA4Print.Text = "A4 Print";
            this.checkBoxA4Print.UseVisualStyleBackColor = false;
            // 
            // FormSearchSalesOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1373, 625);
            this.Controls.Add(this.checkBoxA4Print);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtReprint);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.StatusStrip1);
            this.Controls.Add(this.groupBox4);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormSearchSalesOrder";
            this.Text = "FormSearchSalesOrder";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.easyposelpitiyaDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.allCustomerInvoiceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.StatusStrip1.ResumeLayout(false);
            this.StatusStrip1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private easyposelpitiyaDataSetTableAdapters.AllCustomerInvoiceTableAdapter allCustomerInvoiceTableAdapter;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.TextBox txtReprint;
        private System.Windows.Forms.Panel panel2;
        internal System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button ButtonNew;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        internal System.Windows.Forms.StatusStrip StatusStrip1;
        internal System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel1;
        internal System.Windows.Forms.ToolStripStatusLabel lblUser;
        internal System.Windows.Forms.ToolStripStatusLabel lblUserId;
        internal System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel3;
        private System.Windows.Forms.GroupBox groupBox4;
        private easyposelpitiyaDataSet easyposelpitiyaDataSet;
        private System.Windows.Forms.BindingSource allCustomerInvoiceBindingSource;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox checkBoxA4Print;
    }
}