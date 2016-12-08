using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE
{
    public class Vector3
    {
        public double x { get; set; }
        public double y { get; set; }
        public double z { get; set; }

        public Vector3()
        {
            x = 0;
            y = 0;
            z = 0;
        }

        public Vector3(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Vector3(Table table)
        {
            if (table.Count > 0)
            {
                x = table["x"].Value;
                y = table["y"].Value;
                z = table["z"].Value;
            }
            else
            {
                x = 0;
                y = 0;
                z = 0;
            }
        }

        public Table ToTable()
        {
            Table table = new Table();
            table["x"].Value = x;
            table["y"].Value = y;
            table["z"].Value = z;
            return table;
        }
    }

}
