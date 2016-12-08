using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using RSSE.Utils;

namespace RSSE.ShipElements.Systems
{
    public class LSS : SubSystem
    {
        override public string SystemName { get { return "LSS"; } }
        override public string SystemGroup { get { return "Ship integrity"; } }

        public int mount_MAX { get; set; }
        public int sys_EB { get; set; }
        public int sys_quad { get; set; }

        public int TANKAtotal { get; set; }
        public int TANKBtotal { get; set; }
        public int TANKCtotal { get; set; }
        public double LIFESUPPORTAtankCAP { get; set; }
        public double LIFESUPPORTBtankCAP { get; set; }
        public double CONSUMABLEtankCAP { get; set; }

        public BindingList<Scrubber> scrubber { get; set; }

        public LSS()
        {
            scrubber = new BindingList<Scrubber>();
        }

        public LSS(ShipTable table)
        {
            scrubber = new BindingList<Scrubber>();
            mount_MAX           = table.ship["LSS"]["mount_MAX"].IntValue;
            sys_EB              = table.ship["LSS"]["sys_EB"].IntValue;
            sys_quad            = table.ship["LSS"]["sys_quad"].IntValue;
            TANKAtotal          = table.ship["LSS"]["TANKAtotal"].IntValue;
            TANKBtotal          = table.ship["LSS"]["TANKBtotal"].IntValue;
            TANKCtotal          = table.ship["LSS"]["TANKCtotal"].IntValue;
            LIFESUPPORTAtankCAP = table.ship["LSS"]["LIFESUPPORTAtankCAP"].Value;
            LIFESUPPORTBtankCAP = table.ship["LSS"]["LIFESUPPORTBtankCAP"].Value;
            CONSUMABLEtankCAP   = table.ship["LSS"]["CONSUMABLEtankCAP"].Value;

            int i = 1;
            while(table.ship["LSS"]["scrubber" +i+ "_LOC"].Count > 0)
            {
                scrubber.Add(new Scrubber(table.ship["LSS"]["scrubber" + i + "_LOC"]));
                i++;
            }
        }

        override public void AddToTable( ShipTable table )
        {
            table.ship["LSS"]["mount_MAX"].IntValue = mount_MAX;
            table.ship["LSS"]["sys_EB"].IntValue = sys_EB;
            table.ship["LSS"]["sys_quad"].IntValue = sys_quad;
            table.ship["LSS"]["TANKAtotal"].IntValue = TANKAtotal;
            table.ship["LSS"]["TANKBtotal"].IntValue = TANKBtotal;
            table.ship["LSS"]["TANKCtotal"].IntValue = TANKCtotal;
            table.ship["LSS"]["LIFESUPPORTAtankCAP"].Value = LIFESUPPORTAtankCAP;
            table.ship["LSS"]["LIFESUPPORTBtankCAP"].Value = LIFESUPPORTBtankCAP;
            table.ship["LSS"]["CONSUMABLEtankCAP"].Value = CONSUMABLEtankCAP;


            table.ship["LSS"]["scrubber_TOTAL"].Value = scrubber.Count;
            int i = 1;
            foreach(Scrubber scrub in scrubber)
            {
                table.ship["LSS"]["scrubber" + i + "_LOC"] = scrub.ToTable();
                i++;
            }
        }
    }
}
