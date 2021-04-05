using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void showEl()
        {
            listBox1.Items.Clear();
            for(int i = 0; i < ints.Count; i++)
            {
                listBox1.Items.Add($"Arr[{i}] = {ints[i]}");
            }
            calculate();
        }
        private void showEl2d()
        {
            string matrixRow;
            listBox2.Items.Clear();
            for (int i = 0; i < ints2d.Count; i++)
            {
                matrixRow = "";
                for (int j = 0; j < ints2d[i].Count; j++)
                {
                    matrixRow += $"{ints2d[i][j]}\t";
                }
                listBox2.Items.Add(matrixRow);
            }
        }

        List<int> ints = new List<int>();
        List<List<int>> ints2d = new List<List<int>>();
        Random rand = new Random();

        private void randomize()
        {
            for (int i = 0; i < 10; i++)
            {
                ints.Add(rand.Next(-50, 50));
            }
            showEl();
        }

        private void randomize2dim()
        {
            for(int i = 0; i < 10; i++)
            {
                ints2d.Add(new List<int>() {rand.Next(-50,50), rand.Next(-50,50), rand.Next(-50,50)});
            }
            showEl2d();
        }
        private void Form1_Load(object sender, EventArgs e) {}

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ints.Add(Int32.Parse(textBox1.Text));
                textBox1.Text = "";
                textBox1.Visible = false;
                showEl();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Visible = true;
        }

        private void button2_click(object sender, EventArgs e)
        {
            ints.RemoveAt(listBox1.SelectedIndex);
            showEl();
        }

        private void calculate()
        {
            int mult = 1;
            for(int i = 0; i < ints.Count; i++)
            {
                if (i % 2 == 0) mult *= ints[i];
            }
            textBox2.Text = $"Произведение элементов четных индексов равно {mult}";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ints.Clear();
            randomize();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ints2d.Clear();
            randomize2dim();
        }
    }
}
