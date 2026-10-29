using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPMS_final_project_CSE_Amesha
{
    public partial class userhomepage : Form
    {
        public userhomepage()
        {
            InitializeComponent();
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            homepage hp = new homepage();
            hp.Show();
            this.Hide();
        }

        private void btncheckss_Click(object sender, EventArgs e)
        {
            checkshipstatus css = new checkshipstatus();
            css.Show();
            this.Hide();
        }

        private void btnrequest_Click(object sender, EventArgs e)
        {
            portrequest pr = new portrequest();
            pr.Show();
            this.Hide();
        }

        private void btncheckrs_Click(object sender, EventArgs e)
        {
            checkrequeststatus crs = new checkrequeststatus();
            crs.Show();
            this.Hide();
        }
    }
}
