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
        public int order;

        public Texture(int order, string value)
        {
            name = value;
        }

        public Texture() { }
    }
}
