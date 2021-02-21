using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValleTemperatures.model;

namespace ValleTemperatures.ui
{
    class Control
    {
        private readonly Controller c = new Controller();
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
