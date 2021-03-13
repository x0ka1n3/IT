using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.Red;
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            button2.BackColor = Color.Green;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.BackColor = Color.Blue;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.BackColor = Color.Yellow;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button1.BackColor = SystemColors.Control;
            button2.BackColor = SystemColors.Control;
            button3.BackColor = SystemColors.Control;
            button4.BackColor = SystemColors.Control;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.AutoScroll = true;
            this.BackColor = Color.Bisque;
            label1.Text = label2.Text = "Начало работы";
        }
        
        private void button6_Click(object sender, EventArgs e)
        {
            label1.Text = button6.Text;
        }
        
        private void button7_Click(object sender, EventArgs e)
        {
            label1.Text = button7.Text;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            label2.Visible = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            label2.Visible = true;
        }
    }
}