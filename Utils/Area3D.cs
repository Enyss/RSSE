using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE
{
    public class Area3D
    {
        public Vec3 PointA { get; set; }
        public Vec3 PointB { get; set; }

        public Area3D()
        {
            PointA = new Vec3();
            PointB = new Vec3();
        }
        public Area3D( Vec3 pointA, Vec3 pointB )
        {
            PointA = pointA;
            PointB = pointB;
        }

        // Temporary?
        public Area3D(Table table)
        {
            PointA = new Vec3(table["x1"].Value, table["y1"].Value, table["z1"].Value);
            PointB = new Vec3(table["x2"].Value, table["y2"].Value, table["z2"].Value);
        }

        public Table ToTable()
        {
            Table table = new Table();
            table["PointA"] = PointA.ToTable();
            table["PointB"] = PointB.ToTable();
            return table;
        }

        public Table ToTable2()
        {
            Table table = new Table();

            table["x1"].Value = PointA.x;
            table["y1"].Value = PointA.y;
            table["z1"].Value = PointA.z;

            table["x2"].Value = PointB.x;
            table["y2"].Value = PointB.y;
            table["z2"].Value = PointB.z;

            return table;
        }
    }
}
