using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSSE.Utils;

namespace RSSE.ShipElements.Systems
{
    public class RCM : SubSystem
    {
        override public string SystemName { get { return "RCM"; } }
        override public string SystemGroup { get { return "Ship integrity"; } }

        public int mount_MAX { get; set; }
        public int sys_EB { get; set; }
        public int sys_quad { get; set; }

        public RCM() { }

        public RCM(ShipTable table)
        {
            mount_MAX   = table.ship["RCM"]["mount_MAX"].IntValue;
            sys_EB      = table.ship["RCM"]["sys_EB"].IntValue;
            sys_quad    = table.ship["RCM"]["sys_quad"].IntValue;
        }

        override public void AddToTable(ShipTable table)
        {
            table.ship["RCM"]["mount_MAX"].IntValue = mount_MAX;
            table.ship["RCM"]["sys_EB"].IntValue = sys_EB;
            table.ship["RCM"]["sys_quad"].IntValue = sys_quad;
        }
    }
}
