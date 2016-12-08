using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSSE.Utils;

namespace RSSE.ShipElements.Systems
{
    public class TMS : SubSystem
    {
        override public string SystemName { get { return "TMS"; } }
        override public string SystemGroup { get { return "Ship integrity"; } }

        public int mount_MAX { get; set; }
		public int sys_EB { get; set; }
        public int sys_quad { get; set; }
        public int heatpipe_TOTAL { get; set; }
        public double heatpipe_SURFACEvolume { get; set; }
        public int COOLloopTOTAL { get; set; }
        public double COOLareaMIN { get; set; }
        public double COOLareaMAX { get; set; }
        public double COOLareaREFLECT { get; set; }																				
        public double COOLlevelMAX { get; set; }
        public double COOLpsiMAX { get; set; }
        public string COOLcoolant { get; set; }
        public double COOLtankCAP { get; set; }
        public double COOLlinelength { get; set; }

        public TMS() { }

        public TMS(ShipTable table)
        {
            mount_MAX = table.ship["TMS"]["mount_MAX"].IntValue;
            sys_EB = table.ship["TMS"]["sys_EB"].IntValue;
            sys_quad = table.ship["TMS"]["sys_quad"].IntValue;
            heatpipe_TOTAL = table.ship["TMS"]["heatpipe_TOTAL"].IntValue;
            heatpipe_SURFACEvolume = table.ship["TMS"]["heatpipe_SURFACEvolume"].Value;
            COOLloopTOTAL = table.ship["TMS"]["COOLloopTOTAL"].IntValue;
            COOLareaMIN = table.ship["TMS"]["COOLareaMIN"].Value;
            COOLareaMAX = table.ship["TMS"]["COOLareaMAX"].Value;
            COOLareaREFLECT = table.ship["TMS"]["COOLareaREFLECT"].Value;
            COOLlevelMAX = table.ship["TMS"]["COOLlevelMAX"].Value;
            COOLpsiMAX = table.ship["TMS"]["COOLpsiMAX"].Value;
            COOLcoolant = table.ship["TMS"]["COOLcoolant"].Value;
            COOLtankCAP = table.ship["TMS"]["COOLtankCAP"].Value;
            COOLlinelength = table.ship["TMS"]["COOLlinelength"].Value;
        }

        override public void AddToTable(ShipTable table)
        {

            table.ship["TMS"]["mount_MAX"].IntValue = mount_MAX;
            table.ship["TMS"]["sys_EB"].IntValue = sys_EB;
            table.ship["TMS"]["sys_quad"].IntValue = sys_quad;
            table.ship["TMS"]["heatpipe_TOTAL"].IntValue = heatpipe_TOTAL;
            table.ship["TMS"]["heatpipe_SURFACEvolume"].Value = heatpipe_SURFACEvolume;
            table.ship["TMS"]["COOLloopTOTAL"].IntValue = COOLloopTOTAL;
            table.ship["TMS"]["COOLareaMIN"].Value = COOLareaMIN;
            table.ship["TMS"]["COOLareaMAX"].Value = COOLareaMAX;
            table.ship["TMS"]["COOLareaREFLECT"].Value = COOLareaREFLECT;
            table.ship["TMS"]["COOLlevelMAX"].Value = COOLlevelMAX;
            table.ship["TMS"]["COOLpsiMAX"].Value = COOLpsiMAX;
            table.ship["TMS"]["COOLcoolant"].Value = COOLcoolant;
            table.ship["TMS"]["COOLtankCAP"].Value = COOLtankCAP;
            table.ship["TMS"]["COOLlinelength"].Value = COOLlinelength;
            
        }
    }
}
