using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace multiple_login
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        public int role=0;

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login lg = new Login();
            lg.Show();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (role == 0)
            {
                MessageBox.Show("Login Gagal, Silahkan login kembali!");
                this.Hide();
                Login lg = new Login();
                lg.Show();
            }
            else if (role == 1)
            {
                lbl.Text = "Welcome Admin";
            }
            else if (role == 2)
            {
                lbl.Text = "Welcome User";
            }
            else {
                MessageBox.Show("Login Gagal, Silahkan login kembali!");
                this.Hide();
                Login lg = new Login();
                lg.Show();
            }
        }
    }
}
