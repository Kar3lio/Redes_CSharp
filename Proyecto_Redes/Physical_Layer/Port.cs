﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Redes.Physical_Layer
{
    public class Port
    {
        public string Name { get; set; }
        public Port(string name)
        {
            this.Name = name;
        }
    }
}