using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLua;

namespace RSSE
{
    public class Table : Dictionary<string, Table>
    {
        public dynamic Value { set; get; }
        public string StrValue { set { Value = value; } get { return Value == null ? "" : (string)Value; } }
        public int IntValue { set { Value = value; } get { return Value == null ? 0 : (int)Value; } }
        public double DoubleValue { set { Value = value; } get { return Value == null ? 0 : (double)Value; } }

        public new Table this[string key]
        {
            set { base[key] = value; }

            get
            {
                if (!base.Keys.Contains<string>(key))
                {
                    base[key] = new Table();
                }
                return base[key];
            }
        }

        public Table()
        {
        }

        public Table(Lua lua, LuaTable table)
        {
            Dictionary<object, object> dico = lua.GetTableDict(table);

            foreach (KeyValuePair<object, object> entry in dico)
            {
                if (entry.Value is LuaTable)
                {
                    this[(string)entry.Key] = new Table(lua, (LuaTable)entry.Value);
                }
                else
                {
                    this[(string)entry.Key] = new Table();
                    this[(string)entry.Key].Value = entry.Value;
                }

            }
        }

        public override string ToString()
        {
            string s = "";
            foreach (KeyValuePair<string, Table> element in this)
            {
                s += element.Key + "=";
                if (element.Value.Count > 0)
                {
                    s += "\n{\n" + (element.Value).ToString() + "}";
                }
                else
                {
                    if (element.Value.Value is string)
                    {
                        s += "\"" + element.Value.Value + "\"";
                    }
                    else
                    {
                        s += element.Value.Value;
                    }
                }
                s += ",\n";
            }

            return s.TrimEnd(',');
        }
    }

}
