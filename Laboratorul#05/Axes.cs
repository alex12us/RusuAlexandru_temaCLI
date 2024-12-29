using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
namespace Laboratorul_05
{
    class Axes
    {
        private bool visibility_line;
        private const int LUNGIMEA_AXEI = 75;

        public Axes()
        {
            visibility_line = true;
        }

        public void Draw()
        {
            if (visibility_line)
            {
                GL.LineWidth(3.0f);

                GL.Begin(PrimitiveType.Lines);
                GL.Color3(Color.Red);
                GL.Vertex3(0, 0, 0);
                GL.Vertex3(LUNGIMEA_AXEI, 0, 0);

                GL.Color3(Color.ForestGreen);
                GL.Vertex3(0, 0, 0);
                GL.Vertex3(0, LUNGIMEA_AXEI, 0);

                GL.Color3(Color.RoyalBlue);
                GL.Vertex3(0, 0, 0);
                GL.Vertex3(0, 0, LUNGIMEA_AXEI);

                GL.LineWidth(1.0f);

                GL.End();
            }
        }
        public void Show()
        {
            visibility_line = true;
        }
        public void Hide()
        {
            visibility_line = false;
        }
        public void ToggleVisibility()
        {
            visibility_line = !visibility_line;
        }
    }
}
