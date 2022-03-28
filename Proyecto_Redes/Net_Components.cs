using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Redes
{
    public class Net_Components
    {
        public Dictionary<string, Device> Devices { get; set; }
        public List<Wire> Wires { get; set; }
        
        public Net_Components()
        {
            Devices = new Dictionary<string, Device>();
            Wires = new List<Wire>();
        }
    }
}
