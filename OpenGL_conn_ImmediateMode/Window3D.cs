using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
namespace OpenGL_conn_ImmediateMode
{  
    //Cerinta 3-- OpenGL_conn_ImmediateMode
    class Window3D : GameWindow
    {

        private KeyboardState previousKeyboard;
        public Window3D() : base(800, 600, new GraphicsMode(32, 24, 0, 8)) {

            VSync = VSyncMode.On;
            this.Title = "OpenGL";
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            GL.ClearColor(Color.DarkViolet);

            GL.Enable(EnableCap.DepthTest);
            GL.DepthFunc(DepthFunction.Less);

          
            GL.Hint(HintTarget.PolygonSmoothHint, HintMode.Nicest);
        
           }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            GL.Viewport(0, 0, this.Width, this.Height);

            Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, (float)Width / (float)Height, 1, 256);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perspective);

            //se seteaza camera
            //initial a fost (30,30,30,...)
            Matrix4 lookat = Matrix4.LookAt(30, 30, 30, 0, 0, 0, 0, 1, 0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref lookat);
        }
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
            KeyboardState thisKeyboard = Keyboard.GetState();

            if (thisKeyboard[Key.Escape])
            { Exit(); }


        }
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.Clear(ClearBufferMask.DepthBufferBit);
            //Triunghiuri   
            //Se afiseaza doua triunghiuri
            GL.Begin(PrimitiveType.Triangles);

            GL.Color3(Color.Red);  //am selectat culoarea rosie
            GL.Vertex3(-1.0f, 0.0f,0.0f);
            GL.Vertex3(1.0f,0.0f, 0.0f);

            GL.Color3(Color.Green);   // verde
            GL.Vertex3(0.0f, -1.0f, 0.0f);
            GL.Vertex3(0.0f, 1.0f, 0.0f);


            GL.Color3(Color.Blue);  //albastru
            GL.Vertex3(0.0f, 0.0f, -1.0f);
            GL.Vertex3(0.0f, 0.0f, 1.0f);

            GL.End();


            SwapBuffers();
        }
        
    }
}
