using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLua;


namespace RSSE
{
    public class Camera
    {
        public string name;
        public string name_UI;
        public int id;
        public string parentTo;
        public Vec3 position;
        public Vec3 rotation;

        public Camera()
        {
            name = "default";
            name_UI = "";
            id = 0;
            parentTo = "NONE";
            position = new Vec3();
            rotation = new Vec3();
        }

        public Camera(Table table)
        {
            name = table["Name"].Value;
            name_UI = table["name_UI"].StrValue;
            id = table["ID"].IntValue;
            parentTo = (table["ParentTo"].Value == null)? "NONE" : table["ParentTo"].Value;
            position = new Vec3(table["Position"]);
            rotation = new Vec3(table["Rotation"]);
        }

        public Table ToTable()
        {
            Table table = new Table();
            table["Name"].Value = name;
            table["name_UI"].Value = name_UI;
            table["ID"].Value = id;
            table["ParentTo"].Value = parentTo;
            table["Position"] = position.ToTable();
            table["Rotation"] = rotation.ToTable();
            return table;
        }

    }
}
