using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE
{
    struct VertexUV
    {
        private readonly Vec3 position;
        private readonly Vec2 uv;

        public VertexUV(Vec3 position, Vec2 uv)
        {
            this.position = position;
            this.uv = uv;
        }
    }
}
