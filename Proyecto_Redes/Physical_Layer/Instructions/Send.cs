using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Redes
{
    public class Send : Instruction
    {
        public Send(int time, string[] args) : base(time, args){}

        public override void Exec(Net_Components nc)
        {
            Device transmitter = nc.Devices[Args[0]];
            Data send_d = new Data();
            
            ///el bfs pone en los cables que alcanza el dato que se esta transmitiendo
            Tools.BFS(nc, transmitter, send_d);
            
        }
    }
}
