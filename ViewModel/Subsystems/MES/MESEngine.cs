using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace RSSE
{
    class MESEngineViewModel : ObservableObject
    {
        private MESEngine _engine;
        public MESEngine Model { get { return _engine; } }

        public MESEngineViewModel() { }

        public MESEngineViewModel(MESEngine engine)
        {
            LoadFrom(engine);
        }

        #region Properties

        public string Name
        {
            get { return _engine.name; }
            set
            {
                _engine.name = value;
                OnPropertyChanged();
            }
        }
        public Vec3 Position
        {
            get { return _engine.position; }
            set
            {
                _engine.position = value;
                OnPropertyChanged();
            }
        }
        public Vec3 Rotation
        {
            get { return _engine.rotation; }
            set
            {
                _engine.rotation = value;
                OnPropertyChanged();
            }
        }
        

        #endregion

        public void LoadFrom(MESEngine engine)
        {
            _engine = engine;
        }

        public bool IsViewModelOf(MESEngine engine)
        {
            return engine.Equals(_engine);
        }
    }
}

