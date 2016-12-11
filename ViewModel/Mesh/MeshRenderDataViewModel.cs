using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows;

namespace RSSE
{
    public class MeshRenderDataViewModel : ObservableObject
    {
        private MeshRenderData _render;
        public MeshRenderData Model {  get { return _render; } }

        public ObservableCollection<TextureViewModel> Textures { get; set; }

        public ICommand AddTextureCommand { get; private set; }
        public ICommand RemoveTextureCommand { get; private set; }

        public MeshRenderDataViewModel()
        {
            _render = new MeshRenderData();
            Textures = new ObservableCollection<TextureViewModel>();
            AddTextureCommand = new DelegateCommand(AddTexture);
            RemoveTextureCommand = new DelegateCommand<TextureViewModel>(RemoveTexture);
        }

        public MeshRenderDataViewModel( MeshRenderData render)
        {
            _render = render;
            Textures = new ObservableCollection<TextureViewModel>();
            AddTextureCommand = new DelegateCommand(AddTexture);
            RemoveTextureCommand = new DelegateCommand<TextureViewModel>(RemoveTexture);

            foreach (Texture texture in _render.textures)
            {
                Textures.Add(new TextureViewModel(this, texture));
            }
        }


        #region Properties
        public MeshRenderModeEnum RenderMode
        {
            get { return _render.renderMode; }
            set
            {
                _render.renderMode = value;
                OnPropertyChanged();
            }
        }
        public MeshRenderShadowModeEnum Shadow
        {
            get { return _render.shadow; }
            set
            {
                _render.shadow = value;
                OnPropertyChanged();
            }
        }
        public double LodOut
        {
            get { return _render.lodOut; }
            set
            {
                _render.lodOut = value;
                OnPropertyChanged();
            }
        }
        public string Material
        {
            get { return _render.material; }
            set
            {
                _render.material = value;
                OnPropertyChanged();
            }
        }
        public string Shader
        {
            get { return _render.shader; }
            set
            {
                _render.shader = value;
                OnPropertyChanged();
            }
        }
        public string Subfunction
        {
            get { return _render.subfunction; }
            set
            {
                _render.subfunction = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Drag & drop 

        private IDropTarget _dropSource;

        public IDropTarget DropSource
        {
            get
            {
                if (_dropSource == null)
                    _dropSource = new DropTarget<TextureViewModel>(GetDropEffects, Drop);

                return _dropSource;
            }
        }

        private object GetData(TextureViewModel mesh)
        {
            return this;
        }

        private void Drop(TextureViewModel child)
        {
            MoveTexture(child, null);
        }

        private DragDropEffects GetDropEffects(TextureViewModel mesh)
        {
            return DragDropEffects.Move;
        }


        #endregion

        public void AddTexture()
        {
            Texture tex = new Texture();
            TextureViewModel vm = new TextureViewModel(this, tex);
            Textures.Add(vm);
            _render.textures.Add(tex);
        }
        public void RemoveTexture(TextureViewModel texture)
        {
            Textures.Remove(texture);
            _render.textures.Remove(texture.Model);


            // Update the texture order number.
            foreach (TextureViewModel tex in Textures)
            {
                tex.OrderChanged();
            }
        }
        public void MoveTexture(TextureViewModel texture, TextureViewModel place)
        {
            if (texture == place)
                return;

            Textures.Remove(texture);
            _render.textures.Remove(texture.Model);

            if (place != null)
            {
                Textures.Insert(Textures.IndexOf(place), texture);
                _render.textures.Insert(_render.textures.IndexOf(place.Model), texture.Model);
            }
            else
            {
                Textures.Add(texture);
                _render.textures.Add( texture.Model);
            }

            // Update the texture order number.
            foreach (TextureViewModel tex in Textures)
            {
                tex.OrderChanged();
            }
        }
    }
}
