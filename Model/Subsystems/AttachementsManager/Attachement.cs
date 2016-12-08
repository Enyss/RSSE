using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RSSE
{
    public class Attachement
    {
        public string name;
        public Vector3 position;
        public Vector3 rotation;
        public int size;
        public bool isTowing;
        public bool invertX;
        public bool swapXZ;

        public Attachement()
        {
            position = new Vector3();
            rotation = new Vector3();
        }

        public Attachement(Table table)
        {
            name = table["Name"].Value;
            position = new Vector3(table["Position"]);
            rotation = new Vector3(table["Rotation"]);
            size = table["Size"].IntValue;
            isTowing = table["IsTowing"].Value > 0;
            invertX = table["InvertX"].Value > 0;
            swapXZ = table["SwapXZ"].Value > 0;
        }

        public Table ToTable()
        {
            Table table = new Table();
            table["Name"].Value = name;
            table["Position"] = position.ToTable();
            table["Rotation"] = rotation.ToTable();
            table["Size"].IntValue = size;
            table["IsTowing"].Value = isTowing ? 1 : 0;
            table["InvertX"].Value = invertX?1:0;
            table["SwapXZ"].Value = swapXZ?1:0;
            return table;
        }
    }
}
