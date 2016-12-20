using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE
{
    struct VertexUV
    {
        private readonly Vector3 position;
        private readonly Vector2 uv;

        public VertexUV(Vector3 position, Vector2 uv)
        {
            this.position = position;
            this.uv = uv;
        }
    }
}
