using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;



namespace RSSE
{
    class MFDViewModel : SubsystemViewModel
    {

        private MFD _mfd;

        new public MFD Model { get { return _mfd; } }
        override public SubsystemTypeEnum SystemType { get { return _mfd.SystemType; } }

        public string Name
        {
            get { return SubsystemTypeEnumExtensions.ToNiceString(_mfd.SystemType); }
        }
        public string Group { get { return _mfd.SystemGroup; } }

        #region Properties

        public Vector3 UpperLeft
        {
            get { return _mfd.upperLeft; }
            set
            {
                _mfd.upperLeft = value;
                OnPropertyChanged();
            }
        }
        public Vector3 Dimensions
        {
            get { return _mfd.dimensions; }
            set
            {
                _mfd.dimensions = value;
                OnPropertyChanged();
            }
        }

        #endregion

        public MFDViewModel()
            : this(null)
        {
        }

        public MFDViewModel(MFD mfd)
        {
            if (mfd != null)
            {
                LoadFrom(mfd);
            }

        }

        override public void LoadFrom(Subsystem mfd)
        {
            _mfd = (MFD)mfd;

        }

        public bool IsViewModelOf(MFD mfd)
        {
            return mfd == _mfd;
        }

    }
}
