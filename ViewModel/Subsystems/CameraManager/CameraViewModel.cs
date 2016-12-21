using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RSSE
{
    class CameraViewModel : ObservableObject
    {

        private Camera _camera;

        public Camera Model { get { return _camera; } }

        public CameraViewModel() { }

        public CameraViewModel(Camera camera)
        {
            LoadFrom(camera);
        }

        public void LoadFrom(Camera camera)
        {
            _camera = camera;
        }

        #region Properties 
        public string Name
        {
            get { return _camera.name; }
            set
            {
                _camera.name = value;
                OnPropertyChanged();
            }
        }
        public Vec3 Position
        {
            get { return _camera.position; }
            set
            {
                _camera.position = value;
                OnPropertyChanged();
            }
        }
        public Vec3 Rotation
        {
            get { return _camera.rotation; }
            set
            {
                _camera.rotation = value;
                OnPropertyChanged();
            }
        }
        public int Id
        {
            get { return _camera.id; }
            set
            {
                _camera.id = value;
                OnPropertyChanged();
            }
        }
        public string ParentTo
        {
            get { return _camera.parentTo; }
            set
            {
                _camera.parentTo = value;
                OnPropertyChanged();
            }
        }
        public string Name_UI
        {
            get { return _camera.name_UI; }
            set
            {
                _camera.name_UI = value;
                OnPropertyChanged();
            }
        }
        #endregion

    }
}
