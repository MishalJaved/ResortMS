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
    public partial class A_FoodItems_Insertion : Form
    {
        SqlCommand cmd;
        SqlDataAdapter sda;
        SqlConnection conn = new SqlConnection(@"Data Source=MISHAL-E-EMAN\SQLEXPRESS;Initial Catalog=Resort_Management_System;Integrated Security=True");


        public A_FoodItems_Insertion()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {


        }

        private void button3_Click(object sender, EventArgs e)
        {
            Admin_Main_Menu amm = new Admin_Main_Menu();
            amm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("insert into FOODITEM_tbl (FOOD_NAME,FOOD_TYPE,CATEGORY,COMPANY_NAME,PRICE,QUANTITY,TOTAL_PRICE) VALUES (@FOOD_NAME,@FOOD_TYPE,@CATEGORY,@COMPANY_NAME,@PRICE,@QUANTITY,@TOTAL_PRICE)", conn);
            cmd.Parameters.AddWithValue("FOOD_NAME", textBox2.Text);
            cmd.Parameters.AddWithValue("FOOD_TYPE", comboBox1.Text);
            cmd.Parameters.AddWithValue("CATEGORY", comboBox3.Text);
            cmd.Parameters.AddWithValue("COMPANY_NAME", textBox6.Text);
            cmd.Parameters.AddWithValue("PRICE", textBox3.Text);
            cmd.Parameters.AddWithValue("QUANTITY", textBox4.Text);
            cmd.Parameters.AddWithValue("TOTAL_PRICE", textBox5.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Selected Data has been Inserted ");
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

            this.comboBox1.Text = "";
            this.comboBox3.Text = "";
        }

        private void A_FoodItems_Insertion_Load(object sender, EventArgs e)
        {
            this.textBox5.Text = "/=";

            //Room_BOOK_ID auato Generate..................................
            {
                int c = 0;
                conn.Open();
                cmd = new SqlCommand("select count(FOOD_ID) from FOODITEM_tbl", conn);
                SqlDataReader sda = cmd.ExecuteReader();
                if (sda.Read())
                {
                    c = Convert.ToInt32(sda[0]); c++;
                }

                {
                    textBox1.Text = "FID-00" + c.ToString() + "-" + System.DateTime.Today.Year;
                }

                conn.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(this.textBox3.Text);
            int b = Convert.ToInt32(this.textBox4.Text);

            int Total;
            Total = a * b;
            this.textBox5.Text = Convert.ToString(Total);
        }
    }
}
