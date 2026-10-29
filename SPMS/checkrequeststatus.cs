using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPMS_final_project_CSE_Amesha
{
    public partial class checkrequeststatus : Form
    {
        public checkrequeststatus()
        {
            InitializeComponent();
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            userhomepage uhp = new userhomepage();
            uhp.Show();
            this.Hide();
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            this.txtrid.Text = "";
            this.txtstatus.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //connection
            SqlConnection con = new SqlConnection("Data Source = DESKTOP-B3P4VUV; Initial Catalog = SPMSdb; Integrated Security = True;");
            con.Open();

            //command
            string sql = "SELECT * FROM tblrequest WHERE RequestID = @rid";
            SqlCommand com = new SqlCommand(sql, con);
            com.Parameters.AddWithValue("@rid",this.txtrid.Text);

            //Access data using Data Reader method.
            SqlDataReader dr = com.ExecuteReader();
            string rstat;
            rstat = Convert.ToString(this.txtstatus.Text);
            if (dr.Read() == true)
            {
                //Bind Data with controls.
                this.txtstatus.Text = dr.GetValue(6).ToString();
            }
            else
            {
                    MessageBox.Show("No request found..");
            }
            
        }
    }
}
