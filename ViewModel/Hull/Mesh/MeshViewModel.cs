using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows;


namespace RSSE
{
    public class MeshViewModel : ObservableObject
    {
        private Mesh _mesh;
        public Mesh Model { get { return _mesh; } }

        // Tree state
        public bool _isExpanded = false;
        public bool _isSelected = false;
        // Drag & drop 
        private IDragSource _child;
        private IDropTarget _newParent;

        public ObservableCollection<MeshViewModel> Children { get; set; }

        private MeshViewModel _parent;
        public MeshViewModel Parent
        {
            get { return _parent; }
            set
            {
                SetNewParent(value);
                OnPropertyChanged();
            }
        }

        // Render
        public MeshRenderDataViewModel Render { get; set; }
        public MeshCollisionDataViewModel Collision { get; set; }
        public MeshStateDataViewModel States { get; set; }
        public MeshSurfacesDataViewModel Surfaces { get; set; }
        #region Properties

        // General
        public string Name
        {
            get { return _mesh.name; }
            set
            {
                _mesh.name = value;
                OnPropertyChanged();
            }
        }
        public string MeshModel
        {
            get { return _mesh.model; }
            set
            {
                _mesh.model = value;
                OnPropertyChanged();
            }
        }
        public MeshTypeEnum MeshType
        {
            get { return _mesh.meshType; }
            set
            {
                _mesh.meshType = value;
                OnPropertyChanged();
            }
        }
        public string SystemType
        {
            get { return _mesh.systemType; }
            set
            {
                _mesh.systemType = value;
                OnPropertyChanged();
            }
        }
        public string UiName
        {
            get { return _mesh.uiName; }
            set
            {
                _mesh.uiName = value;
                OnPropertyChanged();
            }
        }
        public string SectionName
        {
            get { return _mesh.sectionName; }
            set
            {
                _mesh.sectionName = value;
                OnPropertyChanged();
            }
        }

        // Position
        public Vector3 Position
        {
            get { return _mesh.position; }
            set
            {
                _mesh.position = value;
                OnPropertyChanged();
            }
        }
        public Vector3 Rotation
        {
            get { return _mesh.rotation; }
            set
            {
                _mesh.rotation = value;
                OnPropertyChanged();
            }
        }

        public string ParentName
        {
            get { return (Parent==null)?"None":Parent.Name; }
        }
        
        // Light
        public MeshLightData Light
        {
            get { return _mesh.light; }
            set
            {
                _mesh.light = value;
                OnPropertyChanged();
            }
        }
        
        #endregion //Properties

        #region Constructors

        public MeshViewModel()
        {
            _mesh = new Mesh();
            Children = new ObservableCollection<MeshViewModel>();
            Render = new MeshRenderDataViewModel();
            Collision = new MeshCollisionDataViewModel();
            States = new MeshStateDataViewModel();
        }

        public MeshViewModel(Mesh mesh)
        {
            _mesh = mesh;
            Children = new ObservableCollection<MeshViewModel>();
            Render = new MeshRenderDataViewModel(mesh.render);
            Collision = new MeshCollisionDataViewModel(mesh.collision);
            States = new MeshStateDataViewModel(mesh.states);
            Surfaces = new MeshSurfacesDataViewModel(mesh.surfaces);
        }

        #endregion //Constructors

        public void SetNewParent(MeshViewModel parent)
        {
            //remove current parent
            if (_parent != null)
            {
                _parent.Children.Remove(this);
                _parent.Model.children.Remove(_mesh);
            }
            
            //set parent
            _parent = parent;
            _mesh.parent = (parent == null)? null : parent.Model;
            if (parent != null)
            {
                // add this mesh to parent's children
                parent.Children.Add(this);
                parent.Model.children.Add(_mesh);
            }
        }

        #region Drag & drop

        public IDragSource Child
        {
            get
            {
                if (_child == null)
                    _child = new DragSource<MeshViewModel>(GetDragEffects, GetData);

                return _child;
            }
        }
        
        public IDropTarget NewParent
        {
            get
            {
                if (_newParent == null)
                    _newParent = new DropTarget<MeshViewModel>(GetDropEffects, Drop);

                return _newParent;
            }
        }

        private DragDropEffects GetDragEffects(MeshViewModel mesh)
        {
            // Only allow the drag and drop to start if we have any cookies
            return DragDropEffects.Move;
        }

        private object GetData(MeshViewModel mesh)
        {
            return this;
        }

        private void Drop(MeshViewModel child)
        {
            child.SetNewParent(this);
            OnPropertyChanged("Parent");
        }

        private DragDropEffects GetDropEffects(MeshViewModel mesh)
        {
            if (HasChild(mesh))
                return DragDropEffects.None;
            return DragDropEffects.Move;
        }

        private bool HasChild(MeshViewModel mesh)
        {
            if (mesh == this)
                return true;
            foreach(MeshViewModel m in mesh.Children)
            {
                if (HasChild(m))
                    return true;
            }
            return false;
        }

        #endregion

        #region IsExpanded

        public bool IsExpanded
        {
            get { return _isExpanded; }
            set
            {
                if (value != _isExpanded)
                {
                    _isExpanded = value;
                    OnPropertyChanged();
                }

                // Expand all the way up to the root.
                if (_isExpanded && Parent != null)
                    Parent.IsExpanded = true;
            }
        }

        #endregion // IsExpanded 

        #region IsSelected

        /// <summary>
        /// Gets/sets whether the TreeViewItem 
        /// associated with this object is selected.
        /// </summary>
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (value != _isSelected)
                {
                    _isSelected = value;
                    OnPropertyChanged();
                }
            }
        }

        #endregion

    }
}
