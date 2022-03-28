using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Redes
{
    public class Send : Instruction
    {
        public Send(int time, string[] args) : base(time, args)
        {
        }

        public override void Exec(Net_Components nc)
        {
            Device a = nc.Devices[Args[0]];
            foreach (Wire item in nc.Wires)
            {
                item.Data.Value = int.Parse(Args[1]);
            }
        }
    }
}
