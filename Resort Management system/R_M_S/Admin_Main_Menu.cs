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
    public partial class Admin_Main_Menu : Form
    {
        public Admin_Main_Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            A_Room ar = new A_Room();
            ar.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            A_Member_Approval ama = new A_Member_Approval();
            ama.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            A_FoodItems_Insertion afi = new A_FoodItems_Insertion();
            afi.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            A_Service_Provide asp = new A_Service_Provide();
            asp.Show();
            this.Hide();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            A_Employee ae = new A_Employee();
            ae.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            A_Purchase_Order apo = new A_Purchase_Order();
            apo.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            A_Invoice ai = new A_Invoice();
            ai.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            A_GRN ag = new A_GRN();
            ag.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Login_Screen ls = new Login_Screen();
            ls.Show();
            this.Hide();
        }

        private void Admin_Main_Menu_Load(object sender, EventArgs e)
        {

        }
    }
}
