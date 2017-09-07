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
        
        MySqlConnection connVar = new MySqlConnection("server=localhost;port=3306;username=root;password=;database=multiple;");

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Please Provide your password and password!");
            }
            else
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("Select id,uname,role from account where uname = '" + txtUsername.Text + "' and pwd=sha2('" + txtPassword.Text + "',224)", connVar);
                    Console.WriteLine(cmd.CommandText);
                    connVar.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    //connVar.Close();
                    //if count equal is to 1, than show frmMain form
                    if (reader.HasRows==true)
                    {
                        int role;
                        reader.Read();
                        role = reader.GetInt32(2);
                       
                        MessageBox.Show("Login Successfull!", "Sukses");
                        this.Hide();
                        frmMain fm = new frmMain();
                        fm.role = role;
                        fm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Login Failed!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
       }   
    }
 }
