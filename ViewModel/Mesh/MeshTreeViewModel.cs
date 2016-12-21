using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;


namespace RSSE
{
    public class MeshTreeViewModel : ObservableObject
    {
        public ObservableCollection<MeshViewModel> RootLevel { get; set; }
        private ObservableCollection<MeshViewModel> MeshList;
        private MeshCollection _meshList;
        public MeshCollection Model { get { return _meshList; } }

        private OGLScene scene;
        public OGLScene Scene
        {
            get { return scene; }
            set
            {
                scene = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddMeshCommand { get; private set; }
        public ICommand RemoveMeshCommand { get; private set; }

        public MeshTreeViewModel()
        {
            RootLevel = new ObservableCollection<MeshViewModel>();
            MeshList = new ObservableCollection<MeshViewModel>();
            

            Scene = new OGLScene();

            AddMeshCommand = new DelegateCommand(AddMesh);
            RemoveMeshCommand = new DelegateCommand<MeshViewModel>(RemoveMesh);
        }

        public MeshTreeViewModel(MeshCollection meshList)
        {
            _meshList = meshList;
            MeshList = new ObservableCollection<MeshViewModel>();
            RootLevel = new ObservableCollection<MeshViewModel>();


            AddMeshCommand = new DelegateCommand(AddMesh);
            RemoveMeshCommand = new DelegateCommand<MeshViewModel>(RemoveMesh);

            // Instantiate meshes
            foreach (Mesh mesh in _meshList.meshes)
            {
                MeshViewModel mv = new MeshViewModel(mesh);
                MeshList.Add(mv);
                mv.PropertyChanged += new PropertyChangedEventHandler(Mesh_PropertyChanged);
            }


            // Linking Tree
            foreach(MeshViewModel mv in MeshList)
            {
                mv.Model.LinkToParent(_meshList.meshes);
                MeshViewModel parent = MeshList.FirstOrDefault(x => (x.Model == mv.Model.parent));
                mv.Parent = parent;
                if (mv.Parent != null)
                {
                    if (!parent.Children.Contains(mv))
                    {
                        parent.Children.Add(mv);
                    }
                }
                mv.PropertyChanged += Mv_PropertyChanged;
            }

            // Create Scene
            Scene = new OGLScene(_meshList.meshes);
        }

        private void Mv_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            // for now we just refresh
            Scene.glControl.Invalidate();
            // When texture or shader change, load it
        }

        private void Mesh_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName=="Parent")
            {
                //clean the root
                RootLevel.Where(x => x.Parent != null).ToList().All(x => RootLevel.Remove(x));

                // add the mesh to the root if necessary
                if (((MeshViewModel)sender).Parent == null && !RootLevel.Contains(((MeshViewModel)sender)))
                    RootLevel.Add((MeshViewModel)sender);
            }
        }

        public void AddMesh()
        {
            MeshViewModel mesh = new MeshViewModel();
            MeshList.Add(mesh);
            RootLevel.Add(mesh);
        }

        public void RemoveMesh(MeshViewModel mesh)
        {
            foreach ( MeshViewModel vm in mesh.Children)
            {
                vm.Parent = mesh.Parent;
            }

            if (mesh.Parent == null)
            {
                RootLevel.Remove(mesh);
            }
            else
            {
                mesh.Parent.Children.Remove(mesh);
            }
        }

        #region Drag & drop

        // Drag & drop 
        private IDropTarget _drag;

        public IDropTarget DragMesh
        {
            get
            {
                if (_drag == null)
                    _drag = new DropTarget<MeshViewModel>(GetDropEffects, Drop);

                return _drag;
            }
        }


        private object GetData(MeshViewModel mesh)
        {
            return this;
        }

        private void Drop(MeshViewModel child)
        {
            if (child.Parent != null)
            {
                child.SetNewParent(null);
                RootLevel.Add(child);
            }
        }

        private DragDropEffects GetDropEffects(MeshViewModel mesh)
        {
            return DragDropEffects.Move;
        }

        #endregion
    }
}
