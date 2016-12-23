using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;



namespace RSSE
{
    class VMSViewModel : SubsystemViewModel
    {

        private VMS _vms;

        new public VMS Model { get { return _vms; } }
        override public SubsystemTypeEnum SystemType { get { return _vms.SystemType; } }

        public string Name
        {
            get { return SubsystemTypeEnumExtensions.ToNiceString(_vms.SystemType); }
        }
        public string Group { get { return _vms.SystemGroup; } }

        #region Properties

        public Vec2 Dimensions
        {
            get { return _vms.dimensions; }
            set
            {
                _vms.dimensions = value;
                OnPropertyChanged();
            }
        }
        public double NormFOV
        {
            get { return _vms.normFOV; }
            set
            {
                _vms.normFOV = value;
                OnPropertyChanged();
            }
        }

        #endregion

        public VMSViewModel()
            : this(null)
        {
        }

        public VMSViewModel(VMS vms)
        {
            if (vms != null)
            {
                LoadFrom(vms);
            }

        }

        override public void LoadFrom(Subsystem vms)
        {
            _vms = (VMS)vms;

        }

        public bool IsViewModelOf(VMS vms)
        {
            return vms == _vms;
        }

    }
}
