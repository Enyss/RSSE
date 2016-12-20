using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL4;
using System.Diagnostics;

namespace RSSE
{
    public class OGLShader
    {
        private readonly int handle;
        public int Handle { get { return handle; } }

        public OGLShader(ShaderType type, string code)
        {
            // create shader object
            handle = GL.CreateShader(type);

            // set source and compile shader
            GL.ShaderSource(this.handle, code);
            GL.CompileShader(this.handle);

            Debug.WriteLine(GL.GetShaderInfoLog(handle));
        }
    }
}
