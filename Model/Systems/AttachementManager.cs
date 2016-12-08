using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using RSSE.Utils;

namespace RSSE.ShipElements.Systems
{
    public class AttachementManager : SubSystem
    {
        override public string SystemName { get { return "CameraManager"; } }
        override public string SystemGroup { get { return "Others"; } }

        public BindingList<Attachement> attachements;

        public AttachementManager()
        {
            attachements = new BindingList<Attachement>();
        }

        public AttachementManager(ShipTable table)
        {

             attachements = new BindingList<Attachement>();
             int i = 1;
             while (table.shipCoords["AttachPoint" + i + "Name"].Value != null )
             {
                Attachement attach = new Attachement();
                attach.Position = new Vector3(table.shipCoords["AttachPoint" + i + "ObjPos"]);
                attach.Rotation = new Vector3(table.shipCoords["AttachPoint" + i + "ObjRot"]);
                attach.Size = table.shipCoords["AttachPoint" + i + "Size"].IntValue;
	            attach.Name = table.shipCoords["AttachPoint" + i + "Name"].Value;
                attach.IsTowing = table.shipCoords["AttachPoint" + i + "isTOWING"].Value > 0.5;
                attach.SwapXZ = table.shipCoords["AttachPoint" + i + "swapXZ"].Value > 0.5;
                attach.InvertX = table.shipCoords["AttachPoint" + i + "invertX"].Value < 0;  // 1 is usual, -1 is inverted
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
                table.shipCoords["AttachPoint" + i + "ObjPos"] = attach.Position.ToTable();
                table.shipCoords["AttachPoint" + i + "ObjRot"] = attach.Rotation.ToTable();
                table.shipCoords["AttachPoint" + i + "Size"].IntValue = attach.Size;
                table.shipCoords["AttachPoint" + i + "Name"].Value = attach.Name;
                table.shipCoords["AttachPoint" + i + "isTOWING"].Value = attach.IsTowing ? 1 : 0;
                table.shipCoords["AttachPoint" + i + "swapXZ"].Value = attach.SwapXZ ? 1 : 0;
                table.shipCoords["AttachPoint" + i + "invertX"].Value = attach.InvertX ? -1 : 1;  // 1 is usual, -1 is inverted
                i++;
            }
        }
    }
}
