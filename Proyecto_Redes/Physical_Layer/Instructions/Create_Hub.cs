using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Redes
{
    public class Create_Hub : Instruction
    {
        public Create_Hub(int time, string[] args) : base(time, args){}

        public override void Exec(Net_Components nc)
        {
            Hub h = new Hub(Args[0], int.Parse(Args[1]));
            nc.Devices.Add(h.Name, h);
        }
    }
}
