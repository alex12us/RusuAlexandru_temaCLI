using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorul_04
{
    class Windows3D:GameWindow
    {
        public Windows3D():base(800,600,new OpenTK.Graphics.GraphicsMode(32,24,0,8))
        {

            VSync = VSyncMode.On;
        }
    }
}
