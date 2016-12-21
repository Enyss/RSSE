using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;



namespace RSSE
{
    class MTSViewModel : SubsystemViewModel
    {
        private MTS _mts;

        new public MTS Model { get { return _mts; } }
        override public SubsystemTypeEnum SystemType { get { return _mts.SystemType; } }

        public string Name
        {
            get { return SubsystemTypeEnumExtensions.ToNiceString(_mts.SystemType); }
        }
        public string Group { get { return _mts.SystemGroup; } }
        public ObservableCollection<MTSBoosterViewModel> Boosters { get; set; }
        public MTSControllerViewModel Controller { get; set; }

        public ICommand AddMTSBoosterCommand { get; private set; }
        public ICommand RemoveMTSBoosterCommand { get; private set; }

        #region Properties 
        public int Mount_MAX
        {
            get { return _mts.mount_MAX; }
            set
            {
                _mts.mount_MAX = value;
                OnPropertyChanged();
            }
        }
        public Vec3 MtsLocation
        {
            get { return _mts.mtsLocation; }
            set
            {
                _mts.mtsLocation = value;
                OnPropertyChanged();
            }
        }
        public double Nozzle_SIZE
        {
            get { return _mts.nozzle_SIZE; }
            set
            {
                _mts.nozzle_SIZE = value;
                OnPropertyChanged();
            }
        }
        #endregion

        public MTSViewModel()
            : this(null)
        {
        }

        public MTSViewModel(MTS mts)
        {
            AddMTSBoosterCommand = new DelegateCommand(AddMTSBooster);
            RemoveMTSBoosterCommand = new DelegateCommand<MTSBoosterViewModel>(RemoveMTSBooster);

            if (mts != null)
            {
                LoadFrom(mts);
            }

        }

        override public void LoadFrom(Subsystem mts)
        {
            _mts = (MTS)mts;
            Controller = new MTSControllerViewModel(_mts.controller);
            Boosters = new ObservableCollection<MTSBoosterViewModel>();
            foreach (MTSBooster booster in _mts.boosters)
            {
                Boosters.Add(new MTSBoosterViewModel(booster));
            }
            
        }

        public bool IsViewModelOf(MTS mts)
        {
            return mts == _mts;
        }

        public void AddMTSBooster()
        {
            MTSBooster booster = new MTSBooster();
            MTSBoosterViewModel vm = new MTSBoosterViewModel(booster);
            Boosters.Add(vm);
            _mts.boosters.Add(booster);
        }

        public void RemoveMTSBooster(MTSBoosterViewModel booster)
        {
            Boosters.Remove(booster);
            _mts.boosters.Remove(booster.Model);
        }
    }
}

