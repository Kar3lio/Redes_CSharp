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

        public override bool Exec()
        {
            throw new NotImplementedException();
        }
    }
}
