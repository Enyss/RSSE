using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace RSSE.Interface
{
    interface IAccessoiresManagerViewModel : IViewModel<AccessoriesManager>
    {
        string Name { get; }
        string Group { get; }
        //ObservableCollection<SeatViewModel> Seats { get; set; }
        //VmCollection<SpeakerViewModel, Speaker> Speakers { get; set; }
    }
}
