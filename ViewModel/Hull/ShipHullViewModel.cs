using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE
{
    public class ShipHullViewModel : ObservableObject
    {
        public ShipHull _ship;

        public SubsystemsManagerViewModel Subsystems { get; set; }
        public MeshTreeViewModel InteriorMeshes { get; set; }
        public MeshTreeViewModel ExteriorMeshes { get; set; }

        #region Properties
        public string Name
        {
            get { return _ship.name; }
            set
            {
                _ship.name = value;
                OnPropertyChanged();
            }
        }
        public string UIName
        {
            get { return _ship.uiName; }
            set
            {
                _ship.uiName = value;
                OnPropertyChanged();
            }
        }
        public string Description
        {
            get { return _ship.description; }
            set
            {
                _ship.description = value;
                OnPropertyChanged();
            }
        }
        public string ShipClass
        {
            get { return _ship.shipClass; }
            set
            {
                _ship.shipClass = value;
                OnPropertyChanged();
            }
        }
        public string SizeClass
        {
            get { return _ship.sizeClass; }
            set
            {
                _ship.sizeClass = value;
                OnPropertyChanged();
            }
        }
        public double MSRPPrice
        {
            get { return _ship.msrpPrice; }
            set
            {
                _ship.msrpPrice = value;
                OnPropertyChanged();
            }
        }
        public double CargoVolume
        {
            get { return _ship.cargoVolume; }
            set
            {
                _ship.cargoVolume = value;
                OnPropertyChanged();
            }
        }
        public double Mass
        {
            get { return _ship.mass; }
            set
            {
                _ship.mass = value;
                OnPropertyChanged();
            }
        }
        public double ExpectedLife
        {
            get { return _ship.expectedLife; }
            set
            {
                _ship.expectedLife = value;
                OnPropertyChanged();
            }
        }
        public double MeanDRAGcoef
        {
            get { return _ship.meanDRAGcoef; }
            set
            {
                _ship.meanDRAGcoef = value;
                OnPropertyChanged();
            }
        }
        public double PwrRequired
        {
            get { return _ship.pwrRequired; }
            set
            {
                _ship.pwrRequired = value;
                OnPropertyChanged();
            }
        }
        public double SysInitTime
        {
            get { return _ship.sysInitTime; }
            set
            {
                _ship.sysInitTime = value;
                OnPropertyChanged();
            }
        }
        public double PwrStart
        {
            get { return _ship.pwrStart; }
            set
            {
                _ship.pwrStart = value;
                OnPropertyChanged();
            }
        }
        public Vector3 BasicDimensions
        {
            get { return _ship.basicDimensions; }
            set
            {
                _ship.basicDimensions = value;
                OnPropertyChanged();
            }
        }
        public double Hull_REFLECTIVITY
        {
            get { return _ship.hull_REFLECTIVITY; }
            set
            {
                _ship.hull_REFLECTIVITY = value;
                OnPropertyChanged();
            }
        }
        public double VolumeInterior
        {
            get { return _ship.volumeInterior; }
            set
            {
                _ship.volumeInterior = value;
                OnPropertyChanged();
            }
        }
        public double SurfaceAreaExterior
        {
            get { return _ship.surfaceAreaExterior; }
            set
            {
                _ship.surfaceAreaExterior = value;
                OnPropertyChanged();
            }
        }
        public double CabinInsPercentage
        {
            get { return _ship.cabinInsPercentage; }
            set
            {
                _ship.cabinInsPercentage = value;
                OnPropertyChanged();
            }
        }

        // Stuff 
        public bool InteriorAvailable
        {
            get { return _ship.interiorAvailable; }
            set
            {
                _ship.interiorAvailable = value;
                OnPropertyChanged();
            }
        }
        public Vector3 PlayerSTART
        {
            get { return _ship.playerSTART; }
            set
            {
                _ship.playerSTART = value;
                OnPropertyChanged();
            }
        }
        public Color Emergencylight
        {
            get { return _ship.emergencylight; }
            set
            {
                _ship.emergencylight = value;
                OnPropertyChanged();
            }
        }
        public bool AsCockpit
        {
            get { return _ship.asCockpit; }
            set
            {
                _ship.asCockpit = value;
                OnPropertyChanged();
            }
        }
        public bool LandingSkids
        {
            get { return _ship.landingSkids; }
            set
            {
                _ship.landingSkids = value;
                OnPropertyChanged();
            }
        }
        public string Pilot_MFD
        {
            get { return _ship.pilot_MFD; }
            set
            {
                _ship.pilot_MFD = value;
                OnPropertyChanged();
            }
        }
        public string Pilot_CAW
        {
            get { return _ship.pilot_CAW; }
            set
            {
                _ship.pilot_CAW = value;
                OnPropertyChanged();
            }
        }
        public string Pilot_VMS
        {
            get { return _ship.pilot_VMS; }
            set
            {
                _ship.pilot_VMS = value;
                OnPropertyChanged();
            }
        }
        public string Pilot_CONTROLS
        {
            get { return _ship.pilot_CONTROLS; }
            set
            {
                _ship.pilot_CONTROLS = value;
                OnPropertyChanged();
            }
        }
        public string Pilot_INSTRUMENTS
        {
            get { return _ship.pilot_INSTRUMENTS; }
            set
            {
                _ship.pilot_INSTRUMENTS = value;
                OnPropertyChanged();
            }
        }
        #endregion

        public ShipHullViewModel()
        {
            _ship = new ShipHull();
            Subsystems = new SubsystemsManagerViewModel();
            ExteriorMeshes = new MeshTreeViewModel();
            InteriorMeshes = new MeshTreeViewModel();
        }

        public ShipHullViewModel(ShipHull ship)
        {
            _ship = ship;
            Subsystems = new SubsystemsManagerViewModel(ship.subsystemsManager);
            ExteriorMeshes = new MeshTreeViewModel(ship.exteriorMeshes);
            InteriorMeshes = new MeshTreeViewModel(ship.interiorMeshes);

        }

    }
}
