using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RSSE
{
    public class MFD : Subsystem
    {
        override public SubsystemTypeEnum SystemType { get { return SubsystemTypeEnum.MFD; } }
        override public string SystemGroup { get { return "Command"; } }

        public Vec3 upperLeft;
        public Vec3 dimensions;

        public MFD()
        {
            upperLeft = new Vec3();
            dimensions = new Vec3();
        }

        public MFD(ShipHullTable table)
        {
            upperLeft = new Vec3(table.shipCoords["MFD1"]["UpperLeft"]);
            dimensions = new Vec3(table.shipCoords["MFD1"]["Dimensions"]);
        }

        override public void AddToTable(ShipHullTable table)
        {
            table.shipCoords["MFD1"]["UpperLeft"] = upperLeft.ToTable();
            table.shipCoords["MFD1"]["Dimensions"] = dimensions.ToTable();
        }
    }
}
