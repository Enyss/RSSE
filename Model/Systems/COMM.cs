using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSSE.Utils;

namespace RSSE.ShipElements.Systems
{
    public class COMM : SubSystem
    {
        override public string SystemName { get { return "COMM"; } }
        override public string SystemGroup { get { return "Command"; } }

        int mount_MAX { get; set; }
        int sys1_EB { get; set; }
        int sys1_quad { get; set; }
        int sys2_EB { get; set; }
        int sys2_quad { get; set; }

        public COMM(ShipTable table)
        {
            mount_MAX   = table.ship["COMM"]["mount_MAX"].IntValue;
            sys1_EB     = table.ship["COMM"]["sys1_EB"].IntValue;
            sys1_quad   = table.ship["COMM"]["sys1_quad"].IntValue;
            sys2_EB     = table.ship["COMM"]["sys2_EB"].IntValue;
            sys2_quad   = table.ship["COMM"]["sys2_quad"].IntValue;
        }

        override public void AddToTable(ShipTable table)
        {
            table.ship["COMM"]["mount_MAX"].IntValue    = mount_MAX;
            table.ship["COMM"]["sys1_EB"].IntValue      = sys1_EB;
            table.ship["COMM"]["sys1_quad"].IntValue    = sys1_quad;
            table.ship["COMM"]["sys2_EB"].IntValue      = sys2_EB;
            table.ship["COMM"]["sys2_quad"].IntValue    = sys2_quad;
        }
    }
}
