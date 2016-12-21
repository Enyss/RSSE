using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE
{
    public class MeshLightData
    {
        public int type { get; set; }
        public int shadowType { get; set; }
        public Vec3 vector; //What parameter is it?
        public Color color;

        public MeshLightData()
        { }

        public MeshLightData(Table table)
        {
            shadowType = table["ShadowType"].IntValue;
            type = table["LightData"]["Type"].IntValue;
            color = new Color(table["LightData"]["color"]);
            int x = table["LightData"]["x"].Value;
            int y = table["LightData"]["y"].Value;
            int z = table["LightData"]["z"].Value;
            vector = new Vec3(x, y, z);
        }

        public void AddToTable(Table table)
        {
            table["ShadowType"].Value = shadowType;
            table["LightData"]["Type"].Value = type;
            table["LightData"]["x"].Value = vector.x;
            table["LightData"]["y"].Value = vector.y;
            table["LightData"]["z"].Value = vector.z;
            table["LightData"]["color"] = color.ToTable();
        }
    }

}
