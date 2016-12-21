using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RSSE
{
    public class Speaker
    {
        public string Name;
        public Vec3 Position;

        public Speaker()
        {
            Name = "default";
            Position = new Vec3();
        }

        public Speaker(Table table)
        {
            Name = table["Name"].StrValue;
            Name = (Name == "") ? "default" : Name;
            Position = new Vec3(table);
        }

        public Table ToTable()
        {
            return Position.ToTable();
        }
    }
}
