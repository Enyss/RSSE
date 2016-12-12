using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace RSSE
{
    public class MeshSurfacesDataViewModel : ObservableObject
    {
        private MeshSurfacesData _surfacesData;
        public MeshSurfacesData Model { get { return _surfacesData; } }
        public ObservableCollection<SurfaceViewModel> Surfaces { get; set; }

        public MeshSurfacesDataViewModel()
        {
            _surfacesData = new MeshSurfacesData();
            Surfaces = new ObservableCollection<SurfaceViewModel>();
        }

        public MeshSurfacesDataViewModel(MeshSurfacesData surfacesData)
        {
            _surfacesData = surfacesData;
            Surfaces = new ObservableCollection<SurfaceViewModel>();
            foreach(Surface surface in _surfacesData.surfaces)
            {
                Surfaces.Add(new SurfaceViewModel(surface));
            }

            
        }

        public SurfaceTypeEnum Surface_EMISSION
        {
            get { return _surfacesData.surface_EMISSION; }
            set
            {
                _surfacesData.surface_EMISSION = value;
                OnPropertyChanged();
            }
        }
    }
}
