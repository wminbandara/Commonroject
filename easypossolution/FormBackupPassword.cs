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
    public partial class FormBackupPassword : Form
    {
        public FormMain frm { set; get; }

        public FormBackupPassword()
        {
            InitializeComponent();
        }

        private void FormBackupPassword_Load(object sender, EventArgs e)
        {
            textBoxPassword.Select();
        }

        private void textBoxPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBoxPassword.Text == "asd@123")
                {
                    frm.correctpassword = true;                    
                }

                this.Close();
            }
        }
    }
}
