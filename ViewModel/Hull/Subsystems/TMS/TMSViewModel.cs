using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;



namespace RSSE
{
    class TMSViewModel : SubsystemViewModel
    {

        private TMS _tms;

        new public TMS Model { get { return _tms; } }
        override public SubsystemTypeEnum SystemType { get { return _tms.SystemType; } }

        public string Name
        {
            get { return SubsystemTypeEnumExtensions.ToNiceString(_tms.SystemType); }
        }
        public string Group { get { return _tms.SystemGroup; } }

        #region Properties

        public int Mount_MAX
        {
            get { return _tms.mount_MAX; }
            set
            {
                _tms.mount_MAX = value;
                OnPropertyChanged();
            }
        }
        public int Sys_EB
        {
            get { return _tms.sys_EB; }
            set
            {
                _tms.sys_EB = value;
                OnPropertyChanged();
            }
        }
        public int Sys_quad
        {
            get { return _tms.sys_quad; }
            set
            {
                _tms.sys_quad = value;
                OnPropertyChanged();
            }
        }
        public int Heatpipe_TOTAL
        {
            get { return _tms.heatpipe_TOTAL; }
            set
            {
                _tms.heatpipe_TOTAL = value;
                OnPropertyChanged();
            }
        }
        public double Heatpipe_SURFACEvolume
        {
            get { return _tms.heatpipe_SURFACEvolume; }
            set
            {
                _tms.heatpipe_SURFACEvolume = value;
                OnPropertyChanged();
            }
        }
        public int CoolLoopTOTAL
        {
            get { return _tms.coolLoopTOTAL; }
            set
            {
                _tms.coolLoopTOTAL = value;
                OnPropertyChanged();
            }
        }
        public double CoolAreaMIN
        {
            get { return _tms.coolAreaMIN; }
            set
            {
                _tms.coolAreaMIN = value;
                OnPropertyChanged();
            }
        }
        public double CoolAreaMAX
        {
            get { return _tms.coolAreaMAX; }
            set
            {
                _tms.coolAreaMAX = value;
                OnPropertyChanged();
            }
        }
        public double CoolAreaREFLECT
        {
            get { return _tms.coolAreaREFLECT; }
            set
            {
                _tms.coolAreaREFLECT = value;
                OnPropertyChanged();
            }
        }
        public double CoolLevelMAX
        {
            get { return _tms.coolLevelMAX; }
            set
            {
                _tms.coolLevelMAX = value;
                OnPropertyChanged();
            }
        }
        public double CoolPsiMAX
        {
            get { return _tms.coolPsiMAX; }
            set
            {
                _tms.coolPsiMAX = value;
                OnPropertyChanged();
            }
        }
        public string CoolCoolant
        {
            get { return _tms.coolCoolant; }
            set
            {
                _tms.coolCoolant = value;
                OnPropertyChanged();
            }
        }
        public double CoolTankCAP
        {
            get { return _tms.coolTankCAP; }
            set
            {
                _tms.coolTankCAP = value;
                OnPropertyChanged();
            }
        }
        public double CoolLinelength
        {
            get { return _tms.coolLinelength; }
            set
            {
                _tms.coolLinelength = value;
                OnPropertyChanged();
            }
        }
        #endregion

        public TMSViewModel()
            : this(null)
        {
        }

        public TMSViewModel(TMS tms)
        {
            if (tms != null)
            {
                LoadFrom(tms);
            }

        }

        override public void LoadFrom(Subsystem tms)
        {
            _tms = (TMS)tms;

        }

        public bool IsViewModelOf(TMS tms)
        {
            return tms == _tms;
        }

    }
}
