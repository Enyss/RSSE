using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE
{
    public class SurfaceViewModel : ObservableObject
    {
        private Surface _surface;
        public Surface Model { get { return _surface; } }

        public SurfaceViewModel()
        {
            _surface = new Surface();
        }

        public SurfaceViewModel(Surface surface)
        {
            _surface = surface;
        }

        #region Properties
        public string Name
        {
            get { return _surface.name; }
            set
            {
                _surface.name = value;
                OnPropertyChanged();
            }
        }
        public string Surface_FUNC
        {
            get { return _surface.surface_FUNC; }
            set
            {
                _surface.surface_FUNC = value;
                OnPropertyChanged();
            }
        }
        public int System_ID
        {
            get { return _surface.system_ID; }
            set
            {
                _surface.system_ID = value;
                OnPropertyChanged();
            }
        }
        public bool Trigger_ONLY
        {
            get { return _surface.trigger_ONLY; }
            set
            {
                _surface.trigger_ONLY = value;
                OnPropertyChanged();
            }
        }
        public double Output_TOTAL
        {
            get { return _surface.output_TOTAL; }
            set
            {
                _surface.output_TOTAL = value;
                OnPropertyChanged();
            }
        }
        public double Output_VALUE
        {
            get { return _surface.output_VALUE; }
            set
            {
                _surface.output_VALUE = value;
                OnPropertyChanged();
            }
        }
        #endregion
    }
}
