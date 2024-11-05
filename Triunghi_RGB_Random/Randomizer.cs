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
            
            Color col = Color.FromArgb(genR, genG, genB);
            return col;
        }
        public Color GetGradientColor(Color startColor,Color endColor,float factor)
        {
            factor = Clamp(factor, 0f, 1f); //
            int r = (int)(startColor.R + (endColor.R - startColor.R) * factor);//R-Red
            int g = (int)(startColor.G + (endColor.G - startColor.G) * factor);//G-Green
            int b = (int)(startColor.B + (endColor.B - startColor.B) * factor);//B-Blue
            int a = (int)(startColor.A + (endColor.A - startColor.A) * factor);//Alpha pentru nivelul de transparenta

            Color culoare = Color.FromArgb(a, r, g, b);
            return culoare;
        }
        private static float Clamp(float value, float min, float max)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }
    }
}
