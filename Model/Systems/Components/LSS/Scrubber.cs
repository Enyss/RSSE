using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSSE.Utils;

namespace RSSE.ShipElements.Systems
{
    public class Scrubber
    {
        public bool is_SPARE { get; set; }
        public Vector3 position { get; set; }
        public Vector3 rotation { get; set; }
        public int EquipBay { get; set; }
        public int Quad { get; set; }

        public Scrubber()
        {
            position = new Vector3();
            rotation = new Vector3();
        }

        public Scrubber(Table table)
        {
            is_SPARE = table["is_SPARE"].Value > 0.5;
            position = new Vector3(table["position"]);
            rotation = new Vector3(table["rotation"]);
            EquipBay = table["EquipBay"].IntValue;
            Quad = table["Quad"].IntValue;
        }

        public Table ToTable()
        {
            Table table = new Table();
            table["is_SPARE"].Value = is_SPARE?1:0;
            table["position"] = position.ToTable();
            table["rotation"] = rotation.ToTable();
            table["EquipBay"].IntValue = EquipBay;
            table["Quad"].IntValue = Quad;
            return table;
        }
    }
}
