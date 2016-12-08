using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSSE.Utils;

namespace RSSE.ShipElements.Systems
{
    public class ECS : SubSystem
    {
        override public string SystemName { get { return "ECS"; } }
        override public string SystemGroup { get { return "Power"; } }

        public double ECS_PWRpercent { get; set; }
        public double ECS_MASSpercent { get; set; }
        public int ECS_SYStotal { get; set; }
        public double ECS_SYSAMPSmax { get; set; }
        public int ECS_HVtotal { get; set; }
        public double ECS_HVAMPSmax { get; set; }
        public int ECS_WPNtotal { get; set; }
        public double ECS_WPNAMPSmax { get; set; }
        public double ECS_RSRVAMPSmax { get; set; }
        public double ECS_EMRGAMPSmax { get; set; }

        public int mount_MAX { get; set; }
        public int sys_EB { get; set; }
        public int sys_quad { get; set; }

        public ECS()
        {

        }

        public ECS(ShipTable table)
        {
            ECS_PWRpercent = table.ship["ECS_PWRpercent"].Value;
            ECS_MASSpercent = table.ship["ECS_MASSpercent"].Value;
            ECS_SYStotal = table.ship["ECS_SYStotal"].IntValue;
            ECS_SYSAMPSmax = table.ship["ECS_SYSAMPSmax"].Value;
            ECS_HVtotal = table.ship["ECS_HVtotal"].IntValue;
            ECS_HVAMPSmax = table.ship["ECS_HVAMPSmax"].Value;
            ECS_WPNtotal = table.ship["ECS_WPNtotal"].IntValue;
            ECS_WPNAMPSmax = table.ship["ECS_WPNAMPSmax"].Value;
            ECS_RSRVAMPSmax = table.ship["ECS_RSRVAMPSmax"].Value;
            ECS_EMRGAMPSmax = table.ship["ECS_EMRGAMPSmax"].Value;

            mount_MAX = table.ship["ECS"]["mount_MAX"].IntValue;
            sys_EB = table.ship["ECS"]["sys_EB"].IntValue;
            sys_quad = table.ship["ECS"]["sys_quad"].IntValue;
        }

        override public void AddToTable(ShipTable table)
        {
            table.ship["ECS_PWRpercent"].Value = ECS_PWRpercent;
            table.ship["ECS_MASSpercent"].Value = ECS_MASSpercent;
            table.ship["ECS_SYStotal"].IntValue = ECS_SYStotal;
            table.ship["ECS_SYSAMPSmax"].Value = ECS_SYSAMPSmax;
            table.ship["ECS_HVtotal"].IntValue = ECS_HVtotal;
            table.ship["ECS_HVAMPSmax"].Value = ECS_HVAMPSmax;
            table.ship["ECS_WPNtotal"].IntValue = ECS_WPNtotal;
            table.ship["ECS_WPNAMPSmax"].Value = ECS_WPNAMPSmax;
            table.ship["ECS_RSRVAMPSmax"].Value = ECS_RSRVAMPSmax;
            table.ship["ECS_EMRGAMPSmax"].Value = ECS_EMRGAMPSmax;

            table.ship["ECS"]["mount_MAX"].IntValue = mount_MAX;
            table.ship["ECS"]["sys_EB"].IntValue = sys_EB;
            table.ship["ECS"]["sys_quad"].IntValue = sys_quad;
        }
    }
}
