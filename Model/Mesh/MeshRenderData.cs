using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE
{
    public class MeshRenderData
    {
        public MeshRenderModeEnum renderMode;
        public MeshRenderShadowModeEnum shadow;
        public double lodOut;
        public string material;
        public string shader;
        public string subfunction;
        public List<Texture> textures;

        public MeshRenderData()
        {
            textures = new List<Texture>();
            renderMode = MeshRenderModeEnum.None;
        }

        public MeshRenderData(Table table)
        {
            textures = new List<Texture>();
            
            // lod
            lodOut = table["LODout"].DoubleValue;

            // shadow
            SetShadow(table);

            // renderMode
            if (table["Shader"].Value != null)
            {
                renderMode = MeshRenderModeEnum.Texture;
                shader = table["Shader"].StrValue;
                subfunction = table["SUBfunction"].StrValue;
                SetTexture(table);
            }
            else if (table["Material"].Value != null)
            {
                renderMode = MeshRenderModeEnum.Material;
                material = table["Material"].StrValue;
                subfunction = table["SUBfunction"].StrValue;
            }
            else
            {
                renderMode = MeshRenderModeEnum.None;
            }
        }

        private void SetShadow(Table table)
        {
            if (table["ShadowCast"].IntValue == 1)
            {
                if (table["DynamicShadow"].IntValue == 1)
                    shadow = MeshRenderShadowModeEnum.Dynamic;
                else
                    shadow = MeshRenderShadowModeEnum.Static;
            }
            else
            {
                shadow = MeshRenderShadowModeEnum.None;
            }
        }
        private void SetTexture(Table table)
        {
            int i = 1;
            while (table["Texture"]["T" + i].Value != null)
            {
                textures.Add(new Texture(table["Texture"]["T" + i].Value) );
                i++;
            }
        }

        public void AddToTable(Table table)
        {
            table["LODout"].Value = lodOut;
            AddShadowToTable(table);

            switch (renderMode)
            {
                case MeshRenderModeEnum.None:
                    break;
                case MeshRenderModeEnum.Material:
                    table["Material"].Value = material;
                    table["SUBfunction"].Value = subfunction;
                    break;
                case MeshRenderModeEnum.Texture:
                    table["Shader"].Value = shader;
                    table["SUBfunction"].Value = subfunction;
                    table["Textures"].Value = textures.Count();
                    for ( int i = 0; i < textures.Count; i++) 
                    {
                        table["Texture"]["T" + i].Value = textures.ElementAt(i).name;
                    }
                    break;
            }
        }
        private void AddShadowToTable(Table table)
        {
            switch (shadow)
            {
                case MeshRenderShadowModeEnum.None:
                    table["ShadowCast"].Value = 0;
                    break;
                case MeshRenderShadowModeEnum.Static:
                    table["ShadowCast"].Value = 1;
                    table["DynamicShadow"].Value = 0;
                    break;
                case MeshRenderShadowModeEnum.Dynamic:
                    table["ShadowCast"].Value = 1;
                    table["DynamicShadow"].Value = 1;
                    break;
            }
        }
    }

}
