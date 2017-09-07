using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace multiple_login
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        //MySQl Connection variable, use for connecting server
        //using server for the best choice

        string sql = "server=localhost;port=3306;username=root;password=;database=multiple;";

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "" || txtPassword.Text == "") {
                MessageBox.Show("Please Provide your password and password!");
                return;
            }
            try {
                MySqlConnection connVar = new MySqlConnection(sql);
                MySqlCommand cmd = new MySqlCommand("Select * from account where uname = '" + txtUsername.Text + "' and pwd = '" + txtPassword.Text + "'", connVar);
                cmd.Parameters.AddWithValue("@uname", txtUsername.Text);
                cmd.Parameters.AddWithValue("@pwd",txtPassword.Text);
                connVar.Open();
                MySqlDataAdapter adapt = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapt.Fill(ds);
                connVar.Close();
                int count = ds.Tables[0].Rows.Count;
                //if count equal is to 1, than show frmMain form
                if (count == 1)
                {
                    MessageBox.Show("Login Successfull!");
                    this.Hide();
                    frmMain fm = new frmMain();
                    fm.Show();
                }
                else {
                    MessageBox.Show("Login Failed!");
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
       }   
    }
 }
