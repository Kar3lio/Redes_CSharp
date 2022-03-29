using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Redes
{
    public class Disconnect:Instruction
    {
        public Disconnect(int time, string[] args) : base(time, args){}

        public override void Exec(Net_Components nc)
        {
            foreach (Wire item in nc.Wires)
            {
                if(item.Port1.Name==Args[0])
                {
                    nc.Wires.Remove(item);
                }
            }            
        }
    }
}
