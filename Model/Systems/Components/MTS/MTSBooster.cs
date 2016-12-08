using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSSE.Utils;

namespace RSSE.ShipElements.Systems
{
    public class MTSBooster
    {
        public string name { get; set; }
        public Vector3 position { get; set; }
        public Vector3 vector { get; set; }
        public string vfx { get; set; }
        public Vector3 pos_REV { get; set; }
        public Vector3 vctr_REV {get; set;}
        public string vfx_REV { get; set; }
        public int quad { get; set; }

        public MTSBooster()
        {
            name = "default";
            position = new Vector3();
            vector = new Vector3();
            pos_REV = new Vector3();
            vctr_REV = new Vector3();
        }

        public MTSBooster(Table table)
        {
            name = (table["name"].Value == null)? "default" : table["name"].Value;
            position = new Vector3(table["position"]);
            vector = new Vector3(table["vector"]);
            vfx = table["vfx"].Value;
            pos_REV = new Vector3(table["pos_REV"]);
            vctr_REV = new Vector3(table["vctr_REV"]);
            vfx_REV = table["vfx_REV"].Value;
            quad = table["quad"].IntValue;
        }

        public Table ToTable()
        {
            Table table = new Table();
            table["name"].Value = name;
            table["position"] = position.ToTable();
            table["vector"] = vector.ToTable();
            table["vfx"].Value = vfx;
            table["pos_REV"] = pos_REV.ToTable();
            table["vctr_REV"] = vctr_REV.ToTable();
            table["vfx_REV"].Value = vfx_REV;
            table["quad"].IntValue = quad;
            return table;
        }
    }
}
