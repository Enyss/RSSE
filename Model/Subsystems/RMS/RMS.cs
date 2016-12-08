using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RSSE
{
    public class RMS : Subsystem
    {
        override public SubsystemTypeEnum SystemType { get { return SubsystemTypeEnum.RMS; } }
        override public string SystemGroup { get { return "Attachements"; } }

        public int hardmounted_TOTAL;
        public int sys1_JOINTtotal;
        public int sys1_EB;
        public int sys1_quad;

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
