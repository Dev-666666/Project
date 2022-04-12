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
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
        }

        private void lbllname_Click(object sender, EventArgs e)
        {

        }

        private void btnsubmit_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(@"Server=LAPTOP-U11GPVJB\SQLEXPRESS;Database=TSystem_Project;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("insert into tsystem_project values @fname,@lname,@address,@pincode,@state,@mobileno", con);
            cmd.Parameters.AddWithValue("fname", txtfname.Text);
            cmd.Parameters.AddWithValue("lname", txtlname.Text);
            cmd.Parameters.AddWithValue("address", txtaddress.Text);
            cmd.Parameters.AddWithValue("pincode", txtpincode.Text);
            cmd.Parameters.AddWithValue("state", cmbstate.SelectedItem);
            cmd.Parameters.AddWithValue("mobileno", txtmobileno.Text);
            cmd.ExecuteNonQuery();

            cmbstate.SelectedItem = "";
        }
    }

    internal class Sqlcommand
    {
    }
}
