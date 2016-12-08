using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;


namespace RSSE
{
    public class LSS : Subsystem
    {
        override public SubsystemTypeEnum SystemType { get { return SubsystemTypeEnum.LSS; } }
        override public string SystemGroup { get { return "Ship integrity"; } }

        public int mount_MAX;
        public int sys_EB;
        public int sys_quad;

        public int tankAtotal;
        public int tankBtotal;
        public int tankCtotal;
        public double lifeSupportAtankCAP;
        public double lifeSupportBtankCAP;
        public double consumableTankCAP;

        public List<Scrubber> scrubbers { get; set; }

        public LSS()
        {
            scrubbers = new List<Scrubber>();
        }

        public LSS(ShipTable table)
        {
            scrubbers = new List<Scrubber>();
            mount_MAX           = table.ship["LSS"]["mount_MAX"].IntValue;
            sys_EB              = table.ship["LSS"]["sys_EB"].IntValue;
            sys_quad            = table.ship["LSS"]["sys_quad"].IntValue;
            tankAtotal          = table.ship["LSS"]["TANKAtotal"].IntValue;
            tankBtotal          = table.ship["LSS"]["TANKBtotal"].IntValue;
            tankCtotal          = table.ship["LSS"]["TANKCtotal"].IntValue;
            lifeSupportAtankCAP = table.ship["LSS"]["LIFESUPPORTAtankCAP"].Value;
            lifeSupportBtankCAP = table.ship["LSS"]["LIFESUPPORTBtankCAP"].Value;
            consumableTankCAP   = table.ship["LSS"]["CONSUMABLEtankCAP"].Value;

            int i = 1;
            while(table.ship["LSS"]["scrubber" +i+ "_LOC"].Count > 0)
            {
                scrubbers.Add(new Scrubber(table.ship["LSS"]["scrubber" + i + "_LOC"]));
                i++;
            }
        }

        override public void AddToTable( ShipTable table )
        {
            table.ship["LSS"]["mount_MAX"].IntValue = mount_MAX;
            table.ship["LSS"]["sys_EB"].IntValue = sys_EB;
            table.ship["LSS"]["sys_quad"].IntValue = sys_quad;
            table.ship["LSS"]["TANKAtotal"].IntValue = tankAtotal;
            table.ship["LSS"]["TANKBtotal"].IntValue = tankBtotal;
            table.ship["LSS"]["TANKCtotal"].IntValue = tankCtotal;
            table.ship["LSS"]["LIFESUPPORTAtankCAP"].Value = lifeSupportAtankCAP;
            table.ship["LSS"]["LIFESUPPORTBtankCAP"].Value = lifeSupportBtankCAP;
            table.ship["LSS"]["CONSUMABLEtankCAP"].Value = consumableTankCAP;


            table.ship["LSS"]["scrubber_TOTAL"].Value = scrubbers.Count;
            int i = 1;
            foreach(Scrubber scrub in scrubbers)
            {
                table.ship["LSS"]["scrubber" + i + "_LOC"] = scrub.ToTable();
                i++;
            }
        }
    }
}
