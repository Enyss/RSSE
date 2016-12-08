using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RSSE
{
    public class NAS : Subsystem
    {
        override public SubsystemTypeEnum SystemType { get { return SubsystemTypeEnum.NAS; } }
        override public string SystemGroup { get { return "Command"; } }

        public int mount_MAX;
        public int sys_EB;
        public int sys_quad;

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
