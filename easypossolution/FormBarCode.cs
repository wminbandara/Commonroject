using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Data.Common;
using MySql.Data.MySqlClient;


namespace easyPOSSolution
{
    public partial class FormBarCode : Form
    {
        public FrmBarcode frm { set; get; }
        ///////Mysql Connection//////////////
        //MySqlConnection connection;
        //MySqlConnectionStringBuilder connBuilder;
        //MySqlCommand cmd;

        //public void makeConnection()
        //{
        //    connBuilder = new MySqlConnectionStringBuilder();
        //    connBuilder.Add("Database", "easypossolution");
        //    connBuilder.Add("Data Source", "NEELTEC-PC");
        //    connBuilder.Add("User Id", "root");
        //    connBuilder.Add("Password", "root");
        //    connection = new MySqlConnection(connBuilder.ConnectionString);
        //    cmd = connection.CreateCommand();
        //    connection.Open();
        //}

        //public void closeConnection()
        //{
        //    MySqlDataReader reader = cmd.ExecuteReader();
        //    connection.Close();
        //}

        string PurchesPrice;
        //public void read(string msg)
        //{
        //    makeConnection();
        //    try
        //    {
        //        cmd.CommandText = msg;
        //        cmd.CommandType = CommandType.Text;
        //        MySqlDataReader reader = cmd.ExecuteReader();
        //        while (reader.Read())
        //        {

        //            PurchesPrice = reader.GetValue(0).ToString();
        //        }
        //        reader.Close();
        //    }
        //    catch (MySqlException ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //    closeConnection();
        //}

        ///////////////End Mysql Connection/////////////

        public FormBarCode()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please Enter Your Code", "easy Soft Barcode Generator", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Text = "0";
                textBox1.Select();
            }
            else if (textBox1.Text.Length < 1)
            {
                MessageBox.Show("Please Enter Min. 1 Charactors", "easy Soft Barcode Generator", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Select();
            }
            else
            {
                laCode.Text = "*" + textBox1.Text + "*";
            }
        }
        int totalnumber = 0;
        int itemperpage = 0;
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

        int k = 0;
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
            }
            else
            {
                MessageBox.Show("Please check the number of pieces", "easy Soft Barcode Generator", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            laCode.Text = textBox1.Text;
            textBox_CompanyName.Text = "MILLY";
            checkBox1.Checked = true;
            button1.Select();
        }

        //public void readItemName(string msg)
        //{
        //    makeConnection();
        //    try
        //    {
        //        cmd.CommandText = msg;
        //        cmd.CommandType = CommandType.Text;
        //        MySqlDataReader reader = cmd.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            comboBox1.Items.Add(reader.GetValue(0).ToString());
        //        }
        //        reader.Close();
        //    }
        //    catch (MySqlException ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //    closeConnection();
        //}
        //public void readItemCode(string msg)
        //{
        //    makeConnection();
        //    try
        //    {
        //        cmd.CommandText = msg;
        //        cmd.CommandType = CommandType.Text;
        //        MySqlDataReader reader = cmd.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            textBox1.Text = reader.GetValue(0).ToString();
        //        }
        //        reader.Close();
        //    }
        //    catch (MySqlException ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //    closeConnection();
        //}

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            laCode.Text = textBox1.Text;
            if ((textBox1.Text.Length > 7) || (textBox1.Text.Length < 5))
            {
                //button1.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //readItemCode("SELECT ItemCode FROM itemsummary where ItemName='" + comboBox1.Text + "'");
        }

        private void textBoxNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            digitonly(e);
        }

        public void digitonly(KeyPressEventArgs e)
        {
            try
            {
                if(!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar) || char.IsPunctuation(e.KeyChar)))
                {
                    e.Handled = true;
                    MessageBox.Show("Enter only Digits", "Inavalid Null", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            catch { }
        }

        private void tbPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            digitonly(e);
        }

        bool loadstate = false;
        private void comboBox1_Enter(object sender, EventArgs e)
        {
            //if (loadstate == false)
            //{
            //    Cursor.Current = Cursors.WaitCursor;
            //    readItemName("SELECT distinct ItemName FROM itemsummary");
            //    loadstate = true;
            //    Cursor.Current = Cursors.Default;
            //}

        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void textBoxNumber_Leave(object sender, EventArgs e)
        {
            if (textBoxNumber.Text == "")
            {
                textBoxNumber.Text = "0";
            }
        }
    }
}
