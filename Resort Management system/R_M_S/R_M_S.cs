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
    public partial class R_M_S : Form
    {
        public R_M_S()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.label1.Text = "Resort Management System";

            this.button1.Text = "Goto Login Screen";

            this.Text = "R_M_S";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login_Screen ls = new Login_Screen();
            ls.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
