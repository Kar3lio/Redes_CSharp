using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Redes
{
    public abstract class Instruction
    {
        public int Time { get; }
        public string[] Args { get; }

        public Instruction(int time, string[] args)
        {
            Time = time;
            Args = args;
        }
        public abstract bool Exec();
    }
}
