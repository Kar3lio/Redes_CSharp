using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Redes.Physical_Layer
{
    public class Host : Device
    {
        public Port Port1 { get; set; } 

        public Host(string name)
        {
            this.Name = name;
            Port1 = new Port(name + "_1");
        }
    }
}
