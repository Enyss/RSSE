using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace RSSE
{
    public class MTSControllerViewModel : ObservableObject
    {
        private MTSController _controller;

        public MTSController Model { get { return _controller; } }

        public MTSControllerViewModel() { }

        public MTSControllerViewModel(MTSController controller)
        {
            LoadFrom(controller);
        }

        public void LoadFrom(MTSController controller)
        {
            _controller = controller;
        }

        #region Properties 
        public int EquipBay
        {
            get { return _controller.equipBay; }
            set
            {
                _controller.equipBay = value;
                OnPropertyChanged();
            }
        }
        public bool Is_SPARE
        {
            get { return _controller.is_SPARE; }
            set
            {
                _controller.is_SPARE = value;
                OnPropertyChanged();
            }
        }
        public Vec3 Position
        {
            get { return _controller.position; }
            set
            {
                _controller.position = value;
                OnPropertyChanged();
            }
        }
        public Vec3 Rotation
        {
            get { return _controller.rotation; }
            set
            {
                _controller.rotation = value;
                OnPropertyChanged();
            }
        }
        public int Quad
        {
            get { return _controller.quad; }
            set
            {
                _controller.quad = value;
                OnPropertyChanged();
            }
        }
        #endregion


    }
}
