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
    public partial class homepage : Form
    {
        public homepage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            adminlogin al = new adminlogin();
            al.Show();
            this.Hide();
        }

        private void btnuser_Click(object sender, EventArgs e)
        {
            userlogin ul  = new userlogin();
            ul.Show();
            this.Hide();
        }
    }
}
