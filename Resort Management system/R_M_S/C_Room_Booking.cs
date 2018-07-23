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
    public partial class C_Room_Booking : Form
    {
         SqlCommand cmd;
        SqlDataAdapter sda;
        SqlConnection conn = new SqlConnection(@"Data Source=MISHAL-E-EMAN\SQLEXPRESS;Initial Catalog=Resort_Management_System;Integrated Security=True");
        public C_Room_Booking()
        {
            InitializeComponent();
        }

        private void C_Room_Booking_Load(object sender, EventArgs e)
        {
            this.Text = "Room_Booking";


            //Room_BOOK_ID auato Generate..................................
            {
                int c = 0;
                conn.Open();
                cmd = new SqlCommand("select count(R_BOOK_ID) from Room_Booking_tbl", conn);
                SqlDataReader sda = cmd.ExecuteReader();
                if (sda.Read())
                {
                    c = Convert.ToInt32(sda[0]); c++;
                }

                {
                    textBox1.Text = "RB-00" + c.ToString() + "-" + System.DateTime.Today.Year;
                }

                conn.Close();
            }

            this.textBox1.ReadOnly = true;

            //Room Category......................
            string[] Category = { "Room", "Hall" };

            this.comboBox1.Items.AddRange(Category);
          //  ...................................................................

          /*  //Populate Room ID.............................

            conn.Open();
            cmd = new SqlCommand("select ROOM_ID from Room_tbl", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                comboBox1.Items.Add(dr["ROOM_ID"].ToString());

            }
            conn.Close();
            */
            //Populate Member ID
            {
                conn.Open();
                cmd = new SqlCommand("select MEMBER_ID from Member_tbl", conn);
                SqlDataReader dr1 = cmd.ExecuteReader();
                while (dr1.Read())
                {

                    comboBox2.Items.Add(dr1["MEMBER_ID"].ToString());

                }
                conn.Close();

            }
            

               
            


        }

        private void button4_Click(object sender, EventArgs e)
        {
            Customer_Main_Menu cmm = new Customer_Main_Menu();
            cmm.Show();
            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
           {
                //Room Booking....................................................

                conn.Open();
                cmd = new SqlCommand("insert into Room_Booking_tbl (MEMBER_ID,MEMBER_NAME,MEMBER_TYPE,PHONE_NO,NO_OF_PERSON,ROOM_ID,CATEGORY,ROOM_TYPE,ROOM_DESCRIPT,ROOM_CHARGES,T_NO_DAYS) VALUES (@MEMBER_ID,@MEMBER_NAME,@MEMBER_TYPE,@PHONE_NO,@NO_OF_PERSON,@ROOM_ID,@CATEGORY,@ROOM_TYPE,@ROOM_DESCRIPT,@ROOM_CHARGES,@T_NO_DAYS)", conn);

              //  cmd.Parameters.AddWithValue("R_BOOK_ID", textBox1.Text);
               cmd.Parameters.AddWithValue("MEMBER_ID", comboBox2.Text);
                cmd.Parameters.AddWithValue("MEMBER_NAME", textBox2.Text);
                cmd.Parameters.AddWithValue("MEMBER_TYPE", textBox7.Text);
                cmd.Parameters.AddWithValue("PHONE_NO", textBox4.Text);
                cmd.Parameters.AddWithValue("NO_OF_PERSON", textBox3.Text);
                cmd.Parameters.AddWithValue("ROOM_ID", this.textBox5.Text);
                cmd.Parameters.AddWithValue("CATEGORY", comboBox1.Text);
                cmd.Parameters.AddWithValue("ROOM_TYPE", comboBox3.Text);
                cmd.Parameters.AddWithValue("ROOM_DESCRIPT", textBox9.Text);
                cmd.Parameters.AddWithValue("ROOM_CHARGES", textBox8.Text);
               cmd.Parameters.AddWithValue("T_NO_DAYS", textBox6.Text);
                 // cmd.Parameters.AddWithValue("CHECK_IN",dateTimePicker1.Text);
                 // cmd.Parameters.AddWithValue("CHECK_OUT",dateTimePicker2.Text);
               
                cmd.ExecuteNonQuery();
                MessageBox.Show("Selected Data has been Inserted ");
                conn.Close();
            }
}
        

        private void button3_Click(object sender, EventArgs e)
        {
            this.textBox1.Text="";
            this.textBox2.Text="";
            this.textBox3.Text="";
            this.textBox4.Text="";
            this.textBox5.Text="";
            this.textBox6.Text="";
            this.textBox7.Text = "";
            this.textBox8.Text = "";
            this.textBox9.Text = "";

            this.comboBox1.Text="";
            this.comboBox2.Text="";
            this.comboBox3.Text = "";
           

            dateTimePicker1.Text="";
            dateTimePicker2.Text="";
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("Select * from Member_tbl where MEMBER_ID=@MEMBER_ID", conn);
            cmd.Parameters.AddWithValue("@MEMBER_ID",comboBox2.Text );
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                this.textBox2.Text = dr["MEMBER_NAME"].ToString();
                this.textBox7.Text = dr["MEMBER_TYPE"].ToString();
                this.textBox4.Text = dr["PHONE_NO"].ToString();
              
            }
            conn.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Room")
            {

                string[] RoomType = { "Single", "Double", "Triple", "Quad", "Queen", "King", "Twin" };
                this.comboBox3.Items.Clear();
                this.comboBox3.Items.AddRange(RoomType);

            }
            if (comboBox1.Text == "Hall")
            {
                string[] HallType = { "Small", "Medium", "Large" };
                this.comboBox3.Items.Clear();
                this.comboBox3.Items.AddRange(HallType);

            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("Select * from Room_tbl where ROOM_TYPE=@ROOM_TYPE AND R_STATUS='Available'", conn);
            cmd.Parameters.AddWithValue("@ROOM_TYPE", comboBox3.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                this.textBox5.Text = dr["ROOM_ID"].ToString();
                this.textBox9.Text = dr["ROOM_DESCRIPT"].ToString();
                this.textBox8.Text = dr["ROOM_CHARGES"].ToString();
            }
            conn.Close();


        }
    }
}
