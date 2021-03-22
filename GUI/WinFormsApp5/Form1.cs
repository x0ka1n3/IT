using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace WinFormsApp5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int factorial(int x)
        {
            if (x == 0) return 1;
            else return x * factorial(x - 1);
        }

        double calculateSum(double eps)
        {
            double sum = 0;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 1; ; i++)
            {
                if (sw.ElapsedMilliseconds > 5000) return -1;
                double slag = (5 + i) / (double)(3*factorial(i) - 1);
                if (Math.Abs(slag - (5 + i - 1) / (double)(3 * factorial(i - 1) - 1)) < eps) break;
                else sum += slag;
            }
            return sum;
        }

        double calculateMult(int limit)
        {
            double mult = 1;
            for (int i = 2; i <= limit; i++) mult *= (double)(0.5 * factorial(i)) / (0.1 * i + 1);
            return mult;
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (sender == radioButton1) label1.Text = "Введите точность";
                else if (sender == radioButton2) label1.Text = "Введите верхний предел";

                try
                {
                    if (radioButton1.Checked) textBox1.Text = "y = " + calculateSum(double.Parse(textBox2.Text));
                    else textBox1.Text = "y = " + calculateMult(int.Parse(textBox2.Text));
                }
                catch
                {
                    textBox1.Text = "Ошибка ввода, введите число";
                }
                if (textBox2.Text == "") textBox1.Text = "Введите число";
            }
        }
    }
}
