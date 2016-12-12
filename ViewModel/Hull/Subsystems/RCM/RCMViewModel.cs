using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;



namespace RSSE
{
    class RCMViewModel : SubsystemViewModel
    {

        private RCM _rcm;

        new public RCM Model { get { return _rcm; } }
        override public SubsystemTypeEnum SystemType { get { return _rcm.SystemType; } }

        public string Name
        {
            get { return SubsystemTypeEnumExtensions.ToNiceString(_rcm.SystemType); }
        }
        public string Group { get { return _rcm.SystemGroup; } }

        #region Properties

        public int Mount_MAX
        {
            get { return _rcm.mount_MAX; }
            set
            {
                _rcm.mount_MAX = value;
                OnPropertyChanged();
            }
        }
        public int Sys_EB
        {
            get { return _rcm.sys_EB; }
            set
            {
                _rcm.sys_EB = value;
                OnPropertyChanged();
            }
        }
        public int Sys_quad
        {
            get { return _rcm.sys_quad; }
            set
            {
                _rcm.sys_quad = value;
                OnPropertyChanged();
            }
        }
        #endregion

        public RCMViewModel()
            : this(null)
        {
        }

        public RCMViewModel(RCM rcm)
        {
            if (rcm != null)
            {
                LoadFrom(rcm);
            }

        }

        override public void LoadFrom(Subsystem rcm)
        {
            _rcm = (RCM)rcm;

        }

        public bool IsViewModelOf(RCM rcm)
        {
            return rcm == _rcm;
        }

    }
}
