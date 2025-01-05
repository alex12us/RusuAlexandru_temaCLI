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
namespace Laboratorul_05
{
    class Windows3D:GameWindow
    {
        private KeyboardState previousKeyboard;
        private MouseState previousMouse;
        private readonly Color Background_DEFAULT = Color.FromArgb(49,50,51);
        private Randomizer rando;
        private Cub cubul;
        public Windows3D() : base(600, 800, new GraphicsMode(32, 24, 0, 8))
        {
            VSync = VSyncMode.On;
            rando = new Randomizer();
            cubul = new Cub();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            GL.ClearColor(Background_DEFAULT);

            GL.Enable(EnableCap.DepthTest);
            GL.DepthFunc(DepthFunction.Less);


            GL.Hint(HintTarget.PolygonSmoothHint, HintMode.Nicest);

        }
        protected override void OnResize(EventArgs e) { base.OnResize(e);

            GL.Viewport(0, 0, Width, Height);

            double aspect_ratio = Width / (double)Height;

            Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, (float)aspect_ratio, 1, 64);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perspective);

            Matrix4 lookat = Matrix4.LookAt(30, 30, 30, 0, 0, 0, 0, 1, 0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref lookat);


        }
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            KeyboardState currentKeyboard = Keyboard.GetState();
            MouseState currentMouse = Mouse.GetState();
            if (currentKeyboard[Key.Escape])
            {
                Exit();
            }
            if (currentKeyboard[Key.C] && !previousKeyboard[Key.C])
            {
                cubul.Disco();
            }
            previousKeyboard = currentKeyboard;

        }
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            GL.Clear(ClearBufferMask.ColorBufferBit|ClearBufferMask.DepthBufferBit);
           
            cubul.DrawCub();
            SwapBuffers();
        }

    }
}
