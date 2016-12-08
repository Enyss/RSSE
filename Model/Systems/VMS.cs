using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSSE.Utils;

namespace RSSE.ShipElements.Systems
{
    public class VMS : SubSystem 
    {

        override public string SystemName { get { return "VMS"; } }
        override public string SystemGroup { get { return "Command"; } }

        public Vector2 Dimensions { get; set; }
        public double normFOV { get; set;}

        public VMS ()
        {
            Dimensions = new Vector2();
        }

        public VMS(ShipTable table)
        {
            Dimensions = new Vector2(table.shipCoords["VMS1"]["Dimensions"]);
            normFOV = table.shipCoords["VMS1"]["normFOV"].Value;
        }

        override public void AddToTable(ShipTable table)
        {
            table.shipCoords["VMS1"]["Dimensions"] = Dimensions.ToTable();
            table.shipCoords["VMS1"]["normFOV"].Value = normFOV;
        }
    }
}
