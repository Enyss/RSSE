using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE
{
    public class TextureViewModel : ObservableObject
    {
        private Texture _texture;
        public Texture Model { get { return _texture; } }

        public TextureViewModel()
        {
            _texture = new Texture();
        }

        public TextureViewModel(Texture texture)
        {
            _texture = texture;
        }

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
            get { return _texture.order; }
            set
            {
                _texture.order = value;
                OnPropertyChanged();
            }
        }
    }
}
