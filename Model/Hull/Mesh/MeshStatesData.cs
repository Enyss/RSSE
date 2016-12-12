using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE
{
    public class MeshStatesData
    {

        // States
        public string function;
        public int functionID;
        public string uiType;
        public int uiPage;
        public List<State> states;

        public MeshStatesData()
        {
            states = new List<State>();
        }

        public MeshStatesData(Table table)
        {
            function = table["Function"].StrValue;
            functionID = table["FunctionID"].IntValue;
            uiType = table["UItype"].StrValue;
            uiPage = table["UIpage"].IntValue;

            states = new List<State>();
            int i = 1;
            while (table["State" + i].Count > 0)
            {
                states.Add(new State(i, table["State" + i]));
                i++;
            }
        }

        public void AddToTable(Table table)
        {

            table["Function"].Value = function;
            table["FunctionID"].Value = functionID;
            table["UItype"].StrValue = uiType;
            table["UIpage"].IntValue = uiPage;

            table["TotalStates"].Value = states.Count;
            for (int i = 0; i < states.Count; i++)
            {
                table["State" + (i + 1)] = states.ElementAt(i).ToTable();
            }
        }
    }
}
