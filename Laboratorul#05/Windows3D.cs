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
        private Randomizer rando;
        private Cub cubul;
        private bool showCube = true;
        private Axes axe;
        private bool axesControl = true;
        public Windows3D() : base(800, 600, new GraphicsMode(32, 24, 0, 8))
        {
            VSync = VSyncMode.On;
            rando = new Randomizer();
            cubul = new Cub();
            axe = new Axes();
            DisplayHelp();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            GL.ClearColor(Background_DEFAULT);

            GL.Enable(EnableCap.DepthTest);
            GL.DepthFunc(DepthFunction.Less);

            //Pentru activarea efectului de transparenta este Blend
            //0 ca este transparent,iar 255 este opac
            //ordinea de desenare a triunghiurilor este datorita efectelor de suprapunere
            //Obiectul este semi-transparent atunci culorile din spatele fetei devin vizibile
            //Acest efect este des folosit in aplicatiile dinamice 3D
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
            //ascunderea sau afisarea axei
            if (currentKeyboard[Key.X] && !previousKeyboard[Key.X])
            {
                if (axesControl)
                {
                    axe.Hide();
                    axesControl = false;
                }
                else {
                    axe.Show();
                    axesControl= true;
                }
                    
              
            }
          
            //Ascunderea  sau afisarea cubului
            if (currentKeyboard[Key.T] && !previousKeyboard[Key.T]) {
                if (showCube) {
                    showCube = false;
                }
                else
                {
                    showCube = true;
                }
            }
       ///Pozitionarile Cubului
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
            //Rotirea cubului
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
            //aplicarea paletelor de culori pe cub
            if (currentKeyboard[Key.P] && !previousKeyboard[Key.P])
            {
                cubul.AplicarePaleteCulori();
            }
            if (currentKeyboard[Key.V] && !previousKeyboard[Key.V]) {
                
                    Color4 col=rando.RandomColor();
                    cubul.SetVertexColor(3,col);
                    cubul.SetVertexColor(4,col);
                
            }
            if (currentKeyboard[Key.H]&& !previousKeyboard[Key.H])
            {
                DisplayHelp();
            }
            //Schimbare imagini de fundal
            if (currentKeyboard[Key.B] && !previousKeyboard[Key.B]) {
                GL.ClearColor(rando.RandomColor());
            }
            //culori gradiente random pentru cub
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
        private void DisplayHelp()
        {
            Console.WriteLine("ESC-Iesirea din aplicatiei");
            Console.WriteLine("X-ascunderea axei sau afisarea axei");
            Console.WriteLine("T-ascunderea sau afisarea cubului");
            Console.WriteLine("W,A,S,D,Q,E-misca cubul (dreapta-stanga,inainte-inapoi,sus-jos) ");
            Console.WriteLine("Tastele Up,Down,Left,Right - rotirea unui cub");
            Console.WriteLine("P-afisarea paletei de culori a unui cub");
            Console.WriteLine("V-schimbarea culorilor a unori varfuri");
            Console.WriteLine("C-Colorarea cubului aleatoriu cu culori gradiente cu canalul de transparenta");
            Console.WriteLine("B-Schimbarea culorii de fundal");
        }
    }
}
