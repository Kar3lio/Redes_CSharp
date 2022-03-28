using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Redes
{
    public class Net_Simulator
    {
        int signal_time;
        public Net_Components NC { get; set; }
        public string Path { get; set; }
        public int Time { get; set; }
        public Queue<Instruction> Instructions { get; set; }
        public Net_Simulator()
        {
            NC = new Net_Components();
            Path = "efvadfv";
            signal_time = 2;
        }

        public void Run_Simulation()
        {
            Instructions = Tools.Build_Instructions(Tools.Read_File(Path));
            Instruction current = Instructions.Dequeue();
            int i_time = signal_time;
            while (true)
            {
                if (current.Time <= Time)
                {
                    current.Exec(NC);
                }
                if(current is Send)
                {
                    if(i_time==0)
                    {
                        current = Instructions.Dequeue();
                        i_time = signal_time;
                        Tools.Clear_Wires(NC.Wires);
                    }
                    else
                    {
                        i_time--;
                    }
                }
                Time++;
            }
        }
    }
}
