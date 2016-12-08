using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSSE.Utils;

namespace RSSE.ShipElements.Systems
{
    public class LENR : SubSystem
    {
        override public string SystemName { get { return "LENR"; } }
        override public string SystemGroup { get { return "Power"; } }

        public int mount_MAX { get; set; }
        public int total_ALLOWED { get; set; }
        public int sys1_EB { get; set; }
        public int sys1_quad { get; set; }

        public LENR() { }

        public LENR(ShipTable table)
        {
            mount_MAX       = table.ship["LENR"]["mount_MAX"].IntValue;
            total_ALLOWED   = table.ship["LENR"]["total_ALLOWED"].IntValue;
            sys1_EB         = table.ship["LENR"]["sys1_EB"].IntValue;
            sys1_quad       = table.ship["LENR"]["sys1_quad"].IntValue;
        }

        override public void AddToTable(ShipTable table)
        {
            table.ship["LENR"]["mount_MAX"].IntValue = mount_MAX;
            table.ship["LENR"]["total_ALLOWED"].IntValue = total_ALLOWED;
            table.ship["LENR"]["sys1_EB"].IntValue = sys1_EB;
            table.ship["LENR"]["sys1_quad"].IntValue = sys1_quad;
        }
    }
}
