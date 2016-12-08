using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;


namespace RSSE
{
    public class MTS : Subsystem
    {
        override public SubsystemTypeEnum SystemType { get { return SubsystemTypeEnum.MTS; } }
        override public string SystemGroup { get { return "Propulsion"; } }

        public List<MTSBooster> boosters;
        public MTSController controller;

        public int mount_MAX;
        public Vector3 mtsLocation;
        public double nozzle_SIZE;

        public MTS()
        {
            mtsLocation = new Vector3();
            controller = new MTSController();
            boosters = new List<MTSBooster>();
        }

        public MTS(ShipTable table)
        {
            mount_MAX = table.ship["MTS"]["mount_MAX"].IntValue;
            nozzle_SIZE = table.ship["MTS"]["nozzle_SIZE"].Value;
            mtsLocation = new Vector3(table.shipCoords["MTSlocation"]);

            controller = new MTSController(table.ship["MTS"]["Controller1_LOC"]);

            boosters = new List<MTSBooster>();
            int i = 1;
            while( table.shipCoords["booster"+i].Count > 0)
            {
                boosters.Add(new MTSBooster(table.shipCoords["booster" + i]));
                i++;
            }
        }

        override public void AddToTable(ShipTable table)
        {
            table.ship["MTS"]["mount_MAX"].IntValue = mount_MAX;
            table.ship["MTS"]["nozzle_SIZE"].Value = nozzle_SIZE;
            table.ship["MTS"]["Controller1_LOC"]= controller.ToTable();

            table.shipCoords["MTSlocation"] = mtsLocation.ToTable();
            table.shipCoords["noz_BOOSTtotal"].Value = boosters.Count;
            int i = 1;
            foreach (MTSBooster mtsBooster in boosters)
            {
                table.shipCoords["booster" + i] = mtsBooster.ToTable();
                i++;
            }
        }
    }
}
