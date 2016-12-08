using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;



namespace RSSE
{
    class ECSViewModel : SubsystemViewModel
    {

        private ECS _ecs;

        new public ECS Model { get { return _ecs; } }
        override public SubsystemTypeEnum SystemType { get { return _ecs.SystemType; } }

        public string Name
        {
            get { return SubsystemTypeEnumExtensions.ToNiceString(_ecs.SystemType); }
        }
        public string Group { get { return _ecs.SystemGroup; } }

        #region Properties

        public int Mount_MAX
        {
            get { return _ecs.mount_MAX; }
            set
            {
                _ecs.mount_MAX = value;
                OnPropertyChanged();
            }
        }
        public int Sys_EB
        {
            get { return _ecs.sys_EB; }
            set
            {
                _ecs.sys_EB = value;
                OnPropertyChanged();
            }
        }
        public int Sys_quad
        {
            get { return _ecs.sys_quad; }
            set
            {
                _ecs.sys_quad = value;
                OnPropertyChanged();
            }
        }
        public double ECS_PWRpercent
        {
            get { return _ecs.ecs_PWRpercent; }
            set
            {
                _ecs.ecs_PWRpercent = value;
                OnPropertyChanged();
            }
        }
        public double ECS_MASSpercent
        {
            get { return _ecs.ecs_MASSpercent; }
            set
            {
                _ecs.ecs_MASSpercent = value;
                OnPropertyChanged();
            }
        }
        public int ECS_SYStotal
        {
            get { return _ecs.ecs_SYStotal; }
            set
            {
                _ecs.ecs_SYStotal = value;
                OnPropertyChanged();
            }
        }
        public double ECS_SYSAMPSmax
        {
            get { return _ecs.ecs_SYSAMPSmax; }
            set
            {
                _ecs.ecs_SYSAMPSmax = value;
                OnPropertyChanged();
            }
        }
        public int ECS_HVtotal
        {
            get { return _ecs.ecs_HVtotal; }
            set
            {
                _ecs.ecs_HVtotal = value;
                OnPropertyChanged();
            }
        }
        public double ECS_HVAMPSmax
        {
            get { return _ecs.ecs_HVAMPSmax; }
            set
            {
                _ecs.ecs_HVAMPSmax = value;
                OnPropertyChanged();
            }
        }
        public int ECS_WPNtotal
        {
            get { return _ecs.ecs_WPNtotal; }
            set
            {
                _ecs.ecs_WPNtotal = value;
                OnPropertyChanged();
            }
        }
        public double ECS_WPNAMPSmax
        {
            get { return _ecs.ecs_WPNAMPSmax; }
            set
            {
                _ecs.ecs_WPNAMPSmax = value;
                OnPropertyChanged();
            }
        }
        public double ECS_RSRVAMPSmax
        {
            get { return _ecs.ecs_RSRVAMPSmax; }
            set
            {
                _ecs.ecs_RSRVAMPSmax = value;
                OnPropertyChanged();
            }
        }
        public double ECS_EMRGAMPSmax
        {
            get { return _ecs.ecs_EMRGAMPSmax; }
            set
            {
                _ecs.ecs_EMRGAMPSmax = value;
                OnPropertyChanged();
            }
        }

        #endregion

        public ECSViewModel()
            : this(null)
        {
        }

        public ECSViewModel(ECS ecs)
        {
            if (ecs != null)
            {
                LoadFrom(ecs);
            }

        }

        override public void LoadFrom(Subsystem ecs)
        {
            _ecs = (ECS)ecs;

        }

        public bool IsViewModelOf(ECS ecs)
        {
            return ecs == _ecs;
        }

    }
}
