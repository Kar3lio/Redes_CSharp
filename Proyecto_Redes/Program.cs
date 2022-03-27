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
            Tools t = new Tools();
            string path = "C:\\Users\\Karel\\Desktop\\Tester\\PC.txt";
            List<string> temp = t.Read_File(path);
            foreach (var item in temp)
            {
                Console.WriteLine(item);
            }
        }
    }
}
