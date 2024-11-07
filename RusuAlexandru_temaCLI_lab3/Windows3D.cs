using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Graphics;
using System.Drawing;
using OpenTK.Input;
namespace RusuAlexandru_temaCLI_lab3
{
    class Windows3D:GameWindow
    {
        public Windows3D():base(600,800, new GraphicsMode(32,24,0,8))
        {
            VSync = VSyncMode.On;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            GL.ClearColor(Color.Silver);
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
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            /*1.Care este ordinea de desenare a vertexurilor pentru aceste metode
(orar sau anti-orar)? Desenați axele de coordonate din aplicația template folosind un singur apel GL.Begin().*/
            ///Axele x,y,z
       //3.
             GL.PointSize(5.0f);//mareste sau micsoreaza marimea punctului print metodaToogleSizePoint();
            GL.LineWidth(3.0f);//mareste sau micsoreaza grosimea unei linii prin metoda TogggleSizeLine()
                     //Nu functioneaza in interiorul functiei GL,Begin() cele doua functii PointSize() si LineWidth() pentru ca
                     //ar distiorsiona imaginea creata de programator
                     //GL.PointSize() si GL.LineWidth() sa fie puse inainte de GL.Begin(PrimitiveTypes.x),x-forma
            GL.Begin(PrimitiveType.Lines);   //metoda anti-orar
             //axa x;
            GL.Color3(Color.Red);
            GL.Vertex3(-5, 0, 0);
            GL.Vertex3(0, 0, 0);

            //axa y
            GL.Color3(Color.Green);
            GL.Vertex3(0, 5.0f, 0);
            GL.Vertex3(0, -0.0f,0);

            //axa z
            GL.Color3(Color.Blue);
            GL.Vertex3(0, 0, -5);
            GL.Vertex3(0, 0, 0);
            GL.End();



            SwapBuffers();
        }
        /* 2.Ce este anti-aliasing? Prezentați această tehnică pe scurt.
         * Anti-aliasing este o tehnica de a netezi marginea zimtata a unei linii 
         */
    }
}
