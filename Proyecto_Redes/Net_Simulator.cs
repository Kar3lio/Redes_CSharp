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
        private bool not_finished;
        public Net_Components NC { get; set; }
        public string Path { get; set; }
        
        public Queue<Instruction> Instructions { get; set; }
        public Net_Simulator()
        {
            NC = new Net_Components();
            signal_time = 2;
            not_finished = true;
        }

        public void Run_Simulation()
        {
            Instructions = Tools.Build_Instructions(Tools.Read_File(Path));
            Instruction current = Instructions.Dequeue();
            int i_time = signal_time;
            while (not_finished)
            {
                if (current.Time <= NC.Time)
                {
                    current.Exec(NC);
                    if (current is Send)
                    {
                        if (i_time == 0)
                        {
                            ((Send)current).Pointer++;
                            if (((Send)current).Pointer == current.Args[1].Length)
                            {
                                if (Instructions.Count > 0)
                                {
                                    current = Instructions.Dequeue();
                                }
                                else
                                {
                                    not_finished = false;
                                }
                            }
                            else
                            {
                                ((Send)current).Update();
                            }
                            i_time = signal_time;
                            Tools.Clear_Wires(NC.Wires);
                        }
                        else
                        {
                            i_time--;
                            Tools.Clear_Wires(NC.Wires);
                        }
                    }
                    else
                    {
                        if (Instructions.Count > 0)
                        {
                            current = Instructions.Dequeue();
                        }
                        else
                        {
                            not_finished = false;
                        }
                        i_time = signal_time;
                        Tools.Clear_Wires(NC.Wires);
                    }
                }
                
                NC.Time++;
            }
        }
    }
}
