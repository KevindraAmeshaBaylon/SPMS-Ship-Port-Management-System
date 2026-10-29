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
    public partial class adminlogin : Form
    {
        public adminlogin()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnback_Click(object sender, EventArgs e)
        {
            homepage hp = new homepage();
            hp.Show();
            this.Hide();
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            this.txtaid.Text = "";
            this.txtusername.Text = "";
            this.txtpwd.Text = "";
        }

        private void llnaac_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source = DESKTOP-B3P4VUV; Initial Catalog = SPMSdb; Integrated Security = True;");
            con.Open();

            //sql command
            string sql = "SELECT * FROM tbladmin WHERE AdminID = @aid AND Username =@uname AND Password = @pwd ";
            SqlCommand com = new SqlCommand(sql, con);
            com.Parameters.AddWithValue("@aid", this.txtaid.Text);
            com.Parameters.AddWithValue("@uname", this.txtusername.Text);
            com.Parameters.AddWithValue("@pwd",this.txtpwd.Text);

            //Access Data using Data reader
            SqlDataReader dr  = com.ExecuteReader();
            if (dr.Read() == true)
            {
                adminhomepage ahp = new adminhomepage();
                ahp.Show();
                this.Hide();
            }
            else
            {
                this.lblmessage.Text = "*Invalid Login Credentials";
            }

            //disconnect server
            con.Close();
        }
    }
}
