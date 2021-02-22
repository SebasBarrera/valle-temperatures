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

        

        private  Control c = new Control();
        public TableShow()
        {
            InitializeComponent();
            LoadData();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void LoadData()
        {
            
          

            OpenFileDialog fileExplorer = new OpenFileDialog();
            if (fileExplorer.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string absolutePathFile = fileExplorer.FileName;
                   

                    if (absolutePathFile.Contains(".csv"))
                    {
                        
                        List<string[]> rowsDvg = c.LoadData(absolutePathFile);
                       
                        dgv.AllowUserToAddRows = false;
                        showGrid(rowsDvg);
                        this.Show();
                        this.BringToFront();

                    }
                    else
                    {
                        MessageBox.Show("Error, no se puede leer el archivo seleccionado.");
                       
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }

            }
        }

        private void showGrid(List<string[]> rowsDvg)
        {
            dgv.Rows.Clear();
           
            foreach (string[] line in rowsDvg)
            {

                DataGridViewRow dataGridViewRow = new DataGridViewRow();
                dataGridViewRow.CreateCells(dgv);
                
                for (int i = 0; i<12; i++) 
                {
                    dataGridViewRow.Cells[i].Value = line[i];
                    if (i==11)
                    {
                        dgv.Rows.Add(dataGridViewRow);
                    }

                }


               

            }
        }

        private void ShowMap(object sender, EventArgs e)
        {
            MessageBox.Show("Se ha generado el mapa con los sensores");

            MapShow map = new MapShow(c.Coordenadas());
            map.Show();
        }

        private void ShowCharts(object sender, EventArgs e)
        {
            MessageBox.Show("Se han generado las graficas");


            ChartShow chart = new ChartShow(c.RetrieveTempData(), c.RetrieveZonaData(), c.RetrieveCantidadData());
            chart.Show();
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_ControlAdded(object sender, ControlEventArgs e)
        {

        }

        private void dgv_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnMunicipio_Click(object sender, EventArgs e)
        {
            //TODO GONZALO
        }

        private void btnZona_Click(object sender, EventArgs e)
        {
            //TODO GONZALO
        }

        private void btnTemperaturas_Click(object sender, EventArgs e)
        {
            //TODO GONZALO
        }
    }
}
