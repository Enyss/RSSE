using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RSSE
{
    public class Scrubber
    {
        public bool is_SPARE;
        public Vec3 position;
        public Vec3 rotation;
        public int equipBay;
        public int quad;

        public Scrubber()
        {
            position = new Vec3();
            rotation = new Vec3();
        }

        public Scrubber(Table table)
        {
            is_SPARE = table["is_SPARE"].Value > 0.5;
            position = new Vec3(table["position"]);
            rotation = new Vec3(table["rotation"]);
            equipBay = table["EquipBay"].IntValue;
            quad = table["Quad"].IntValue;
        }

        public Table ToTable()
        {
            Table table = new Table();
            table["is_SPARE"].Value = is_SPARE?1:0;
            table["position"] = position.ToTable();
            table["rotation"] = rotation.ToTable();
            table["EquipBay"].IntValue = equipBay;
            table["Quad"].IntValue = quad;
            return table;
        }
    }
}
