using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE
{
    public class Color
    {
        public double r { get; set; }
        public double g { get; set; }
        public double b { get; set; }

        public Color()
        { }

        public Color(double r, double g, double b)
        {
            this.r = r;
            this.g = g;
            this.b = b;
        }

        public Color(Table table)
        {
            r = table["r"].DoubleValue;
            g = table["g"].DoubleValue;
            b = table["b"].DoubleValue; 
        }

        public Table ToTable()
        {
            Table table = new Table();
            table["r"].Value = r;
            table["g"].Value = g;
            table["b"].Value = b;
            return table;
        }
    }
}
