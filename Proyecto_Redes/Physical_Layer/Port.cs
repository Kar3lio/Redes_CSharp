using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Redes
{
    public class Port
    {
        public string Name { get; set; }
        public Wire WireP { get; set; }
        public Data DataP { get; set; }
        public Port(string name)
        {
            Name = name;
            WireP = null;
        }
    }
}
