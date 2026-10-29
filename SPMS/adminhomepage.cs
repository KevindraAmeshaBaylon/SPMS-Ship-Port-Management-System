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
    public partial class adminhomepage : Form
    {
        public adminhomepage()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void adminhomepage_Load(object sender, EventArgs e)
        {

        }

        private void btnback_Click(object sender, EventArgs e)
        {
            
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            homepage hp = new homepage();
            hp.Show();
            this.Hide();
        }

        private void btnsup_Click(object sender, EventArgs e)
        {
            updateshipstatus uss = new updateshipstatus();
            uss.Show();
            this.Hide();
        }

        private void btnrup_Click(object sender, EventArgs e)
        {
            updaterequests ur = new updaterequests();
            ur.Show();
            this.Hide();
        }
    }
}
