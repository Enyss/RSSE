using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;



namespace RSSE
{
    class COMMViewModel : SubsystemViewModel
    {

        private COMM _comm;

        new public COMM Model { get { return _comm; } }
        override public SubsystemTypeEnum SystemType { get { return _comm.SystemType; } }

        public string Name
        {
            get { return SubsystemTypeEnumExtensions.ToNiceString(_comm.SystemType); }
        }
        public string Group { get { return _comm.SystemGroup; } }

        #region Properties

        public int Mount_MAX
        {
            get { return _comm.mount_MAX; }
            set
            {
                _comm.mount_MAX = value;
                OnPropertyChanged();
            }
        }
        public int Sys1_EB
        {
            get { return _comm.sys1_EB; }
            set
            {
                _comm.sys1_EB = value;
                OnPropertyChanged();
            }
        }
        public int Sys1_quad
        {
            get { return _comm.sys1_quad; }
            set
            {
                _comm.sys1_quad = value;
                OnPropertyChanged();
            }
        }
        public int Sys2_EB
        {
            get { return _comm.sys2_EB; }
            set
            {
                _comm.sys2_EB = value;
                OnPropertyChanged();
            }
        }
        public int Sys2_quad
        {
            get { return _comm.sys2_quad; }
            set
            {
                _comm.sys2_quad = value;
                OnPropertyChanged();
            }
        }

        #endregion

        public COMMViewModel()
            : this(null)
        {
        }

        public COMMViewModel(COMM comm)
        {
            if (comm != null)
            {
                LoadFrom(comm);
            }

        }

        override public void LoadFrom(Subsystem comm)
        {
            _comm = (COMM)comm;

        }

        public bool IsViewModelOf(COMM comm)
        {
            return comm == _comm;
        }

    }
}
