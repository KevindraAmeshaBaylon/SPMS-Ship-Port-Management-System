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
    public partial class updateshipstatus : Form
    {
        public updateshipstatus()
        {
            InitializeComponent();
        }

        private void updateshipstatus_Load(object sender, EventArgs e)
        {
            filldgv();
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            adminhomepage ahp = new adminhomepage();
            ahp.Show();
            this.Hide();
        }

        public void filldgv()
        {
            //connection
            SqlConnection con = new SqlConnection("Data Source = DESKTOP-B3P4VUV; Initial Catalog = SPMSdb; Integrated Security = True;");
            con.Open();

            //command
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM tblship", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            //disconnect server
            con.Close();
        }
        private void btnupdate_Click(object sender, EventArgs e)
        {
            //connection
            SqlConnection con = new SqlConnection("Data Source = DESKTOP-B3P4VUV; Initial Catalog = SPMSdb; Integrated Security = True;");

            //command
            SqlCommand update = new SqlCommand("UPDATE tblship SET  Status ='" + cmbshipstat.Text + "' WHERE ShipNo = '" + txtshipno.Text + "' ", con);
            con.Open();
            update.CommandType = CommandType.Text;
            update.ExecuteNonQuery();
            MessageBox.Show("Data updated succesfully!");

            filldgv();

            //disconnect server
            con.Close();
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            this.txtshipno.Text = "";
            this.cmbshipstat.Text = "";
        }
    }
}
