using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValleTemperatures.model;

namespace ValleTemperatures.ui
{
    class Control
    {

        const string PATH = "../data/dataset.csv";

        

        private Controller c = new Controller();

        public void LoadData()
        {

            string[] lines = File.ReadAllLines(PATH);

            foreach (string line in lines)
            {
                string[] values = line.Split(',');
                string cod = values[0];
                char initial1stWord = cod[0];
                if (initial1stWord != 'c')
                {
                    Record newRecord = new Record(values[0], values[1], values[2], Convert.ToDouble(values[3]), values[4], values[5], values[6], values[7], Convert.ToDouble(values[8]), Convert.ToDouble(values[8]), values[10], values[11]);
                    c.AddRecord(newRecord);
                    

                }
            }
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
