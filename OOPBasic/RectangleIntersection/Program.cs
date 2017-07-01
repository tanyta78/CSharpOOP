using System;
using System.Collections.Generic;
using System.Linq;

internal class Program
{
    private static void Main()
    {
        var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var numberOfRectangels = line[0];
        var numberOfIntersectionChecks = line[1];

        var rectangels = new List<Rectangle>();

        for (int i = 0; i < numberOfRectangels; i++)
        {
            var input = Console.ReadLine().Split();
            rectangels.Add(new Rectangle(input[0],double.Parse(input[1]), double.Parse(input[2]), double.Parse(input[3]), double.Parse(input[4])));
        }

        for (int checksIndex = 0; checksIndex < numberOfIntersectionChecks; checksIndex++)
        {
            var checkInfo = Console.ReadLine().Split();
            var firstRectId = checkInfo[0];
            var secRectId = checkInfo[1];

            var firstRect = rectangels.First(r => r.ID == firstRectId);
            var secondRect = rectangels.First(r => r.ID == secRectId);

            Console.WriteLine(firstRect.IsIntersect(secondRect) ? "true" : "false");
        }
    }
}