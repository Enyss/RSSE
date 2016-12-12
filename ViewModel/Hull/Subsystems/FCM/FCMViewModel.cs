using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;



namespace RSSE
{
    class FCMViewModel : SubsystemViewModel
    {

        private FCM _fcm;

        new public FCM Model { get { return _fcm; } }
        override public SubsystemTypeEnum SystemType { get { return _fcm.SystemType; } }

        public string Name
        {
            get { return SubsystemTypeEnumExtensions.ToNiceString(_fcm.SystemType); }
        }
        public string Group { get { return _fcm.SystemGroup; } }

        #region Properties

        public int Mount_MAX
        {
            get { return _fcm.mount_MAX; }
            set
            {
                _fcm.mount_MAX = value;
                OnPropertyChanged();
            }
        }
        public int Total_ALLOWED
        {
            get { return _fcm.total_ALLOWED; }
            set
            {
                _fcm.total_ALLOWED = value;
                OnPropertyChanged();
            }
        }
        public int Sys1_EB
        {
            get { return _fcm.sys1_EB; }
            set
            {
                _fcm.sys1_EB = value;
                OnPropertyChanged();
            }
        }
        public int Sys1_quad
        {
            get { return _fcm.sys1_quad; }
            set
            {
                _fcm.sys1_quad = value;
                OnPropertyChanged();
            }
        }
        public int Sys2_EB
        {
            get { return _fcm.sys2_EB; }
            set
            {
                _fcm.sys2_EB = value;
                OnPropertyChanged();
            }
        }
        public int Sys2_quad
        {
            get { return _fcm.sys2_quad; }
            set
            {
                _fcm.sys2_quad = value;
                OnPropertyChanged();
            }
        }

        #endregion

        public FCMViewModel()
            : this(null)
        {
        }

        public FCMViewModel(FCM fcm)
        {
            if (fcm != null)
            {
                LoadFrom(fcm);
            }

        }

        override public void LoadFrom(Subsystem fcm)
        {
            _fcm = (FCM)fcm;

        }

        public bool IsViewModelOf(FCM fcm)
        {
            return fcm == _fcm;
        }

    }
}
