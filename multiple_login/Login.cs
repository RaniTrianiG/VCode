﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace multiple_login
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        int login;
        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "select uname, pwd from account where uname = '" + txtUsername.Text + "' and pwd = '" + txtPassword.Text + "'";
            DataTable dt = new DataTable();
            Module db = new Module();
            dt = db.BukaTable(sql);
            if(dt.Rows.Count > 0)
            {
                MessageBox.Show("Login Berhasil");
                string roleee = "select role from account where uname = '" + txtUsername.Text + "'"; 
                DataTable dt2 = new DataTable();
                dt2 = db.BukaTable(roleee);
                Module.rolee = dt2.Rows[0][0].ToString();
                Menu r = new Menu();
                r.Show();
                this.Hide();
            }
            
            else
            {
                MessageBox.Show("Login Gagal");
                txtUsername.Text = "";
                txtPassword.Text = "";
            }
        }
    }
}
