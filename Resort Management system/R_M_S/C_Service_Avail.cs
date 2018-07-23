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
    public partial class C_Service_Avail : Form
    {
        SqlCommand cmd;
        SqlDataAdapter sda;
        SqlConnection conn = new SqlConnection(@"Data Source=MISHAL-E-EMAN\SQLEXPRESS;Initial Catalog=Resort_Management_System;Integrated Security=True");

        string[] SNAME = new string[50];
        string[] SID = new string[50];
        string[] MID = new string[50];
        string[] SCHARGES = new string[50];
        int[] TOTALAMOUNT = new int[50];
        int counter = 0;
 

        public C_Service_Avail()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Customer_Main_Menu cmm = new Customer_Main_Menu();
            cmm.Show();
            this.Hide();
        }

        private void C_Service_Avail_Load(object sender, EventArgs e)
        {
            this.textBox6.ReadOnly = true;

            //Populate Member ID…………………………………………………………………………………………
            {
                conn.Open();
                cmd = new SqlCommand("select MEMBER_ID from Member_tbl", conn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    comboBox1.Items.Add(dr["MEMBER_ID"].ToString());

                }
                conn.Close();

                //Populate PSERVICE ID…………………………………………………………………………………………
                {
                    conn.Open();
                    cmd = new SqlCommand("select PSERVICE_NAME from Service_Provide_tbl WHERE SERVICE_STATUS='Available'", conn);
                    SqlDataReader dr1 = cmd.ExecuteReader();
                    while (dr1.Read())
                    {

                        comboBox2.Items.Add(dr1["PSERVICE_NAME"].ToString());

                    }
                    conn.Close();

                }

                //Room_ID auato Generate..................................
                {
                    int c = 0;
                    conn.Open();
                    cmd = new SqlCommand("select count(SERVICE_ID) from Service_AVAIL_tbl", conn);
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

            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("Select * from Member_tbl where MEMBER_ID=@MEMBER_ID", conn);
            cmd.Parameters.AddWithValue("@MEMBER_ID", comboBox1.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                this.textBox1.Text = dr["MEMBER_NAME"].ToString();
                this.textBox2.Text = dr["MEMBER_TYPE"].ToString();
            }
            conn.Close();


        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("Select * from Service_Provide_tbl where PSERVICE_NAME=@PSERVICE_NAME", conn);
            cmd.Parameters.AddWithValue("@PSERVICE_NAME", comboBox2.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                this.textBox4.Text = dr["PSERVICE_ID"].ToString();
                this.textBox5.Text = dr["SERVICE_CHARGES"].ToString();
            }
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        
             //CODING OF ADD PRODUCT.............................
      
        {
           /* int baseprice=0;
            int productqty=0;

            baseprice=Convert.ToInt32(textBox6.Text);
            productqty=Convert.ToInt32(textBox5.Text);

         //   baseprice* productqty = Convert.ToInt32(this.textBox9.Text); 
            this.textBox9.Text = Convert.ToString(baseprice * productqty);

            //multiple SERVICES storing in Array..................................
            prds[counter] = comboBox3.Text;
            pname[counter] = this.textBox7.Text;
            pqty[counter] = Convert.ToInt32(textBox5.Text);
            pprice[counter] = Convert.ToInt32(textBox9.Text);
            counter++;*/

          

            //multiple SERVICES storing in Array..................................
            SNAME[counter]=this.comboBox2.Text;
            SID[counter]=this.textBox4.Text;
            MID[counter] = this.comboBox1.Text;
          
            SCHARGES[counter] = this.textBox5.Text;

            counter++;
            MessageBox.Show("SERVICE DATA STORED... ");

            //TOTALAMOUNT[counter]=;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("insert into Service_AVAIL_tbl (MEMBER_ID,NO_OF_PERSON) VALUES(@MEMBER_ID,@NO_OF_PERSON)", conn);
            cmd.Parameters.AddWithValue("MEMBER_ID",this.comboBox1.Text);
            cmd.Parameters.AddWithValue("NO_OF_PERSON",this.textBox3.Text);
           // cmd.Parameters.AddWithValue("PSERVICE_ID",this.textBox4.Text);
          //  cmd.Parameters.AddWithValue("PSERVICE_NAME",this.comboBox2.Text);
           // cmd.Parameters.AddWithValue("S_DATE", this.dateTimePicker1);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Service Selection Data has been Inserted ");
            conn.Close();

            {
                //Insertion of Products in PoProducts table.................
                try
                {
                    for (int counter = 0; counter < SID.Length; counter++)
                    {
                        conn.Open();
                        cmd = new SqlCommand("insert into S_Avail2_tbl(SERVICE_ID,MEMBER_ID,PSERVICE_ID,SERVICE_CHARGES)values(@SERVICE_ID,@MEMBER_ID,@PSERVICE_ID,@SERVICE_CHARGES)", conn);
                        cmd.Parameters.AddWithValue("@SERVICE_ID", this.textBox6.Text);
                        cmd.Parameters.AddWithValue("@MEMBER_ID", MID[counter]);
                        cmd.Parameters.AddWithValue("@PSERVICE_ID", SID[counter]);
                        cmd.Parameters.AddWithValue("@SERVICE_CHARGES", SCHARGES[counter]);
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
    }
}
