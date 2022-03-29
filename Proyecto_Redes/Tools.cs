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
        public static void Write_File(string path,int time, string device_name, int port, string action, string data, bool a_collision)
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

        internal static void BFS(Net_Components nc, Device start, Data data)
        {
            Dictionary<string, bool> visited = Get_Falsev(nc.Devices);
            Dictionary<string, int> d = Get_Negd(nc.Devices);
            Dictionary<string, Device> pi = Get_NullPi(nc.Devices);
            
            Dictionary<string, List<Device>> adj = Get_AdjacencyList(nc.Devices, nc.Wires);

            Queue<Device> q = new Queue<Device>();
            q.Enqueue(start);
            visited[start.Name] = true;
            d[start.Name] = 0;
            pi[start.Name] = null;

            while (q.Count != 0)
            {
                Device u = q.Dequeue();
                foreach (Device v in adj[u.Name])
                {
                    if (d[v.Name] == -1) 
                    {   //aqui descubrimos un nuevo nodo hay que ver que se hace, por ahora poner Data en el cable(arista)
                        //mas adelante el dato se envia a una pc en especifico, en ese caso cuando la encontremos paramos
                        d[v.Name] = d[u.Name] + 1;
                        pi[v.Name] = u;
                        q.Enqueue(v);
                        Wire w = Get_Wire(u.Name,v.Name,nc.Wires);
                        w.Data = data;
                    }
                }
            }
        }

        private static Wire Get_Wire(string name1, string name2, List<Wire> wires)
        {
            foreach (var item in wires)
            {
                string host1 = item.Port1.Name.Split('_')[0];
                string host2 = item.Port2.Name.Split('_')[0];
                if ((host1 == name1 && host2 == name2) || (host1 == name2 && host2 == name1))
                {
                    return item;
                }
            }
            return null;
        }

        private static Dictionary<string, Device> Get_NullPi(Dictionary<string, Device> devices)
        {
            Dictionary<string, Device> pi = new Dictionary<string, Device>();
            foreach (string item in devices.Keys)
            {
                pi.Add(item, null);
            }
            return pi;
        }

        private static Dictionary<string, int> Get_Negd(Dictionary<string, Device> devices)
        {
            Dictionary<string, int> d = new Dictionary<string, int>();
            foreach (string item in devices.Keys)
            {
                d.Add(item, -1);
            }
            return d;
        }

        private static Dictionary<string, bool> Get_Falsev(Dictionary<string, Device> devices)
        {
            Dictionary<string, bool> visited = new Dictionary<string, bool>();
            foreach (string item in devices.Keys)
            {
                visited.Add(item, false);
            }
            return visited;
        }

        private static Dictionary<string, List<Device>> Get_AdjacencyList
                                                            (Dictionary<string, Device> devices, List<Wire> wires)
        {
            Dictionary<string, List<Device>> adj = new Dictionary<string, List<Device>>();
            string name_d1;
            string name_d2;
            foreach (string item in devices.Keys)
            {
                adj.Add(item, new List<Device>());
            }
            foreach (Wire item in wires)
            {
                name_d1 = item.Port1.Name.Split('_')[0];
                name_d2 = item.Port2.Name.Split('_')[0];
                adj[name_d1].Add(devices[name_d2]);
                adj[name_d2].Add(devices[name_d1]);
            }
            return adj;
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

        internal static void Clear_Wires(List<Wire> wires)
        {
            foreach (Wire item in wires)
            {
                item.Data = null;
            }
        }

        public static Queue<Instruction> Build_Instructions(List<string> lines)
        {
            Queue<Instruction> q = new Queue<Instruction>();
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
                q.Enqueue(i);
            }
            q.OrderBy(p => p.Time);
            return q;
        }
    }
}
