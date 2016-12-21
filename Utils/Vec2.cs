using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE
{
    public class Vec2
    {
        public double x { get; set; }
        public double y { get; set; }

        public Vec2() { }

        public Vec2( double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public Vec2(Table table)
        {
            x = table["x"].DoubleValue;
            y = table["y"].DoubleValue;
        }

        public Table ToTable()
        {
            Table table = new Table();
            table["x"].Value = x;
            table["y"].Value = y;
            return table;
        }
    }
}
