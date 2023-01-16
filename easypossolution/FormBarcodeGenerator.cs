using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace easyPOSSolution
{
    public partial class FormBarcodeGenerator : Form
    {
        #region Local Variables

        public FormStock frm { set; get; }
        int totalnumber = 0;
        int itemperpage = 0;
        int k = 0;

        #endregion

        #region Constructor

        public FormBarcodeGenerator()
        {
            InitializeComponent();
        }

        #endregion      

        #region Methods

        void DrawForm(Graphics g, int resX, int resY)
        {
            k = 0;
            for (int i = 50; i < 800; i = i + 150)
            {
                for (int j = 100; j < 1000; j = j + 100)
                {
                    k++;
                    g.DrawRectangle(new Pen(Color.Red), i, j, 150, 100);

                    g.DrawString(textBox_CompanyName.Text, textBox_CompanyName.Font, new SolidBrush(tbSet.ForeColor), i + 20, j + 5, new StringFormat());

                    g.DrawString(laCode.Text, laCode.Font, new SolidBrush(laCode.ForeColor), i + 10, j + 26, new StringFormat());

                    g.DrawString("Rs. " + tbPrice.Text, tbPrice.Font, new SolidBrush(tbSet.ForeColor), i + 30, j + 75, new StringFormat());

                    if (k == Convert.ToInt32(textBoxNumber.Text))
                    {
                        break;
                    }
                }

                if (k == Convert.ToInt32(textBoxNumber.Text))
                {
                    break;
                }

            }
        }

        #endregion


        #region Events

        private void button1_Click(object sender, EventArgs e)
        {
            if ((Convert.ToInt32(textBoxNumber.Text) != 0))
            {
                if (checkBox1.Checked == false)
                {
                    if (Convert.ToInt32(textBoxNumber.Text) > 0)
                    {
                        if (textBox1.Text.Length >= 1)
                        {
                            button2_Click(sender, e);

                            if (printDialog1.ShowDialog() == DialogResult.OK)
                            {

                                printDocument1.Print();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please Enter Min. 1 Charactor", "easy Soft Barcode Generator", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            textBox1.Select();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Enter Number of pieces grate than 1", "easy Soft Barcode Generator", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                }
                else
                {
                    if (textBox1.Text.Length >= 1)
                    {
                        //button2_Click(sender, e);

                        //if (printDialog1.ShowDialog() == DialogResult.OK)
                        //{

                        //    printDocument1.Print();
                        //}
                        FrmBarcode bcode = new FrmBarcode();
                        bcode.textBox1.Text = textBox1.Text;
                        bcode.textBoxNumber.Text = textBoxNumber.Text;
                        bcode.textBox_CompanyName.Text = textBox_CompanyName.Text;
                        bcode.tbPrice.Text = tbPrice.Text;
                        bcode.Show();
                    }
                    else
                    {
                        MessageBox.Show("Please Enter Min. 1 Charactor", "easy Soft Barcode Generator", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBox1.Select();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please check the number of pieces", "easy Soft Barcode Generator", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            laCode.Text = "*" + textBox1.Text + "*";
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            PrinterResolution pr = e.PageSettings.PrinterResolution;
            if (checkBox1.Checked == true)
            {
                DrawForm(e.Graphics, pr.X, pr.Y);
            }
            if (checkBox1.Checked == false)
            {



                float currentY = 0;
                while (totalnumber < Convert.ToInt32(textBoxNumber.Text))
                {

                    e.Graphics.DrawString(textBox_CompanyName.Text, textBox_CompanyName.Font, new SolidBrush(tbSet.ForeColor), 20, currentY + 5, new StringFormat());
                    e.Graphics.DrawString(laCode.Text, laCode.Font, new SolidBrush(laCode.ForeColor), 10, currentY + 25, new StringFormat());
                    if (tbPrice.Text != "")
                    {
                        e.Graphics.DrawString("Rs. " + Convert.ToDouble(tbPrice.Text).ToString("0.00"), tbPrice.Font, new SolidBrush(tbSet.ForeColor), 30, currentY + 75, new StringFormat());
                    }

                    currentY += 110;
                    totalnumber += 1;
                    if (itemperpage < 10)
                    {
                        itemperpage += 1;
                        e.HasMorePages = false;
                    }
                    else
                    {
                        itemperpage = 0;
                        e.HasMorePages = true;
                        return;
                    }
                }
                totalnumber = 0;
                itemperpage = 0;
            }
        }

        #endregion

        private void button3_Click(object sender, EventArgs e)
        {
            FrmBarcode bcode = new FrmBarcode();
            bcode.textBox1.Text = textBox1.Text;
            bcode.textBoxNumber.Text = textBoxNumber.Text;
            bcode.textBox_CompanyName.Text = textBox_CompanyName.Text;
            bcode.tbPrice.Text = tbPrice.Text;
            bcode.Show();
        }




        #region Validation Methods



        #endregion


    }
}
