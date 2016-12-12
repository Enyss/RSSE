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
        public Vector3 Position;

        public Speaker()
        {
            Name = "default";
            Position = new Vector3();
        }

        public Speaker(Table table)
        {
            Name = table["Name"].StrValue;
            Name = (Name == "") ? "default" : Name;
            Position = new Vector3(table);
        }

        public Table ToTable()
        {
            return Position.ToTable();
        }
    }
}
