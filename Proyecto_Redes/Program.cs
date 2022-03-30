using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Redes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the read address");
            string path = Console.ReadLine();
            Net_Simulator ns = new Net_Simulator();
            ns.Path = path;
            if (ns.Path != null)
            {
                ns.Run_Simulation();
            }

        }
    }
}
