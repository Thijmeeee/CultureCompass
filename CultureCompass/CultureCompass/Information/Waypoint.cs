using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CultureCompass.Information
{
    internal class Waypoint
    {
        public int ID { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string ImagePath { get; set; }
        public string InfoEnglish { get; set; }
        public string InfoFrench { get; set; }
        public string InfoDutch { get; set; }
    }
}

