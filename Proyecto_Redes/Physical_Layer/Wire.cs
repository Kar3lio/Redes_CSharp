using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Redes
{
    public class Wire
    {
        public Port Port1 { get; set; }
        public Port Port2 { get; set; }
        public Data Data { get; set; }

        public Wire(Port port1, Port port2)
        {
            Port1 = port1;
            Port2 = port2;
            Data = null;
        }
    }
}
