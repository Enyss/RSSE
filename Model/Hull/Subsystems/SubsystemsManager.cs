using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE
{
    public class SubsystemsManager
    {
        public List<Subsystem> subsystems;

        public SubsystemsManager()
        {
            subsystems = new List<Subsystem>();
        }

        public SubsystemsManager(List<Subsystem> subsystemList)
        {
            subsystems = subsystemList;
        }
    }
}
