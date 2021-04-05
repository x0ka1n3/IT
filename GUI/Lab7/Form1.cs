using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<List<int>> ints2d = new List<List<int>>();
        Random rand = new Random();

        private void randomize2dim()
        {
            ints2d.Clear();
            
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                List<int> row = new List<int>();
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    row.Add(rand.Next(-50,50));

                ints2d.Add(row);
                //row.Clear();
            }
            //textBox3.Text = ints2d[0][0].ToString();
        }

        private int[] findMinMax()
        {
            int max = ints2d[0][0];
            int indexMax = 0;

            int min = ints2d[0][0];
            int indexMin = 0;

            for (int i = 0; i < ints2d.Count; i++)
            {
                for(int j = 0; j < ints2d[i].Count; j++)
                {
                    if (ints2d[i][j] > max) { max = ints2d[i][j]; indexMax = j; }
                    if (ints2d[i][j] < min) { min = ints2d[i][j]; indexMin = j; }
                }
            }
            int[] ret = new int[] { indexMin, indexMax };
            return ret;
        }

        private void nullify()
        {
            int[] indexes = findMinMax();
            for (int i = 0; i < ints2d.Count; i++)
            {
                ints2d[i][indexes[0]] = 0;
                ints2d[i][indexes[1]] = 0;
            }
        }

        private void showMatrix()
        {
            for (int i = 0; i < ints2d.Count; i++)
            {
                for (int j = 0; j < ints2d[i].Count; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = ints2d[i][j];
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            randomize2dim();
            showMatrix();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.RowCount = int.Parse(textBox2.Text);
            dataGridView1.ColumnCount = int.Parse(textBox1.Text);
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                Form1_Load(sender, e);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            nullify();
            showMatrix();
        }
    }
}
