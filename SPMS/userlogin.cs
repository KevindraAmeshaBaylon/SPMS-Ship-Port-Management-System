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
    public partial class userlogin : Form
    {
        public userlogin()
        {
            InitializeComponent();
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            homepage hp = new homepage();   
            hp.Show();
            this.Hide();
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            this.txtuid.Text = "";
            this.txtusername.Text = "";
            this.txtpwd.Text = "";
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            //connection
            SqlConnection con = new SqlConnection("Data Source = DESKTOP-B3P4VUV; Initial Catalog = SPMSdb; Integrated Security = True;");
            con.Open();

            //sql command
            string sql = "SELECT * FROM tbluser WHERE UserID = @uid AND Username =@uname AND Password = @pwd  ";
            SqlCommand com = new SqlCommand(sql, con);
            com.Parameters.AddWithValue("@uid",this.txtuid.Text);
            com.Parameters.AddWithValue("@uname",this.txtusername.Text);
            com.Parameters.AddWithValue("@pwd",this.txtpwd.Text);

            //Access Data using Data Reader method.
            SqlDataReader dr = com.ExecuteReader();
            if (dr.Read() == true)
            {
                userhomepage uhp = new userhomepage();
                uhp.Show();
                this.Hide();
            }
            else
            {
                this.lblmessage.Text = "*Invalid Login Credentials";
            }

            //Disconnect Server
            con.Close();
        }

        private void llnuac_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            usernewacc una = new usernewacc();
            una.Show();
            this.Hide();
        }
    }
}
