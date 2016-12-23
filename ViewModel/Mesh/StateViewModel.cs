using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE
{
    public class StateViewModel : ObservableObject
    {
        private State _state;
        public State Model { get { return _state; } }

        public StateViewModel()
        {
            _state = new State();
        }

        public StateViewModel(State state)
        {
            _state = state;
        }

        public string Name
        {
            get { return _state.name; }
            set
            {
                _state.name = value;
                OnPropertyChanged();
            }
        }
        public StateMotionTypeEnum MotionType
        {
            get { return _state.motionType; }
            set
            {
                _state.motionType = value;
                OnPropertyChanged();
            }
        }
        public bool IsTriggered  { get { return MotionType == StateMotionTypeEnum.EVENTDRIVEN; } }

        public Vec3 Position
        {
            get { return _state.position; }
            set
            {
                _state.position = value;
                OnPropertyChanged();
            }
        }
        public Vec3 Rotation
        {
            get { return _state.rotation; }
            set
            {
                _state.rotation = value;
                OnPropertyChanged();
            }
        }
        public Vec3 Scale
        {
            get { return _state.scale; }
            set
            {
                _state.scale = value;
                OnPropertyChanged();
            }
        }
        public int StartPause
        {
            get { return _state.startPause; }
            set
            {
                _state.startPause = value;
                OnPropertyChanged();
            }
        }
        public int Rate
        {
            get { return _state.rate; }
            set
            {
                _state.rate = value;
                OnPropertyChanged();
            }
        }
        public bool Visible
        {
            get { return _state.visible; }
            set
            {
                _state.visible = value;
                OnPropertyChanged();
            }
        }
        public bool CollisionEnabled
        {
            get { return _state.collisionEnabled; }
            set
            {
                _state.collisionEnabled = value;
                OnPropertyChanged();
            }
        }
        public string TriggerFunction
        {
            get { return _state.triggerFunction; }
            set
            {
                _state.triggerFunction = value;
                OnPropertyChanged();
            }
        }
        public int TriggerSysID
        {
            get { return _state.triggerSysID; }
            set
            {
                _state.triggerSysID = value;
                OnPropertyChanged();
            }
        }
        public int TriggerState
        {
            get { return _state.triggerState; }
            set
            {
                _state.triggerState = value;
                OnPropertyChanged();
            }
        }
    }
}
