using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Redes
{
    public class Connect : Instruction
    {
        public Connect(int time, string[] args):base(time, args){}

        public override void Exec(Net_Components nc)
        {
            string[] aux = Args[0].Split('_');
            Device device1 = nc.Devices[aux[0]];
            Port port1 = device1.Ports[int.Parse(aux[1])-1];
                
            string[] aux2 = Args[1].Split('_');
            device1 = nc.Devices[aux2[0]];
            Port port2 = device1.Ports[int.Parse(aux2[1])-1];

            Wire wire = new Wire(port1, port2);
            port1.WireP = wire;
            port2.WireP = wire;
            nc.Wires.Add(wire);
        }
    }
}
