using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Redes
{
    public class Send : Instruction
    {
        public int Pointer { get; set; }
        public Data Data { get; set; }
        public Send(int time, string[] args) : base(time, args)
        {
            Pointer = 0;
            Data = new Data();
            Data.Value = int.Parse(Args[1][Pointer].ToString());
        }

        public override void Exec(Net_Components nc)
        {
            Device transmitter = nc.Devices[Args[0]];
           
            ///el bfs pone en los cables que alcanza el dato que se esta transmitiendo
            Tools.BFS(nc, transmitter, Data);
            
        }
    }
}
