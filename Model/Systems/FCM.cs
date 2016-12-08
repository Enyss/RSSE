using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSSE.Utils;

namespace RSSE.ShipElements.Systems
{
    public class FCM : SubSystem
    {
        override public string SystemName { get { return "FCM"; } }
        override public string SystemGroup { get { return "Power"; } }

        public int mount_MAX { get; set; }
        public int total_ALLOWED { get; set; }
        public int sys1_EB { get; set; }
        public int sys1_quad { get; set; }
        public int sys2_EB { get; set; }
        public int sys2_quad { get; set; }

        public FCM() { }

        public FCM(ShipTable table)
        {
            mount_MAX       = table.ship["FCM"]["mount_MAX"].IntValue;
            total_ALLOWED   = table.ship["FCM"]["total_ALLOWED"].IntValue;
            sys1_EB         = table.ship["FCM"]["sys1_EB"].IntValue;
            sys1_quad       = table.ship["FCM"]["sys1_quad"].IntValue;
            sys2_EB         = table.ship["FCM"]["sys2_EB"].IntValue;
            sys2_quad       = table.ship["FCM"]["sys2_quad"].IntValue;
        }

        override public void AddToTable(ShipTable table)
        {
            table.ship["FCM"]["mount_MAX"].IntValue = mount_MAX;
            table.ship["FCM"]["total_ALLOWED"].IntValue = total_ALLOWED;
            table.ship["FCM"]["sys1_EB"].IntValue = sys1_EB;
            table.ship["FCM"]["sys1_quad"].IntValue = sys1_quad;
            table.ship["FCM"]["sys2_EB"].IntValue = sys2_EB;
            table.ship["FCM"]["sys2_quad"].IntValue = sys2_quad;
        }
    }
}
