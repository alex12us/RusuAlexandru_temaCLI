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

namespace RusuAlexandru_temaCLI
{
    class Program : GameWindow
    {
        float angle;
        float mouse_positionY;

        public Program() : base(800, 600)
        {
            VSync = VSyncMode.On;
            Console.WriteLine("OpenGl versiunea: " + GL.GetString(StringName.Version));
            this.Title = "OpenGl versiunea: " + GL.GetString(StringName.Version) + " (mod imediat)";
        }
        

        protected override void OnLoad(EventArgs e)
        {
           // base.OnLoad(e);
            GL.ClearColor(Color.Chocolate);
            mouse_positionY = Mouse.GetState().Y;
        }


        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-1.0, 1.0, -1.0, 1.0, 0.0, 4.0);
        }
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            
            base.OnUpdateFrame(e);
            if (Keyboard.GetState().IsKeyDown(Key.W))
                angle += 1f;
            if (Keyboard.GetState().IsKeyDown(Key.S))
                angle -= 1f;

            float mouseY = Mouse.GetState().Y;
             angle += (mouseY - mouse_positionY) * 0.1f;
            mouse_positionY = mouseY;
            if (Keyboard.GetState().IsKeyDown(Key.Escape))
                Exit();
               
        }
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.PushMatrix();
            GL.Rotate(angle, 0.0f, 0.0f, 1.0f);

            GL.Begin(PrimitiveType.LineStrip);
            GL.Color3(4.0f, 2.0f, 0.0f);
            GL.Vertex2(-0.5f, -0.5f);
            GL.Color3(-2.0f, 1.0f, 0.0f);
            GL.Vertex2(0.5f, -0.5f);
            GL.Color3(0.0f, 0.0f, 1.0f);
            GL.Vertex2(0.0f, 0.5f);
            GL.Color3(1.0f, 0.0f, 3.0f);
            GL.Vertex2(0.9f, 0.4f);
            GL.End();

            GL.PopMatrix();
            SwapBuffers();
        }
            [STAThread]
        static void Main(string[] args)
        {

            using (Program example = new Program())
            {


                // Verificați semnătura funcției în documentația inline oferită de IntelliSense!
                example.Run(30.0, 0.0);
            }
        }
    }

}
