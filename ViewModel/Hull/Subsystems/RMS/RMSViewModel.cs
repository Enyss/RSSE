using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;



namespace RSSE
{
    class RMSViewModel : SubsystemViewModel
    {

        private RMS _rms;

        new public RMS Model { get { return _rms; } }
        override public SubsystemTypeEnum SystemType { get { return _rms.SystemType; } }

        public string Name
        {
            get { return SubsystemTypeEnumExtensions.ToNiceString(_rms.SystemType); }
        }
        public string Group { get { return _rms.SystemGroup; } }

        #region Properties


        public int Hardmounted_TOTAL
        {
            get { return _rms.hardmounted_TOTAL; }
            set
            {
                _rms.hardmounted_TOTAL = value;
                OnPropertyChanged();
            }
        }
        public int Sys1_JOINTtotal
        {
            get { return _rms.sys1_JOINTtotal; }
            set
            {
                _rms.sys1_JOINTtotal = value;
                OnPropertyChanged();
            }
        }
        public int Sys1_EB
        {
            get { return _rms.sys1_EB; }
            set
            {
                _rms.sys1_EB = value;
                OnPropertyChanged();
            }
        }
        public int Sys1_quad
        {
            get { return _rms.sys1_quad; }
            set
            {
                _rms.sys1_quad = value;
                OnPropertyChanged();
            }
        }

        #endregion

        public RMSViewModel()
            : this(null)
        {
        }

        public RMSViewModel(RMS rms)
        {
            if (rms != null)
            {
                LoadFrom(rms);
            }

        }

        override public void LoadFrom(Subsystem rms)
        {
            _rms = (RMS)rms;

        }

        public bool IsViewModelOf(RMS rms)
        {
            return rms == _rms;
        }

    }
}
