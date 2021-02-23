using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ValleTemperatures.ui
{
    public partial class ChartShow : Form
    {
        public ChartShow(List<string[]> info1, List<string[]> info2, List<string[]> info3) // info1 temperatura por municipio, info2 zona hidrografica, info3 cantidad sensores por municipio
        {
            InitializeComponent();

            chart1.Titles.Add("Temperatura promedio por municipio");
            chart2.Titles.Add("Cantidad de municipios por zona hidrografica");
            chart3.Titles.Add("Cantidad de registros de temperatura por municipio");

            chart1.Series["Temperatura promedio"].IsValueShownAsLabel = true;
            chart2.Series["pie"].IsValueShownAsLabel = true;
            chart3.Series["barras"].IsValueShownAsLabel = true;

            Punto(info1);
            Pie(info2);
            Barra(info3);

            //chart1.Series["puntos"].Points.AddXY("");
            //chart2.Series["pie"].Points.AddXY("");
            //chart3.Series["barras"].Points.AddXY("");
        }

        private void Punto(List<string[]> info) //info[0] temperatura, info[1] municipio
        {
            int count = 1;
            foreach (string[] i in info)
            {
                if (count == 1)
                {
                    MessageBox.Show("Temperatura promedio por municipio" + i[1] + i[0]);
                    count++;
                }
                double a = Convert.ToDouble(i[0], CultureInfo.InvariantCulture);
                var separator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
                string b = Regex.Replace(i[0], "[.,]", separator);
                chart1.Series["Temperatura promedio"].Points.AddXY(i[1], a);
            }
        }
        private void Pie(List<string[]> info) //info[0] cantidad, info[1] Zona Hidrografica
        {
            int count = 1;
            foreach (string[] i in info)
            {
                if (count == 1)
                {
                    MessageBox.Show("Cantidad de municipios por zona hidrografica" + i[1] + i[0]);
                    count++;
                }
                chart2.Series["pie"].Points.AddXY(i[0], i[1]);
            }
        }
        private void Barra(List<string[]> info) //info[0] cantidad, info[1] municipio
        {
            int count = 1;
            foreach (string[] i in info)
            {
                if (count == 1)
                {
                    MessageBox.Show("Cantidad de registros de temperatura por municipio" + i[1] + i[0]);
                    count++;
                }
                chart3.Series["barras"].Points.AddXY(i[0], i[1]);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Chart2_Click(object sender, EventArgs e)
        {

        }

        private void Button_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

    }
}
