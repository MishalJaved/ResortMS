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
    public partial class Customer_Main_Menu : Form
    {
        public Customer_Main_Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            C_Room_Booking crb = new C_Room_Booking();
            crb.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            C_Service_Avail csa = new C_Service_Avail();
            csa.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            C_Bill_Payment cbp = new C_Bill_Payment();
            cbp.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            C_Member_Regs cmg = new C_Member_Regs();
            cmg.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Login_Screen ls = new Login_Screen();
            ls.Show();
            this.Hide();
        }
    }
}
