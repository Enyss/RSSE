using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL4;

namespace RSSE
{
    class OGLibo
    {
        private readonly int handle;
        public int Handle { get { return handle; } }

        private readonly int indexSize;
        private ushort[] indexes; 

        private int count;
        public int Count { get { return count; } }


        public OGLibo()
        {

            // generate the actual Vertex Buffer Object
            this.handle = GL.GenBuffer();

            this.indexSize = 2;
            indexes = new ushort[3];
        }

        public void AddTriangle(ushort a, ushort b, ushort c)
        {
            if (this.count > this.indexes.Length - 3)
                Array.Resize(ref this.indexes, this.count * 2);
            // add vertex
            this.indexes[count] = a;
            this.indexes[count + 1] = b;
            this.indexes[count + 2] = c;

            this.count += 3;
        }

        public void Bind()
        {
            // make this the active array buffer
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, this.handle);
        }

        internal void CopyIndexes(ushort[] value)
        {
            count = value.GetLength(0);
            Array.Resize(ref indexes, count);
            Array.Copy(value, indexes, count);
        }

        public void BufferData(BufferUsageHint bufferUsage)
        {
            // copy contained vertices to GPU memory
            GL.BufferData(BufferTarget.ElementArrayBuffer, (IntPtr)(indexSize * this.count), this.indexes, bufferUsage);
        }
    }
}
