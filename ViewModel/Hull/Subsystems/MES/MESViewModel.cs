using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;



namespace RSSE
{
    class MESViewModel : SubsystemViewModel
    {

        private MES _mes;

        new public MES Model { get { return _mes; } }
        override public SubsystemTypeEnum SystemType { get { return _mes.SystemType; } }

        public string Name
        {
            get { return SubsystemTypeEnumExtensions.ToNiceString(_mes.SystemType); }
        }
        public string Group { get { return _mes.SystemGroup; } }
        public ObservableCollection<MESEngineViewModel> Engines { get; set; }


        public ICommand AddMESEngineCommand { get; private set; }
        public ICommand RemoveMESEngineCommand { get; private set; }

        #region Properties

        public int Mount_MAX
        {
            get { return _mes.mount_MAX; }
            set
            {
                _mes.mount_MAX = value;
                OnPropertyChanged();
            }
        }
        public int Total_ALLOWED
        {
            get { return _mes.total_ALLOWED; }
            set
            {
                _mes.total_ALLOWED = value;
                OnPropertyChanged();
            }
        }
        public int Sys1_EB
        {
            get { return _mes.sys1_EB; }
            set
            {
                _mes.sys1_EB = value;
                OnPropertyChanged();
            }
        }
        public int Sys1_quad
        {
            get { return _mes.sys1_quad; }
            set
            {
                _mes.sys1_quad = value;
                OnPropertyChanged();
            }
        }

        #endregion

        public MESViewModel()
            : this(null)
        {
        }

        public MESViewModel(MES mes)
        {
            AddMESEngineCommand = new DelegateCommand(AddEngine);
            RemoveMESEngineCommand = new DelegateCommand<MESEngineViewModel>(RemoveEngine);

            if (mes != null)
            {
                LoadFrom(mes);
            }

        }

        override public void LoadFrom(Subsystem mes)
        {
            _mes = (MES)mes;

            Engines = new ObservableCollection<MESEngineViewModel>();
            foreach (MESEngine engine in _mes.engines)
            {
                Engines.Add(new MESEngineViewModel(engine));
            }

        }

        private void RemoveEngine(MESEngineViewModel engine)
        {
            Engines.Remove(engine);
            _mes.engines.Remove(engine.Model);
        }

        private void AddEngine()
        {
            MESEngine engine = new MESEngine();
            MESEngineViewModel vm = new MESEngineViewModel(engine);
            Engines.Add(vm);
            _mes.engines.Add(engine);
        }

        public bool IsViewModelOf(MES mes)
        {
            return mes == _mes;
        }

    }
}
