using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLua;

namespace RSSE
{

    public class State
    {
        // two way dictionnary that map each state to the table key
        private static Bictionary<StateMotionTypeEnum, string> bictionnary = new Bictionary<StateMotionTypeEnum, string>()
        {
            { StateMotionTypeEnum.EVENTDRIVEN, "EVENTDRIVEN"},
            { StateMotionTypeEnum.LINEAR, "LINEAR"},
            { StateMotionTypeEnum.alt_LINEAR, "alt_LINEAR"},
            { StateMotionTypeEnum.STEP, "STEP"},
        };

        public string name;
        public StateMotionTypeEnum motionType;
        public Vector3 position;
        public Vector3 rotation;
        public Vector3 scale;
        public int startPause;
        public int rate;
        public bool visible;
        public bool collisionEnabled;
        public string triggerFunction;
        public int triggerSysID;
        public int triggerState;

        public State()
        {
            name = "default";
            position = new Vector3();
            rotation = new Vector3();
            scale = new Vector3();
        }
        
        public State(int id, Table table)
        {
            if (table["name"].Value == null)
            {
                name = "default";
            }
            else
            {
                name = table["name"].Value;
            }
            motionType = bictionnary[table["MotionType"].Value];
            position = new Vector3(table["Position"]);
            rotation = new Vector3(table["Rotation"]);
            scale = new Vector3(table["Scale"]);
            startPause = table["StartPause"].IntValue;
            rate = table["Rate"].IntValue;
            visible = table["Visible"].Value > 0.5;
            collisionEnabled = table["CollisionEnabled"].Value > 0.5;
            if (motionType == StateMotionTypeEnum.EVENTDRIVEN)
            {
                triggerFunction = table["TriggerFunction"].Value;
                triggerSysID = table["TriggerSysID"].IntValue;
                triggerState = table["TriggerState"].IntValue;
            }
            else
            {
                triggerFunction = "NONE";
            }
        }

        public Table ToTable()
        {
            Table table = new Table();

            table["name"].Value = name;
            table["MotionType"].Value = bictionnary[motionType];
            table["Position"] = position.ToTable();
            table["Rotation"] = rotation.ToTable();
            table["Scale"] = scale.ToTable();
            table["StartPause"].Value = startPause;
            table["Rate"].Value = rate;
            table["Visible"].Value = visible? 1:0;
            table["CollisionEnabled"].Value = collisionEnabled;
            if (motionType == StateMotionTypeEnum.EVENTDRIVEN)
            {
                table["TriggerFunction"].Value = triggerFunction;
                table["TriggerSysID"].Value = triggerSysID;
                table["TriggerState"].Value = triggerState;
            }
            else
            {
                table["TriggerFunction"].Value = "NONE";
            }

            return table;
        }
    }
}
