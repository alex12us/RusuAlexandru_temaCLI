using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Input;

namespace Laboratorul_04
{
    class Windows3D:GameWindow
    {
        private KeyboardState previousKeyboard;
        private MouseState previousMouse;
        private readonly Randomizer rando;
        private readonly Axes axe;
        private readonly Grid grid;
        private readonly Camera3DIsometric cam;
        private readonly Obiect objx;
        private List<Obiect> ploaie_de_obiecte;
        //implicit
        private readonly Color DEFAULT_BKG_COLOR = Color.FromArgb(49, 50, 51);
        public Windows3D():base(800,600,new GraphicsMode(32,24,0,8))
        {
            DisplayHelp();
            VSync = VSyncMode.On;
            //initializari
            rando = new Randomizer();
            axe = new Axes();
            grid = new Grid();
            cam = new Camera3DIsometric();
            objx = new Obiect();
            ploaie_de_obiecte = new List<Obiect>();
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            GL.ClearColor(DEFAULT_BKG_COLOR);

            //setare viewportului
            GL.Viewport(0, 0, this.Width, this.Height);
            //setare perspectiva
            Matrix4 perspectiva = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4,(float)Width/(float)Height,1,1024);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perspectiva);

            //setare camera
            cam.SetCamera();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            GL.Enable(EnableCap.DepthTest);
            GL.DepthFunc(DepthFunction.Less);

            GL.Hint(HintTarget.PolygonSmoothHint, HintMode.Nicest);

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
            if (currentKeyboard[Key.H] && !previousKeyboard[Key.H])
            {
                DisplayHelp();
            }

            if (currentKeyboard[Key.R] && !previousKeyboard[Key.R])
            {
                GL.ClearColor(DEFAULT_BKG_COLOR);
                axe.Show();
                grid.Show();
            }

            if (currentKeyboard[Key.K] && !previousKeyboard[Key.K])
            {
                axe.ToggleVisibility();
            }

            if (currentKeyboard[Key.B] && !previousKeyboard[Key.B])
            {
                GL.ClearColor(rando.RandomColor());
            }

            if (currentKeyboard[Key.V] && !previousKeyboard[Key.V])
            {
                grid.ToggleVisibility();
            }

            // controlarea camerei(isometric mode)
            if (currentKeyboard[Key.W])
            {
                cam.MoveForward();
            }
            if (currentKeyboard[Key.S])
            {
                cam.MoveBackward();
            }
            if (currentKeyboard[Key.A])
            {
                cam.MoveLeft();
            }
            if (currentKeyboard[Key.D])
            {
                cam.MoveRight();
            }
            if (currentKeyboard[Key.Q])
            {
                cam.MoveUp();
            }
            if (currentKeyboard[Key.E])
            {
                cam.MoveDown();
            }
            previousKeyboard = currentKeyboard;
            previousMouse = currentMouse;
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            axe.Draw();
            grid.Draw();
            objx.Draw();
            SwapBuffers();
        }
        private void DisplayHelp()
        {
            Console.WriteLine("\n      MENIU");
            Console.WriteLine(" (H) - meniul");
            Console.WriteLine(" (ESC) - parasire aplicatie");
            Console.WriteLine(" (K) - schimbare vizibilitate sistem de axe");
            Console.WriteLine(" (R) - resteaza scena la valori implicite");
            Console.WriteLine(" (B) - schimbare culoare de fundal");
            Console.WriteLine(" (V) - schimbare vizibilitate linii");
            Console.WriteLine(" (W,A,S,D) - deplasare camera (izometric)");
            Console.WriteLine("(Q,E)-sunt folosit pentru deplasare in jos sau in sus");
        }

    }
}
