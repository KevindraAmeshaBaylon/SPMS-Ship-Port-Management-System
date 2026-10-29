using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPMS_final_project_CSE_Amesha
{
    public partial class portrequest : Form
    {
        public portrequest()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source = DESKTOP-B3P4VUV; Initial Catalog = SPMSdb; Integrated Security = True;");
            con.Open();

            //command
            string sql1 = "INSERT INTO tblship(ShipNo,ShipName) VALUES (@sno,@sname)";
            SqlCommand cmd = new SqlCommand(sql1, con);
            cmd.Parameters.AddWithValue("@sno", this.txtshipno.Text);
            cmd.Parameters.AddWithValue("@sname", this.txtshipname.Text);

            string sql = "INSERT INTO tblrequest(RequestID,FromCountry,ToCountry,ShipNo,Arrival,Departure) VALUES (@rid,@from,@to,@sno,@arrival,@dep)";
            SqlCommand com = new SqlCommand(sql, con);
            
            com.Parameters.AddWithValue("@rid", this.txtrid.Text);
            com.Parameters.AddWithValue("@from", this.txtfrom.Text);
            com.Parameters.AddWithValue("@to", this.txtto.Text);
            com.Parameters.AddWithValue("@sno", this.txtshipno.Text);
            com.Parameters.AddWithValue("@arrival", this.dtparrival.Text);
            com.Parameters.AddWithValue("@dep", this.dtpdeparture.Text);

            //execute command to insert data
            cmd.ExecuteNonQuery();
            com.ExecuteNonQuery();

            MessageBox.Show("Request Sent.");

            //disconnect server
            con.Close();
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            userhomepage uhp = new userhomepage();
            uhp.Show();
            this.Hide();
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            this.txtfrom.Text = "";
            this.txtto.Text = "";
            this.txtshipno.Text = "";
            this.txtshipname.Text = "";
        }

        private void portrequest_Load(object sender, EventArgs e)
        {
            //connection
            SqlConnection con = new SqlConnection("Data Source = DESKTOP-B3P4VUV; Initial Catalog = SPMSdb; Integrated Security = True;");
            con.Open();

            //command
            string sql = "SELECT max(RequestID) FROM tblrequest";
            SqlCommand com = new SqlCommand(sql, con);

            //Access data using data reader method
            int rid;
            SqlDataReader dr = com.ExecuteReader();
            if (dr.Read() == true)
            {
                rid =Convert.ToInt32(dr.GetValue(0)) + 1;
            }
            else
            {
                rid = 1;
            }
            this.txtrid.Text = rid.ToString();

            //disconnect server
            con.Close();
        }
    }
}
