using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLua;

namespace RSSE
{
    public class Surface
    {
        public string name;
        public string surface_FUNC;
        public int system_ID;
        public bool trigger_ONLY;
        public double output_TOTAL;
        public double output_VALUE;

        public Surface()
        {
            name = "default";
        }

        public Surface(int id, Table table)
        {
            if (table["name"].Value == null)
            {
                name = "default";
            }
            else
            {
                name = table["name"].Value;
            }
            surface_FUNC = table["surface_FUNC"].Value;
            system_ID = table["system_ID"].IntValue;
            trigger_ONLY = table["trigger_ONLY"].Value > 0.5;
            output_TOTAL = table["output_TOTAL"].Value;
            output_VALUE = table["output_VALUE"].Value;
        }

        public Table ToTable()
        {
            Table table = new Table();

            table["name"].Value = name;
            table["surface_FUNC"].Value = surface_FUNC;
            table["system_ID"].Value = system_ID;
            table["trigger_ONLY"].Value = trigger_ONLY? 1 : 0;
            table["output_TOTAL"].Value = output_TOTAL;
            table["output_VALUE"].Value = output_VALUE;

            return table;
        }
    }
}
