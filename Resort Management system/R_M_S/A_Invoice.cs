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
    public partial class A_Invoice : Form
    {
        SqlCommand cmd;
        SqlDataAdapter sda;
        SqlConnection conn = new SqlConnection(@"Data Source=MISHAL-E-EMAN\SQLEXPRESS;Initial Catalog=Resort_Management_System;Integrated Security=True");

        public A_Invoice()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Admin_Main_Menu amm = new Admin_Main_Menu();
            amm.Show();
            this.Hide();
        }

        private void A_Invoice_Load(object sender, EventArgs e)
        {
            this.textBox6.ReadOnly = true;
            //GRN_ID auato Generate..................................
            {
                int c = 0;
                conn.Open();
                cmd = new SqlCommand("select count(INVOICE_ID) from INVOICE1_tbl", conn);
                SqlDataReader sda = cmd.ExecuteReader();
                if (sda.Read())
                {
                    c = Convert.ToInt32(sda[0]); c++;
                }
                {
                    textBox6.Text = c.ToString();
                }

                conn.Close();
            }
            //POPULATING ID………………………………………………………………………………………………………………………

            conn.Open();
            cmd = new SqlCommand("select GRN_ID from GRNP_tbl", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                comboBox1.Items.Add(dr["GRN_ID"].ToString());

            }
            conn.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //FETCHING DATA…………………………………………………………………………………………………………………….

            conn.Open();
            cmd = new SqlCommand("Select * from GRNP_tbl where GRN_ID=@GRN_ID", conn);
            cmd.Parameters.AddWithValue("@GRN_ID", comboBox1.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
              
                this.textBox7.Text = dr["DEPARTMENT"].ToString();
                this.textBox8.Text = dr["COMPANY_ID"].ToString();
                this.textBox1.Text = dr["ITEM_ID"].ToString();
                this.textBox3.Text = dr["ITEM_TYPE"].ToString();
                this.textBox4.Text = dr["QUANTITY"].ToString();
                this.textBox5.Text = dr["TOTAL_PRICE"].ToString();
            }
            conn.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("insert into INVOICE1_tbl (DEPARTMENT,COMPANY_ID,ITEM_ID,ITEM_TYPE,QUANTITY,TOTAL_PRICE) VALUES(@DEPARTMENT,@COMPANY_ID,@ITEM_ID,@ITEM_TYPE,@QUANTITY,@TOTAL_PRICE)", conn);
           
            cmd.Parameters.AddWithValue("DEPARTMENT", textBox7.Text);
            cmd.Parameters.AddWithValue("COMPANY_ID", textBox8.Text);
            cmd.Parameters.AddWithValue("ITEM_ID", textBox1.Text);
            cmd.Parameters.AddWithValue("ITEM_TYPE", textBox3.Text);
            cmd.Parameters.AddWithValue("QUANTITY", textBox4.Text);
            cmd.Parameters.AddWithValue("TOTAL_PRICE", textBox5.Text);

            cmd.ExecuteNonQuery();
            MessageBox.Show("INVOICE Data has been Inserted ");
            conn.Close();
        }
    }
}
