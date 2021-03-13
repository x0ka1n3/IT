using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private double x;

        double f(double x)
        {
            if (radioButton1.Checked) return Math.Sinh(x);
            if (radioButton2.Checked) return Math.Cosh(x);
            if (radioButton3.Checked) return Math.Exp(x);
            return 0;
        }
        double calculate(double x)
        {
            double result = 0;
            if (x > 2) result = Math.Pow(f(x), 2);
            if (x > -1 && x <= 2) result = 0.5*f(x);
            if (x <= -1) result = Math.Abs(f(x) + 1);
            return result;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            { 
                x = double.Parse(textBox1.Text);
                textBox2.Text = "y = " + calculate(x);
            }
            catch 
            { 
                textBox2.Text = "Ошибка ввода. Введите число.";
            }

            if (textBox1.Text == "") textBox2.Text = "Введите число";
        }
    }
}
