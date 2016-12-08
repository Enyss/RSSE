using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;




namespace RSSE
{ 
    public class Ship
    {
        public string name;
        public string uiName;
        public string description;
        public string shipClass;
        public string sizeClass;
        public double msrpPrice;
        public double cargoVolume;
        public double mass;
        public double expectedLife;
        public double meanDRAGcoef;
        public double pwrRequired;
        public double sysInitTime;
        public double pwrStart;
        public Vector3 basicDimensions;
        public double hull_REFLECTIVITY;
        public double volumeInterior;
        public double surfaceAreaExterior;
        public double cabinInsPercentage;

        // Stuff 
        public bool interiorAvailable;
        public Vector3 playerSTART;
        public Color emergencylight;
        public bool asCockpit;
        public bool landingSkids;
        public string pilot_MFD;
        public string pilot_CAW;
        public string pilot_VMS;
        public string pilot_CONTROLS;
        public string pilot_INSTRUMENTS;

        public SubsystemsManager subsystemsManager;

        public MeshCollection interiorMeshes;
        public MeshCollection exteriorMeshes;

        public Ship()
        {
            subsystemsManager = new SubsystemsManager();
            interiorMeshes = new MeshCollection();
            exteriorMeshes = new MeshCollection();
        }

        public Ship(ShipTable table)
        {
            // General
            GetFromTable(table);
            // Mesh
            interiorMeshes = new MeshCollection(table.shipInterior);
            exteriorMeshes = new MeshCollection(table.shipExterior);

            // Subsystems
            List<Subsystem> subsystemList = new List<Subsystem>();

            subsystemList.Add( new AccessoriesManager(table) );
            subsystemList.Add( new AttachementsManager(table) );
            subsystemList.Add( new BMS(table));
            subsystemList.Add( new CameraManager(table));
            subsystemList.Add( new COMM(table));
            subsystemList.Add( new CSSM(table));
            subsystemList.Add( new ECS(table));
            subsystemList.Add( new FCM(table));
            subsystemList.Add( new LENR(table));
            subsystemList.Add( new LSS(table));
            subsystemList.Add( new MES(table));
            subsystemList.Add( new MFD(table));
            subsystemList.Add( new MTS(table));
            subsystemList.Add( new NAS(table));
            subsystemList.Add( new RCM(table));
            subsystemList.Add( new RCS(table));
            subsystemList.Add( new RMS(table));
            subsystemList.Add( new TMS(table));
            subsystemList.Add( new VMS(table));
            

            subsystemList.Add( new LegacySystems());
            

            subsystemsManager = new SubsystemsManager(subsystemList);
        }

        public ShipTable ToShipTable()
        {
            ShipTable table = new ShipTable(name);
            
            table.shipInterior = interiorMeshes.ToTable();
            table.shipExterior = exteriorMeshes.ToTable();

            // Base Stuff
            this.AddToTable(table);

            // SubSystems
            foreach( Subsystem subsystem in subsystemsManager.subsystems)
            {
                subsystem.AddToTable(table);
            }
            return table;
        }


        public void GetFromTable(ShipTable table)
        {
            name = table.ship["Name"].Value;
            uiName = table.ship["UIName"].Value;
            description = table.ship["Desc"].Value;
            shipClass = table.ship["Class"].Value;
            sizeClass = table.ship["SIZEclass"].Value;
            msrpPrice = table.ship["MSRPPrice"].Value;
            cargoVolume = table.ship["CARGOvolume"].Value;
            mass = table.ship["Mass"].Value;
            expectedLife = table.ship["ExpectedLife"].Value;
            meanDRAGcoef = table.ship["meanDRAGcoef"].DoubleValue;
            pwrRequired = table.ship["PWRrequired"].Value;
            sysInitTime = table.ship["SYSinitTIME"].Value;
            pwrStart = table.ship["PWRstart"].Value;
            basicDimensions = new Vector3(table.ship["BasicDimensions"]["l"].Value,
                                           table.ship["BasicDimensions"]["h"].Value,
                                           table.ship["BasicDimensions"]["w"].Value);
            hull_REFLECTIVITY = table.ship["hull_REFLECTIVITY"].Value;
            volumeInterior = table.ship["VOLUMEinterior"].Value;
            surfaceAreaExterior = table.ship["SURFACEAREAexterior"].Value;
            cabinInsPercentage = table.ship["CabinINSpercentage"].Value;
            interiorAvailable = table.ship["InteriorAvailable"].Value > 0.5;
            playerSTART = new Vector3(table.ship["playerSTART"]);
            emergencylight = new Color(table.ship["color_EMERlight"]);
            asCockpit = table.ship["AsCockpit"].Value > 0.5;
            landingSkids = table.ship["LandingSkids"].Value > 0.5;
            pilot_MFD = table.ship["pilot_MFD"].Value;
            pilot_CAW = table.ship["pilot_CAW"].Value;
            pilot_VMS = table.ship["pilot_VMS"].Value;
            pilot_CONTROLS = table.ship["pilot_CONTROLS"].Value;
            pilot_INSTRUMENTS = table.ship["pilot_INSTRUMENTS"].Value;
        }

        public void AddToTable(ShipTable table)
        {
            table.ship["Name"].Value          = name;
            table.ship["UIName"].Value        = uiName;
            table.ship["Desc"].Value          = description;
            table.ship["Class"].Value         = shipClass;
            table.ship["SIZEclass"].Value     = sizeClass;
            table.ship["MSRPPrice"].Value     = msrpPrice;
            table.ship["CARGOvolume"].Value   = cargoVolume;
            table.ship["Mass"].Value          = mass;
            table.ship["ExpectedLife"].Value  = expectedLife;
            table.ship["meanDRAGcoef"].Value  = meanDRAGcoef;
            table.ship["PWRrequired"].Value   = pwrRequired;
            table.ship["SYSinitTIME"].Value   = sysInitTime;
            table.ship["PWRstart"].Value      = pwrStart;
            table.ship["BasicDimensions"]["l"].Value = basicDimensions.x;
            table.ship["BasicDimensions"]["h"].Value = basicDimensions.y;
            table.ship["BasicDimensions"]["w"].Value = basicDimensions.z;
            table.ship["hull_REFLECTIVITY"].Value = hull_REFLECTIVITY;
            table.ship["VOLUMEinterior"].Value = volumeInterior;
            table.ship["SURFACEAREAexterior"].Value = surfaceAreaExterior;
            table.ship["CabinINSpercentage"].Value = cabinInsPercentage; 
            table.ship["InteriorAvailable"].Value = interiorAvailable?1:0;
            table.ship["playerSTART"] = playerSTART.ToTable();
            table.ship["color_EMERlight"] = emergencylight.ToTable();
            table.ship["AsCockpit"].Value = asCockpit ? 1 : 0;
            table.ship["LandingSkids"].Value = landingSkids ? 1 : 0;
            table.ship["pilot_MFD"].Value = pilot_MFD;
            table.ship["pilot_CAW"].Value = pilot_CAW;
            table.ship["pilot_VMS"].Value = pilot_VMS;
            table.ship["pilot_CONTROLS"].Value = pilot_CONTROLS;
            table.ship["pilot_INSTRUMENTS"].Value = pilot_INSTRUMENTS;

        }

    }    

}
