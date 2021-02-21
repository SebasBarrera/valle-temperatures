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
        public ChartShow(List<string[]> info1, List<string[]> info2, List<string[]> info3) // info1 temperatura por municipio, info2 zona hidrografica, info3 cantidad sensores por municipio
        {
            InitializeComponent();

            chart1.Titles.Add("grafico de puntos");
            chart2.Titles.Add("grafico circular");
            chart1.Titles.Add("grafico de barras");

            chart1.Series["puntos"].IsValueShownAsLabel = true;
            chart2.Series["pie"].IsValueShownAsLabel = true;
            chart3.Series["barras"].IsValueShownAsLabel = true;

            punto(info1);
            pie(info2);
            barra(info3);

            chart1.Series["puntos"].Points.AddXY("");
            chart2.Series["pie"].Points.AddXY("");
            chart3.Series["barras"].Points.AddXY("");
        }

        private void punto(List<string[]> info) //info[0] temperatura, info[1] municipio
        {
            foreach (string[] i in info)
            {
                chart1.Series["puntos"].Points.AddXY(i[1], i[0]);
            }
        }
        private void pie(List<string[]> info) //info[0] cantidad, info[1] Zona Hidrografica
        {
            foreach (string[] i in info)
            {
                chart2.Series["pie"].Points.AddXY(i[1], i[0]);
            }
        }
        private void barra(List<string[]> info) //info[0] cantidad, info[1] municipio
        {
            foreach (string[] i in info)
            {
                chart3.Series["barras"].Points.AddXY(i[1], i[0]);
            }
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
