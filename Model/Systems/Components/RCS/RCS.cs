using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSSE.Utils;

namespace RSSE.ShipElements.Systems
{
    public class RCS
    {
        public string Name { get; set; }
        public Vector3 nozzlePOS { get; set; }
        public Vector3 directionVEC { get; set; }
        public RCSDir motionTYPES { get; set; }
        public string exhaustVFX { get; set; }
        public double forceMULTI { get; set; }
        public int locationQUAD { get; set; }

        public RCS(Table table)
        {
            Name = (table["Name"].Value == null)? "default RCS" : table["Name"].Value;
            nozzlePOS = new Vector3(table["nozzlePOS"]);
            directionVEC = new Vector3(table["directionVEC"]);
            motionTYPES = new RCSDir(table["motionTYPES"]);
            exhaustVFX = table["exhaustVFX"].Value;
            forceMULTI = table["forceMULTI"].Value;
            locationQUAD = table["locationQUAD"].IntValue;
        }

        public Table ToTable()
        {
            Table table = new Table();
            table["Name"].Value = Name;
            table["nozzlePOS"] = nozzlePOS.ToTable();
            table["directionVEC"] = directionVEC.ToTable();
            table["motionTYPES"] = motionTYPES.ToTable();
            table["exhaustVFX"].Value = exhaustVFX;
            table["forceMULTI"].Value = forceMULTI;
            table["locationQUAD"].IntValue = locationQUAD;
            return table;
        }
    }
}
