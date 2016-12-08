using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSSE.Utils;

namespace RSSE.ShipElements.Systems
{
    public class CSSM : SubSystem
    {
        override public string SystemName { get { return "CSSM"; } }
        override public string SystemGroup { get { return "Command"; } }

        int mount_MAX { get; set; }
        int sys_EB { get; set; }
        int sys_quad { get; set; }
        int cargo_BAYS { get; set; }
        int cargo_RADSattached { get; set; }
        
        public CSSM(ShipTable table)
        {
            mount_MAX = table.ship["CSSM"]["mount_MAX"].IntValue;
            sys_EB = table.ship["CSSM"]["sys_EB"].IntValue;
            sys_quad = table.ship["CSSM"]["sys_quad"].IntValue;
            cargo_BAYS = table.ship["CSSM"]["cargo_BAYS"].IntValue;
            cargo_RADSattached = table.ship["CSSM"]["cargo_RADSattached"].IntValue;
        }

        override public void AddToTable(ShipTable table)
        {
            table.ship["CSSM"]["mount_MAX"].IntValue = mount_MAX;
            table.ship["CSSM"]["sys_EB"].IntValue = sys_EB;
            table.ship["CSSM"]["sys_quad"].IntValue = sys_quad;
            table.ship["CSSM"]["cargo_BAYS"].IntValue = cargo_BAYS;
            table.ship["CSSM"]["cargo_RADSattached"].IntValue = cargo_RADSattached;
        }
    }
}
