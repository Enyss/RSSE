using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace RSSE
{
    public class RCS : Subsystem
    {
        override public SubsystemTypeEnum SystemType { get { return SubsystemTypeEnum.RCS; } }
        override public string SystemGroup { get { return "Propulsion"; } }

        public List<RCSThruster> thrusters { get; set; }

        public RCS()
        {
            thrusters = new List<RCSThruster>();
        }

        public RCS( ShipHullTable table )
        {
            thrusters = new List<RCSThruster>();
            int i = 1;
            while (table.shipCoords["Thruster" + i].Count > 0)
            {
                thrusters.Add(new RCSThruster(table.shipCoords["Thruster" + i]));
                i++;
            }
        }

        override public void AddToTable(ShipHullTable table)
        {
            int i = 1;
            foreach (RCSThruster thruster in thrusters)
            {
                table.shipCoords["Thruster" + i] = thruster.ToTable();
                i++;
            }
        }
    }
}
