using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace RSSE.Interface
{
    interface ISeatViewModel : IViewModel<Seat>
    {
        string Name { get; set; }
        Area3D safeLIMIT { get; set; }
        Area3D unsafeLIMIT { get; set; }
    }
}
