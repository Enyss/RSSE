using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace RSSE
{
    public class AttachementViewModel : ObservableObject
    {
        private Attachement _attachement;

        public Attachement Model { get { return _attachement; } }

        public AttachementViewModel() { }

        public AttachementViewModel(Attachement attachement)
        {
            LoadFrom(attachement);
        }

        public void LoadFrom(Attachement attachement)
        {
            _attachement = attachement;
        }

        #region Properties 
        public string Name
        {
            get { return _attachement.name; }
            set
            {
                _attachement.name = value;
                OnPropertyChanged();
            }
        }
        public Vector3 Position
        {
            get { return _attachement.position; }
            set
            {
                _attachement.position = value;
                OnPropertyChanged();
            }
        }
        public Vector3 Rotation
        {
            get { return _attachement.rotation; }
            set
            {
                _attachement.rotation = value;
                OnPropertyChanged();
            }
        }
        public int Size
        {
            get { return _attachement.size; }
            set
            {
                _attachement.size = value;
                OnPropertyChanged();
            }
        }
        public bool IsTowing
        {
            get { return _attachement.isTowing; }
            set
            {
                _attachement.isTowing = value;
                OnPropertyChanged();
            }
        }
        public bool InvertX
        {
            get { return _attachement.invertX; }
            set
            {
                _attachement.invertX = value;
                OnPropertyChanged();
            }
        }
        public bool SwapXZ
        {
            get { return _attachement.swapXZ; }
            set
            {
                _attachement.swapXZ = value;
                OnPropertyChanged();
            }
        }
        #endregion


    }
}
