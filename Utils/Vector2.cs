using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE
{
    public class Vector2
    {
        public double x { get; set; }
        public double y { get; set; }

        public Vector2() { }

        public Vector2( double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public Vector2(Table table)
        {
            x = table["x"].Value;
            y = table["y"].Value;
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
