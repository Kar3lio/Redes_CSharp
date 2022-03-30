using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Redes
{
    public class Hub : Device
    {
        
        public Hub(string name, int ports_count)
        {
            Name = name;
            Ports = new List<Port>(ports_count);
            Port p;
            for (int i = 1; i <= ports_count; i++)
            {
                p = new Port(name + "_" + i);
                Ports.Add(p);
            }
        }

        public override void ReadData(int time)
        {
            Port receiving_port = null;
            foreach (Port item in Ports)
            {
                if (item.WireP.Data != null)
                {
                    receiving_port = item;
                }
            }
            if (receiving_port.DataP != receiving_port.WireP.Data)
            {
                Tools.Write_File("Data\\" + Name + ".txt",time,Name,receiving_port.Name,"receive",receiving_port.DataP.Value,false);
                foreach (Port item in Ports)
                {
                    if (item.WireP != null)
                    {
                        item.DataP = item.WireP.Data;
                        if (receiving_port.Name != item.Name)
                        {
                            Tools.Write_File("Data\\" + Name + ".txt", time, Name, item.Name, "send", item.DataP.Value, false);
                        }
                    }
                }
            }
        }
    }
}
