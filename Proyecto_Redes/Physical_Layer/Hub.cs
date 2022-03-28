using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Redes
{
    public class Hub : Device
    {
        
        public Hub(string name, int ports_count)
        {
            this.Name = name;
            this.Ports = new List<Port>(ports_count);
            Port p;
            for (int i = 1; i <= ports_count; i++)
            {
                p = new Port(name + "_" + i);
                Ports.Add(p);
            }
        }
    }
}
