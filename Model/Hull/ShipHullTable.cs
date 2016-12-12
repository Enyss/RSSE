using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLua;

namespace RSSE
{
    public class ShipHullTable
    {
        public string name;
        public Table ship;
        public Table shipInterior;
        public Table shipExterior;
        public Table shipCameras;
        public Table shipCoords;

        public ShipHullTable(string name)
        {
            this.name = name;
            ship = new Table();
            shipInterior = new Table();
            shipExterior = new Table();
            shipCameras = new Table();
            shipCoords = new Table();
        }

        public ShipHullTable(string name, string content)
        {
            Lua lua = new Lua();
            lua.DoString(content);

            this.name = name;
            ship = new Table(lua, lua.GetTable(name));
            shipInterior = new Table(lua, lua.GetTable(name + "Interior"));
            shipExterior = new Table(lua, lua.GetTable(name + "Exterior"));
            shipCoords = new Table(lua, lua.GetTable(name + "Coords"));
            shipCameras = new Table(lua, lua.GetTable(name + "Cameras"));
        }

        public override string ToString()
        {
            string save = "";
            save += name + "={" + ship.ToString() + "}\n";
            save += name + "Interior" + "={" + shipInterior.ToString() + "}\n";
            save += name + "Exterior" + "={" + shipExterior.ToString() + "}\n";
            save += name + "Coords" + "={" + shipCoords.ToString() + "}\n";
            save += name + "Cameras" + "={" + shipCameras.ToString() + "}";
            return save;
        }

    }

}
