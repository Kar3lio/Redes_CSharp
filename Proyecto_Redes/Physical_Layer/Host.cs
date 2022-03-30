using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Redes
{
    public class Host : Device
    {
        public Host(string name)
        {
            Name = name;

            Port p = new Port(name + "_1");
            Ports = new List<Port>(1);
            Ports.Add(p);
        }

        public override void ReadData(int time)
        {
            Data newData = Ports[0].WireP.Data;
            if (newData!= Ports[0].DataP)
            {
                Tools.Write_File("Data\\" + Name + ".txt", time, Name, Ports[0].Name, "receive", newData.Value, false);
                Ports[0].DataP = newData;
            }
        }
    }
}
