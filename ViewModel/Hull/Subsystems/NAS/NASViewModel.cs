using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;



namespace RSSE
{
    class NASViewModel : SubsystemViewModel
    {

        private NAS _nas;

        new public NAS Model { get { return _nas; } }
        override public SubsystemTypeEnum SystemType { get { return _nas.SystemType; } }

        public string Name
        {
            get { return SubsystemTypeEnumExtensions.ToNiceString(_nas.SystemType); }
        }
        public string Group { get { return _nas.SystemGroup; } }

        #region Properties

        public int Mount_MAX
        {
            get { return _nas.mount_MAX; }
            set
            {
                _nas.mount_MAX = value;
                OnPropertyChanged();
            }
        }
        public int Sys_EB
        {
            get { return _nas.sys_EB; }
            set
            {
                _nas.sys_EB = value;
                OnPropertyChanged();
            }
        }
        public int Sys_quad
        {
            get { return _nas.sys_quad; }
            set
            {
                _nas.sys_quad = value;
                OnPropertyChanged();
            }
        }
        #endregion

        public NASViewModel()
            : this(null)
        {
        }

        public NASViewModel(NAS nas)
        {
            if (nas != null)
            {
                LoadFrom(nas);
            }

        }

        override public void LoadFrom(Subsystem nas)
        {
            _nas = (NAS)nas;

        }

        public bool IsViewModelOf(NAS nas)
        {
            return nas == _nas;
        }

    }
}
