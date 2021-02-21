using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValleTemperatures.ui;
using Control = ValleTemperatures.ui.Control;

namespace ValleTemperatures
{
    public partial class TableShow : Form
    {
        private readonly Control c = new Control();
        public TableShow()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ShowMap(object sender, EventArgs e)
        {
            MessageBox.Show("Se ha generado el mapa con los sensores");

            MapShow map = new MapShow();
            map.Show();
        }

        private void ShowCharts(object sender, EventArgs e)
        {
            MessageBox.Show("Se han generado las graficas");


            ChartShow chart = new ChartShow(c.RetrieveTempData(), c.RetrieveZonaData(), c.RetrieveCantidadData());
            chart.Show();
        }
    }
}
