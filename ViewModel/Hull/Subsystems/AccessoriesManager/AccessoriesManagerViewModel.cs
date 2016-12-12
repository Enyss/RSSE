using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.ComponentModel;


using RSSE.Interface;

namespace RSSE
{
    class AccessoriesManagerViewModel : SubsystemViewModel
    {
        private AccessoriesManager _manager;

        new public AccessoriesManager Model { get { return _manager; } }
        override public SubsystemTypeEnum SystemType { get { return _manager.SystemType; } }

        public string Name {
            get { return SubsystemTypeEnumExtensions.ToNiceString(_manager.SystemType); }
        }
        public string Group { get { return _manager.SystemGroup; } }
        public ObservableCollection<SeatViewModel> Seats { get; set; }
        public ObservableCollection<SpeakerViewModel> Speakers { get; set; }


        public ICommand AddSeatCommand { get; private set; }
        public ICommand RemoveSeatCommand { get; private set; }
        public ICommand AddSpeakerCommand { get; private set; }
        public ICommand RemoveSpeakerCommand { get; private set; }


        public AccessoriesManagerViewModel()
            : this(null)
        {          
        }

        public AccessoriesManagerViewModel(AccessoriesManager accessoriesManager)
        {
            AddSeatCommand = new DelegateCommand(AddSeat);
            RemoveSeatCommand = new DelegateCommand<SeatViewModel>(RemoveSeat);
            AddSpeakerCommand = new DelegateCommand(AddSpeaker);
            RemoveSpeakerCommand = new DelegateCommand<SpeakerViewModel>(RemoveSpeaker);

            if ( accessoriesManager != null)
            {
                LoadFrom(accessoriesManager);
            }
            
        }

        override public void LoadFrom(Subsystem accessoriesManager)
        {
            _manager = (AccessoriesManager)accessoriesManager;

            Seats = new ObservableCollection<SeatViewModel>();
            foreach(Seat seat in _manager.Seats )
            {
                Seats.Add(new SeatViewModel(seat) );
            }

            Speakers = new ObservableCollection<SpeakerViewModel>();
            foreach (Speaker speaker in _manager.Speakers)
            {
                Speakers.Add(new SpeakerViewModel(speaker));
            }
        }

        public bool IsViewModelOf(AccessoriesManager manager)
        {
            return manager == _manager;
        }

        public void AddSeat()
        {
            Seat seat = new Seat();
            SeatViewModel vm = new SeatViewModel(seat);
            Seats.Add(vm);
            Model.Seats.Add(seat);
        }

        public void RemoveSeat(SeatViewModel seat)
        {
            Seats.Remove(seat);
            Model.Seats.Remove(seat.Model);
        }

        public void AddSpeaker()
        {
            Speaker speaker = new Speaker();
            SpeakerViewModel vm = new SpeakerViewModel(speaker);
            Speakers.Add(vm);
            Model.Speakers.Add(speaker);
        }

        public void RemoveSpeaker(SpeakerViewModel speaker)
        {
            Speakers.Remove(speaker);
            Model.Speakers.Remove(speaker.Model);
        }

    }
}
