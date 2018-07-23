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
    public partial class A_Purchase_Order : Form
    {
        SqlCommand cmd;
        SqlDataAdapter sda;
        SqlConnection conn = new SqlConnection(@"Data Source=MISHAL-E-EMAN\SQLEXPRESS;Initial Catalog=Resort_Management_System;Integrated Security=True");


        string[] ITEM_ID = new string[50];
        string[] ITEM_TYPE = new string[50];
        string[] QUANTITY = new string[50];
        string[] TOTALAMOUNT = new string[50];
        int counter = 0;

        public A_Purchase_Order()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Admin_Main_Menu amm = new Admin_Main_Menu();
            amm.Show();
            this.Hide();
        }

        private void A_Purchase_Order_Load(object sender, EventArgs e)
        {
            this.textBox5.Text = "500";

            //PO_ID auato Generate..................................
            {
                int c = 0;
                conn.Open();
                cmd = new SqlCommand("select count(PO_ID) from PO_tbl", conn);
                SqlDataReader sda = cmd.ExecuteReader();
                if (sda.Read())
                {
                    c = Convert.ToInt32(sda[0]); c++;
                }
                {
                    textBox2.Text = c.ToString();
                }

                conn.Close();
            }
            //POPULATING ID………………………………………………………………………………………………………………………

            conn.Open();
            cmd = new SqlCommand("select COMPANY_ID from COMPANY_tbl", conn);
            SqlDataReader dr1 = cmd.ExecuteReader();
            while (dr1.Read())
            {

                comboBox2.Items.Add(dr1["COMPANY_ID"].ToString());

            }
            conn.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("Select * from COMPANY_tbl where COMPANY_ID=@COMPANY_ID", conn);
            cmd.Parameters.AddWithValue("@COMPANY_ID", comboBox2.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                this.textBox3.Text = dr["COMPANY_NAME"].ToString();
                this.textBox4.Text = dr["ITEM_ID"].ToString();
                this.textBox8.Text = dr["ITEM_NAME"].ToString();
               

            }
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int price;
            int qty;

            price = Convert.ToInt32(this.textBox5.Text);
            qty = Convert.ToInt32(this.textBox6.Text);

            int TAmount;
            TAmount = price * qty;
            this.textBox1.Text = Convert.ToString(TAmount);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("insert into PO_tbl (DEPART,COMPANY_ID,ITEM_TYPE,ITEM_ID,TOTAL_AMOUNT) VALUES(@DEPART,@COMPANY_ID,@ITEM_TYPE,@ITEM_ID,@TOTAL_AMOUNT)", conn);
          
            cmd.Parameters.AddWithValue("DEPART", comboBox1.Text);
             cmd.Parameters.AddWithValue("COMPANY_ID",comboBox2.Text);
             cmd.Parameters.AddWithValue("ITEM_TYPE",textBox8.Text);
            cmd.Parameters.AddWithValue("ITEM_ID", textBox4.Text);
           
            cmd.Parameters.AddWithValue("TOTAL_AMOUNT", textBox1.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("PO Selection Data has been Inserted ");
            conn.Close();

            {
                //Insertion of Products in PoProducts table.................
                try
                {
                    for (int counter = 0; counter < ITEM_ID.Length; counter++)
                    {
                        conn.Open();
                        cmd = new SqlCommand("insert into PO_Product_tbl(PO_ID,ITEM_ID,ITEM_TYPE,QUANTITY,TOTAL_AMOUNT)values(@PO_ID,@ITEM_ID,@ITEM_TYPE,@QUANTITY,@TOTAL_AMOUNT)", conn);
                        cmd.Parameters.AddWithValue("@PO_ID", this.textBox2.Text);
                        cmd.Parameters.AddWithValue("@ITEM_ID", ITEM_ID[counter]);
                        cmd.Parameters.AddWithValue("@ITEM_TYPE", ITEM_TYPE[counter]);
                        cmd.Parameters.AddWithValue("@QUANTITY", QUANTITY[counter]);
                        cmd.Parameters.AddWithValue("@TOTAL_AMOUNT",TOTALAMOUNT[counter]);
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                    MessageBox.Show("Multiple Services Added ");
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ITEM_ID[counter]=textBox4.Text;
            ITEM_TYPE[counter]=textBox8.Text;
            QUANTITY[counter]=textBox6.Text;
            TOTALAMOUNT[counter] = this.textBox1.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
             this.textBox7.Text +="**********PRODUCT DETAILS**********"+Environment.NewLine;
             this.textBox7.Text +="PO_ID:"+this.textBox2.Text+Environment.NewLine;
             this.textBox7.Text +="DEPARTMENT:"+this.comboBox1.Text+Environment.NewLine;
             this.textBox7.Text +="COMPANY_ID:"+this.comboBox2.Text+Environment.NewLine;
             this.textBox7.Text +="COMPANY_NAME"+this.textBox3.Text+Environment.NewLine;
             this.textBox7.Text +="ITEM_ID:"+this.textBox8.Text+Environment.NewLine;
             this.textBox7.Text +="ITEM_TYPE:"+this.textBox4.Text+Environment.NewLine;
             this.textBox7.Text +="PRICE:"+this.textBox5.Text+Environment.NewLine;
             this.textBox7.Text +="QUANTITY:"+this.textBox6.Text+Environment.NewLine;
             this.textBox7.Text += "TOTAL_AMOUNT:" + this.textBox1.Text + Environment.NewLine;
             
        }
    }
}
