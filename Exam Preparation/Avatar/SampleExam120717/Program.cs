using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        string input = Console.ReadLine();
        var nationBuilder = new NationsBuilder();
        while (!input.Equals("Quit"))
        {
            var commandLine = input.Split().ToList();
            switch (commandLine[0])
            {
                case "Bender":
                    nationBuilder.AssignBender(commandLine);
                    break;

                case "Monument":
                    nationBuilder.AssignMonument(commandLine);
                    break;

                case "Status":
                    Console.WriteLine(nationBuilder.GetStatus(commandLine[1]));
                    break;

                case "War":
                    nationBuilder.IssueWar(commandLine[1]);
                    break;
            }

            input = Console.ReadLine();
        }

        Console.WriteLine(nationBuilder.GetWarsRecord());
    }
}