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
    public partial class A_Member_Approval : Form
    {
       

SqlCommand cmd;
        SqlDataAdapter sda;
       SqlConnection conn = new SqlConnection(@"Data Source=MISHAL-E-EMAN\SQLEXPRESS;Initial Catalog=Resort_Management_System;Integrated Security=True");
        public A_Member_Approval()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Admin_Main_Menu amm = new Admin_Main_Menu();
            amm.Show();
            this.Hide();
        }

        private void A_Member_Approval_Load(object sender, EventArgs e)
        {
            //Populate Member ID
            {
                conn.Open();
                cmd = new SqlCommand("select MEMBER_ID from Member_tbl where M_STATUS='PENDING'", conn);
                SqlDataReader dr2 = cmd.ExecuteReader();
                while (dr2.Read())
                {

                    comboBox2.Items.Add(dr2["MEMBER_ID"].ToString());

                }
                conn.Close();
            }

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("select * from Member_tbl where MEMBER_ID=@MEMBER_ID", conn);
            cmd.Parameters.AddWithValue("MEMBER_ID",comboBox2.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                this.textBox2.Text = dr["MEMBER_NAME"].ToString();
                this.textBox3.Text = dr["PHONE_NO"].ToString();
                this.textBox4.Text = dr["E_MAIL"].ToString();
                this.textBox5.Text = dr["USERNAME"].ToString();
                this.textBox6.Text = dr["U_PASSWORD"].ToString();
                this.textBox7.Text = dr["M_ADDRESS"].ToString();
                this.textBox1.Text = dr["MEMBER_TYPE"].ToString();
               
            }
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
             conn.Open();
            cmd = new SqlCommand("Update Member_tbl set M_STATUS=@M_STATUS where MEMBER_ID=@MEMBER_ID", conn);
            cmd.Parameters.AddWithValue("@M_STATUS","APPROVE");
            cmd.Parameters.AddWithValue("@MEMBER_ID",comboBox2.Text );
            cmd.ExecuteNonQuery();
            MessageBox.Show("Selected Data has been Updated ");
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.textBox3.Text = "";
            this.textBox4.Text = "";
            this.textBox5.Text = "";
            this.textBox6.Text = "";
            this.textBox7.Text = "";
            this.comboBox2.Text = "";
       
        }
    }
}
