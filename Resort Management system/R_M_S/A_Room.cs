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
    public partial class A_Room : Form
    {
        SqlCommand cmd;
        SqlDataAdapter sda;
        SqlConnection conn = new SqlConnection(@"Data Source=MISHAL-E-EMAN\SQLEXPRESS;Initial Catalog=Resort_Management_System;Integrated Security=True");

        public A_Room()
        {
            InitializeComponent();
        }

        private void A_Room_Load(object sender, EventArgs e)
        {
            this.ActiveControl = this.comboBox1;

            //For delete panel........................................
            this.panel3.Visible = false;
            this.label1.Visible = true;
            this.label3.Visible = true;
            this.label4.Visible = true;
            this.label5.Visible = true;
            this.label6.Visible = true;
            this.label7.Visible = true;
            this.button1.Visible = true;
            this.button2.Visible = true;
            this.button3.Visible = true;
          //  .............................................................

            this.textBox1.ReadOnly = true;

            this.Text = "ROOM DETAILS";
            
            //Room Category......................
            string []Category={"Room","Hall"};

            this.comboBox1.Items.AddRange(Category);

            //Room_ID auato Generate..................................
            {
                int c = 0;
                conn.Open();
               cmd = new SqlCommand("select count(ROOM_ID) from Room_tbl", conn);
               SqlDataReader sda = cmd.ExecuteReader();
                if (sda.Read())
                {
                    c = Convert.ToInt32(sda[0]); c++;
                }
              
                {
                    textBox1.Text = "Room-00" + c.ToString() + "-" + System.DateTime.Today.Year;
                }
   
                conn.Close();
            }

           

            //Populate Room ID.............................

            conn.Open();
            cmd = new SqlCommand("select ROOM_ID from Room_tbl", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                comboBox4.Items.Add(dr["ROOM_ID"].ToString());

            }
            conn.Close();


        }

        private void button4_Click(object sender, EventArgs e)
        {
            Admin_Main_Menu amm = new Admin_Main_Menu();
            amm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.textBox3.Text = "";
            this.comboBox1.Text = "";
            this.comboBox2.Text = "";

            //Room_ID auato Generate..................................
            {
                int c = 0;
                conn.Open();
                cmd = new SqlCommand("select count(ROOM_ID) from Room_tbl", conn);
                SqlDataReader sda = cmd.ExecuteReader();
                if (sda.Read())
                {
                    c = Convert.ToInt32(sda[0]); c++;
                }

                {
                    textBox1.Text = "Room-00" + c.ToString() + "-" + System.DateTime.Today.Year;
                }

                conn.Close();
            }
        }
        //Add Room in Room table.........................................................................
        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("insert into Room_tbl (CATEGORY,ROOM_TYPE,ROOM_DESCRIPT,ROOM_CHARGES,R_STATUS) VALUES (@CATEGORY,@ROOM_TYPE,@ROOM_DESCRIPT,@ROOM_CHARGES,@R_STATUS)", conn);
            cmd.Parameters.AddWithValue("CATEGORY", this.comboBox1.Text);
            cmd.Parameters.AddWithValue("ROOM_TYPE", this.comboBox2.Text);
            cmd.Parameters.AddWithValue("ROOM_DESCRIPT",this.textBox2.Text );
            cmd.Parameters.AddWithValue("ROOM_CHARGES", this.textBox3.Text+"/=");
            cmd.Parameters.AddWithValue("R_STATUS", "Available");
  
            cmd.ExecuteNonQuery();
            MessageBox.Show("Selected Data has been Inserted ");
            conn.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Room")
            {

                string[] RoomType = {"Single","Double","Triple","Quad","Queen","King","Twin" };
                this.comboBox2.Items.Clear();
                this.comboBox2.Items.AddRange(RoomType);
               
            }
            if (comboBox1.Text == "Hall")
            {
                string[] HallType = { "Small","Medium","Large" };
                this.comboBox2.Items.Clear();
                this.comboBox2.Items.AddRange(HallType);
               
            }
         
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("Select * from Room_tbl where ROOM_ID=@ROOM_ID", conn);
            cmd.Parameters.AddWithValue("@ROOM_ID", comboBox4.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                this.textBox6.Text = dr["CATEGORY"].ToString();
                this.textBox7.Text = dr["ROOM_TYPE"].ToString();
                this.textBox5.Text = dr["ROOM_DESCRIPT"].ToString();
                this.textBox4.Text = dr["ROOM_CHARGES"].ToString();


            }
            conn.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //DELETE ROOM DETAIL.........................................

            conn.Open();
            cmd = new SqlCommand("Delete from Room_tbl where ROOM_ID=@ROOM_ID", conn);
            cmd.Parameters.AddWithValue("@ROOM_ID", comboBox4.Text);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Selected Room Data has been deleted ");
            conn.Close();

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.panel3.Visible = true;
         
            this.label1.Visible = false;
            this.label3.Visible = false;
            this.label4.Visible = false;
            this.label5.Visible = false;
            this.label6.Visible = false;
            this.label7.Visible = false;
            this.button1.Visible = false;
            this.button2.Visible = false;
            this.button3.Visible = false;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            //For HIDING DELETE panel........................................
            this.panel3.Visible = false;
            this.label1.Visible = true;
            this.label3.Visible = true;
            this.label4.Visible = true;
            this.label5.Visible = true;
            this.label6.Visible = true;
            this.label7.Visible = true;
            this.button1.Visible = true;
            this.button2.Visible = true;
            this.button3.Visible = true;

            //Room_ID auato Generate..................................
            {
                int c = 0;
                conn.Open();
                cmd = new SqlCommand("select count(ROOM_ID) from Room_tbl", conn);
                SqlDataReader sda = cmd.ExecuteReader();
                if (sda.Read())
                {
                    c = Convert.ToInt32(sda[0]); c++;
                }

                {
                    textBox1.Text = "Room-00" + c.ToString() + "-" + System.DateTime.Today.Year;
                }

                conn.Close();
            }
        }
    }
}
