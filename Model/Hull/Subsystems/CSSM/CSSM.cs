using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RSSE
{
    public class CSSM : Subsystem
    {
        override public SubsystemTypeEnum SystemType { get { return SubsystemTypeEnum.CSSM; } }
        override public string SystemGroup { get { return "Command"; } }

        public int mount_MAX;
        public int sys_EB;
        public int sys_quad;
        public int cargo_BAYS;
        public int cargo_RADSattached;
        
        public CSSM(ShipHullTable table)
        {
            mount_MAX = table.ship["CSSM"]["mount_MAX"].IntValue;
            sys_EB = table.ship["CSSM"]["sys_EB"].IntValue;
            sys_quad = table.ship["CSSM"]["sys_quad"].IntValue;
            cargo_BAYS = table.ship["CSSM"]["cargo_BAYS"].IntValue;
            cargo_RADSattached = table.ship["CSSM"]["cargo_RADSattached"].IntValue;
        }

        override public void AddToTable(ShipHullTable table)
        {
            table.ship["CSSM"]["mount_MAX"].IntValue = mount_MAX;
            table.ship["CSSM"]["sys_EB"].IntValue = sys_EB;
            table.ship["CSSM"]["sys_quad"].IntValue = sys_quad;
            table.ship["CSSM"]["cargo_BAYS"].IntValue = cargo_BAYS;
            table.ship["CSSM"]["cargo_RADSattached"].IntValue = cargo_RADSattached;
        }
    }
}
