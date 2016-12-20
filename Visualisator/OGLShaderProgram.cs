using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL4;

using System.Diagnostics;

namespace RSSE
{
    class OGLShaderProgram
    {
        private readonly int handle;
        public int Handle { get { return handle; } }

        public OGLShaderProgram(params OGLShader[] shaders)
        {
            // create program object
            handle = GL.CreateProgram();

            // assign all shaders
            foreach (var shader in shaders)
                GL.AttachShader(handle, shader.Handle);

            // link program (effectively compiles it)
            GL.LinkProgram(this.handle);
            
            // detach shaders
            foreach (var shader in shaders)
                GL.DetachShader(handle, shader.Handle);
        }
    }
}
