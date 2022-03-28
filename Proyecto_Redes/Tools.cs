using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Proyecto_Redes
{
    public class Tools
    {
        static readonly string path = "C:\\Users\\Karel\\Desktop\\Tester\\";
        public static void Write_File(int time, string device_name, int port, string action, string data, bool a_collision)
        {
            string collision = "ok";
            if (a_collision)
            {
                collision = "collision";
            }
            StreamWriter sw = new StreamWriter(path + device_name + ".txt",true);
            sw.WriteLine(time + " " + device_name + " " + port + " " + action + " " + data + " " + collision);
            sw.Close();
        }
        public static List<string> Read_File(string path)
        {
            StreamReader sr = new StreamReader(path);
            List<string> lines = new List<string>();
            string line = sr.ReadLine();
            while(line!=null)
            {
                lines.Add(line);
                line = sr.ReadLine();
            }
            sr.Close();
            return lines;
            
        }
        public static List<Instruction> Build_Instructions(List<string> lines)
        {
            List<Instruction> l = new List<Instruction>();
            Instruction i = null;
            foreach (string item in lines)
            {
                string[] temp = item.Split();
                int time = int.Parse(temp[0]);
                string[] aux  = new string[temp.Length - 2];
                temp.CopyTo(aux, 2);
                switch (temp[1])
                {
                    case "connect":
                        i = new Connect(time, aux);
                        break;
                    case "create":
                        aux = new string[temp.Length - 3];
                        temp.CopyTo(aux, 3);

                        if (temp[2] == "hub")
                            i = new Create_Hub(time, aux);

                        else if(temp[2] == "host")
                            i = new Create_Host(time, aux);

                        break;
                    case "disconnect":
                        i = new Disconnect(time, aux);
                        break;
                    case "send":
                        i = new Send(time, aux);
                        break;
                    default:
                        break;
                }
                l.Add(i);
            }
            return l;
        }
    }
}
