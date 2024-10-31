using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triunghi_RGB_Random
{
     class Randomizer
    {   /// <summary>
    ///  Am creat funcita clasa Randomizer
    ///  
    ///  /// </summary>
        private Random r;
        public Randomizer()
        {
            r = new Random();
            
        }

        public Color GetRandomColor()
        {
            int genR = r.Next(0, 255);
            int genG = r.Next(0, 255);
            int genB = r.Next(0, 255);
            int genA=r.Next(0,255); // alpha  este transparenta
            Color col = Color.FromArgb(genA,genR, genG, genB);
            return col;
        }
    }
}
