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
    public partial class Form1 : System.Windows.Forms.Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using(frmAbout frma = new frmAbout())
            {
                frma.ShowDialog();
            }
        }

        private void btnPassword_Click(object sender, EventArgs e)
        {
            using(frmPassword frmPass = new frmPassword())
            {
                frmPass.ShowDialog();
            }
        }

        private static string ConnectionString
        {
            get { return ConfigurationSettings.AppSettings["ConnectionString"]; }
        }

        private void btnNotes_Click(object sender, EventArgs e)
        {
            String connString;
            connString = ConfigurationSettings.AppSettings["ConnectionString"];

            SqlConnection cnn = MiscFunction.OpenConnection(connString);

            //Вывод в таблицу информации
            using (SqlDataAdapter a = new SqlDataAdapter("SELECT id, name, text, date, complete FROM Notes", cnn))
            {
                SqlCommandBuilder cb = new SqlCommandBuilder(a);
                DataSet ds = new DataSet();
                a.Fill(ds, "Notes");
                dataGridView1.DataSource = ds.Tables[0];
            }
        }
    }
}
