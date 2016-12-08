using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RSSE
{
    public class VMS : Subsystem 
    {

        override public SubsystemTypeEnum SystemType { get { return SubsystemTypeEnum.VMS; } }
        override public string SystemGroup { get { return "Command"; } }

        public Vector2 dimensions;
        public double normFOV;

        public VMS ()
        {
            dimensions = new Vector2();
        }

        public VMS(ShipTable table)
        {
            dimensions = new Vector2(table.shipCoords["VMS1"]["Dimensions"]);
            normFOV = table.shipCoords["VMS1"]["normFOV"].Value;
        }

        override public void AddToTable(ShipTable table)
        {
            table.shipCoords["VMS1"]["Dimensions"] = dimensions.ToTable();
            table.shipCoords["VMS1"]["normFOV"].Value = normFOV;
        }
    }
}
