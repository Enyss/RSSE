using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSSE.Utils;

namespace RSSE.ShipElements.Systems
{
    public class RMS : SubSystem
    {
        override public string SystemName { get { return "RMS"; } }
        override public string SystemGroup { get { return "Attachements"; } }

        public int hardmounted_TOTAL { get; set; }
        public int sys1_JOINTtotal { get; set; }
        public int sys1_EB { get; set; }
        public int sys1_quad { get; set; }

        public RMS() { }

        public RMS(ShipTable table)
        {
            hardmounted_TOTAL = table.ship["RMS"]["hardmounted_TOTAL"].IntValue;
            sys1_JOINTtotal = table.ship["RMS"]["sys1_JOINTtotal"].IntValue;
            sys1_EB = table.ship["RMS"]["sys1_EB"].IntValue;
            sys1_quad = table.ship["RMS"]["sys1_quad"].IntValue;
        }

        override public void AddToTable(ShipTable table)
        {
            table.ship["RMS"]["hardmounted_TOTAL"].IntValue = hardmounted_TOTAL;
            table.ship["RMS"]["sys1_JOINTtotal"].IntValue = sys1_JOINTtotal;
            table.ship["RMS"]["sys1_EB"].IntValue = sys1_EB;
            table.ship["RMS"]["sys1_quad"].IntValue = sys1_quad;
        }
    }
}
