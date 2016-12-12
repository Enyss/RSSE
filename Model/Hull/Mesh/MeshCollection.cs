using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace RSSE
{
    public class MeshCollection
    {
        public List<Mesh> meshes;

        public MeshCollection()
        {
            meshes = new List<Mesh>();
        }

        public MeshCollection(Table table)
        {
            // Create the meshes
            meshes = new List<Mesh>();
            int i = 1;
            while (table.ContainsKey("Mesh" + i))
            {
                Mesh mesh = new Mesh(table["Mesh" + i]);
                meshes.Add(mesh);
                i++;
            }
        }
        
        public Table ToTable()
        {
            Table table = new Table();

            int i = 1;
            table["Total"].Value = meshes.Count;
            foreach(Mesh mesh in meshes)
            {
                table["Mesh" + i] = mesh.ToTable();
                i++;
            }

            return table;
        }
    }
}
