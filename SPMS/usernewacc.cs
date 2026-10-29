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
    public partial class usernewacc : Form
    {
        public usernewacc()
        {
            InitializeComponent();
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            this.txtuid.Text = "";
            this.txtusername.Text = "";
            this.txtpwd.Text = "";
            this.txtrepwd.Text = "";
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            userlogin ul = new userlogin();
            ul.Show();
            this.Hide();
        }

        private void btncreate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source = DESKTOP-B3P4VUV; Initial Catalog = SPMSdb; Integrated Security = True;");
            con.Open();

            //Sql command
            string sql = "INSERT INTO tbluser(UserID,Username,Password) VALUES (@uid,@uname,@pwd)";
            SqlCommand com = new SqlCommand(sql, con);
            com.Parameters.AddWithValue("@uid", this.txtuid.Text);
            com.Parameters.AddWithValue("@uname", this.txtusername.Text);
            com.Parameters.AddWithValue("@pwd", this.txtpwd.Text);

            //execute command
            if (this.txtpwd.Text == this.txtrepwd.Text)
            {
                com.ExecuteNonQuery();
                MessageBox.Show("User Account Created Successfully");
            }
            else
            {
                this.lblmessage.Text = "*Passwords does not match";
            }
            

            //Disconnect server
            con.Close();
        }
    }
}
