using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;



namespace RSSE
{
    class BMSViewModel : SubsystemViewModel
    {

        private BMS _bms;

        new public BMS Model { get { return _bms; } }
        override public SubsystemTypeEnum SystemType { get { return _bms.SystemType; } }

        public string Name
        {
            get { return SubsystemTypeEnumExtensions.ToNiceString(_bms.SystemType); }
        }
        public string Group { get { return _bms.SystemGroup; } }

        #region Properties

        public int Mount_MAX
        {
            get { return _bms.mount_MAX; }
            set
            {
                _bms.mount_MAX = value;
                OnPropertyChanged();
            }
        }
        public int Total_ALLOWED
        {
            get { return _bms.total_ALLOWED; }
            set
            {
                _bms.total_ALLOWED = value;
                OnPropertyChanged();
            }
        }
        public int Sys1_EB
        {
            get { return _bms.sys1_EB; }
            set
            {
                _bms.sys1_EB = value;
                OnPropertyChanged();
            }
        }
        public int Sys1_quad
        {
            get { return _bms.sys1_quad; }
            set
            {
                _bms.sys1_quad = value;
                OnPropertyChanged();
            }
        }
        public int Sys2_EB
        {
            get { return _bms.sys2_EB; }
            set
            {
                _bms.sys2_EB = value;
                OnPropertyChanged();
            }
        }
        public int Sys2_quad
        {
            get { return _bms.sys2_quad; }
            set
            {
                _bms.sys2_quad = value;
                OnPropertyChanged();
            }
        }

        #endregion

        public BMSViewModel()
            : this(null)
        {
        }

        public BMSViewModel(BMS bms)
        {
            if (bms != null)
            {
                LoadFrom(bms);
            }

        }

        override public void LoadFrom(Subsystem bms)
        {
            _bms = (BMS)bms;

        }

        public bool IsViewModelOf(BMS bms)
        {
            return bms == _bms;
        }

    }
}
