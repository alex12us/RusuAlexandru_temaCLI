using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Graphics;

namespace Laboratorul_06
{
   class Windows3D:GameWindow
    {
        public Windows3D():base(800, 600, new GraphicsMode(32, 24, 0, 8))
        {

        }
    }
}
