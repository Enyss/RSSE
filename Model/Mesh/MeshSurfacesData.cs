using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE
{
    public class MeshSurfacesData
    {
        private static Bictionary<SurfaceTypeEnum, int> bictionnary = new Bictionary<SurfaceTypeEnum, int>()
        {
            { SurfaceTypeEnum.RBLCport, 0 },
            { SurfaceTypeEnum.HeatPipes, 1 },
            { SurfaceTypeEnum.Radiator, 2 }
        };

        public SurfaceTypeEnum surface_EMISSION;
        public List<Surface> surfaces;

        public MeshSurfacesData()
        {
            surfaces = new List<Surface>();
        }

        public MeshSurfacesData(Table table)
        {
            surface_EMISSION = bictionnary[table["surface_EMISSION"].IntValue];

            surfaces = new List<Surface>();
            int  i = 1;
            while (table["Surface_" + i].Count > 0)
            {
                surfaces.Add(new Surface(i, table["Surface_" + i]));
                i++;
            }
        }

        public void AddToTable(Table table)
        {

            table["surface_EMISSION"].Value = bictionnary[surface_EMISSION];
            for (int i = 0; i < surfaces.Count; i++)
            {
                table["Surface_" + (i + 1)] = surfaces.ElementAt(i).ToTable();
            }
        }
    }
}
