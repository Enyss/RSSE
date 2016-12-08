using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RSSE
{
    public class TMS : Subsystem
    {
        override public SubsystemTypeEnum SystemType { get { return SubsystemTypeEnum.TMS; } }
        override public string SystemGroup { get { return "Ship integrity"; } }

        public int mount_MAX;
        public int sys_EB;
        public int sys_quad;
        public int heatpipe_TOTAL;
        public double heatpipe_SURFACEvolume;
        public int coolLoopTOTAL;
        public double coolAreaMIN;
        public double coolAreaMAX;
        public double coolAreaREFLECT;
        public double coolLevelMAX;
        public double coolPsiMAX;
        public string coolCoolant;
        public double coolTankCAP;
        public double coolLinelength;

        public TMS() { }

        public TMS(ShipTable table)
        {
            mount_MAX = table.ship["TMS"]["mount_MAX"].IntValue;
            sys_EB = table.ship["TMS"]["sys_EB"].IntValue;
            sys_quad = table.ship["TMS"]["sys_quad"].IntValue;
            heatpipe_TOTAL = table.ship["TMS"]["heatpipe_TOTAL"].IntValue;
            heatpipe_SURFACEvolume = table.ship["TMS"]["heatpipe_SURFACEvolume"].Value;
            coolLoopTOTAL = table.ship["TMS"]["COOLloopTOTAL"].IntValue;
            coolAreaMIN = table.ship["TMS"]["COOLareaMIN"].Value;
            coolAreaMAX = table.ship["TMS"]["COOLareaMAX"].Value;
            coolAreaREFLECT = table.ship["TMS"]["COOLareaREFLECT"].Value;
            coolLevelMAX = table.ship["TMS"]["COOLlevelMAX"].Value;
            coolPsiMAX = table.ship["TMS"]["COOLpsiMAX"].Value;
            coolCoolant = table.ship["TMS"]["COOLcoolant"].Value;
            coolTankCAP = table.ship["TMS"]["COOLtankCAP"].Value;
            coolLinelength = table.ship["TMS"]["COOLlinelength"].Value;
        }

        override public void AddToTable(ShipTable table)
        {

            table.ship["TMS"]["mount_MAX"].IntValue = mount_MAX;
            table.ship["TMS"]["sys_EB"].IntValue = sys_EB;
            table.ship["TMS"]["sys_quad"].IntValue = sys_quad;
            table.ship["TMS"]["heatpipe_TOTAL"].IntValue = heatpipe_TOTAL;
            table.ship["TMS"]["heatpipe_SURFACEvolume"].Value = heatpipe_SURFACEvolume;
            table.ship["TMS"]["COOLloopTOTAL"].IntValue = coolLoopTOTAL;
            table.ship["TMS"]["COOLareaMIN"].Value = coolAreaMIN;
            table.ship["TMS"]["COOLareaMAX"].Value = coolAreaMAX;
            table.ship["TMS"]["COOLareaREFLECT"].Value = coolAreaREFLECT;
            table.ship["TMS"]["COOLlevelMAX"].Value = coolLevelMAX;
            table.ship["TMS"]["COOLpsiMAX"].Value = coolPsiMAX;
            table.ship["TMS"]["COOLcoolant"].Value = coolCoolant;
            table.ship["TMS"]["COOLtankCAP"].Value = coolTankCAP;
            table.ship["TMS"]["COOLlinelength"].Value = coolLinelength;
            
        }
    }
}
