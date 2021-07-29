using System;
using System.Collections.Generic;
using System.Text;

namespace GeoAPI
{
    public struct Polygon
    {
        public string Type { get; set; }
        public float[][][] Coordinates { get; set; }
    }
}
