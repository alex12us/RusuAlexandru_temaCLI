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
        float angle_Y;
        float mouse_positionY;
        float angle_X;
        float mouse_positionX;
        public Program() : base(800, 800)
        {
            VSync = VSyncMode.On;
            Console.WriteLine("OpenGl versiunea: " + GL.GetString(StringName.Version));
            this.Title = "OpenGl versiunea: " + GL.GetString(StringName.Version)+"-2024 CLI";
        }
        

        protected override void OnLoad(EventArgs e)
        {
           // base.OnLoad(e);
            GL.ClearColor(Color.Chocolate);
            mouse_positionX = Mouse.GetState().X;
            mouse_positionY = Mouse.GetState().Y;
            
           
        }


        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-2.0, 2.0, -2.0, 2.0, 0.0, 4.0);
        }
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            
            base.OnUpdateFrame(e);
            if (Keyboard.GetState().IsKeyDown(Key.W))
                angle_Y += 1f;
            if (Keyboard.GetState().IsKeyDown(Key.S))
                angle_Y -= 1f;
            if (Keyboard.GetState().IsKeyDown(Key.A))
                angle_X -= 1f;
            if (Keyboard.GetState().IsKeyDown(Key.D))
                angle_X += 1f;

            float mouseX = Mouse.GetState().X;
            float mouseY = Mouse.GetState().Y;
            
             angle_X+=(mouseX-mouse_positionX)*0.1f;
             angle_Y += (mouseY - mouse_positionY) * 0.1f;
            mouse_positionX = mouseX;
            mouse_positionY = mouseY;
            if (Keyboard.GetState().IsKeyDown(Key.Escape))
                Exit();
               
        }
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.PushMatrix();
            GL.Rotate(angle_Y, 0.0f, 0.0f, 1.0f);
            GL.Rotate(angle_X,0.0f,1.0f,0.0f);
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
            DrawObject();

            GL.PopMatrix();
            SwapBuffers();
        }
        void DrawObject()
        {
            GL.Begin(PrimitiveType.Triangles);
            GL.Color3(Color.Yellow);
            GL.Vertex2(1, 1);
            GL.Color3(Color.Blue);
            GL.Vertex2(1, 0);
            GL.Color3(Color.Azure);
            GL.Vertex2(2, 0);
            GL.End();
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
