using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        double calculate(double x)
        {
            if ((Math.Pow(2, (x + 1)) * x + 1 - Math.Pow(Math.E, (5 * x * x - 1))) == 0)
            {
                textBox2.Text = "Знаменатель равен нулю. Деление невозможно";
                return 0;
            }
            double result = (Math.Sin(3 * x) + Math.Pow(Math.E, (1 - x * x))) /
                            (Math.Pow(2, (x + 1)) * x + 1 - Math.Pow(Math.E, (5 * x * x - 1))); 
            return result;
        }

        private double x;
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                x = Convert.ToDouble(textBox1.Text);
                textBox2.Text = "y = " + calculate(x);
            }
            catch (Exception exception)
            {
                textBox2.Text = "Ошибка ввода. Введите число. ";
            }
            if (textBox1.Text.Length == 0) textBox2.Text = "";
        }
    }
}