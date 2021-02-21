using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValleTemperatures
{
    public partial class MapShow : Form
    {

        private List<PointLatLng> Markers;
        private GMapOverlay MarkersOverlay;

        public MapShow()
        {
            InitializeComponent();
            Markers = new List<PointLatLng>();
            MarkersOverlay = new GMapOverlay("markers");
        }

        
        
        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void Cerrar(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void GMap_Load(object sender, EventArgs e)
        {
            gmap.MapProvider = GoogleMapProvider.Instance;
            GMaps.Instance.Mode = AccessMode.ServerOnly;

            gmap.Position = new PointLatLng(3.416667, -76.516667);
            gmap.Overlays.Add(MarkersOverlay);
        }
    }
}
