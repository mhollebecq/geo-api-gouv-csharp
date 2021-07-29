using System;
using System.Collections.Generic;
using System.Text;

namespace GeoAPI
{
    public class Departement
    {
        public string Code { get; set; }
        public string Nom { get; set; }
        public string CodeRegion { get; set; }
        public Region Region { get; set; }
        public float _Score { get; set; }
    }
}
