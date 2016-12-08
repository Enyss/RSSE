using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLua;
using RSSE.Utils;

namespace RSSE
{
    public class Camera
    {
        public string name { get; set; }
        public string UIname { get; set; }
        public int id { get; set; }
        public string parentTo { get; set; }
        public Vector3 position { get; set; }
        public Vector3 rotation { get; set; }

        public Camera()
        {
            name = "default";
            UIname = "";
            id = 0;
            parentTo = "NONE";
            position = new Vector3();
            rotation = new Vector3();
        }

        public Camera(Table table)
        {
            name = table["Name"].Value;
            UIname = table["name_UI"].StrValue;
            id = table["ID"].IntValue;
            parentTo = (table["ParentTo"].Value == null)? "NONE" : table["ParentTo"].Value;
            position = new Vector3(table["Position"]);
            rotation = new Vector3(table["Rotation"]);
        }

        public Table ToTable()
        {
            Table table = new Table();
            table["Name"].Value = name;
            table["name_UI"].Value = UIname;
            table["ID"].Value = id;
            table["ParentTo"].Value = parentTo;
            table["Position"] = position.ToTable();
            table["Rotation"] = rotation.ToTable();
            return table;
        }

    }
}
