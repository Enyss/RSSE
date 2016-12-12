using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace RSSE
{
    public class MES : Subsystem
    {
        override public SubsystemTypeEnum SystemType { get { return SubsystemTypeEnum.MES; } }
        override public string SystemGroup { get { return "Propulsion"; } }

        public List<MESEngine> engines { get; set; }
        public int mount_MAX;
        public int total_ALLOWED;
        public int sys1_EB;
        public int sys1_quad;

        public MES()
        {
            engines = new List<MESEngine>();
        }

        public MES(ShipHullTable ship)
        {
            engines = new List<MESEngine>();
            mount_MAX = ship.ship["MES"]["mount_MAX"].IntValue;
            total_ALLOWED = ship.ship["MES"]["total_ALLOWED"].IntValue;
            sys1_EB = ship.ship["MES"]["sys1_EB"].IntValue;
            sys1_quad = ship.ship["MES"]["sys1_quad"].IntValue;

            int i = 1;
            while( ship.shipCoords["MES"+i].Count > 0)
            {
                engines.Add(new MESEngine(ship.shipCoords["MES" + i]));
                i++;
            }
        }

        override public void AddToTable(ShipHullTable ship)
        {
            ship.ship["MES"]["mount_MAX"].IntValue = mount_MAX;
            ship.ship["MES"]["total_ALLOWED"].IntValue = total_ALLOWED;
            ship.ship["MES"]["sys1_EB"].IntValue = sys1_EB;
            ship.ship["MES"]["sys1_quad"].IntValue = sys1_quad;

            int i = 1;
            foreach (MESEngine mesEngine in engines)
            {
                ship.shipCoords["MES" + i] = mesEngine.ToTable();
                i++;
            }
        }
    }
}
