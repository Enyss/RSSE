using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL4;

namespace RSSE
{
    sealed class OGLvbo<TVertex>
        where TVertex : struct // vertices must be structs so we can copy them to GPU memory easily
    {
        private readonly int handle;
        public int Handle { get { return handle; } }

        private readonly int vertexSize;
        public int VertexSize { get { return vertexSize; } }


        private TVertex[] vertices = new TVertex[4];

        private int count;


        public OGLvbo()
        {
            // We get the TVertex size
            vertexSize = System.Runtime.InteropServices.Marshal.SizeOf( new TVertex() );

            // generate the actual Vertex Buffer Object
            handle = GL.GenBuffer();
        }

        public void AddVertex(TVertex v)
        {
            Bind();
            // resize array if too small
            if (this.count == this.vertices.Length)
                Array.Resize(ref this.vertices, this.count * 2);
            // add vertex
            this.vertices[count] = v;
            this.count++;
        }

        public void Bind()
        {
            // make this the active array buffer
            GL.BindBuffer(BufferTarget.ArrayBuffer, this.handle);
        }

        public void Buffer(BufferUsageHint usage)
        {
            // copy contained vertices to GPU memory
            int size1 = this.vertices.GetLength(0);
            int size = this.vertexSize * size1;
            GL.BufferData(BufferTarget.ArrayBuffer, (IntPtr)size, vertices, usage);
        }

    }
}
