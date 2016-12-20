using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using OpenTK.Graphics.OpenGL4;

namespace RSSE
{
    public class OGLTexture
    {
        private readonly int handle;
        public int Handle { get { return handle; } }

        public OGLTexture()
        {
            handle = GL.GenTexture();
        }

        public void LoadFromFile(string filename)
        {
            GL.BindTexture(TextureTarget.Texture2D, handle);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureBaseLevel, 0);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMaxLevel, 0);

            ReadTexFile(filename);


        }

        private void ReadTexFile(string filename)
        {
            BinaryReader b = new BinaryReader(File.Open(filename, FileMode.Open));

            // Header
            b.ReadBytes(8);
            int format = b.ReadInt32();
            b.ReadBytes(4);
            int baseWidth = b.ReadInt32();
            int baseHeight = b.ReadInt32();
            b.ReadBytes(24);
            int mipMapLevel = b.ReadInt32();

            // First mipMapLevel
            int width = b.ReadInt32();
            int height = b.ReadInt32();
            int size = b.ReadInt32();
            byte[] data = b.ReadBytes(size);


            /*// Second mipMapLevel
            width = b.ReadInt32();
            height = b.ReadInt32();
            size = b.ReadInt32();
            data = b.ReadBytes(size);*/
            
            switch (format)
            {
                case 8:
                    GL.CompressedTexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.CompressedRgbS3tcDxt1Ext, width, height, 0, size, data);
                    break;
                case 6:
                    GL.CompressedTexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.CompressedRgbaS3tcDxt5Ext, width, height, 0, size, data);
                    break;
                default:
                    GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, width, height, 0, PixelFormat.Rgba, PixelType.UnsignedInt8888, data);
                    break;
            }

            b.Dispose();
        }
    }
}
