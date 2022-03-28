using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Redes
{
    public class Create_Host : Instruction
    {
        public Create_Host(int time, string[] args) : base(time, args){}

        public override void Exec(Net_Components nc)
        {
            Host h = new Host(Args[0]);
            nc.Devices.Add(h.Name, h);
        }
    }
}
