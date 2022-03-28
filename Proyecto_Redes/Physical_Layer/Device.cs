using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Redes.Physical_Layer
{
    public abstract class Device
    {
        public string Name { get; set; }
        public List<Port> Ports { get; set; }
    }
}
