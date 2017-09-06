using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace multiple_login
{
    class Module
    {
        public string dbHost = "localhost";
        public string dbUser = "root";
        public string dbPass = "";
        public string dbName = "multiple";
        public MySqlDataReader db = null;
        public static string rolee = "-";
        public MySqlConnection CreateConnection() {
            return new MySqlConnection(string.Format("server={0};User Id={1}; Password = {2}; Persist Security Info = True; database = {3}; Allow User Variables = true", dbHost, dbUser, dbPass, dbName));
        }

        public Boolean TestConnection() {
            Boolean result = false;
            using (MySqlConnection conn = CreateConnection())
            {
                try
                {
                    conn.Open();
                    result = true;
                }
                catch
                {
                    result = false;
                }
                conn.Dispose();
                return result;
            }
        }

        public Boolean SendSql(string strQuery, params MySqlParameter[] parameters)
        {
            Boolean result = false;

            using (MySqlConnection conn = CreateConnection()) {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(strQuery, conn);
                cmd.Parameters.AddRange(parameters);
                try
                {
                    cmd.ExecuteNonQuery();
                    result = true;
                }
                catch(MySqlException ex) {
                    MessageBox.Show(string.Format("Gagal! :{0}Error Code : {1}{2}{3}", System.Environment.NewLine, ex.Number, ex.Message));
                    result = true;
                }
                conn.Dispose();
                return result;
            }
        }

        public MySqlParameter P(string parameterName, object parameterValue) {
            return new MySqlParameter(parameterName, parameterValue);
        }

        public DataTable BukaTable(string isisql) {
            using (MySqlConnection conn = CreateConnection()) {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(isisql, conn);
                    db = cmd.ExecuteReader();
                }
                catch (MySqlException e)
                {
                    MessageBox.Show(e.Message);
                }
                DataTable dt = new DataTable();
                dt.Load(db);
                db.Close();
                conn.Close();
                return dt;
            }
        }

        public bool AksiQuery(string isisql)
        {
            using (MySqlConnection conn = CreateConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(isisql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
        }
    }
}
