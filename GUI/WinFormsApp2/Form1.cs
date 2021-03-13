using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            generateField();
        }

        private int[,] field = new int[3, 3];

        void generateField()
        {
            Random rand = new Random();

            for (int i = 0; i < 9; i++)
            {
                field[i / 3, i % 3] = rand.Next(0, 2);
            }

            string s = "";
            for (int i = 0; i < 9; i++)
            {
                s += field[i / 3, i % 3];
                if ((i+1) % 3 == 0) s += "\n";
            }
            label1.Text = s;
        }


        void server(object sender, EventArgs e)
        {
            int senderNum = Convert.ToInt32((sender as Button).Name.Last().ToString()) - 1;
            if (field[senderNum / 3, senderNum % 3] == 1)
            {
                label3.Text = "Смерть";
                (sender as Button).BackColor = Color.Firebrick;
                (sender as Button).Text = "МИНА";
            }
            else
            {
                var curX = senderNum % 3;
                var curY = senderNum / 3;

                var mineNum = 0;
                try { if (field[curY, curX + 1] == 1) mineNum += 1; }
                catch (Exception exception) { }
                try { if (field[curY, curX - 1] == 1) mineNum += 1; }
                catch (Exception exception) { }
                try { if (field[curY + 1, curX] == 1) mineNum += 1; }
                catch (Exception exception) { }
                try { if (field[curY - 1, curX] == 1) mineNum += 1; }
                catch (Exception exception) { }
                try { if (field[curY - 1, curX - 1] == 1) mineNum += 1; }
                catch (Exception exception) { }
                try { if (field[curY - 1, curX + 1] == 1) mineNum += 1; }
                catch (Exception exception) { }
                try { if (field[curY + 1, curX - 1] == 1) mineNum += 1; }
                catch (Exception exception) { }
                try { if (field[curY + 1, curX + 1] == 1) mineNum += 1; }
                catch (Exception exception) { }

                (sender as Button).Text = mineNum.ToString();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Text = button2.Text = button3.Text = 
                button4.Text = button5.Text = button6.Text =
                    button7.Text = button8.Text = button9.Text ="";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form f2 = new Form2();
            f2.Show();
            this.Hide();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.Show();
        }
    }
}