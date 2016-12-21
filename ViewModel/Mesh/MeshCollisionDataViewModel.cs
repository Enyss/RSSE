using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE
{
    public class MeshCollisionDataViewModel : ObservableObject
    {
        private MeshCollisionData _collision;
        public MeshCollisionData Model { get { return _collision; } }

        public MeshCollisionDataViewModel()
        {
            _collision = new MeshCollisionData();
        }
        public MeshCollisionDataViewModel(MeshCollisionData collision)
        {
            _collision = collision;
        }

        #region Properties
        public bool UseCollision
        {
            get { return _collision.useCollision; }
            set
            {
                _collision.useCollision = value;
                OnPropertyChanged();
            }
        }
        public MeshCollisionShapeEnum CollisionShape
        {
            get { return _collision.collisionShape; }
            set
            {
                _collision.collisionShape = value;
                OnPropertyChanged();
                OnPropertyChanged("HasShapeSize");
                OnPropertyChanged("IsSphere");
            }
        }
        public bool CollAutogen
        {
            get { return _collision.collAutogen; }
            set
            {
                _collision.collAutogen = value;
                OnPropertyChanged();
            }
        }

        public bool HasShapeSize
        {
            get { return NeedShapeSize(); }
        }
        public bool IsSphere
        {
            get { return CollisionShape == MeshCollisionShapeEnum.Sphere; }
        }
        public Vec3 CollShapeSize
        {
            get { return _collision.collShapeSize; }
            set
            {
                _collision.collShapeSize = value;
                OnPropertyChanged();
            }
        }
        public double ShapeRadius
        {
            get { return _collision.collShapeSize.x; }
            set
            {
                _collision.collShapeSize.x = value;
                OnPropertyChanged();
            }
        }
        public int CollisionObjectTotal
        {
            get { return _collision.collisionObjectTotal; }
            set
            {
                _collision.collisionObjectTotal = value;
                OnPropertyChanged();
            }
        }
        public bool IsMovable
        {
            get { return Math.Abs(Mass) > 0.00000001; }
            set
            {
                Mass = value?1:0;
            }
        }
        public double Mass
        {
            get { return _collision.mass; }
            set
            {
                _collision.mass = value;
                OnPropertyChanged();
                OnPropertyChanged("IsMovable");
            }
        }
        public double Friction
        {
            get { return _collision.friction; }
            set
            {
                _collision.friction = value;
                OnPropertyChanged();
            }
        }

        #endregion

        private bool NeedShapeSize()
        {
            return (CollisionShape == MeshCollisionShapeEnum.Box) ||
                (CollisionShape == MeshCollisionShapeEnum.Cone) ||
                (CollisionShape == MeshCollisionShapeEnum.Cylinder);
        }
        
    }
}
