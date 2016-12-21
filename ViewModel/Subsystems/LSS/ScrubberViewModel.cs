using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace RSSE
{
    class ScrubberViewModel : ObservableObject
    {
        private Scrubber _scrubber;
        public Scrubber Model { get { return _scrubber; } }

        public ScrubberViewModel() { }

        public ScrubberViewModel(Scrubber scrubber)
        {
            LoadFrom(scrubber);
        }

        #region Properties

        public string Name
        {
            get { return "Scrubber"; }
        }

        public bool Is_SPARE
        {
            get { return _scrubber.is_SPARE; }
            set
            {
                _scrubber.is_SPARE = value;
                OnPropertyChanged();
}
        }

        public Vec3 Position
        {
            get { return _scrubber.position; }
            set
            {
                _scrubber.position = value;
                OnPropertyChanged();
            }
        }

        public Vec3 Rotation
        {
            get { return _scrubber.rotation; }
            set
            {
                _scrubber.rotation = value;
                OnPropertyChanged();
            }
        }

        public int EquipBay
        {
            get { return _scrubber.equipBay; }
            set
            {
                _scrubber.equipBay = value;
                OnPropertyChanged();
            }   
        }

        public int Quad
        {
            get { return _scrubber.quad; }
            set
            {
                _scrubber.quad = value;
                OnPropertyChanged();
            }
        }

        #endregion

        public void LoadFrom(Scrubber scrubber)
        {
            _scrubber = scrubber;
        }

        public bool IsViewModelOf(Scrubber scrubber)
        {
            return scrubber.Equals(_scrubber);
        }
    }
}

