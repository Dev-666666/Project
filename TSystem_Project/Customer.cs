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
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public Customer()
        {
            InitializeComponent();
             con = new SqlConnection(@"Server=LAPTOP-U11GPVJB\SQLEXPRESS;Database=TSystem_Project;Integrated Security=True");
        }
        private void ClearData()
        {
            txtcustid.Clear();
            txtfname.Clear();
            txtlname.Clear();
            txtaddress.Clear();
            txtmobileno.Clear();
            txtpincode.Clear();
            txtstate.Clear();
            txtusername.Clear();
            txtpass.Clear();


        }


        private void lbllname_Click(object sender, EventArgs e)
        {

        }

        private void btnsubmit_Click(object sender, EventArgs e)
        {

            try
            {
                string qry = "insert into CustomerTable values(@Customer_Id,@First_Name,@Last_Name,@Cust_Address,@Cust_Pincode,@Cust_State,@Cust_MobileNo,@User_Name,@Password)";
                cmd = new SqlCommand(qry, con);
                con.Open();
                cmd.Parameters.AddWithValue("@Customer_Id", Convert.ToInt32(txtcustid.Text));
                cmd.Parameters.AddWithValue("@First_Name", txtfname.Text);
                cmd.Parameters.AddWithValue("@Last_Name", txtlname.Text);
                cmd.Parameters.AddWithValue("@Cust_Address", txtaddress.Text);
                cmd.Parameters.AddWithValue("@Cust_Pincode", txtpincode.Text);
                cmd.Parameters.AddWithValue("@Cust_State", txtstate.Text);
                cmd.Parameters.AddWithValue("@Cust_MobileNo", txtmobileno.Text);
                cmd.Parameters.AddWithValue("@User_Name", txtusername.Text);
                cmd.Parameters.AddWithValue("@Password", txtpass.Text);

                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    MessageBox.Show("Successfully Saved the Record");
                    txtcustid.Enabled = true;
                    ClearData();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            ClearData();
        }
    }

    internal class Sqlcommand
    {
    }
}
