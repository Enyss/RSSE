using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;
using System.IO;

namespace RSSE
{
    class OGLMesh
    {
        public Matrix4 RogMatrix;
        private Matrix4 BaseMatrix;
        private readonly Mesh mesh;
        private OGLShaderProgram shaderProgram;
        private OGLTexture texture;
        private int vbo; //OGLvbo<VertexUV> vbo;
        private int vao; //OGLvao<VertexUV> vao;
        private int indexBuffer; //OGLibo ibo;
        private int indexBufferCount;

        public OGLMesh(Mesh mesh, Dictionary<string, OGLTexture> textures, Dictionary<string, OGLShaderProgram> shaderPrograms)
        {
            this.mesh = mesh;
            SetTexture(textures);
            SetShader(shaderPrograms);
            ReadFile();
        }

        private void SetShader(Dictionary<string, OGLShaderProgram> shaderPrograms)
        {
            shaderProgram = shaderPrograms["UV"];
        }

        private void SetTexture(Dictionary<string, OGLTexture> textures)
        {
            switch (mesh.render.renderMode)
            {
                case MeshRenderModeEnum.Texture: 
                    texture = textures[mesh.render.textures[0].name];
                    break;
                case MeshRenderModeEnum.Material:
                    texture = textures["pink"];
                    break;
            }
        }

        private void ReadFile()
        {
            OGLMdlReader reader = new OGLMdlReader();

            string baseFolder = Appli.Instance.Settings.RogueSysemFileRoot; 
            string shipFolder = "/Mod/RogSysCM/Ships/"+ Appli.Instance.ShipName + "/";
            string commonFolder = "/Mod/RogSysCM/Shared/Art/Models/";
            
            string name = (mesh.model == "" || mesh.model == "NONE") ? mesh.name : mesh.model;

            string filename = baseFolder + shipFolder + name + ".mdl";
            string commonFilename = baseFolder + commonFolder + name + ".mdl";
            if (File.Exists(filename))
            {
                reader.Read(filename);
            }
            else if (File.Exists(commonFilename))
            {
                reader.Read(commonFilename);
            }
            else
            {
                throw new Exception(name + " model not found");
            }

            

            #region Model Matrix
            float[] mat = reader.floatArray[0];
            BaseMatrix = new Matrix4(mat[0], mat[1], mat[2], mat[3],
                mat[4], mat[5], mat[6], mat[7],
                mat[8], mat[9], mat[10], mat[11],
                mat[12], mat[13], mat[14], mat[15]
                );


            #endregion



            vao = GL.GenVertexArray();
            GL.BindVertexArray(vao);

            #region VBO
            /*vbo = new OGLvbo<VertexUV>();
            float[,] vertex = reader.floatArray2D[0];
            float[,] texture = reader.floatArray2D[2];
            int size = vertex.GetUpperBound(0);
            for (int i = 0; i <= size; i++)
            {
                Vector3 position = new Vector3(vertex[i, 0], vertex[i, 1], vertex[i, 2]);
                Vector2 uv = new Vector2(texture[i, 0], texture[i, 1]);
                vbo.AddVertex(new VertexUV(position, uv));
            }


            vbo.Bind();
            vbo.Buffer(BufferUsageHint.StaticDraw);*/
            float[,] vertex = reader.floatArray2D[0];
            float[,] texture = reader.floatArray2D[2];
            int size = vertex.Length/3;
            float[] data = new float[5*size];
            for (int i = 0; i < size; i++)
            {
                data[5*i + 0] = vertex[i, 0];
                data[5*i + 1] = vertex[i, 1];
                data[5*i + 2] = vertex[i, 2];
                data[5*i + 3] = texture[i, 0];
                data[5*i + 4] = texture[i, 1];
            }

            vbo = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, vbo);
            GL.BufferData<float>(BufferTarget.ArrayBuffer, data.Length*4, data, BufferUsageHint.StaticDraw);

            int vPosition = GL.GetAttribLocation(shaderProgram.Handle, "vPosition");
            GL.VertexAttribPointer(vPosition, 3, VertexAttribPointerType.Float, false, 20, 0);
            int vTexture = GL.GetAttribLocation(shaderProgram.Handle, "vTexture");
            GL.VertexAttribPointer(vTexture, 2, VertexAttribPointerType.Float, false, 20, 12);

            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            #endregion

            #region IBO

            /*
            ibo = new OGLibo();
            ibo.Bind();
            ibo.CopyIndexes(reader.ushortArray[0]);
            ibo.BufferData(BufferUsageHint.StaticRead);*/


            indexBufferCount = reader.ushortArray[0].Length;
            ushort[] indexData = new ushort[indexBufferCount];
            Array.Copy(reader.ushortArray[0], indexData, indexBufferCount);

            indexBuffer = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, indexBuffer);
            GL.BufferData(BufferTarget.ElementArrayBuffer, indexBufferCount * 2, indexData, BufferUsageHint.StaticDraw);
            #endregion

            #region VAO

            /*vao = new OGLvao<VertexUV>(vbo, shaderProgram,
                            new VertexAttribute("vPosition", 3, VertexAttribPointerType.Float, vbo.VertexSize, 0),
                            new VertexAttribute("vTexture", 2, VertexAttribPointerType.Float, vbo.VertexSize, 12)
                            );
                            */

            #endregion

            GL.BindVertexArray(0);
        }

        public void Draw(Matrix4 VMatrix, Matrix4 PMatrix)
        {
            GL.UseProgram(shaderProgram.Handle);

            #region Uniforms setting

            //Set the MVP matrix

            Matrix4 MVP =  getRogMatrix(mesh) * VMatrix * PMatrix;
            int mvp_index = GL.GetUniformLocation(shaderProgram.Handle, "MVP");
            GL.UniformMatrix4(mvp_index, false, ref MVP);



            //Set the texture 
            int tex_index = GL.GetUniformLocation(shaderProgram.Handle, "tex");
            //GL.Uniform1(tex_index, 0);
            GL.ActiveTexture(TextureUnit.Texture0);
            GL.BindTexture(TextureTarget.Texture2D, texture.Handle);
            #endregion

            GL.BindVertexArray(vao);
            GL.EnableVertexAttribArray(0);
            GL.EnableVertexAttribArray(1);

            GL.DrawElements(BeginMode.Triangles, indexBufferCount, DrawElementsType.UnsignedShort, 0);
        }
        
        public Matrix4 getRogMatrix(Mesh mesh)
        {
            Matrix4 rotX = Matrix4.CreateRotationX(-(float)mesh.rotation.x / 180*MathHelper.Pi);
            Matrix4 rotY = Matrix4.CreateRotationY(-(float)mesh.rotation.z / 180 * MathHelper.Pi);
            Matrix4 rotZ = Matrix4.CreateRotationZ((float)mesh.rotation.y / 180 * MathHelper.Pi);
            Matrix4 trans = Matrix4.CreateTranslation( (float)mesh.position.x, (float)mesh.position.z, (float)mesh.position.y );

            Matrix4 self = rotZ *  rotX *  rotY * trans;
            
            return self;
        }
    }
}