using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;



namespace RSSE
{
    class CSSMViewModel : SubsystemViewModel
    {

        private CSSM _cssm;

        new public CSSM Model { get { return _cssm; } }
        override public SubsystemTypeEnum SystemType { get { return _cssm.SystemType; } }

        public string Name
        {
            get { return SubsystemTypeEnumExtensions.ToNiceString(_cssm.SystemType); }
        }
        public string Group { get { return _cssm.SystemGroup; } }

        #region Properties

        public int Mount_MAX
        {
            get { return _cssm.mount_MAX; }
            set
            {
                _cssm.mount_MAX = value;
                OnPropertyChanged();
            }
        }
        public int Sys_EB
        {
            get { return _cssm.sys_EB; }
            set
            {
                _cssm.sys_EB = value;
                OnPropertyChanged();
            }
        }
        public int Sys_quad
        {
            get { return _cssm.sys_quad; }
            set
            {
                _cssm.sys_quad = value;
                OnPropertyChanged();
            }
        }
        public int Cargo_BAYS
        {
            get { return _cssm.cargo_BAYS; }
            set
            {
                _cssm.cargo_BAYS = value;
                OnPropertyChanged();
            }
        }
        public int Cargo_RADSattached
        {
            get { return _cssm.cargo_RADSattached; }
            set
            {
                _cssm.cargo_RADSattached = value;
                OnPropertyChanged();
            }
        }

        #endregion

        public CSSMViewModel()
            : this(null)
        {
        }

        public CSSMViewModel(CSSM cssm)
        {
            if (cssm != null)
            {
                LoadFrom(cssm);
            }

        }

        override public void LoadFrom(Subsystem cssm)
        {
            _cssm = (CSSM)cssm;

        }

        public bool IsViewModelOf(CSSM cssm)
        {
            return cssm == _cssm;
        }

    }
}
