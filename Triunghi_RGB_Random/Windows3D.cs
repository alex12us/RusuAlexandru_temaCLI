using OpenTK;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
namespace Triunghi_RGB_Random   ///Cerintele 8 si 9
{
    class Windows3D:GameWindow
    {
        private float angleX;
        private float angleY;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            GL.ClearColor(Color.White);
            GL.Enable(EnableCap.DepthTest);


            GL.Hint(HintTarget.PointSmoothHint, HintMode.Nicest);
            GL.Hint(HintTarget.PolygonSmoothHint, HintMode.Nicest);

        }

        protected override void OnMouseMove(MouseMoveEventArgs e)
        {
            angleX += e.XDelta * 0.1f;    //Detecteaza miscarile mouse-lui
            angleY += e.YDelta * 0.1f;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            //se seteaza viewport-ul
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
    }
}
