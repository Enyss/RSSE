using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL4;

namespace RSSE
{
    class OGLvao<TVertex> where TVertex : struct
    {
        private readonly int handle;
        public int Handle {  get { return handle; } }

        public OGLvao(OGLvbo<TVertex> vertexBuffer, OGLShaderProgram program,
            params VertexAttribute[] attributes)
        {
            // create new vertex array object
            GL.GenVertexArrays(1, out this.handle);
            
            // bind the object so we can modify it
            this.Bind();
            
            // bind the vertex buffer object
            vertexBuffer.Bind();
            // set all attributes
            foreach (var attribute in attributes)
                attribute.Set(program);
            // unbind objects to reset state
            GL.BindVertexArray(0);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);

        }

        public void Bind()
        {
            // bind for usage (modification or rendering)
            GL.BindVertexArray(handle);
        }
    }
}
