using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeIsUp
{
    public partial class frmAbout : System.Windows.Forms.Form
    {
        public frmAbout()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAbout_Load(object sender, EventArgs e)
        {
            lblProductName.Text = String.Format("Product name: {0}", Application.ProductName);
            lblProductVersion.Text = String.Format("Product version: {0}", Application.ProductVersion);
            lblCopyright.Text = "Copyright ©  2017 by StibeNet";
        }
    }
}
