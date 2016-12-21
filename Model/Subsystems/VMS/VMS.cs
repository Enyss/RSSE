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

        public Vec2 dimensions;
        public double normFOV;

        public VMS ()
        {
            dimensions = new Vec2();
        }

        public VMS(ShipHullTable table)
        {
            dimensions = new Vec2(table.shipCoords["VMS1"]["Dimensions"]);
            normFOV = table.shipCoords["VMS1"]["normFOV"].DoubleValue;
        }

        override public void AddToTable(ShipHullTable table)
        {
            table.shipCoords["VMS1"]["Dimensions"] = dimensions.ToTable();
            table.shipCoords["VMS1"]["normFOV"].Value = normFOV;
        }
    }
}
