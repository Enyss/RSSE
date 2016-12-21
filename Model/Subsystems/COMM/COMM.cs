using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RSSE
{
    public class COMM : Subsystem
    {
        override public SubsystemTypeEnum SystemType { get { return SubsystemTypeEnum.COMM; } }
        override public string SystemGroup { get { return "Command"; } }

        public int mount_MAX;
        public int sys1_EB;
        public int sys1_quad;
        public int sys2_EB;
        public int sys2_quad;

        public COMM(ShipHullTable table)
        {
            mount_MAX   = table.ship["COMM"]["mount_MAX"].IntValue;
            sys1_EB     = table.ship["COMM"]["sys1_EB"].IntValue;
            sys1_quad   = table.ship["COMM"]["sys1_quad"].IntValue;
            sys2_EB     = table.ship["COMM"]["sys2_EB"].IntValue;
            sys2_quad   = table.ship["COMM"]["sys2_quad"].IntValue;
        }

        override public void AddToTable(ShipHullTable table)
        {
            table.ship["COMM"]["mount_MAX"].IntValue    = mount_MAX;
            table.ship["COMM"]["sys1_EB"].IntValue      = sys1_EB;
            table.ship["COMM"]["sys1_quad"].IntValue    = sys1_quad;
            table.ship["COMM"]["sys2_EB"].IntValue      = sys2_EB;
            table.ship["COMM"]["sys2_quad"].IntValue    = sys2_quad;
        }
    }
}
