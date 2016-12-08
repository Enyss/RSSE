using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RSSE
{
    public class BMS : Subsystem
    {
        override public SubsystemTypeEnum SystemType { get { return SubsystemTypeEnum.BMS; } }
        override public string SystemGroup { get { return "Power"; } }

        public int mount_MAX;
        public int total_ALLOWED;
        public int sys1_EB;
        public int sys1_quad;
        public int sys2_EB;
        public int sys2_quad;

        public BMS()
        {

        }

        public BMS(ShipTable table)
        {
            mount_MAX = table.ship["BMS"]["mount_MAX"].IntValue;
            total_ALLOWED = table.ship["BMS"]["total_ALLOWED"].IntValue;
            sys1_EB = table.ship["BMS"]["sys1_EB"].IntValue;
            sys1_quad = table.ship["BMS"]["sys1_quad"].IntValue;
            sys2_EB = table.ship["BMS"]["sys2_EB"].IntValue;
            sys2_quad = table.ship["BMS"]["sys2_quad"].IntValue;
        }

        override public void AddToTable(ShipTable table)
        {
            table.ship["BMS"]["mount_MAX"].IntValue = mount_MAX;
            table.ship["BMS"]["total_ALLOWED"].IntValue = total_ALLOWED;
            table.ship["BMS"]["sys1_EB"].IntValue = sys1_EB;
            table.ship["BMS"]["sys1_quad"].IntValue = sys1_quad;
            table.ship["BMS"]["sys2_EB"].IntValue = sys2_EB;
            table.ship["BMS"]["sys2_quad"].IntValue = sys2_quad;
        }
    }
}
