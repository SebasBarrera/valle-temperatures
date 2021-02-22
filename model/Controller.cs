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
        Hashtable cantidadRegistrosPorMunicipio;

        public Controller()
        {
            Records = new List<Record>();
            promedioTemperaturaPorMunicipio = new Hashtable();
            cantidadZonaHidrografica = new Hashtable();
            cantidadRegistrosPorMunicipio = new Hashtable();
        }

        

        public void AddRecord(Record rec)
        {
            Records.Add(rec);

            int oneUnit = 1;
            double[] arrayForAverage = {0,0};

            if (promedioTemperaturaPorMunicipio.ContainsKey(rec.Mun))
            {
                //arrayForAverage[] = promedioTemperaturaPorMunicipio[rec.Mun];

                object[] objArray= promedioTemperaturaPorMunicipio[rec.Mun] as object[];

                if (objArray != null)
                {
                    arrayForAverage = objArray.OfType<double>().ToArray();

                    arrayForAverage[0] = arrayForAverage[0] + rec.Temperatura;
                    arrayForAverage[1] = arrayForAverage[1] + 1;
                
                    promedioTemperaturaPorMunicipio[rec.Mun] = arrayForAverage;
                }

                
            }
            else
            {
                arrayForAverage[0] = rec.Temperatura;
                arrayForAverage[1] = 1;
                promedioTemperaturaPorMunicipio.Add(rec.Mun , arrayForAverage);
            }
            

            if (cantidadZonaHidrografica.ContainsKey(rec.Zona))
            {
                cantidadZonaHidrografica[rec.Zona] = ((int) cantidadZonaHidrografica[rec.Zona]) + 1;
            }
            else
            {
                
                cantidadZonaHidrografica.Add(rec.Zona, oneUnit);
            }


            if (cantidadRegistrosPorMunicipio.ContainsKey(rec.Mun))
            {
                 cantidadRegistrosPorMunicipio[rec.Mun] = ((int) cantidadRegistrosPorMunicipio[rec.Mun]) + 1;
            }
            else
            {
                cantidadRegistrosPorMunicipio.Add(rec.Mun, oneUnit);
            }
        }

        internal List<double[]> Coordenadas()
        {
            List<double[]> datos = new List<double[]>();
            
            for (int i = 0; i < 100; i++)
            {
                double[] cor = new double[2];
                cor[0] = Records.ElementAt(i).Lat;
                cor[1] = Records.ElementAt(i).Lon;
                datos.Add(cor);
            }
            return datos;
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
