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
        private string _path;
        public List<ShipHull> shipHulls;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path">the path to the RogSys Ships folder</param>
        public ShipHullManager( string path )
        {
            // Read ShipHullList.ROG.
            _path = path;
            string content = File.ReadAllText(_path+"ShipHullList.ROG");

            // Get the table.
            Lua lua = new Lua();
            lua.DoString(content);
            Table shipHullsTable = new Table(lua, lua.GetTable("ShipHull"));

            // Get the shipHulls.
            shipHulls = new List<ShipHull>();
            for(int i=1; i<=shipHullsTable["Total"].IntValue; i++)
            {
                ShipHullTable table = new ShipHullTable(path + shipHullsTable["Ship" + i]["Name"].Value + ".ROG");
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
            File.WriteAllText(_path + "ShipHullList.ROG", ToTable().ToString() );
        }

    }
}
