using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TSystem_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnsubmit_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(@"Server=LAPTOP-U11GPVJB\SQLEXPRESS;Database=TSystem_Project;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("select * from Login  where username=@Username and password =@password", con);

            cmd.Parameters.AddWithValue("@username", txtusername.Text);
            cmd.Parameters.AddWithValue("@password", txtpassword.Text);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (dt.Rows.Count > 0)
            {
                Customer settingsForm = new Customer();
                settingsForm.Show();
            }

            else
            {

                MessageBox.Show("Please enter Correct Username and Password");
            }


        }

        private void btnnewuser_Click(object sender, EventArgs e)
        {

        }
    }
}
