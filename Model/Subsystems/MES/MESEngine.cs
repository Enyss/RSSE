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
        public Vec3 position;
        public Vec3 rotation;

        public MESEngine()
        {
            name = "default engine" ;
            position = new Vec3();
            rotation = new Vec3();
        }

        public MESEngine( Table table )
        {
            name = (table["Name"].Value == null) ? "default engine" : table["Name"].Value;
            position = new Vec3(table["objectPOSITION"]);
            rotation = new Vec3(table["objectROTATION"]);
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
