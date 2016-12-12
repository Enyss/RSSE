using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows;

namespace RSSE
{
    public class TextureViewModel : ObservableObject
    {
        private Texture _texture;
        private MeshRenderDataViewModel _parent;
        public Texture Model { get { return _texture; } }


        public TextureViewModel(MeshRenderDataViewModel parent)
        {
            _parent = parent;
            _texture = new Texture();
        }

        public TextureViewModel(MeshRenderDataViewModel parent, Texture texture)
        {
            _parent = parent;
            _texture = texture;
        }

        #region Properties
        public string Name
        {
            get { return _texture.name; }
            set
            {
                _texture.name = value;
                OnPropertyChanged();
            }
        }
        public int Order
        {
            get { return _parent.Textures.IndexOf(this) +1; }
        }

        #endregion

        #region Drag & drop

        // Drag & drop 
        private IDragSource _dragSource;
        private IDropTarget _dropSource;


        public IDragSource DragSource
        {
            get
            {
                if (_dragSource == null)
                    _dragSource = new DragSource<TextureViewModel>(GetDragEffects, GetData);

                return _dragSource;
            }
        }

        public IDropTarget DropSource
        {
            get
            {
                if (_dropSource == null)
                    _dropSource = new DropTarget<TextureViewModel>(GetDropEffects, Drop);

                return _dropSource;
            }
        }

        private DragDropEffects GetDragEffects(TextureViewModel mesh)
        {
            return DragDropEffects.Move;
        }

        private object GetData(TextureViewModel mesh)
        {
            return this;
        }

        private void Drop(TextureViewModel child)
        {
            _parent.MoveTexture(child, this);
        }

        private DragDropEffects GetDropEffects(TextureViewModel mesh)
        {
            //if (mesh == this)
            //    return DragDropEffects.None;
            return DragDropEffects.Move;
        }
        
        public void OrderChanged()
        {
            OnPropertyChanged("Order");
        }
        #endregion
    }
}
