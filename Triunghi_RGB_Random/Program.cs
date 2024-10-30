using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triunghi_RGB_Random
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            using (TriunghiApp ex =new TriunghiApp())
            {
                ex.Run(30.0,0.0);
            }
        }
    }
}
