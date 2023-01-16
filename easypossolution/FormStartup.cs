using easyBAL;
using easyDAL;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace easyPOSSolution
{
    public partial class FormStartup : Form
    {
        int InvoiceNo = 0;
        bool errormsg = false;

        public FormStartup()
        {
            InitializeComponent();
        }

        private void FormStartup_Load(object sender, EventArgs e)
        {
            progressBar1.Width = this.Width;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            FormLogin frm = new FormLogin();
            progressBar1.Visible = true;

            this.progressBar1.Value = this.progressBar1.Value + 2;
            if (this.progressBar1.Value == 10)
            {
                label3.Text = "Reading easy POS Solution..";
            }
            else if (this.progressBar1.Value == 20)
            {
                label3.Text = "Turning on easy POS Solution.";
            }
            else if (this.progressBar1.Value == 40)
            {
                label3.Text = "Starting easy POS Solution..";
            }
            else if (this.progressBar1.Value == 60)
            {
                label3.Text = "Loading easy POS Solution..";
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    CrystalReportExpenses rpt = new CrystalReportExpenses();
                    ClassPOBAL objBAL = new ClassPOBAL();
                    objBAL.date1 = DateTime.Today;
                    objBAL.date2 = DateTime.Today;
                    ClassPODAL objDAL = new ClassPODAL();
                    objBAL.DtDataSet = objDAL.retreiveExpensesDatabyDate(objBAL);
                    rpt.SetDataSource(objBAL.DtDataSet);
                    crystalReportViewer1.ReportSource = rpt;
                    crystalReportViewer1.Refresh();
                    Cursor.Current = Cursors.Default;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (this.progressBar1.Value == 80)
            {
                //dataGridView1.DataSource = GetDataTableFromCSVFile("C:\\CSV\\Invoice.csv");
                //GenerateInvoice();

                //int firstvalue = Convert.ToInt32(dataGridView1.Rows[0].Cells[0].Value.ToString());
                //if (firstvalue > InvoiceNo)
                //{
                //    errormsg = true;
                //    MessageBox.Show("Please Contact Software Provider", "Error in DB", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}

                label3.Text = "Done Loading easy POS Solution..";
            }
            else if (this.progressBar1.Value == 100)
            {
                if (errormsg == false)
                {
                    frm.Show();
                    timer1.Enabled = false;
                    this.Hide();
                }
                else
                {
                    Application.Exit();
                }
                
            }
        }

        private void GenerateInvoice()
        {
            try
            {
                InvoiceNo = 0;
                ClassInvoiceBAL objInvBAL = new ClassInvoiceBAL();
                ClassInvoiveDAL objInvDAL = new ClassInvoiveDAL();
                InvoiceNo = Convert.ToInt32(objInvDAL.SelectMaxSOHDandBillNO(objInvBAL).Tables[1].Rows[0][0]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private static DataTable GetDataTableFromCSVFile(string csvfilePath)
        {
            Cursor.Current = Cursors.WaitCursor;
            DataTable csvData = new DataTable();
            using (TextFieldParser csvReader = new TextFieldParser(csvfilePath))
            {
                csvReader.SetDelimiters(new string[] { "," });
                csvReader.HasFieldsEnclosedInQuotes = true;

                //Read columns from CSV file, remove this line if columns not exits  
                string[] colFields = csvReader.ReadFields();

                foreach (string column in colFields)
                {
                    DataColumn datecolumn = new DataColumn(column);
                    datecolumn.AllowDBNull = true;
                    csvData.Columns.Add(datecolumn);
                }

                while (!csvReader.EndOfData)
                {
                    string[] fieldData = csvReader.ReadFields();
                    //Making empty value as null
                    for (int i = 0; i < fieldData.Length; i++)
                    {
                        if (fieldData[i] == "")
                        {
                            fieldData[i] = null;
                        }
                    }
                    csvData.Rows.Add(fieldData);
                }
            }
            return csvData;
            Cursor.Current = Cursors.Default;
        }
    }
}
