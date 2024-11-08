using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
///RusuAlexandruCLI
namespace Laboratorul_04
{
    class Program
    {
        [STAThread]   
        
        static void Main(string[] args)
        {
            using(Windows3D ex = new Windows3D())
            {
                ex.Run(30.0, 0.0);
            }
        
             
        
        }

    }
}
