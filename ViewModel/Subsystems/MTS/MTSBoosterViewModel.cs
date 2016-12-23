using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace RSSE
{
    public class MTSBoosterViewModel : ObservableObject
    {
        private MTSBooster _booster;

        public MTSBooster Model { get { return _booster; } }

        public MTSBoosterViewModel() { }

        public MTSBoosterViewModel(MTSBooster booster)
        {
            LoadFrom(booster);
        }

        public void LoadFrom(MTSBooster booster)
        {
            _booster = booster;
        }

        #region Properties 
        public string Name
        {
            get { return _booster.name; }
            set
            {
                _booster.name = value;
                OnPropertyChanged();
            }
        }
        public Vec3 Position
        {
            get { return _booster.position; }
            set
            {
                _booster.position = value;
                OnPropertyChanged();
            }
        }
        public Vec3 Vector
        {
            get { return _booster.vector; }
            set
            {
                _booster.vector = value;
                OnPropertyChanged();
            }
        }
        public Vec3 Pos_REV
        {
            get { return _booster.pos_REV; }
            set
            {
                _booster.pos_REV = value;
                OnPropertyChanged();
            }
        }
        public Vec3 Vctr_REV
        {
            get { return _booster.vctr_REV; }
            set
            {
                _booster.vctr_REV = value;
                OnPropertyChanged();
            }
        }
        public int Quad
        {
            get { return _booster.quad; }
            set
            {
                _booster.quad = value;
                OnPropertyChanged();
            }
        }
        public string Vfx
        {
            get { return _booster.vfx; }
            set
            {
                _booster.vfx = value;
                OnPropertyChanged();
            }
        }
        public string Vfx_REV
        {
            get { return _booster.vfx_REV; }
            set
            {
                _booster.vfx_REV = value;
                OnPropertyChanged();
            }
        }

        #endregion


    }
}
