using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace exsercises
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Users> users = new List<Users>();

            using (StreamReader stream = new StreamReader ("../../../Stream and File.txt"))
            {
                while (!stream.EndOfStream)
                {
                    string[] line = stream.ReadLine().Split(" - ",StringSplitOptions.RemoveEmptyEntries);
                    string name = line[0];
                    double point = double.Parse(line[1]);
                    users.Add(new Users(name, point));
                }

            }
            Console.WriteLine($"Students numbers is: {users.Count}");
            //Console.WriteLine();
            foreach (Users user in users.OrderByDescending(x=>x.Point).ThenByDescending(x=>x.Point))
            {
               
                Console.WriteLine($"{user.Name} -> {user.Point}");
            }
            
        }
    }
}
class Users
{
    public string Name { get; set; }
    public double Point { get; set; }
    public Users(string name, double point)
    {
        Name = name;
        Point = point;
    }
}

