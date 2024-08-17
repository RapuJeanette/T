using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace T
{
    public class Game: GameWindow
    {
        public Game(int width, int height, string title) : base(width, height, GraphicsMode.Default, title) { }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            GL.Rotate(1.0f, 0.0f, 1.0f, 0.0f);
            base.OnUpdateFrame(e);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            // definimos el color de fondo de la ventana
            GL.ClearColor(Color4.AliceBlue);
            GL.Enable(EnableCap.DepthTest);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.Begin(PrimitiveType.Quads);

            // Barra horizontal de la "T"
            // Posición (x, y, z), Ancho, Altura, Profundidad
            DrawPrism(0.0f, 0.4f, 0.0f, 1.0f, 0.2f, 0.2f);  

            // Barra vertical de la "T"
            DrawPrism(0.0f, -0.2f, 0.0f, 0.2f, 0.8f, 0.2f); 

            GL.End();

            //GL.Flush(); //para limpiar


            Context.SwapBuffers();
            base.OnRenderFrame(e);
        }

        private void DrawPrism(float x, float y, float z, float width, float height, float depth)
        {
            float x0 = x - width / 2, x1 = x + width / 2;
            float y0 = y, y1 = y + height;
            float z0 = z - depth / 2, z1 = z + depth / 2;

            // Front face
            GL.Color4(Color.Black);
            GL.Vertex3(x0, y0, z1);
            GL.Vertex3(x1, y0, z1);
            GL.Vertex3(x1, y1, z1);
            GL.Vertex3(x0, y1, z1);

            // Back face
            GL.Vertex3(x0, y0, z0);
            GL.Vertex3(x1, y0, z0);
            GL.Vertex3(x1, y1, z0);
            GL.Vertex3(x0, y1, z0);

            // Left face
            GL.Vertex3(x0, y0, z0);
            GL.Vertex3(x0, y0, z1);
            GL.Vertex3(x0, y1, z1);
            GL.Vertex3(x0, y1, z0);

            // Right face
            GL.Vertex3(x1, y0, z0);
            GL.Vertex3(x1, y0, z1);
            GL.Vertex3(x1, y1, z1);
            GL.Vertex3(x1, y1, z0);

            // Top face
            GL.Vertex3(x0, y1, z0);
            GL.Vertex3(x1, y1, z0);
            GL.Vertex3(x1, y1, z1);
            GL.Vertex3(x0, y1, z1);

            // Bottom face
            GL.Vertex3(x0, y0, z0);
            GL.Vertex3(x1, y0, z0);
            GL.Vertex3(x1, y0, z1);
            GL.Vertex3(x0, y0, z1);
        }

        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);

            Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, Width / (float)Height, 0.1f, 100.0f);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref projection);

            Matrix4 modelview = Matrix4.LookAt(Vector3.UnitZ * 5, Vector3.Zero, Vector3.UnitY);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref modelview);

            base.OnResize(e);
        }

    }
}
