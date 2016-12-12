using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace RSSE
{
    public class RCSThrusterViewModel : ObservableObject
    {
        private RCSThruster _thruster;

        public RCSThruster Model { get { return _thruster; } }

        #region Properties

        public string Name
        {
            get { return _thruster.name; }
            set
            {
                _thruster.name = value;
                OnPropertyChanged();
            }
        }
        public Vector3 NozzlePOS
        {
            get { return _thruster.nozzlePOS; }
            set
            {
                _thruster.nozzlePOS = value;
                OnPropertyChanged();
            }
        }
        public Vector3 DirectionVEC
        {
            get { return _thruster.directionVEC; }
            set
            {
                _thruster.directionVEC = value;
                OnPropertyChanged();
            }
        }
        public DoF Dof
        {
            get { return _thruster.dof; }
            set
            {
                _thruster.dof = value;
                OnPropertyChanged();
            }
        }
        public string ExhaustVFX
        {
            get { return _thruster.exhaustVFX; }
            set
            {
                _thruster.exhaustVFX = value;
                OnPropertyChanged();
            }
        }
        public double ForceMULTI
        {
            get { return _thruster.forceMULTI; }
            set
            {
                _thruster.forceMULTI = value;
                OnPropertyChanged();
            }
        }
        public int LocationQUAD
        {
            get { return _thruster.locationQUAD; }
            set
            {
                _thruster.locationQUAD = value;
                OnPropertyChanged();
            }
        }

        #endregion

        public RCSThrusterViewModel() { }

        public RCSThrusterViewModel(RCSThruster thruster)
        {
            LoadFrom(thruster);
        }

        public void LoadFrom(RCSThruster thruster)
        {
            _thruster = thruster;
        }


    }
}
