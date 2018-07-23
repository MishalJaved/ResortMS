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
    public partial class C_Member_Regs : Form
    {
        SqlCommand cmd;
        SqlDataAdapter sda;
        SqlConnection conn = new SqlConnection(@"Data Source=MISHAL-E-EMAN\SQLEXPRESS;Initial Catalog=Resort_Management_System;Integrated Security=True");
        public C_Member_Regs()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Customer_Main_Menu cmm = new Customer_Main_Menu();
            cmm.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.label2.Visible = false;
            this.label3.Visible = false;
            this.label4.Visible = false;
            this.label5.Visible = false;
            this.label6.Visible = false;
            this.label7.Visible = false;
            this.label8.Visible = false;
            this.label9.Visible = false;
            this.label10.Visible = false;

            this.textBox1.Visible = false;
            this.textBox2.Visible = false;
            this.textBox3.Visible = false;
            this.textBox4.Visible = false;
            this.textBox5.Visible = false;
            this.textBox6.Visible = false; 
            this.textBox7.Visible = false;
            this.comboBox1.Visible = false;
            this.button1.Visible = false;
            this.button2.Visible = false;
            this.button3.Visible = false;
           
            this.button5.Visible = false;

            this.panel2.Visible = true;
        }

        private void C_Member_Regs_Load(object sender, EventArgs e)
        {
            this.panel2.Visible = false;
            this.ActiveControl = textBox2;
            this.textBox1.ReadOnly = true;
            this.textBox15.Text = "5000/=";
            this.textBox14.ReadOnly = true;

            //MEMBER ID AUTO.......................................................
            int c = 0;
            conn.Open();
            cmd = new SqlCommand("select count(MEMBER_ID) from Member_tbl", conn);
            SqlDataReader sda = cmd.ExecuteReader();
            if (sda.Read())
            {
                c = Convert.ToInt32(sda[0]); c++;
            }

            {
                textBox1.Text = "MID-00" + c.ToString() + "-" + System.DateTime.Today.Year;
            }

            conn.Close();

            //MEMBERSHIP ID AUTO.......................................................
            {
                int D = 0;
                conn.Open();
                cmd = new SqlCommand("select count(MEMBERSHIP_ID) from Member_tbl", conn);
                SqlDataReader sda1 = cmd.ExecuteReader();
                if (sda1.Read())
                {
                    D = Convert.ToInt32(sda1[0]); 
                    D++;
                }

                {
                    textBox14.Text = "MSID-00" + D.ToString() + "-" + System.DateTime.Today.Year;
                }

                conn.Close();

            }

            //Populate Member ID
            {
                conn.Open();
                cmd = new SqlCommand("select MEMBER_ID from Member_tbl", conn);
                SqlDataReader dr2 = cmd.ExecuteReader();
                while (dr2.Read())
                {

                    comboBox2.Items.Add(dr2["MEMBER_ID"].ToString());

                }
                conn.Close();
            }

           
        }
        private void button7_Click(object sender, EventArgs e)
        {
            this.panel2.Visible = false;

            this.label2.Visible = true;
            this.label3.Visible = true;
            this.label4.Visible = true;
            this.label5.Visible = true;
            this.label6.Visible = true;
            this.label7.Visible = true;
            this.label8.Visible = true;
            this.label9.Visible = true;
            this.label10.Visible = true;
            this.comboBox1.Visible = true;

            this.textBox1.Visible = true;
            this.textBox2.Visible = true;
            this.textBox3.Visible = true;
            this.textBox4.Visible = true;
            this.textBox5.Visible = true;
            this.textBox6.Visible = true;
            this.textBox7.Visible = true;

            this.button1.Visible = true;
            this.button2.Visible = true;
            this.button3.Visible = true;
           
            this.button5.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
         
            this.label2.Visible = false;
            this.label3.Visible = false;
            this.label4.Visible = false;
            this.label5.Visible = false;
            this.label6.Visible = false;
            this.label7.Visible = false;
            this.label8.Visible = false;
            this.label9.Visible = false;
            this.label10.Visible = false;

            this.textBox1.Visible = false;
            this.textBox2.Visible = false;
            this.textBox3.Visible = false;
            this.textBox4.Visible = false;
            this.textBox5.Visible = false;
            this.textBox6.Visible = false;
            this.textBox7.Visible = false;
            this.comboBox1.Visible = false;
            this.button1.Visible = false;
            this.button2.Visible = false;
            this.button3.Visible = false;
          
            this.button5.Visible = false;

            this.panel2.Visible = false;


        }

        private void button8_Click(object sender, EventArgs e)
        {
          

          

           /* conn.Open();
            // cmd = new SqlCommand("Select * from Member_tbl where Member_ID=@MEMBER_ID", conn);
            sda = new SqlDataAdapter("Select * from Member_tbl where Member_ID=@MEMBER_ID", conn);
            cmd.Parameters.AddWithValue("@MEMBER_ID", comboBox3.Text);
            // SqlDataReader dr = cmd.ExecuteReader();


            DataTable dt = new DataTable();
           // sda.Fill(dt);
            this.dataGridView1.DataSource = dt;

            conn.Close();*/
        }
        private void button9_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
              
            conn.Open();
            cmd = new SqlCommand("insert into Member_tbl (MEMBER_NAME,PHONE_NO,E_MAIL,USERNAME,U_PASSWORD,M_ADDRESS,MEMBER_TYPE,MEMBERSHIP_CHARGES,M_STATUS) VALUES (@MEMBER_NAME,@PHONE_NO,@E_MAIL,@USERNAME,@U_PASSWORD,@M_ADDRESS,@MEMBER_TYPE,@MEMBERSHIP_CHARGES,@M_STATUS)", conn);
            cmd.Parameters.AddWithValue("MEMBER_NAME",textBox2.Text);
            cmd.Parameters.AddWithValue("PHONE_NO",textBox3.Text);
             cmd.Parameters.AddWithValue("E_MAIL",textBox4.Text);
             cmd.Parameters.AddWithValue("USERNAME",textBox5.Text);
             cmd.Parameters.AddWithValue("U_PASSWORD",textBox6.Text);
             cmd.Parameters.AddWithValue("M_ADDRESS",textBox7.Text);
             cmd.Parameters.AddWithValue("MEMBER_TYPE",comboBox1.Text);
            cmd.Parameters.AddWithValue("M_STATUS","PENDING");
             cmd.Parameters.AddWithValue("MEMBERSHIP_CHARGES",this.textBox15.Text);
           


            cmd.ExecuteNonQuery();
            MessageBox.Show("Selected Data has been Inserted ");
            conn.Close();
        
        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
             conn.Open();
            cmd = new SqlCommand("Update Member_tbl set MEMBERSHIP_CHARGES=@MEMBERSHIP_CHARGES,MEMBERSHIP_ID=@MEMBERSHIP_ID where MEMBER_ID=@MEMBER_ID", conn);
            cmd.Parameters.AddWithValue("@MEMBERSHIP_CHARGES",textBox15.Text );
            cmd.Parameters.AddWithValue("@MEMBERSHIP_ID",textBox14.Text);
            cmd.Parameters.AddWithValue("@MEMBER_ID",comboBox2.Text);
          
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

            this.comboBox1.Text = "";
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
