using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace RSSE.Interface
{
    interface ISpeakerViewModel : IViewModel<Speaker>
    {
        string Name { get; set; }
        Vec3 Position { get; set; }
    }
}
