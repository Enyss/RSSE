using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;


namespace RSSE
{
    public class AttachementsManager : Subsystem
    {
        override public SubsystemTypeEnum SystemType { get { return SubsystemTypeEnum.AttachementsManager; } }
        override public string SystemGroup { get { return "Others"; } }

        public List<Attachement> attachements;

        public AttachementsManager()
        {
            attachements = new List<Attachement>();
        }

        public AttachementsManager(ShipTable table)
        {

             attachements = new List<Attachement>();
             int i = 1;
             while (table.shipCoords["AttachPoint" + i + "Name"].Value != null )
             {
                Attachement attach = new Attachement();
                attach.position = new Vector3(table.shipCoords["AttachPoint" + i + "ObjPos"]);
                attach.rotation = new Vector3(table.shipCoords["AttachPoint" + i + "ObjRot"]);
                attach.size = table.shipCoords["AttachPoint" + i + "Size"].IntValue;
	            attach.name = table.shipCoords["AttachPoint" + i + "Name"].Value;
                attach.isTowing = table.shipCoords["AttachPoint" + i + "isTOWING"].Value > 0.5;
                attach.swapXZ = table.shipCoords["AttachPoint" + i + "swapXZ"].Value > 0.5;
                attach.invertX = table.shipCoords["AttachPoint" + i + "invertX"].Value < 0;  // 1 is usual, -1 is inverted
                attachements.Add(attach);
                i++;
             }
        }

        public override void AddToTable(ShipTable table)
        {
            table.ship["totalATTACHMENTS"].Value = attachements.Count;
            int i = 1;
            foreach(Attachement attach in attachements)
            {
                table.shipCoords["AttachPoint" + i + "ObjPos"] = attach.position.ToTable();
                table.shipCoords["AttachPoint" + i + "ObjRot"] = attach.rotation.ToTable();
                table.shipCoords["AttachPoint" + i + "Size"].IntValue = attach.size;
                table.shipCoords["AttachPoint" + i + "Name"].Value = attach.name;
                table.shipCoords["AttachPoint" + i + "isTOWING"].Value = attach.isTowing ? 1 : 0;
                table.shipCoords["AttachPoint" + i + "swapXZ"].Value = attach.swapXZ ? 1 : 0;
                table.shipCoords["AttachPoint" + i + "invertX"].Value = attach.invertX ? -1 : 1;  // 1 is usual, -1 is inverted
                i++;
            }
        }
    }
}
