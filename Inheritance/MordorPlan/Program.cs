using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MordorPlan
{
   public class Program
    {
       public static void Main()
       {
           string input = Console.ReadLine();
           try
           {
               var foods = input.Split();
                Gandalf gandalf = new Gandalf();
                gandalf.setFoods(foods);
                gandalf.setMood();
                Console.WriteLine(gandalf);
           }
           catch (Exception e)
           {
               Console.WriteLine(e.Message);
               
           }
       }
    }
}
