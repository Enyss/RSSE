using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE
{
    public class LegacySystems : Subsystem
    {
        /// <summary>
        /// Coords
        /// </summary>
        override public SubsystemTypeEnum SystemType { get { return SubsystemTypeEnum.Legacy; } }
        override public string SystemGroup { get { return "Others"; } }

        public int RegionTotal = 1;
        // start in ["Region1"]
        public int mustCROUCH = 1;
        public int mustSTAND = 0;
        public int isZeroG = 0;
        public Vector3 location = new Vector3(0.0, 11.02, 0.127);
        public double radius = 1.7;
        // end in ["Region1"]

        public Vector3 LandAlignmentPos = new Vector3(0.0, 0.948, -3.306);

        public int PriWepExtObjects = 0;
        public Vector3 PriWep1ObjPos = new Vector3(-4.784, 0.0, 0.0);
        public Vector3 PriWep1ObjRot = new Vector3(0.0, -90.0, 0.0);
        public Vector3 PriWep2ObjPos = new Vector3(4.784, 0.0,  0.0);
        public Vector3 PriWep2ObjRot = new Vector3(0.0, 90.0, 0.0);
        public Vector3 SecWep1ObjPos = new Vector3(-1.18, 0.499, -0.116);
        public Vector3 SecWep1ObjRot = new Vector3(0.0, 0.0, 0.0 );
        public Vector3 SecWep2ObjPos = new Vector3(1.18, 0.499, -0.116);
        public Vector3 SecWep2ObjRot = new Vector3(0.0, 0.0, 0.0 );
        public Vector3 SecWep3ObjPos = new Vector3(-0.818, -0.592, -0.182);
        public Vector3 SecWep3ObjRot = new Vector3(0.0, 0.0, 0.0 );
        public Vector3 SecWep4ObjPos = new Vector3(0.818, -0.592, -0.182);
        public Vector3 SecWep4ObjRot = new Vector3(0.0, 0.0, 0.0 );
        public Vector3 TerWep1Pos = new Vector3(-2, 0, 1);
        public Vector3 TerWep2Pos = new Vector3(2, 0, 1);

        override public void AddToTable(ShipHullTable table)
        {
            table.ship["WPN_CAP"]["mount_MAX"].Value = 1;
            table.ship["WPN_CAP"]["total_ALLOWED"].Value = 0;
            table.ship["WPN_CAP"]["sys1_EB"].Value = 3;
            table.ship["WPN_CAP"]["sys1_quad"].Value = 64;

            table.ship["WPN_PRI"]["mount_MAX"].Value = 1;
            table.ship["WPN_PRI"]["total_ALLOWED"].Value = 0;
            table.ship["WPN_PRI"]["sys1_EB"].Value = 3;
            table.ship["WPN_PRI"]["sys1_quad"].Value = 2;
            table.ship["WPN_PRI"]["sys2_EB"].Value = 4;
            table.ship["WPN_PRI"]["sys2_quad"].Value = 1;

            table.ship["WPN_SEC"]["mount_MAX"].Value = 1;
            table.ship["WPN_SEC"]["total_ALLOWED"].Value = 0;
            table.ship["WPN_SEC"]["sys1_EB"].Value = 3;
            table.ship["WPN_SEC"]["sys1_quad"].Value = 2;
            table.ship["WPN_SEC"]["sys2_EB"].Value = 4;
            table.ship["WPN_SEC"]["sys2_quad"].Value = 1;

            table.ship["WTC"]["mount_MAX"].Value = 2;
            table.ship["WTC"]["sys_EB"].Value = 1;
            table.ship["WTC"]["sys_quad"].Value = 2;
            
            table.ship["maxATTACHmount"].Value = 1;
            table.ship["maxTERWPNmount"].Value = 1;
            table.ship["totalCREW"].Value = 1;
            table.ship["totalHATCHES"].Value = 6;
            table.ship["totalPASSENGERS"].Value = 0;
            table.ship["maxSOImount"].Value = 1;
            table.ship["totalHMDs"].Value = 0;
            table.ship["totalHANGARS"].Value = 0;
            table.ship["totalDOCKINGBAYS"].Value = 0;
            table.ship["totalTERWPN"].Value = 0;


            table.ship["equip_BAY1"]["name"].Value = "Forward Dorsal";
            table.ship["equip_BAY2"]["name"].Value = "Forward Ventral";
            table.ship["equip_BAY3"]["name"].Value = "Central Port";
            table.ship["equip_BAY4"]["name"].Value = "Central Starboard";
            table.ship["equip_BAY5"]["name"].Value = "Central Aft";
            table.ship["equip_BAY6"]["name"].Value = "Aft";
            
            table.shipCoords["RegionTotal"].IntValue = RegionTotal;
            table.shipCoords["Region1"]["mustCROUCH"].IntValue = mustCROUCH;
            table.shipCoords["Region1"]["mustSTAND"].IntValue = mustSTAND;
            table.shipCoords["Region1"]["isZeroG"].IntValue = isZeroG;
            table.shipCoords["Region1"]["location"] = location.ToTable();
            table.shipCoords["Region1"]["radius"].Value = radius;

            table.shipCoords["LandAlignmentPos"] = LandAlignmentPos.ToTable();

            table.shipCoords["PriWepExtObjects"].IntValue = RegionTotal;

            table.shipCoords["PriWep1ObjPos"] = PriWep1ObjPos.ToTable();
            table.shipCoords["PriWep1ObjRot"] = PriWep1ObjRot.ToTable();
            table.shipCoords["PriWep2ObjPos"] = PriWep2ObjPos.ToTable();
            table.shipCoords["PriWep2ObjRot"] = PriWep2ObjRot.ToTable();
            table.shipCoords["SecWep1ObjPos"] = SecWep1ObjPos.ToTable();
            table.shipCoords["SecWep1ObjRot"] = SecWep1ObjRot.ToTable();
            table.shipCoords["SecWep2ObjPos"] = SecWep2ObjPos.ToTable();
            table.shipCoords["SecWep2ObjRot"] = SecWep2ObjRot.ToTable();
            table.shipCoords["SecWep3ObjPos"] = SecWep3ObjPos.ToTable();
            table.shipCoords["SecWep3ObjRot"] = SecWep3ObjRot.ToTable();
            table.shipCoords["SecWep4ObjPos"] = SecWep4ObjPos.ToTable();
            table.shipCoords["SecWep4ObjRot"] = SecWep4ObjRot.ToTable();
            table.shipCoords["TerWep1Pos"] = TerWep1Pos.ToTable();
            table.shipCoords["TerWep2Pos"] = TerWep2Pos.ToTable();

        }

    }
}
