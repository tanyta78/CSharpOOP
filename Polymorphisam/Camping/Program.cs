using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camping
{
   public class Program
    {
       public static void Main()
        {
            string input = Console.ReadLine();
            var camps = new Dictionary<string,Dictionary<string,int>>();

            while (!input.Equals("end"))
            {
                var tokens = input.Split();
                var name = tokens[0];
                var camper = tokens[1];
                var nights = int.Parse(tokens[2]);

                if (!camps.ContainsKey(name))
                {
                    camps.Add(name,new Dictionary<string, int>());
                }

                if (!camps[name].ContainsKey(camper))
                {
                    camps[name].Add(camper,0);
                }

                camps[name][camper] += nights;
                
                input = Console.ReadLine();
            }


            foreach (var camp in camps.OrderByDescending(c=>c.Value.Keys.Count).ThenBy(c=>c.Key.Length))
            {
                Console.WriteLine($"{camp.Key}: {camp.Value.Keys.Count}");
                foreach (var valueKey in camp.Value.Keys)
                {
                    Console.WriteLine($"***{valueKey}");
                }
                Console.WriteLine($"Total stay: {camp.Value.Values.Sum()} nights");
            }
        }
    }
}
