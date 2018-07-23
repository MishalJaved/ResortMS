using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace R_M_S
{
    public partial class C_Bill_Payment : Form
    {
        SqlCommand cmd;
        SqlDataAdapter sda;
        SqlConnection conn = new SqlConnection(@"Data Source=MISHAL-E-EMAN\SQLEXPRESS;Initial Catalog=Resort_Management_System;Integrated Security=True");

        public C_Bill_Payment()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Customer_Main_Menu cmm = new Customer_Main_Menu();
            cmm.Show();
            this.Hide();
        }

        private void C_Bill_Payment_Load(object sender, EventArgs e)
        {
            this.textBox2.ScrollBars = ScrollBars.Both;

            //GRN_ID auato Generate..................................
            {
                int c = 0;
                conn.Open();
                cmd = new SqlCommand("select count(BILL_ID) from BILL_tbl", conn);
                SqlDataReader sda = cmd.ExecuteReader();
                if (sda.Read())
                {
                    c = Convert.ToInt32(sda[0]); c++;
                }
                {
                    textBox3.Text = c.ToString();
                }

                conn.Close();
            }

            //POPULATING ID………………………………………………………………………………………………………………………

            conn.Open();
            cmd = new SqlCommand("select MEMBER_ID from Member_tbl", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                comboBox1.Items.Add(dr["MEMBER_ID"].ToString());

            }
            conn.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("Select * from Member_tbl where MEMBER_ID=@MEMBER_ID", conn);
            cmd.Parameters.AddWithValue("@MEMBER_ID", comboBox1.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                this.textBox4.Text = dr["MEMBER_NAME"].ToString();
                this.textBox5.Text = dr["MEMBER_TYPE"].ToString();
            }
            conn.Close();

            

            {
                conn.Open();
                cmd = new SqlCommand("Select * from Room_Booking_tbl where MEMBER_ID=@MEMBER_ID", conn);
                cmd.Parameters.AddWithValue("@MEMBER_ID", comboBox1.Text);
                SqlDataReader dr1 = cmd.ExecuteReader();
                if (dr1.Read())
                {
                    this.textBox6.Text = dr1["ROOM_CHARGES"].ToString();
                   
                }
                conn.Close();
            }
            {
                conn.Open();
                cmd = new SqlCommand("Select * from Service_AVAIL_tbl where MEMBER_ID=@MEMBER_ID", conn);
                cmd.Parameters.AddWithValue("@MEMBER_ID", comboBox1.Text);
                SqlDataReader dr2 = cmd.ExecuteReader();
                if (dr2.Read())
                {
                    this.textBox4.Text = dr2["SERVICE_CHARGES"].ToString();
                  
                }
                conn.Close();
            }
            {
             conn.Open();
            cmd = new SqlCommand("Select * from Member_tbl where MEMBER_ID=@MEMBER_ID", conn);
            cmd.Parameters.AddWithValue("@MEMBER_ID", comboBox1.Text);
            SqlDataReader dr3 = cmd.ExecuteReader();
            if (dr3.Read())
            {
                this.textBox8.Text = dr3["MEMBERSHIP_CHARGES"].ToString();
               
            }
            conn.Close();
        }
        }

    }
}
