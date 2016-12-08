using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE
{
    public abstract class Subsystem
    {

        public abstract SubsystemTypeEnum SystemType { get; }
        public abstract string SystemGroup { get; }

        public abstract void AddToTable(ShipTable table);
    }
}
