using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSSE.Utils;

namespace RSSE.ShipElements.Systems
{
    public class NAS : SubSystem
    {
        override public string SystemName { get { return "NAS"; } }
        override public string SystemGroup { get { return "Command"; } }

        public int mount_MAX { get; set; }
        public int sys_EB { get; set; }
        public int sys_quad { get; set; }

        public NAS() { }

        public NAS(ShipTable table)
        {
            mount_MAX   = table.ship["NAS"]["mount_MAX"].IntValue;
            sys_EB      = table.ship["NAS"]["sys_EB"].IntValue;
            sys_quad    = table.ship["NAS"]["sys_quad"].IntValue;
        }

        override public void AddToTable(ShipTable table)
        {
            table.ship["NAS"]["mount_MAX"].IntValue = mount_MAX;
            table.ship["NAS"]["sys_EB"].IntValue = sys_EB;
            table.ship["NAS"]["sys_quad"].IntValue = sys_quad;
        }
    }
}
