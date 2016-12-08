using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using RSSE.Utils;

namespace RSSE.ShipElements.Systems
{
    public class MTS : SubSystem
    {
        override public string SystemName { get { return "MTS"; } }
        override public string SystemGroup { get { return "Propulsion"; } }

        public Vector3 MTSlocation { get; set; }
        public BindingList<MTSBooster> booster { get; set; } = new BindingList<MTSBooster>();

        int mount_MAX { get; set; }
        double nozzle_SIZE { get; set; }
        public MTSController controller { get; set; }

        public MTS()
        {
            MTSlocation = new Vector3();
            controller = new MTSController();
        }

        public MTS(ShipTable table)
        {
            mount_MAX = table.ship["MTS"]["mount_MAX"].IntValue;
            nozzle_SIZE = table.ship["MTS"]["nozzle_SIZE"].Value;
            controller = new MTSController(table.ship["MTS"]["Controller1_LOC"]);

            MTSlocation = new Vector3(table.shipCoords["MTSlocation"]);
            int i = 1;
            while( table.shipCoords["booster"+i].Count > 0)
            {
                booster.Add(new MTSBooster(table.shipCoords["booster" + i]));
                i++;
            }
        }

        override public void AddToTable(ShipTable table)
        {
            table.ship["MTS"]["mount_MAX"].IntValue = mount_MAX;
            table.ship["MTS"]["nozzle_SIZE"].Value = nozzle_SIZE;
            table.ship["MTS"]["Controller1_LOC"]= controller.ToTable();

            table.shipCoords["MTSlocation"] = MTSlocation.ToTable();
            table.shipCoords["noz_BOOSTtotal"].Value = booster.Count;
            int i = 1;
            foreach (MTSBooster mtsBooster in booster)
            {
                table.shipCoords["booster" + i] = mtsBooster.ToTable();
                i++;
            }
        }
    }
}
