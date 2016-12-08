using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RSSE
{
    public class LENR : Subsystem
    {
        override public SubsystemTypeEnum SystemType { get { return SubsystemTypeEnum.LENR; } }
        override public string SystemGroup { get { return "Power"; } }

        public int mount_MAX;
        public int total_ALLOWED;
        public int sys1_EB;
        public int sys1_quad;

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
