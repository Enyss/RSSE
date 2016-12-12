using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;



namespace RSSE
{
    class RCSViewModel : SubsystemViewModel
    {
        private RCS _rcs;

        new public RCS Model { get { return _rcs; } }
        override public SubsystemTypeEnum SystemType { get { return _rcs.SystemType; } }

        public string Name
        {
            get { return SubsystemTypeEnumExtensions.ToNiceString(_rcs.SystemType); }
        }
        public string Group { get { return _rcs.SystemGroup; } }

        public ObservableCollection<RCSThrusterViewModel> Thrusters { get; set; }


        public ICommand AddRCSThrusterCommand { get; private set; }
        public ICommand RemoveRCSThrusterCommand { get; private set; }


        public RCSViewModel()
            : this(null)
        {
        }

        public RCSViewModel(RCS rcs)
        {
            AddRCSThrusterCommand = new DelegateCommand(AddThruster);
            RemoveRCSThrusterCommand = new DelegateCommand<RCSThrusterViewModel>(RemoveThruster);

            if (rcs != null)
            {
                LoadFrom(rcs);
            }

        }

        override public void LoadFrom(Subsystem rcs)
        {
            _rcs = (RCS)rcs;

            Thrusters = new ObservableCollection<RCSThrusterViewModel>();
            foreach (RCSThruster thruster in _rcs.thrusters)
            {
                Thrusters.Add(new RCSThrusterViewModel(thruster));
            }
            
        }

        public bool IsViewModelOf(RCS rcs)
        {
            return rcs == _rcs;
        }

        public void AddThruster()
        {
            RCSThruster thruster = new RCSThruster();
            RCSThrusterViewModel vm = new RCSThrusterViewModel(thruster);
            Thrusters.Add(vm);
            _rcs.thrusters.Add(thruster);
        }

        public void RemoveThruster(RCSThrusterViewModel thruster)
        {
            Thrusters.Remove(thruster);
            _rcs.thrusters.Remove(thruster.Model);
        }
    }
}

