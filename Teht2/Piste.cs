using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teht2
{
    class Piste
    {
        public string Nimi { get; set; }
        public double X { get; set; }
        public double Y { get; set; }

        public Piste()
        {

        }
        public Piste(string nimi, double x, double y)
        {
            Nimi = nimi;
            X = x;
            Y = y;
        }
        public override string ToString()
        {
            return Nimi + " " + X + " " + Y;
        }
    }
}
