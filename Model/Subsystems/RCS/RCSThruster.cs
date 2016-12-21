using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RSSE
{
    public class RCSThruster
    {
        public string name;
        public Vec3 nozzlePOS;
        public Vec3 directionVEC;
        public DoF dof;
        public string exhaustVFX;
        public double forceMULTI;
        public int locationQUAD;


        public RCSThruster()
        {
            name = "default thruster";
            nozzlePOS = new Vec3();
            directionVEC = new Vec3();
            dof = new DoF();
        }

        public RCSThruster(Table table)
        {
            name = (table["Name"].Value == null)? "default thruster" : table["Name"].Value;
            nozzlePOS = new Vec3(table["nozzlePOS"]);
            directionVEC = new Vec3(table["directionVEC"]);
            dof = new DoF(table["motionTYPES"]);
            exhaustVFX = table["exhaustVFX"].Value;
            forceMULTI = table["forceMULTI"].Value;
            locationQUAD = table["locationQUAD"].IntValue;
        }

        public Table ToTable()
        {
            Table table = new Table();
            table["Name"].Value = name;
            table["nozzlePOS"] = nozzlePOS.ToTable();
            table["directionVEC"] = directionVEC.ToTable();
            table["motionTYPES"] = dof.ToTable();
            table["exhaustVFX"].Value = exhaustVFX;
            table["forceMULTI"].Value = forceMULTI;
            table["locationQUAD"].IntValue = locationQUAD;
            return table;
        }
    }
}
