using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE
{
    public class MeshCollisionData
    {
        private static Bictionary<int, MeshCollisionShapeEnum> shape = new Bictionary<int, MeshCollisionShapeEnum>(){
            {1,MeshCollisionShapeEnum.DynamicConvexDecomp},
            {2, MeshCollisionShapeEnum.ConvexHull },
            {3, MeshCollisionShapeEnum.StaticMesh },
            {4, MeshCollisionShapeEnum.Box },
            {5, MeshCollisionShapeEnum.Cone },
            {6, MeshCollisionShapeEnum.Cylinder },
            {7, MeshCollisionShapeEnum.Sphere },
        };

        public bool useCollision;
        public MeshCollisionShapeEnum collisionShape;
        public bool collAutogen;
        public Vec3 collShapeSize;
        public int collisionObjectTotal;
        public double mass;
        public double friction;


        public MeshCollisionData()
        {
            collShapeSize = new Vec3();
        }
        public MeshCollisionData(Table table)
        {
            useCollision = table["useCollision"].DoubleValue > 0.5;
            if (useCollision)
            {
                collisionShape = shape[table["CollisionShape"].IntValue % 100];
                collAutogen = table["CollisionShape"].IntValue >= 100;
                collShapeSize = new Vec3(table["CollShapeSize"]);
                collisionObjectTotal = table["CollisionObjectTotal"].IntValue;
                mass = table["Mass"].DoubleValue;
                friction = table["Friction"].DoubleValue;
            }
            else
            {
                collShapeSize = new Vec3();
            }
        }

        public void AddToTable(Table table)
        {
            table["useCollision"].Value = useCollision ? 1 : 0;
            table["CollisionShape"].Value = shape[collisionShape] + (collAutogen ? 100 : 0);
            table["CollShapeSize"] = collShapeSize.ToTable();
            table["CollisionObjectTotal"].Value = collisionObjectTotal;
            table["Mass"].Value = mass;
            table["Friction"].Value = friction;

        }
    }
}
