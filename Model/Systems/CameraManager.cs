using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace RSSE.ShipElements.Systems
{
    public class CameraManager : SubSystem
    {
        override public string SystemName { get { return "CameraManager"; } }
        override public string SystemGroup { get { return "Sensors"; } }

        public BindingList<Camera> cameras;

        public CameraManager()
        {
            cameras = new BindingList<Camera>();
        }

        public CameraManager(ShipTable table)
        {
            cameras = new BindingList<Camera>();
            int i = 1;
            while (table.shipCameras["Camera" + i].Count > 0)
            {
                cameras.Add(new Camera(table.shipCameras["Camera" + i]));
                i++;
            }
        }

        public override void AddToTable(ShipTable table)
        {
            table.shipCameras["Total"].Value = cameras.Count;
            for (int i = 0; i < cameras.Count; i++)
            {
                table.shipCameras["Camera" + (i + 1)] = cameras.ElementAt(i).ToTable();
            }
            
        }
    }
}
