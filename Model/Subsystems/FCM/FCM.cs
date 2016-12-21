using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RSSE
{
    public class FCM : Subsystem
    {
        override public SubsystemTypeEnum SystemType { get { return SubsystemTypeEnum.FCM; } }
        override public string SystemGroup { get { return "Power"; } }

        public int mount_MAX;
        public int total_ALLOWED;
        public int sys1_EB;
        public int sys1_quad;
        public int sys2_EB;
        public int sys2_quad;

        public FCM() { }

        public FCM(ShipHullTable table)
        {
            mount_MAX       = table.ship["FCM"]["mount_MAX"].IntValue;
            total_ALLOWED   = table.ship["FCM"]["total_ALLOWED"].IntValue;
            sys1_EB         = table.ship["FCM"]["sys1_EB"].IntValue;
            sys1_quad       = table.ship["FCM"]["sys1_quad"].IntValue;
            sys2_EB         = table.ship["FCM"]["sys2_EB"].IntValue;
            sys2_quad       = table.ship["FCM"]["sys2_quad"].IntValue;
        }

        override public void AddToTable(ShipHullTable table)
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
