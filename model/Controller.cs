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
            AddRecord2Hashtables(rec);
        }

        public void AddRecord2Hashtables(Record rec)
        {
            

            int oneUnit = 1;
            double[] arrayForAverage = { 0, 0 };

            if (promedioTemperaturaPorMunicipio.ContainsKey(rec.Mun))
            {
                //arrayForAverage[] = promedioTemperaturaPorMunicipio[rec.Mun];

                object[] objArray = promedioTemperaturaPorMunicipio[rec.Mun] as object[];

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
                promedioTemperaturaPorMunicipio.Add(rec.Mun, arrayForAverage);
            }


            if (cantidadZonaHidrografica.ContainsKey(rec.Zona))
            {
                cantidadZonaHidrografica[rec.Zona] = ((int)cantidadZonaHidrografica[rec.Zona]) + 1;
            }
            else
            {

                cantidadZonaHidrografica.Add(rec.Zona, oneUnit);
            }


            if (cantidadRegistrosPorMunicipio.ContainsKey(rec.Mun))
            {
                cantidadRegistrosPorMunicipio[rec.Mun] = ((int)cantidadRegistrosPorMunicipio[rec.Mun]) + 1;
            }
            else
            {
                cantidadRegistrosPorMunicipio.Add(rec.Mun, oneUnit);
            }
        }

       

        public List<string[]> FilterByMun(string comboBoxText)
        {
            List<string[]> rowsDvg = new List<string[]>();
            promedioTemperaturaPorMunicipio.Clear();
            cantidadZonaHidrografica.Clear();
            cantidadRegistrosPorMunicipio.Clear();

            foreach (Record mun in Records)
            {
                string munName = mun.Mun;
                if (munName.Equals(comboBoxText))
                {
                    string[] line = mun.TransformRecord2String();
                    rowsDvg.Add(line);
                    AddRecord2Hashtables(mun);
                }
            }



            return rowsDvg;
        }



        public List<string[]> FilterByZona(string textBoxText)
        {
            List<string[]> rowsDvg = new List<string[]>();
            promedioTemperaturaPorMunicipio.Clear();
            cantidadZonaHidrografica.Clear();
            cantidadRegistrosPorMunicipio.Clear();

            foreach (Record mun in Records)
            {
                string munZona = mun.Zona;
                if (munZona.Contains(textBoxText))
                {
                    string[] line = mun.TransformRecord2String();
                    rowsDvg.Add(line);
                    AddRecord2Hashtables(mun);
                }
            }



            return rowsDvg;
        }



        public List<string[]> FilterByTempRange(string comboBoxText)
        {
            List<string[]> rowsDvg = new List<string[]>();
            promedioTemperaturaPorMunicipio.Clear();
            cantidadZonaHidrografica.Clear();
            cantidadRegistrosPorMunicipio.Clear();

            foreach (Record mun in Records)
            {
                string munName = mun.Mun;
                if (munName.Equals(comboBoxText))
                {
                    string[] line = mun.TransformRecord2String();
                    rowsDvg.Add(line);
                    AddRecord2Hashtables(mun);
                }
            }



            return rowsDvg;
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
            foreach (DictionaryEntry i in cantidadRegistrosPorMunicipio)
            {
                string[] dato = new string[2];

                dato[0] = (string)i.Key;
                dato[1] = "" + i.Value;
                datos.Add(dato);
            }

            return datos;
        }

        public List<string[]> TemperaturaCiudad()
        {
            List<string[]> datos = new List<string[]>();
            foreach (DictionaryEntry i in promedioTemperaturaPorMunicipio)
            {
                string[] dato = new string[2];

                dato[0] = (string)i.Key;
                dato[1] = i.Value + "";
                datos.Add(dato);
            }

            return datos;
        }

        public List<string[]> CantidadZona()
        {
            List<string[]> datos = new List<string[]>();
            foreach (DictionaryEntry i in cantidadZonaHidrografica)
            {
                string[] dato = new string[2];

                dato[0] = (string)i.Key;
                dato[1] = "" + i.Value;
                datos.Add(dato);
            }

            return datos;
        }
    }
}
