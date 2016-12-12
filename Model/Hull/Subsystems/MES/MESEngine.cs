using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RSSE
{
    public class MESEngine
    {
        public string name;
        public Vector3 position;
        public Vector3 rotation;

        public MESEngine()
        {
            name = "default engine" ;
            position = new Vector3();
            rotation = new Vector3();
        }

        public MESEngine( Table table )
        {
            name = (table["Name"].Value == null) ? "default engine" : table["Name"].Value;
            position = new Vector3(table["objectPOSITION"]);
            rotation = new Vector3(table["objectROTATION"]);
        }

        public Table ToTable()
        {
            Table table = new Table();
            table["Name"].Value = name;
            table["objectPOSITION"] = position.ToTable();
            table["objectROTATION"] = position.ToTable();
            return table;
        }
    }


}
