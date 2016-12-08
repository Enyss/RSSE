using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace RSSE
{
    public class MeshStateDataViewModel : ObservableObject
    {
        private MeshStatesData _stateData;
        public MeshStatesData Model { get { return _stateData; } }

        public ObservableCollection<StateViewModel> States { get; set; }

        public ICommand AddStateCommand { get; private set; }
        public ICommand RemoveStateCommand { get; private set; }

        public MeshStateDataViewModel()
        {
            _stateData = new MeshStatesData();
            States = new ObservableCollection<StateViewModel>();
            AddStateCommand = new DelegateCommand(AddState);
            RemoveStateCommand = new DelegateCommand<StateViewModel>(RemoveState);
        }
        public MeshStateDataViewModel(MeshStatesData stateData)
        {
            _stateData = stateData;
            States = new ObservableCollection<StateViewModel>();
            AddStateCommand = new DelegateCommand(AddState);
            RemoveStateCommand = new DelegateCommand<StateViewModel>(RemoveState);

            foreach (State state in _stateData.states)
            {
                States.Add(new StateViewModel(state));
            }
        }

        #region Properties
        public string Function
        {
            get { return _stateData.function; }
            set
            {
                _stateData.function = value;
                OnPropertyChanged();
            }
        }
        public int FunctionID
        {
            get { return _stateData.functionID; }
            set
            {
                _stateData.functionID = value;
                OnPropertyChanged();
            }
        }
        public string UiType
        {
            get { return _stateData.uiType; }
            set
            {
                _stateData.uiType = value;
                OnPropertyChanged();
            }
        }
        public int UiPage
        {
            get { return _stateData.uiPage; }
            set
            {
                _stateData.uiPage = value;
                OnPropertyChanged();
            }
        }
        #endregion

        public void AddState()
        {
            State state = new State();
            StateViewModel vm = new StateViewModel(state);
            States.Add(vm);
            _stateData.states.Add(state);
        }

        public void RemoveState(StateViewModel state)
        {
            States.Remove(state);
            _stateData.states.Remove(state.Model);
        }
    }
}
