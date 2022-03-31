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
        private bool control;
        public Send(int time, string[] args) : base(time, args)
        {
            Pointer = 0;
            Data = new Data();
            Data.Value = int.Parse(Args[1][Pointer].ToString());
            control = true;
        }

        public override void Exec(Net_Components nc)
        {
            Device transmitter = nc.Devices[Args[0]];
            if (control)
            {
                Tools.Write_File("Data\\" + transmitter.Name + ".txt", nc.Time, transmitter.Name, transmitter.Ports[0].Name, "send", Data.Value, false);
            }
            control = false;
            ///el bfs pone en los cables que alcanza el dato que se esta transmitiendo
            Tools.BFS(nc, transmitter, Data);
            
        }
        public void Update()
        {
            if (Pointer < Args[1].Length)
            {
                Data = new Data();
                Data.Value = int.Parse(Args[1][Pointer].ToString());
                control = true;
            }
        }
    }
}
