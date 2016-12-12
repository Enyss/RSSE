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

        public Vector3 upperLeft;
        public Vector3 dimensions;

        public MFD()
        {
            upperLeft = new Vector3();
            dimensions = new Vector3();
        }

        public MFD(ShipHullTable table)
        {
            upperLeft = new Vector3(table.shipCoords["MFD1"]["UpperLeft"]);
            dimensions = new Vector3(table.shipCoords["MFD1"]["Dimensions"]);
        }

        override public void AddToTable(ShipHullTable table)
        {
            table.shipCoords["MFD1"]["UpperLeft"] = upperLeft.ToTable();
            table.shipCoords["MFD1"]["Dimensions"] = dimensions.ToTable();
        }
    }
}
