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
     
        private float position_X;
        private float position_Y;
        private float position_Z;
        private float rotation_X=0.0f;
        private float rotation_Y=0.0f;
        private float rotation_X_axis = 0.0f;
        private float rotation_Y_axis = 0.0f;
        private Randomizer rando;
        private Cub cubul;
        private bool showCube = true;
        private Axes axe;
        private bool axesControl = true;
        public Windows3D() : base(600, 800, new GraphicsMode(32, 24, 0, 8))
        {
            VSync = VSyncMode.On;
            rando = new Randomizer();
            cubul = new Cub();
            axe = new Axes();
           
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            GL.ClearColor(Background_DEFAULT);

            GL.Enable(EnableCap.DepthTest);
            GL.DepthFunc(DepthFunction.Less);

            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha,BlendingFactorDest.OneMinusSrcAlpha);


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
            
            if (currentKeyboard[Key.S])
            {
                position_Y -= 1f;

            }
            if (currentKeyboard[Key.A])
            {
                position_X -= 1f;
            }
            if (currentKeyboard[Key.D])
            {

                position_X += 1f;
            }
            if (currentKeyboard[Key.W])
            {
                position_Y += 1f;
            }
            if (currentKeyboard[Key.Q])
            {
                position_Z -=1f;
            }
            if (currentKeyboard[Key.E])
            {
                position_Z += 1f;
            }
            if (currentKeyboard[Key.Up])
            {
                rotation_Y += 1f;
            }
            if (currentKeyboard[Key.Down])
            {
                rotation_Y -= 1f;
            }
            if (currentKeyboard[Key.Left])
            {
                rotation_X -= 1f;
            }
            if (currentKeyboard[Key.Right])
            {
                rotation_X += 1f;
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
     
            if (showCube == true)
            {
                GL.PushMatrix();
                GL.Translate(position_X, position_Y, position_Z);
                GL.Rotate(rotation_Y, 0.0f, 0.0f, 1.0f);
                GL.Rotate(rotation_X, 0.0f, 1.0f, 0.0f);
                cubul.DrawCub();
                GL.PopMatrix();
            }
            if (axesControl)
            {
 
                axe.Draw();

            }
            
            SwapBuffers();
        }

    }
}
