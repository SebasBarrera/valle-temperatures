using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValleTemperatures.model
{
    class Controller
    {

        List<Record> Records;
        Hashtable promedioTemperaturaPorMunicipio;
        Hashtable cantidadZonaHidrografica;
        Hashtable cantidadSensoresPorMunicipio;

        public Controller()
        {
            Records = new List<Record>();
            promedioTemperaturaPorMunicipio = new Hashtable();
            cantidadZonaHidrografica = new Hashtable();
            cantidadSensoresPorMunicipio = new Hashtable();
        }

        

        public void AddRecord(Record rec)
        {
            Records.Add(rec);
            if (!openWith.ContainsKey(rec))
            {

            }
            
        }




        public List<string[]> CandidadMunicipio()
        {
            List<string[]> datos = new List<string[]>();


            return datos;
        }

        public List<string[]> TemperaturaCiudad()
        {
            List<string[]> datos = new List<string[]>();


            return datos;
        }

        public List<string[]> CantidadZona()
        {
            List<string[]> datos = new List<string[]>();


            return datos;
        }
    }
}
