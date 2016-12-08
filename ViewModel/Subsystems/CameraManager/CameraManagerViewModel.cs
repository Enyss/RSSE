using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;



namespace RSSE
{
    class CameraManagerViewModel : SubsystemViewModel
    {
        private CameraManager _manager;

        new public CameraManager Model { get { return _manager; } }
        override public SubsystemTypeEnum SystemType { get { return _manager.SystemType; } }

        public string Name
        {
            get { return SubsystemTypeEnumExtensions.ToNiceString(_manager.SystemType); }
        }
        public string Group { get { return _manager.SystemGroup; } }
        public ObservableCollection<CameraViewModel> Cameras { get; set; }


        public ICommand AddCameraCommand { get; private set; }
        public ICommand RemoveCameraCommand { get; private set; }


        public CameraManagerViewModel()
            : this(null)
        {
        }

        public CameraManagerViewModel(CameraManager cameraManager)
        {
            AddCameraCommand = new DelegateCommand(AddCamera);
            RemoveCameraCommand = new DelegateCommand<CameraViewModel>(RemoveCamera);

            if (cameraManager != null)
            {
                LoadFrom(cameraManager);
            }

        }

        override public void LoadFrom(Subsystem cameraManager)
        {
            _manager = (CameraManager)cameraManager;

            Cameras = new ObservableCollection<CameraViewModel>();
            foreach (Camera camera in _manager.cameras)
            {
                Cameras.Add(new CameraViewModel(camera));
            }

        }

        public bool IsViewModelOf(CameraManager manager)
        {
            return manager == _manager;
        }

        public void AddCamera()
        {
            Camera camera = new Camera();
            CameraViewModel vm = new CameraViewModel(camera);
            Cameras.Add(vm);
            _manager.cameras.Add(camera);
        }

        public void RemoveCamera(CameraViewModel camera)
        {
            Cameras.Remove(camera);
            _manager.cameras.Remove(camera.Model);
        }
    }
}
