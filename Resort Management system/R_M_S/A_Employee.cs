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
    public partial class A_Employee : Form
    {
        SqlCommand cmd;
        SqlDataAdapter sda;
        SqlConnection conn = new SqlConnection(@"Data Source=MISHAL-E-EMAN\SQLEXPRESS;Initial Catalog=Resort_Management_System;Integrated Security=True");

        public A_Employee()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Admin_Main_Menu amm = new Admin_Main_Menu();
            amm.Show();
            this.Hide();
        }

        private void A_Employee_Load(object sender, EventArgs e)
        {
           
            this.textBox1.ReadOnly = true;
            this.ActiveControl = comboBox1;

            this.panel4.Visible = false;

            string[] Emp_Depart = { "HouseKeeping", "Food", "First Aid Staff", "Heads", "Accounting", "Others.." };
            this.comboBox1.Items.AddRange(Emp_Depart);

            //Employee_ID auato Generate..................................
            {
                int c = 0;
                conn.Open();
                cmd = new SqlCommand("select count(EMP_ID) from Employee_tbl", conn);
                SqlDataReader sda = cmd.ExecuteReader();
                if (sda.Read())
                {
                    c = Convert.ToInt32(sda[0]); c++;
                    textBox1.Text = "EMP-00" + c.ToString() + "-" + System.DateTime.Today.Year;
                }

                {
                 //   textBox1.Text = "EMP-00" + c.ToString() + "-" + System.DateTime.Today.Year;
                }

                conn.Close();
            }
            //Populate Member ID
            {
                conn.Open();
                cmd = new SqlCommand("select EMP_ID from Employee_tbl", conn);
                SqlDataReader dr1 = cmd.ExecuteReader();
                while (dr1.Read())
                {

                    comboBox3.Items.Add(dr1["EMP_ID"].ToString());

                }
                conn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.panel4.Visible = true;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "HouseKeeping")
            {

                string[] HK_JOB = { "HK Director", "HK Deputy", "HK Manager", "Floor Supervisor", "HouseKeepers" };
                this.comboBox2.Items.Clear();
                this.comboBox2.Items.AddRange(HK_JOB);

            }
            if (comboBox1.Text == "Food")
            {
                string[] FOOD_JOB = { "Cheif", "Manager", "Mid Staff", "Dish Washer", "Waiter" };
                this.comboBox2.Items.Clear();
                this.comboBox2.Items.AddRange(FOOD_JOB);
            }

            if (comboBox1.Text == "First Aid Staff")
            {
                string[] FAS_JOB = { "Doctor", "Nurse", "WardMan" };
                this.comboBox2.Items.Clear();
                this.comboBox2.Items.AddRange(FAS_JOB);
            }
            if (comboBox1.Text == "Heads")
            {
                string[] HEAD_JOB = { "CEO", "HRM", "MD" };
                this.comboBox2.Items.Clear();
                this.comboBox2.Items.AddRange(HEAD_JOB);
            }
            if (comboBox1.Text == "Accounting")
            {
                string[] ACCOUNT_JOB = { "Account-Manager", "Casheir" };
                this.comboBox2.Items.Clear();
                this.comboBox2.Items.AddRange(ACCOUNT_JOB);
            }
            if (comboBox1.Text == "Others")
            {
                string[] OTHER_JOB = { "SWEEPER", "GUARDS" };
                this.comboBox2.Items.Clear();
                this.comboBox2.Items.AddRange(OTHER_JOB);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("insert into Employee_tbl (EMP_NAME,DEPART,AGE,PHONE_NO,JOB_TYPE,RESPONS,SALARY,EMP_STATUS) VALUES(@EMP_NAME,@DEPART,@AGE,@PHONE_NO,@JOB_TYPE,@RESPONS,@SALARY,@EMP_STATUS)", conn);
          
            cmd.Parameters.AddWithValue("EMP_NAME",textBox6.Text);
            cmd.Parameters.AddWithValue("DEPART",comboBox1.Text);
            cmd.Parameters.AddWithValue("AGE",textBox2.Text);
            cmd.Parameters.AddWithValue("PHONE_NO",textBox3.Text);
            cmd.Parameters.AddWithValue("JOB_TYPE",comboBox2.Text);
            cmd.Parameters.AddWithValue("RESPONS",textBox4.Text+"/=");
            cmd.Parameters.AddWithValue("SALARY",textBox5.Text);
            cmd.Parameters.AddWithValue("EMP_STATUS","Active");
            cmd.ExecuteNonQuery();
            MessageBox.Show("Employee Data has been Inserted ");
            conn.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.textBox3.Text = "";
            this.textBox4.Text = "";
            this.textBox5.Text = "";
            this.textBox6.Text = "";

            comboBox1.Text = "";
            comboBox2.Text = "";

            //Employee_ID auato Generate..................................
            {
                int c = 0;
                conn.Open();
                cmd = new SqlCommand("select count(EMP_ID) from Employee_tbl", conn);
                SqlDataReader sda = cmd.ExecuteReader();
                if (sda.Read())
                {
                    c = Convert.ToInt32(sda[0]); c++;
                    textBox1.Text = "EMP-00" + c.ToString() + "-" + System.DateTime.Today.Year;
                }

                {
                    //   textBox1.Text = "EMP-00" + c.ToString() + "-" + System.DateTime.Today.Year;
                }

                conn.Close();
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.panel4.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("Update Employee_tbl set EMP_STATUS='INActive' where EMP_ID=@EMP_ID ", conn);
            cmd.Parameters.AddWithValue("@EMP_ID", comboBox3.Text);   
        
            cmd.ExecuteNonQuery();
            MessageBox.Show("Selected Data has been Updated ");
            conn.Close();

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("Select * from Employee_tbl where EMP_ID=@EMP_ID", conn);
            cmd.Parameters.AddWithValue("@EMP_ID", comboBox3.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                this.textBox7.Text = dr["DEPART"].ToString();
                this.textBox9.Text = dr["EMP_NAME"].ToString();
                this.textBox8.Text = dr["AGE"].ToString();
                this.textBox10.Text = dr["PHONE_NO"].ToString();
                this.textBox13.Text = dr["JOB_TYPE"].ToString();
                this.textBox11.Text = dr["SALARY"].ToString();
                this.textBox12.Text = dr["RESPONS"].ToString();
            
            }
            conn.Close();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.comboBox3.Text = "";
            this.textBox7.Text = "";
            this.textBox8.Text = "";
            this.textBox9.Text = "";
            this.textBox10.Text = "";
            this.textBox11.Text = "";
            this.textBox12.Text = "";
            this.textBox13.Text = "";
        }
    }
}