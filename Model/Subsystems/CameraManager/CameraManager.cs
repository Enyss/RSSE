using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace RSSE
{
    public class CameraManager : Subsystem
    {
        override public SubsystemTypeEnum SystemType { get { return SubsystemTypeEnum.CameraManager; } }
        override public string SystemGroup { get { return "Sensors"; } }

        public List<Camera> cameras;

        public CameraManager()
        {
            cameras = new List<Camera>();
        }

        public CameraManager(ShipTable table)
        {
            cameras = new List<Camera>();
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
