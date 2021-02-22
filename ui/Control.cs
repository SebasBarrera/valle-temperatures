using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValleTemperatures.model;

namespace ValleTemperatures.ui
{
    class Control
    {
        
        

        private Controller c = new Controller();

        public List<string[]> LoadData(string path)
        {
                 List<string[]> rowsList = new List<string[]>();
                 try
                 {
                     string[] lines = File.ReadAllLines(path);

                     for (int i = 0; i <5000; i++)
                     {
                         string[] values = lines[i].Split(','); 
                         Record newRecord = new Record(values[0], values[1], values[2], Convert.ToDouble(values[3]), values[4], values[5], values[6], values[7], Convert.ToDouble(values[8]), Convert.ToDouble(values[9]), values[10], values[11]);
                         c.AddRecord(newRecord);
                         rowsList.Add(values);
                     }
                 }
                 catch (Exception ex)
                 {
                     MessageBox.Show("FAIL");
                 }


                 return rowsList;
         }



        public List<double[]> Coordenadas()
        {
            return c.Coordenadas();
        }

        public List<string[]> RetrieveTempData()
        {
            return c.TemperaturaCiudad();
        }

        public List<string[]> RetrieveZonaData()
        {
            return c.CantidadZona();
        }

        public List<string[]> RetrieveCantidadData()
        {
            return c.CandidadMunicipio();
        }
    }
}
