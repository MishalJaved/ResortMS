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
    public partial class Admin_Login : Form
    {
        SqlCommand cmd;
        SqlDataAdapter sda;
        SqlConnection conn = new SqlConnection(@"Data Source=MISHAL-E-EMAN\SQLEXPRESS;Initial Catalog=RMS_LA;Integrated Security=True");
        
        public Admin_Login()
        {
            InitializeComponent();
        }

        private void Admin_Login_Load(object sender, EventArgs e)
        {
            this.label1.Text = "Resort Management System";
            this.label2.Text = "Welcome To Admin Portal";
            this.Username.Text = "USERNAME:";
            this.Password.Text = "PASSWORD:";

            this.Login_btn.Text = "LOGIN";
            this.Clear_btn.Text = "CLEAR";
            this.Back_btn.Text = "BACK";

            this.AcceptButton = Login_btn;

            this.textBox2.PasswordChar = '*';

            this.textBox1.CharacterCasing = CharacterCasing.Lower;
            this.textBox2.CharacterCasing = CharacterCasing.Lower;
        }

        private void Back_btn_Click(object sender, EventArgs e)
        {
            Login_Screen ls = new Login_Screen();
            ls.Show();
            this.Hide();
        }

        private void Login_btn_Click(object sender, EventArgs e)
        {
            try
            {
                sda = new SqlDataAdapter("select count(*) from LA_tbl where username='" + textBox1.Text + "' and upassword='" + textBox2.Text + "'", conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {

                    Admin_Main_Menu amm = new Admin_Main_Menu();
                    amm.Show();
                    this.Hide();
                }

                else
                {
                    MessageBox.Show("Invalid UserName OR Password!");
                }
            }
            catch (SqlException ex)
            {
                throw ex;



            }
        }

        private void Clear_btn_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
            this.textBox2.Text = "";
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_Click(object sender, EventArgs e)
        {
           
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            
           
        }
    }
}
