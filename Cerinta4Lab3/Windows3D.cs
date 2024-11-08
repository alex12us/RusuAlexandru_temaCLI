using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System;
using System.Drawing;

namespace Cerinta4Lab3
{    /// <summary>
/// Laboratorul 3
/// </summary>
    class Windows3D : GameWindow
    {
       //Am dat raspunsurile de la cerinta 4 in consola
        private KeyboardState previousKeyboard;
        public Windows3D() : base(800, 600, new GraphicsMode(32, 8, 0, 24))
        {
            VSync = VSyncMode.On;
            RaspunsCerinta4();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            GL.Enable(EnableCap.DepthTest);
            GL.DepthFunc(DepthFunction.Less);

            GL.Hint(HintTarget.PolygonSmoothHint, HintMode.Nicest);
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            //Setarea background-ul
            GL.ClearColor(Color.LemonChiffon);
            //Setarea viewport-ului
            GL.Viewport(0, 0, this.Width, this.Height);
            //Setarea perspectiva
            Matrix4 perspectiva = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, (float)this.Width / (float)this.Height, 1, 256);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perspectiva);
            //Setarea camera
            Matrix4 lookat = Matrix4.LookAt(30, 30, 30, 0, 0, 0, 0, 1, 0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref lookat);
        }
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
            KeyboardState currentKeyboard = Keyboard.GetState();
            if (currentKeyboard[Key.Escape])
            {
                Exit();
            }
            

            previousKeyboard = currentKeyboard;

        }


        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            GL.Clear(ClearBufferMask.DepthBufferBit | ClearBufferMask.ColorBufferBit);

            DrawLineStrip();
            DrawTriangleFan();
            DrawLineLoop();
            DrawTriangleStrip();
            SwapBuffers();

        }
        private void DrawLineStrip()
        {
            GL.Begin(PrimitiveType.LineLoop);

            GL.Color3(Color.Red);
            GL.Vertex3(-2.5f, -2.5f, 0.0f);
            GL.Vertex3(2.5f, -2.5f, 0.0f);
            GL.Vertex3(2.5f, 2.5f, 0.0f);
            GL.Vertex3(-2.5f, 2.5f, 0.0f);



            GL.End();

        }
        private void DrawLineLoop()
        {
            GL.Begin(PrimitiveType.LineStrip);

            GL.Color3(Color.Green);
            GL.Vertex3(-4.5f, -4.5f, 0.0f);
            GL.Color3(Color.DarkOrchid);
            GL.Vertex3(4.5f, -0.5f, 0.0f);
            GL.Color3(Color.DarkSeaGreen);
            GL.Vertex3(4.5f, 2.5f, 0.0f);
            GL.Color3(Color.DarkViolet);
            GL.Vertex3(-4.5f, 4.5f, 0.0f);

            GL.Vertex3(5.5f, 5.5f, 0.0f);
            GL.Color3(Color.Firebrick);
            GL.Vertex3(-5.5f, 5.5f, 0.0f);
            GL.Color3(Color.FloralWhite);
            GL.Vertex3(-5.5f, -5.5f, 0.0f);
            GL.Color3(Color.Indigo); 
            GL.Vertex3(5.5f, -5.5f, 0.0f);

            GL.End();

        }
        private void DrawTriangleFan()
        {
            GL.Begin(PrimitiveType.TriangleFan);

            GL.Color3(Color.Blue);
            GL.Vertex3(0.0f, 0.0f, 0.0f); // Centrul fanului
            GL.Vertex3(4.5f, 0.0f, 0.0f);
            GL.Vertex3(3.3f, 0.5f, 0.0f);
            GL.Vertex3(-0.3f, 0.5f, 0.0f);
            GL.Vertex3(-0.5f, 0.0f, 0.0f);
            GL.Vertex3(-3.3f, -4.5f, 0.0f);
            GL.Vertex3(3.3f, -4.5f, 0.0f);
            GL.Vertex3(4.5f, 0.0f, 0.0f); // Închide fanul

            GL.End();

        }
        private void DrawTriangleStrip()
        {
            GL.Begin(PrimitiveType.TriangleStrip);

            GL.Color3(Color.Yellow);
            GL.Vertex3(-5.5f, -0.5f, 0.0f);
            GL.Color3(Color.Azure);
            GL.Vertex3(-0.5f, 0.5f, 0.0f);
            GL.Color3(Color.Crimson);
            GL.Vertex3(0.0f, -0.5f, 0.0f);
            GL.Color3(Color.Chocolate);
            GL.Vertex3(0.0f, 5.5f, 0.0f);
            GL.Color3(Color.DarkOrange);
            GL.Vertex3(0.5f, -0.5f, 0.0f);
            GL.Color3(Color.DarkMagenta);
            GL.Vertex3(5.5f, 5.5f, 0.0f);

            GL.End();
        }
        private void RaspunsCerinta4()
        {
            Console.WriteLine("LineStrip--Conecteaza fiecare pereche consecutiva de varfuri cu un segment de linie,fara sa inchida bucla");
            Console.WriteLine("Fiecare pereche consecutiva de varfuri este conecntata printr-o linie fara sa inchida bucla spre deosebire de linelop");
            Console.WriteLine("LineLoop-conecteaza fiecare segment de dreapta astfel incat se va forma o bucla inchisa");
            Console.WriteLine("Ca efect se creeaza un poligon delimitat si conecteaza ultimul vertex cu primul vertex.Sunt conectate intr-o linie");
            Console.WriteLine("TriangleFan, ca efect imparte un punct central comun dupa creearea unui set de triunghiuri");
            Console.WriteLine("TriangleStrip--creeaza o serie de triunghiuri conectate,unde ficeare triunghi are doua varfuri cu triunghiul anterior,ceea ce rezulta o banda de triunghiuri ce reda unei suprafete lungi si inguste");
        }
        }
}