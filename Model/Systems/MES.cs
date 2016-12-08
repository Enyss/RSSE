using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace RSSE.ShipElements.Systems
{
    public class MES : SubSystem
    {
        override public string SystemName { get { return "MES"; } }
        override public string SystemGroup { get { return "Propulsion"; } }

        public BindingList<MESEngine> engines { get; set; }
        public int mount_MAX { get; set; }
        public int total_ALLOWED { get; set; }
        public int sys1_EB { get; set; }
        public int sys1_quad { get; set; }

        public MES()
        {
            engines = new BindingList<MESEngine>();
        }

        public MES(ShipTable ship)
        {
            engines = new BindingList<MESEngine>();
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

        override public void AddToTable(ShipTable ship)
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
