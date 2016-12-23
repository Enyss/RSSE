using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using NLua;

namespace RSSE
{
    class ShipHullManager
    {
        private string path;
        public List<ShipHull> shipHulls;
        

        public ShipHullManager( )
        {
            path = Appli.Instance.Settings.RogueSysemFileRoot + "/Mod/RogSysCM/Ships/";
            // Read ShipHullList.ROG.
            string content = File.ReadAllText(path+"ShipHullList.ROG");

            // Get the table.
            Lua lua = new Lua();
            lua.DoString(content);
            Table shipHullsTable = new Table(lua, lua.GetTable("ShipHull"));

            // Get the shipHulls.
            shipHulls = new List<ShipHull>();
            for(int i=1; i<=shipHullsTable["Total"].IntValue; i++)
            {
                string name = shipHullsTable["Ship" + i]["Name"].Value;
                string file = path + name + ".ROG";
                ShipHullTable table = new ShipHullTable(name, File.ReadAllText(file));
                shipHulls.Add(new ShipHull(table) );
            }
        }

        public Table ToTable()
        {
            Table table = new Table();
            table["Total"].Value = shipHulls.Count;

            int i = 1;
            foreach( ShipHull s in shipHulls)
            {
                table["Ship" + i]["Name"].Value = s.name;
                i++;
            }

            return table;
        }

        public void Save()
        {
            File.WriteAllText(Appli.Instance.Settings.RogueSysemFileRoot + "/Mod/RogSysCM/Ships/ShipHullList.ROG", ToTable().ToString() );
        }

    }
}
