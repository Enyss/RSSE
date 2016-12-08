using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSSE.Utils;

namespace RSSE.ShipElements.Systems
{
    public class BMS : SubSystem
    {
        override public string SystemName { get { return "BMS"; } }
        override public string SystemGroup { get { return "Power"; } }

        public int mount_MAX { get; set; }
        public int total_ALLOWED { get; set; }
        public int sys1_EB { get; set; }
        public int sys1_quad { get; set; }
        public int sys2_EB { get; set; }
        public int sys2_quad { get; set; }

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
