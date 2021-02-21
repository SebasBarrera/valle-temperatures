using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValleTemperatures.ui
{
    public partial class ChartShow : Form
    {
        public ChartShow(List<string[]> info)
        {
            InitializeComponent();

            chart1.Titles.Add("grafico de puntos");
            chart2.Titles.Add("grafico circular");
            chart1.Titles.Add("grafico de barras");

            chart1.Series["puntos"].IsValueShownAsLabel = true;
            chart2.Series["pie"].IsValueShownAsLabel = true;
            chart3.Series["barras"].IsValueShownAsLabel = true;

            foreach (string[] i in info)
            {
                int mun = Convert.ToInt32(i[0]);
                if (mun > 10)
                {

                }
            }

            chart1.Series["puntos"].Points.AddXY("");
            chart2.Series["pie"].Points.AddXY("");
            chart3.Series["barras"].Points.AddXY("");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }

         private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

    }
}
