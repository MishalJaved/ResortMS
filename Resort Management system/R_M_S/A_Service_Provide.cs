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
    public partial class A_Service_Provide : Form
    {
        SqlCommand cmd;
        SqlDataAdapter sda;
        SqlConnection conn = new SqlConnection(@"Data Source=MISHAL-E-EMAN\SQLEXPRESS;Initial Catalog=Resort_Management_System;Integrated Security=True");


        public A_Service_Provide()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Admin_Main_Menu amm = new Admin_Main_Menu();
            amm.Show();
            this.Hide();
        }

        private void A_Service_Provide_Load(object sender, EventArgs e)
        {
            this.textBox1.ReadOnly = true;
            this.ActiveControl = this.textBox2;

            this.panel3.Visible = false;
            


            //Service Add_ID auato Generate..................................
            {
                int c = 0;
                conn.Open();
                cmd = new SqlCommand("select count(PSERVICE_ID) from Service_Provide_tbl", conn);
                SqlDataReader sda = cmd.ExecuteReader();
                if (sda.Read())
                {
                    c = Convert.ToInt32(sda[0]); c++;
                }

                {
                    textBox1.Text = "SERvice-00" + c.ToString() + "-" + System.DateTime.Today.Year;
                }

                conn.Close();
                //.........................................................................

                //MEMBER TYPE...........................................................
                string[] MEMBER_TYPE = { "Member", "Life Member", "Guest+Member", "Member+Life Member", "Guest+Member+Life Member" };

                this.comboBox2.Items.AddRange(MEMBER_TYPE);
                //  ...................................................................

                //Populate SERVICE NAME...............................................
                {
                    conn.Open();
                    cmd = new SqlCommand("select PSERVICE_NAME from Service_Provide_tbl", conn);
                    SqlDataReader dr1 = cmd.ExecuteReader();
                    while (dr1.Read())
                    {

                        comboBox3.Items.Add(dr1["PSERVICE_NAME"].ToString());

                    }
                    conn.Close();

                }
            


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("insert into Service_Provide_tbl(PSERVICE_NAME,AVAIL_TO,AVAIL_POINTS,SERVICE_HEAD_NAME,WORKERS,SERVICE_CHARGES,SERVICE_STATUS) VALUES(@PSERVICE_NAME,@AVAIL_TO,@AVAIL_POINTS,@SERVICE_HEAD_NAME,@WORKERS,@SERVICE_CHARGES,@SERVICE_STATUS)", conn);
            cmd.Parameters.AddWithValue("PSERVICE_NAME", this.textBox2.Text);
            cmd.Parameters.AddWithValue("AVAIL_TO", this.comboBox2.Text);
            cmd.Parameters.AddWithValue("AVAIL_POINTS", this.textBox7.Text);
            cmd.Parameters.AddWithValue("SERVICE_HEAD_NAME", this.textBox4.Text);
            cmd.Parameters.AddWithValue("WORKERS", this.textBox5.Text);
            cmd.Parameters.AddWithValue("SERVICE_CHARGES", this.textBox6.Text + "/=");
            cmd.Parameters.AddWithValue("SERVICE_STATUS","AVALABLE");

            cmd.ExecuteNonQuery();
            MessageBox.Show("Selected Data has been Inserted ");
            conn.Close();


        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.textBox4.Text = "";
            this.textBox5.Text = "";
            this.textBox6.Text = "";
            this.textBox7.Text = "";
            this.comboBox2.Text = "";


            //Service Add_ID auato Generate..................................
            {
                int c = 0;
                conn.Open();
                cmd = new SqlCommand("select count(PSERVICE_ID) from Service_Provide_tbl", conn);
                SqlDataReader sda = cmd.ExecuteReader();
                if (sda.Read())
                {
                    c = Convert.ToInt32(sda[0]); c++;
                }

                {
                    textBox1.Text = "SERvice-00" + c.ToString() + "-" + System.DateTime.Today.Year;
                }

                conn.Close();
                //.........................................................................


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.panel3.Visible = true;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("Select * from Service_Provide_tbl where PSERVICE_NAME=@PSERVICE_NAME", conn);
            cmd.Parameters.AddWithValue("@PSERVICE_NAME", comboBox3.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                this.textBox12.Text = dr["PSERVICE_ID"].ToString();
                this.textBox11.Text = dr["AVAIL_TO"].ToString();
                this.textBox3.Text = dr["AVAIL_POINTS"].ToString();
                this.textBox10.Text = dr["SERVICE_HEAD_NAME"].ToString();
                this.textBox9.Text = dr["WORKERS"].ToString();
                this.textBox8.Text = dr["SERVICE_CHARGES"].ToString();
             
            }
            conn.Close();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("Update Service_Provide_tbl set SERVICE_STATUS='UnAvailable' where PSERVICE_NAME=@PSERVICE_NAME ", conn);
            cmd.Parameters.AddWithValue("@PSERVICE_NAME", comboBox3.Text);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Selected Data has been Updated ");
            conn.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.panel3.Visible = false;
        }
    }
}