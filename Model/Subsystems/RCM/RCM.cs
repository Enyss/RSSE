using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RSSE
{
    public class RCM : Subsystem
    {
        override public SubsystemTypeEnum SystemType { get { return SubsystemTypeEnum.RCM; } }
        override public string SystemGroup { get { return "Ship integrity"; } }

        public int mount_MAX;
        public int sys_EB;
        public int sys_quad;

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
