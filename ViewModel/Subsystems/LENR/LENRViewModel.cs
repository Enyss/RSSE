using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;



namespace RSSE
{
    class LENRViewModel : SubsystemViewModel
    {

        private LENR _lenr;

        new public LENR Model { get { return _lenr; } }
        override public SubsystemTypeEnum SystemType { get { return _lenr.SystemType; } }

        public string Name
        {
            get { return SubsystemTypeEnumExtensions.ToNiceString(_lenr.SystemType); }
        }
        public string Group { get { return _lenr.SystemGroup; } }

        #region Properties

        public int Mount_MAX
        {
            get { return _lenr.mount_MAX; }
            set
            {
                _lenr.mount_MAX = value;
                OnPropertyChanged();
            }
        }
        public int Total_ALLOWED
        {
            get { return _lenr.total_ALLOWED; }
            set
            {
                _lenr.total_ALLOWED = value;
                OnPropertyChanged();
            }
        }
        public int Sys1_EB
        {
            get { return _lenr.sys1_EB; }
            set
            {
                _lenr.sys1_EB = value;
                OnPropertyChanged();
            }
        }
        public int Sys1_quad
        {
            get { return _lenr.sys1_quad; }
            set
            {
                _lenr.sys1_quad = value;
                OnPropertyChanged();
            }
        }

        #endregion

        public LENRViewModel()
            : this(null)
        {
        }

        public LENRViewModel(LENR lenr)
        {
            if (lenr != null)
            {
                LoadFrom(lenr);
            }

        }

        override public void LoadFrom(Subsystem lenr)
        {
            _lenr = (LENR)lenr;

        }

        public bool IsViewModelOf(LENR lenr)
        {
            return lenr == _lenr;
        }

    }
}
