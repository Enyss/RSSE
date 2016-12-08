using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE
{
    public class DoF
    {
        // Pitch
        public bool PU { get; set; }
        public bool PD { get; set; }
        // Roll       
        public bool RL { get; set; }
        public bool RR { get; set; }
        // Yaw        
        public bool YL { get; set; }
        public bool YR { get; set; }
        // Translation 
        public bool XU { get; set; }
        public bool XD { get; set; }
        public bool XL { get; set; }
        public bool XR { get; set; }
        public bool XF { get; set; }
        public bool XA { get; set; }

        public DoF() { }


        public DoF(Table table)
        {
            PU = table["PU"].Value > 0.5;
            PD = table["PD"].Value > 0.5;

            RL = table["RL"].Value > 0.5;
            RR = table["RR"].Value > 0.5;

            YL = table["YL"].Value > 0.5;
            YR = table["YR"].Value > 0.5;

            XU = table["XU"].Value > 0.5;
            XD = table["XD"].Value > 0.5;
            XL = table["XL"].Value > 0.5;
            XR = table["XR"].Value > 0.5;
            XF = table["XF"].Value > 0.5;
            XA = table["XA"].Value > 0.5;
        }
        public Table ToTable()
        {
            Table table = new Table();

            table["PU"].Value = PU ? 1 : 0;
            table["PD"].Value = PU ? 1 : 0;

            table["RL"].Value = RL ? 1 : 0;
            table["RR"].Value = RR ? 1 : 0;

            table["YL"].Value = YL ? 1 : 0;
            table["YR"].Value = YR ? 1 : 0;

            table["XU"].Value = XU ? 1 : 0;
            table["XD"].Value = XD ? 1 : 0;
            table["XL"].Value = XL ? 1 : 0;
            table["XR"].Value = XR ? 1 : 0;
            table["XF"].Value = XF ? 1 : 0;
            table["XA"].Value = XA ? 1 : 0;

            return table;
        }
    }
}
