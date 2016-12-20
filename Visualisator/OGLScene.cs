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
    public class OGLScene
    {
        public GLControl glControl;
        Matrix4 VMatrix;
        Matrix4 PMatrix;
        Dictionary<Mesh,OGLMesh> oglMesh;
        Dictionary<string, OGLTexture> textures;
        Dictionary<string, OGLShaderProgram> shaderPrograms;

        Vector2 mousePos;
        OpenTK.Vector3 ViewDirection;
        OpenTK.Vector3 top;
        OpenTK.Vector3 eye;

        public OGLScene()
        {
            glControl = new GLControl();
            mousePos = new Vector2();
        }

        public OGLScene(List<Mesh> mesh)
        {

            mousePos = new Vector2();
            glControl = new GLControl();
            glControl.MakeCurrent();
            glControl.Paint += Paint;
            glControl.MouseMove += GlControl_MouseMove;
            glControl.Dock = System.Windows.Forms.DockStyle.Fill;

            oglMesh = new Dictionary<Mesh, OGLMesh>();
            textures = new Dictionary<string, OGLTexture>();
            shaderPrograms = new Dictionary<string, OGLShaderProgram>();


            Init(1280, 720);
            LoadShaders();
            LoadTextures(mesh);
            LoadMesh(mesh);
        }

        



        public void Init(int width, int height)
        {

            GL.Viewport(0, 0, width, height);
            GL.Enable(EnableCap.DepthTest);
            GL.DepthFunc(DepthFunction.Less);
            

            ViewDirection = new OpenTK.Vector3(2, 0, 2);
            eye = new OpenTK.Vector3(-2, 0, -2);
            top = new OpenTK.Vector3(0, 1, 0);
            VMatrix = Matrix4.LookAt(ViewDirection, OpenTK.Vector3.Add(eye,ViewDirection) , top); 
            PMatrix = Matrix4.CreateScale(-1,1,1)*Matrix4.CreatePerspectiveFieldOfView(
                MathHelper.PiOver2, 16f / 9, 0.1f, 500f);

        }

        private void GlControl_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            switch (e.Button)
            {
                case System.Windows.Forms.MouseButtons.Left:
                    double dx = e.X-mousePos.x ;
                    double dy = mousePos.y - e.Y;
                    Matrix4 Yaw = Matrix4.CreateFromAxisAngle(top, (float)dx / 100);
                    Matrix4 Pitch = Matrix4.CreateFromAxisAngle(OpenTK.Vector3.Cross(ViewDirection, top), (float)dy / 100);
                    Matrix4 rot = Yaw * Pitch;
                    ViewDirection = OpenTK.Vector3.TransformVector(ViewDirection, rot);
                    top = OpenTK.Vector3.TransformVector(top, rot);
                    mousePos.x = e.X;
                    mousePos.y = e.Y;
                    glControl.Invalidate();
                    break;
                case System.Windows.Forms.MouseButtons.Right:
                    dx = e.X- mousePos.x;
                    dy = mousePos.y - e.Y;
                    eye += OpenTK.Vector3.Multiply(OpenTK.Vector3.Cross(ViewDirection, top), (float)dx / 100);
                    eye += OpenTK.Vector3.Multiply(top, (float)dy / 5);
                    mousePos.x = e.X;
                    mousePos.y = e.Y;
                    glControl.Invalidate();
                    break;
                case System.Windows.Forms.MouseButtons.Middle:
                    dx = e.X-mousePos.x ;
                    dy = mousePos.y - e.Y;
                    eye += OpenTK.Vector3.Multiply(ViewDirection, (float)dy / 100);
                    mousePos.x = e.X;
                    mousePos.y = e.Y;
                    glControl.Invalidate();
                    break;
                default:
                    mousePos.x = e.X;
                    mousePos.y = e.Y;
                    break;
            }
            VMatrix = Matrix4.LookAt(eye, eye + ViewDirection, top);
        }

        private void LoadTextures(List<Mesh> mesh)
        {
            string baseFolder = Appli.Instance.Settings.RogueSysemFileRoot;
            string shipFolder = "/Mod/RogSysCM/Ships/" + Appli.Instance.ShipName + "/";
            string commonFolder = "/Mod/RogSysCM/Shared/Art/Maps/";

            OGLTexture tex = new OGLTexture();
            tex.LoadFromFile(baseFolder + commonFolder + "pink.tex");
            textures["pink"] = tex; 

            foreach (Mesh m in mesh)
            {
                if (m.meshType != MeshTypeEnum.LIGHT && m.render.renderMode != MeshRenderModeEnum.Material)
                {
                    
                    string name = m.render.textures[0].name;
                    if (!textures.ContainsKey(name))
                    {
                        tex = new OGLTexture();

                        string filename = baseFolder + shipFolder + name + ".tex";
                        string commonFilename = baseFolder + commonFolder + name + ".tex";
                        if (File.Exists(filename))
                        {
                            tex.LoadFromFile(filename);
                        }
                        else if (File.Exists(commonFilename))
                        {
                            tex.LoadFromFile(commonFilename);
                        }
                        else
                        {
                            tex.LoadFromFile(baseFolder + commonFolder + "pink.tex");
                        }

                        textures[name] = tex;
                    }
                }
            }
        }

        private void LoadShaders()
        {
            OGLShader vertexShader = new OGLShader(ShaderType.VertexShader, Properties.Resources.VertexShader1);
            OGLShader fragmentShader = new OGLShader(ShaderType.FragmentShader, Properties.Resources.FragmentShader1);
            shaderPrograms["UV"] = new OGLShaderProgram(vertexShader, fragmentShader);

        }

        private void LoadMesh(List<Mesh> mesh)
        {
            foreach (Mesh m in mesh)
            {
                if (m.meshType != MeshTypeEnum.LIGHT)
                {
                    oglMesh.Add(m, new OGLMesh(m, textures, shaderPrograms));
                }
            }
        }
 
        public void Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            glControl.MakeCurrent();


            GL.ClearColor(0.7f, 0.3f, 0.3f, 1.0f);
            GL.Clear(
                ClearBufferMask.ColorBufferBit |
                ClearBufferMask.DepthBufferBit |
                ClearBufferMask.StencilBufferBit);
            int count = 0;
            foreach ( KeyValuePair<Mesh,OGLMesh> element in oglMesh)
            {
                element.Value.Draw(VMatrix, PMatrix);
                count++;
                if (count > 300)
                    break;
                
            }
            

            glControl.SwapBuffers();
        }
    }
}
