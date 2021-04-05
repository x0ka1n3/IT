using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Lab8
{
    public partial class Form1 : Form
    {
        private double XMin = 0;
        private double XMax = 100;

        private double step = 10;

        private double[] x;
        private double[] y;

        public Form1()
        {
            InitializeComponent();
        }

        public void calcFunc()
        {
            int count = (int)Math.Ceiling((XMax - XMin) / step) + 1;
            x = new double[count];
            y = new double[count];

            for(int i = 0; i < count; i++)
            {
                x[i] = XMin + step * i;
                y[i] = Func(x[i]);
            }
        }

        public double Func(double x)
        {
            return (Math.Sqrt(2 + 3 * Math.Pow(Math.Cos(2 * x), 2) + 2) - 1) / (Math.Pow(2, (1 + Math.Log(x))) - Math.Abs(1 - Math.Sin(Math.Sqrt(2 + x))));
        }

        Chart chart = new Chart();
        private void CreateGraph()
        {
            chart.Parent = this;
            chart.SetBounds(10, 10, ClientSize.Width - 20, ClientSize.Height - 20);
            ChartArea area = new ChartArea();
            area.Name = "График";
            area.AxisX.Minimum = XMin;
            area.AxisX.Maximum = XMax;

            area.AxisX.MajorGrid.Interval = step;
            chart.ChartAreas.Add(area);

            Series series = new Series();
            series.ChartArea = "График";
            series.ChartType = SeriesChartType.Spline;
            series.BorderWidth = 3;
            series.Legend = "График1";
            chart.Series.Add(series);

            //Legend legend = new Legend();
            //chart1.Legends.Add(legend);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CreateGraph();
            calcFunc();

            chart.Series[0].Points.DataBindXY(x, y);
        }
    }
}
