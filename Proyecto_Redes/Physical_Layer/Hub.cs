using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Redes.Physical_Layer
{
    public class Hub
    {
        //Host y Hub heredan de Device para poder luego hacer el grafo de dispositivos
        public List<Port> Ports { get; set; }
        public string Name { get; set; }

        public Hub(int ports_count)
        {
        }
    }
}
