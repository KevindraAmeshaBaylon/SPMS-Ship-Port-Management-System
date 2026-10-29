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
    public partial class updaterequests : Form
    {
        public updaterequests()
        {
            InitializeComponent();
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            adminhomepage ahp = new adminhomepage();
            ahp.Show();
            this.Hide();
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {

        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            //connection
            SqlConnection con = new SqlConnection("Data Source = DESKTOP-B3P4VUV; Initial Catalog = SPMSdb; Integrated Security = True;");
            con.Open();

            //command
            string sql = "INSERT INTO tblrequest(RequestStatus) VALUES (@rs)";
            SqlCommand com = new SqlCommand(sql, con);

        }

        private void cmbreqstat_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void updaterequests_Load(object sender, EventArgs e)
        {

        }

        public void filldgv()
        {
            //connection
            SqlConnection con = new SqlConnection("Data Source = DESKTOP-B3P4VUV; Initial Catalog = SPMSdb; Integrated Security = True;");
            con.Open();

            //command
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM tblrequest",con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            //disconnect server
            con.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            //connection
            SqlConnection con = new SqlConnection("Data Source = DESKTOP-B3P4VUV; Initial Catalog = SPMSdb; Integrated Security = True;");
            
            //command
            SqlCommand update = new SqlCommand("UPDATE tblrequest SET  RequestStatus ='" + cmbreqstat.Text + "' WHERE RequestID = '" + txtreqid.Text + "' ", con);
            con.Open();
            update.CommandType = CommandType.Text;
            update.ExecuteNonQuery();
            MessageBox.Show("Data updated succesfully!");

            filldgv();

            //disconnect server
            con.Close();

        }

        private void updaterequests_Load_1(object sender, EventArgs e)
        {
            filldgv();
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            this.txtreqid.Text = "";
            this.cmbreqstat.Text = "";
        }
    }
}
