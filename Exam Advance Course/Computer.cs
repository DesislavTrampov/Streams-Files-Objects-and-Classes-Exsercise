using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace ComputerArchitecture
{
    public class Computer
    {
        public Computer(string model,int capacity)
        {
            Model = model;
            Capacity = capacity;

            Multiprocessor = new List<CPU>();


        }


        public string Model { get; set; }

        public int Capacity { get; set; }

        public List <CPU> Multiprocessor{ get; set; }

        public int Count => Multiprocessor.Count;


        public void Add(CPU cpu)
        {
            if(Multiprocessor.Count >= 0)
            {
                Multiprocessor.Add(cpu);

            }
        }
        public bool Remove(string brand)
        {
            bool isvalid = false;
            foreach(CPU cpu in Multiprocessor)
            {
                if(cpu.Brand == brand)
                {
                    Multiprocessor.Remove(cpu);
                    isvalid = true;
                    break;
                    
                }
            }
            if (isvalid)
            {
                return true;
            }
            else
            {
                return false;
            }


        }
        public CPU MostPowerful()
        {
          return  Multiprocessor.OrderByDescending(x => x.Frequency).First();

        }
        public CPU GetCPU(string brand)
        {
          CPU cPU = Multiprocessor.FindAll(x=>x.Brand== brand).FirstOrDefault();
            if(cPU == null)
            {
                return null;
            }
            else
            {
                return cPU;
            }
           
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();


            sb.AppendLine($"CPUs in the Computer {Model}:");
            foreach(CPU cpu in Multiprocessor)
            {
                sb.AppendLine(cpu.ToString());
            }
            return sb.ToString().TrimEnd();
        }

    }
}
