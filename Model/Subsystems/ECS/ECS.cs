using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RSSE
{
    public class ECS : Subsystem
    {
        override public SubsystemTypeEnum SystemType { get { return SubsystemTypeEnum.ECS; } }
        override public string SystemGroup { get { return "Power"; } }

        public double ecs_PWRpercent;
        public double ecs_MASSpercent;
        public int ecs_SYStotal;
        public double ecs_SYSAMPSmax;
        public int ecs_HVtotal;
        public double ecs_HVAMPSmax;
        public int ecs_WPNtotal;
        public double ecs_WPNAMPSmax;
        public double ecs_RSRVAMPSmax;
        public double ecs_EMRGAMPSmax;

        public int mount_MAX { get; set; }
        public int sys_EB { get; set; }
        public int sys_quad { get; set; }

        public ECS()
        {

        }

        public ECS(ShipHullTable table)
        {
            ecs_PWRpercent = table.ship["ECS_PWRpercent"].Value;
            ecs_MASSpercent = table.ship["ECS_MASSpercent"].Value;
            ecs_SYStotal = table.ship["ECS_SYStotal"].IntValue;
            ecs_SYSAMPSmax = table.ship["ECS_SYSAMPSmax"].Value;
            ecs_HVtotal = table.ship["ECS_HVtotal"].IntValue;
            ecs_HVAMPSmax = table.ship["ECS_HVAMPSmax"].Value;
            ecs_WPNtotal = table.ship["ECS_WPNtotal"].IntValue;
            ecs_WPNAMPSmax = table.ship["ECS_WPNAMPSmax"].Value;
            ecs_RSRVAMPSmax = table.ship["ECS_RSRVAMPSmax"].Value;
            ecs_EMRGAMPSmax = table.ship["ECS_EMRGAMPSmax"].Value;

            mount_MAX = table.ship["ECS"]["mount_MAX"].IntValue;
            sys_EB = table.ship["ECS"]["sys_EB"].IntValue;
            sys_quad = table.ship["ECS"]["sys_quad"].IntValue;
        }

        override public void AddToTable(ShipHullTable table)
        {
            table.ship["ECS_PWRpercent"].Value = ecs_PWRpercent;
            table.ship["ECS_MASSpercent"].Value = ecs_MASSpercent;
            table.ship["ECS_SYStotal"].IntValue = ecs_SYStotal;
            table.ship["ECS_SYSAMPSmax"].Value = ecs_SYSAMPSmax;
            table.ship["ECS_HVtotal"].IntValue = ecs_HVtotal;
            table.ship["ECS_HVAMPSmax"].Value = ecs_HVAMPSmax;
            table.ship["ECS_WPNtotal"].IntValue = ecs_WPNtotal;
            table.ship["ECS_WPNAMPSmax"].Value = ecs_WPNAMPSmax;
            table.ship["ECS_RSRVAMPSmax"].Value = ecs_RSRVAMPSmax;
            table.ship["ECS_EMRGAMPSmax"].Value = ecs_EMRGAMPSmax;

            table.ship["ECS"]["mount_MAX"].IntValue = mount_MAX;
            table.ship["ECS"]["sys_EB"].IntValue = sys_EB;
            table.ship["ECS"]["sys_quad"].IntValue = sys_quad;
        }
    }
}
