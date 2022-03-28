using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Redes.Physical_Layer
{
    public class Host : Device
    {
        public Host(string name)
        {
            this.Name = name;

            Port p = new Port(name + "_1");
            this.Ports = new List<Port>(1);
            Ports.Add(p);

        }
    }
}
