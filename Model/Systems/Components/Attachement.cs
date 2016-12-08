using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSSE.Utils;

namespace RSSE.ShipElements
{
    public class Attachement
    {
        public string Name { get; set; }
        public Vector3 Position { get; set; }
        public Vector3 Rotation { get; set; }
        public int Size { get; set; }
        public bool IsTowing { get; set; }
        public bool InvertX { get; set; }
        public bool SwapXZ { get; set; }

        public Attachement()
        {
            Position = new Vector3();
            Rotation = new Vector3();
        }

        public Attachement(Table table)
        {
            Name = table["Name"].Value;
            Position = new Vector3(table["Position"]);
            Rotation = new Vector3(table["Rotation"]);
            Size = table["Size"].IntValue;
            IsTowing = table["IsTowing"].Value > 0;
            InvertX = table["InvertX"].Value > 0;
            SwapXZ = table["SwapXZ"].Value > 0;
        }

        public Table ToTable()
        {
            Table table = new Table();
            table["Name"].Value = Name;
            table["Position"] = Position.ToTable();
            table["Rotation"] = Rotation.ToTable();
            table["Size"].IntValue = Size;
            table["IsTowing"].Value = IsTowing ? 1 : 0;
            table["InvertX"].Value = InvertX?1:0;
            table["SwapXZ"].Value = SwapXZ?1:0;
            return table;
        }
    }
}
