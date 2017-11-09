using System;

public class Program
{
    private static void Main()
    {
        var firstDate = Console.ReadLine();
        var secondDate = Console.ReadLine();

        var daysBetweenTwoDates = new DateModifier();
        daysBetweenTwoDates.CalculateDifferenceBetweenTwoDates(firstDate, secondDate);
    }
}