using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSSE.Utils;

namespace RSSE.ShipElements.Systems
{
    public class MFD : SubSystem
    {
        override public string SystemName { get { return "MFD"; } }
        override public string SystemGroup { get { return "Command"; } }

        public Vector3 UpperLeft { get; set; }
        public Vector3 Dimensions { get; set; }

        public MFD()
        {
            UpperLeft = new Vector3();
            Dimensions = new Vector3();
        }

        public MFD(ShipTable table)
        {
            UpperLeft = new Vector3(table.shipCoords["MFD1"]["UpperLeft"]);
            Dimensions = new Vector3(table.shipCoords["MFD1"]["Dimensions"]);
        }

        override public void AddToTable(ShipTable table)
        {
            table.shipCoords["MFD1"]["UpperLeft"] = UpperLeft.ToTable();
            table.shipCoords["MFD1"]["Dimensions"] = Dimensions.ToTable();
        }
    }
}
