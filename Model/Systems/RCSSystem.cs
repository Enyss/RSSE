using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace RSSE.ShipElements.Systems
{
    public class RCSSystem : SubSystem
    {
        override public string SystemName { get { return "RCS"; } }
        override public string SystemGroup { get { return "Propulsion"; } }

        public BindingList<RCS> rcs { get; set; }

        public RCSSystem()
        {
            rcs = new BindingList<RCS>();
        }

        public RCSSystem( ShipTable table )
        {
            rcs = new BindingList<RCS>();
            int i = 1;
            while (table.shipCoords["Thruster" + i].Count > 0)
            {
                rcs.Add(new RCS(table.shipCoords["Thruster" + i]));
                i++;
            }
        }

        override public void AddToTable(ShipTable table)
        {
            int i = 1;
            foreach (RCS thruster in rcs)
            {
                table.shipCoords["Thruster" + i] = thruster.ToTable();
                i++;
            }
        }
    }
}
