using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeIsUp
{
    public partial class frmPassword : Form
    {
        public frmPassword()
        {
            InitializeComponent();
        }

        private static string ConnectionString
        {
            get { return ConfigurationSettings.AppSettings["ConnectionString"]; }
        }

        #region Кнопка "Получить пароль"
        private void btnGetPassword_Click(object sender, EventArgs e)
        {
            using (ResultSearchPassword frmrsp = new ResultSearchPassword())
            {
                frmrsp.ShowDialog();

                String connString;
                connString = ConfigurationSettings.AppSettings["ConnectionString"];

                SqlConnection cnn = MiscFunction.OpenConnection(connString);

                using (SqlDataAdapter a = new SqlDataAdapter("SELECT name, login, password FROM Password", cnn))
                {
                    SqlCommandBuilder cb = new SqlCommandBuilder(a);
                    DataSet ds = new DataSet();
                    a.Fill(ds, "Notes");
                    

                    //dataGridView1.DataSource = ds.Tables[0];
                    //DataGridViewRow dr = dataGridView1.SelectedRows[0];
                    //dr.Cells[1].Value = ds;
                    //dr.Cells[2].Value = ds;
                    //dr.Cells[3].Value = ds;
                    //dr.Cells[4].Value = ds;
                }
            }
        }
        #endregion

        #region Кнопка "Сохранить пароль"
        private void btnSave_Click(object sender, EventArgs e)
        {
            String connString;
            connString = ConfigurationSettings.AppSettings["ConnectionString"];
            SqlConnection cnn = MiscFunction.OpenConnection(connString);

            String strSQL;

            strSQL = "INSERT INTO Password (name, login, password, date) " +
                "VALUES (@name, @login, @password, @date)";

            if (tBName.Text == String.Empty || tBLogin.Text == String.Empty || tBPassword.Text == String.Empty)
            {
                lbInform.Text = "Enter your data";
            }
            else
            {
                SqlCommand cmd = new SqlCommand(strSQL, cnn) { CommandTimeout = 60 };
                cmd.Parameters.Add(new SqlParameter("@name", SqlDbType.NVarChar, 128)).Value = Convert.ToString(tBName.Text);
                cmd.Parameters.Add(new SqlParameter("@login", SqlDbType.NVarChar, 50)).Value = Convert.ToString(tBLogin.Text);
                cmd.Parameters.Add(new SqlParameter("@password", SqlDbType.NVarChar, 50)).Value = Convert.ToString(tBPassword.Text);
                cmd.Parameters.Add(new SqlParameter("@date", DateTime.Now.Date));
                cmd.ExecuteNonQuery();

                tBName.Clear();
                tBLogin.Clear();
                tBPassword.Clear();

                lbInform.Text = "Save";
            }
        }
        #endregion
    }
}
