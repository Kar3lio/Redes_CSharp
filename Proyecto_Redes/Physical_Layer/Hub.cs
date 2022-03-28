﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Redes.Physical_Layer
{
    public class Hub : Device
    {
        //Host y Hub heredan de Device para poder luego hacer el grafo de dispositivos
        public List<Port> Ports { get; set; }
        public string Name { get; set; }

        public Hub(string name, int ports_count)
        {
            this.Name = name;
            Ports = new List<Port>(ports_count);
            Port p;
            for (int i = 1; i <= ports_count; i++)
            {
                p = new Port(name + "_" + i);
                Ports.Add(p);
            }
        }
    }
}