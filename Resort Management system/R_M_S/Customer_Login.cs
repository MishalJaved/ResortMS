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
    public partial class Customer_Login : Form
    {
        SqlCommand cmd;
        SqlDataAdapter sda;
        SqlConnection conn = new SqlConnection(@"Data Source=MISHAL-E-EMAN\SQLEXPRESS;Initial Catalog=RMS_LM;Integrated Security=True");
        public Customer_Login()
        {
            InitializeComponent();
        }

        private void Customer_Login_Load(object sender, EventArgs e)
        {
            this.label1.Text = "Resort Management System";
            this.label2.Text = "Welcome To Member Portal";
            this.Username.Text = "USERNAME:";
            this.Password.Text = "PASSWORD:";

            this.Login_btn.Text = "LOGIN";
            this.Clear_btn.Text = "CLEAR";
            this.Back_btn.Text = "BACK";

            this.AcceptButton = Login_btn;

            this.textBox2.PasswordChar ='*';

            this.textBox1.CharacterCasing = CharacterCasing.Lower;
            this.textBox2.CharacterCasing = CharacterCasing.Lower;
        }

        private void Login_btn_Click(object sender, EventArgs e)
        {
            try
            {
                sda = new SqlDataAdapter("select count(*) from LM_tbl where username='" + textBox1.Text + "' and upassword='" + textBox2.Text + "'", conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {

                    Customer_Main_Menu Cmm = new Customer_Main_Menu();
                    Cmm.Show();
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

        private void Back_btn_Click(object sender, EventArgs e)
        {
            Login_Screen ls = new Login_Screen();
            ls.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
