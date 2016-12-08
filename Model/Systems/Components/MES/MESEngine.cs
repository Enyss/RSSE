using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSSE.Utils;

namespace RSSE.ShipElements.Systems
{
    public class MESEngine
    {
        public string Name { get; set;  }
        public Vector3 Position { get; set; }
        public Vector3 Rotation { get; set; }

        public MESEngine( Table table )
        {
            Name = (table["Name"].Value == null) ? "default engine" : table["Name"].Value;
            Position = new Vector3(table["objectPOSITION"]);
            Rotation = new Vector3(table["objectROTATION"]);
        }

        public Table ToTable()
        {
            Table table = new Table();
            table["Name"].Value = Name;
            table["objectPOSITION"] = Position.ToTable();
            table["objectROTATION"] = Position.ToTable();
            return table;
        }
    }


}
