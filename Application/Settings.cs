using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RSSE                                                                                                                                                                    
{
    [Serializable]
    public class Settings : PersistableObject
    {
        public string RogueSysemFileRoot { get; set; }
    }
}
