using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;


using RSSE.Interface;

namespace RSSE
{
    class SeatViewModel : ObservableObject, ISeatViewModel
    {
        private Seat _seat;
        public Seat Model { get { return _seat; } }

        public SeatViewModel() { }

        public SeatViewModel(Seat seat)
        {
            LoadFrom(seat);
        }

        public string Name
        {
            get { return _seat.Name; }
            set
            {
                _seat.Name = value;
                OnPropertyChanged();
            }
        }
        public Area3D safeLIMIT
        {
            get { return _seat.safeLIMIT; }
            set
            {
                _seat.safeLIMIT = value;
                OnPropertyChanged();
            }
        }
        public Area3D unsafeLIMIT
        {
            get { return _seat.safeLIMIT; }
            set
            {
                _seat.safeLIMIT = value;
                OnPropertyChanged();
            }
        }

        public void LoadFrom( Seat seat)
        {
            _seat = seat;
        }

        public bool IsViewModelOf(Seat seat)
        {
            return seat.Equals(_seat);
        }
    }
}
