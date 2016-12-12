using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;



namespace RSSE
{
    class LSSViewModel : SubsystemViewModel
    {

        private LSS _lss;

        new public LSS Model { get { return _lss; } }
        override public SubsystemTypeEnum SystemType { get { return _lss.SystemType; } }

        public string Name
        {
            get { return SubsystemTypeEnumExtensions.ToNiceString(_lss.SystemType); }
        }
        public string Group { get { return _lss.SystemGroup; } }
        public ObservableCollection<ScrubberViewModel> Scrubbers { get; set; }


        public ICommand AddScrubberCommand { get; private set; }
        public ICommand RemoveScrubberCommand { get; private set; }

        #region Properties


        public int TankAtotal
        {
            get { return _lss.tankAtotal; }
            set
            {
                _lss.tankAtotal = value;
                OnPropertyChanged();
            }
        }
        public int TankBtotal
        {
            get { return _lss.tankBtotal; }
            set
            {
                _lss.tankBtotal = value;
                OnPropertyChanged();
            }
        }
        public int TankCtotal
        {
            get { return _lss.tankCtotal; }
            set
            {
                _lss.tankCtotal = value;
                OnPropertyChanged();
            }
        }
        public double LifeSupportAtankCAP
        {
            get { return _lss.lifeSupportAtankCAP; }
            set
            {
                _lss.lifeSupportAtankCAP = value;
                OnPropertyChanged();
            }
        }
        public double LifeSupportBtankCAP
        {
            get { return _lss.lifeSupportBtankCAP; }
            set
            {
                _lss.lifeSupportBtankCAP = value;
                OnPropertyChanged();
            }
        }
        public double ConsumableTankCAP
        {
            get { return _lss.consumableTankCAP; }
            set
            {
                _lss.consumableTankCAP = value;
                OnPropertyChanged();
            }
        }


        public int Mount_MAX
        {
            get { return _lss.mount_MAX; }
            set
            {
                _lss.mount_MAX = value;
                OnPropertyChanged();
            }
        }
        public int Sys_EB
        {
            get { return _lss.sys_EB; }
            set
            {
                _lss.sys_EB = value;
                OnPropertyChanged();
            }
        }
        public int Sys_quad
        {
            get { return _lss.sys_quad; }
            set
            {
                _lss.sys_quad = value;
                OnPropertyChanged();
            }
        }

        #endregion

        public LSSViewModel()
            : this(null)
        {
        }

        public LSSViewModel(LSS lss)
        {
            AddScrubberCommand = new DelegateCommand(AddScrubber);
            RemoveScrubberCommand = new DelegateCommand<ScrubberViewModel>(RemoveScrubber);

            if (lss != null)
            {
                LoadFrom(lss);
            }

        }

        override public void LoadFrom(Subsystem lss)
        {
            _lss = (LSS)lss;

            Scrubbers = new ObservableCollection<ScrubberViewModel>();
            foreach (Scrubber scrubber in _lss.scrubbers)
            {
                Scrubbers.Add(new ScrubberViewModel(scrubber));
            }

        }

        private void RemoveScrubber(ScrubberViewModel scrubber)
        {
            Scrubbers.Remove(scrubber);
            _lss.scrubbers.Remove(scrubber.Model);
        }

        private void AddScrubber()
        {
            Scrubber scrubber = new Scrubber();
            ScrubberViewModel vm = new ScrubberViewModel(scrubber);
            Scrubbers.Add(vm);
            _lss.scrubbers.Add(scrubber);
        }

        public bool IsViewModelOf(LSS lss)
        {
            return lss == _lss;
        }

    }
}
