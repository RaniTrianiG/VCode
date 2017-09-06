using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using MySql.Data.MySqlClient;

namespace multiple_login
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        // MySQL Connection variable, use for connecting to server
        // using server for best choice
        MySqlConnection connVar = new MySqlConnection("server=localhost;port=3306;username=root;password=;database=multiple;");
        
        // MySQL Command for executing SQL Query using this variable MySqlCommand

        // MySQL Reader for getting data from MySQL Command using this variable MySqlDataReader

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
