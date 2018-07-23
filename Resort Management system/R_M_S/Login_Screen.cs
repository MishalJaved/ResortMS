using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace R_M_S
{
    public partial class Login_Screen : Form
    {
        public Login_Screen()
        {
            InitializeComponent();
        }

        private void Login_Screen_Load(object sender, EventArgs e)
        {
            this.label1.Text = "Resort Management System";

            this.button1.Text = "ADMIN LOGIN";
            this.button2.Text = "MEMBER LOGIN";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Admin_Login al = new Admin_Login();
            al.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Customer_Login cl = new Customer_Login();
            cl.Show();
            this.Hide();
        }
    }
}
