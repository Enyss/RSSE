using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE
{
    public class Texture
    {
        public string name;

        public Texture(string value)
        {
            name = value;
        }

        public Texture()
        {
            name = "default";
        }
    }
}
