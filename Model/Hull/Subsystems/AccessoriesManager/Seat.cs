using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RSSE
{
    public class Seat
    {
        public string Name;
        public Area3D safeLIMIT;
        public Area3D unsafeLIMIT;

        public Seat()
        {
            Name = "default";
            safeLIMIT = new Area3D();
            unsafeLIMIT = new Area3D();
        }

        public Seat(Table table)
        {
            Name = table["Name"].StrValue;
            Name = (Name == "" )? "default" : Name;
            safeLIMIT = new Area3D(table["safeLIMIT"]);
            unsafeLIMIT = new Area3D(table["unsafeLIMIT"]);
        }

        public Table ToTable()
        {
            Table table = new Table();
            table["Name"].Value = Name;
            table["safeLIMIT"] = safeLIMIT.ToTable2();
            table["unsafeLIMIT"] = unsafeLIMIT.ToTable2();
            return table;
        }
    }
}
