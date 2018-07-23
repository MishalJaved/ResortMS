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
    public partial class A_GRN : Form
    {
        SqlCommand cmd;
        SqlDataAdapter sda;
        SqlConnection conn = new SqlConnection(@"Data Source=MISHAL-E-EMAN\SQLEXPRESS;Initial Catalog=Resort_Management_System;Integrated Security=True");

        public A_GRN()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Admin_Main_Menu amm = new Admin_Main_Menu();
            amm.Show();
            this.Hide();

        }

        private void A_GRN_Load(object sender, EventArgs e)
        {
            this.textBox1.ReadOnly = true;

            //GRN_ID auato Generate..................................
            {
                int c = 0;
                conn.Open();
                cmd = new SqlCommand("select count(GRN_ID) from GRNP_tbl", conn);
                SqlDataReader sda = cmd.ExecuteReader();
                if (sda.Read())
                {
                    c = Convert.ToInt32(sda[0]); c++;
                }
                {
                    textBox1.Text = c.ToString();
                }

                conn.Close();
            }
            //POPULATING ID………………………………………………………………………………………………………………………

            conn.Open();
            cmd = new SqlCommand("select PO_ID from PO_tbl", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                comboBox1.Items.Add(dr["PO_ID"].ToString());

            }
            conn.Close();

            //POPULATING ID………………………………………………………………………………………………………………………

            conn.Open();
            cmd = new SqlCommand("select COMPANY_ID from COMPANY_tbl", conn);
            SqlDataReader dr1 = cmd.ExecuteReader();
            while (dr1.Read())
            {
                comboBox1.Items.Add(dr1["COMPANY_ID"].ToString());
            }
            conn.Close();

        
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
           

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("Select * from PO_tbl where PO_ID=@PO_ID", conn);
            cmd.Parameters.AddWithValue("@PO_ID", comboBox1.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                this.textBox7.Text = dr["DEPART"].ToString();
                this.textBox6.Text = dr["COMPANY_ID"].ToString();
                this.textBox2.Text = dr["ITEM_TYPE"].ToString();
                this.textBox3.Text = dr["ITEM_ID"].ToString();
                this.textBox4.Text = dr["QUANTITY"].ToString();
                this.textBox5.Text = dr["TOTAL_AMOUNT"].ToString();

            }
            conn.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("insert into GRNP_tbl (PO_ID,DEPARTMENT,COMPANY_ID,ITEM_ID,ITEM_TYPE,QUANTITY,TOTAL_PRICE) VALUES(@PO_ID,@DEPARTMENT,@COMPANY_ID,@ITEM_ID,@ITEM_TYPE,@QUANTITY,@TOTAL_PRICE)", conn);
            cmd.Parameters.AddWithValue("PO_ID",comboBox1.Text);
            cmd.Parameters.AddWithValue("DEPARTMENT",textBox7.Text);
            cmd.Parameters.AddWithValue("COMPANY_ID",textBox6.Text);
            cmd.Parameters.AddWithValue("ITEM_ID",textBox3.Text);
            cmd.Parameters.AddWithValue("ITEM_TYPE",textBox2.Text);
             cmd.Parameters.AddWithValue("QUANTITY",textBox4.Text);
             cmd.Parameters.AddWithValue("TOTAL_PRICE", textBox5.Text);
            
            cmd.ExecuteNonQuery();
            MessageBox.Show("GRN Data has been Inserted ");
            conn.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.textBox3.Text = "";
            this.textBox4.Text = "";
            this.textBox5.Text = "";
            this.textBox6.Text = "";
            this.textBox7.Text = "";
            this.comboBox1.Text = "";

            //GRN_ID auato Generate..................................
            {
                int c = 0;
                conn.Open();
                cmd = new SqlCommand("select count(GRN_ID) from GRNP_tbl", conn);
                SqlDataReader sda = cmd.ExecuteReader();
                if (sda.Read())
                {
                    c = Convert.ToInt32(sda[0]); c++;
                }
                {
                    textBox1.Text = c.ToString();
                }

                conn.Close();
            }
        }
    }
}
