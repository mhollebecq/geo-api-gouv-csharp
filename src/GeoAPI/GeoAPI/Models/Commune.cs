using System;
using System.Collections.Generic;
using System.Text;

namespace GeoAPI
{
    public class Commune
    {
        public string Code { get; set; }
        public string Nom { get; set; }
        public string[] CodesPostaux { get; set; }
        public string CodeDepartement { get; set; }
        public string CodeRegion { get; set; }
        public int Population { get; set; }
        public float _Score { get; set; }

        public Departement Departement { get; set; }
        public Region Region { get; set; }

        public int? Surface { get; set; }

        public Point Centre { get; set; }

        public Polygon Contour { get; set; }
    }
}
