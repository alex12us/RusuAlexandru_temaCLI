using OpenTK.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System.Drawing.Drawing2D;
namespace Laboratorul_05
{
    class Randomizer
    {
        private Random r;
        public Randomizer()
        {
            r = new Random();
        }
    
        public Color4 RandomColor()
        {
            int genR=r.Next(0,255);
            int genG=r.Next(0,255);
            int genB=r.Next(0,255);
            int genA=r.Next(127,255);

           Color4 col= new Color4(genR,genG,genB,genA);
            return col;
        }

       
    }
}
