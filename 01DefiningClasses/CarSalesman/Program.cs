using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        int numberOfEngines = int.Parse(Console.ReadLine());
        var engines = new List<Engine>();

        for (int i = 0; i < numberOfEngines; i++)
        {
            var input = Console.ReadLine().Split();
            var model = input[0];
            var power = input[1];
            var displacement = "n/a";
            var efficiency = "n/a";
            if (input.Length > 2)
            {
                var result = 0;
                if (int.TryParse(input[2], out result))
                {
                    displacement = input[2];
                    if (input.Length > 3)
                    {
                        efficiency = input[3];
                    }
                }
                else
                {
                    efficiency = input[2];
                }
            }
            engines.Add(new Engine(model, power, displacement, efficiency));
        }

        int numberOfCars = int.Parse(Console.ReadLine());
        var cars = new List<Car>();

        for (int i = 0; i < numberOfCars; i++)
        {
            var input = Console.ReadLine().Split();
            var model = input[0];
            var engineType = input[1];
            var engine = engines.First(e => e.Model == engineType);
            var weight = "n/a";
            var color = "n/a";
            if (input.Length > 2)
            {
                var result = 0;
                if (int.TryParse(input[2], out result))
                {
                    weight = input[2];
                    if (input.Length > 3)
                    {
                        color = input[3];
                    }
                }
                else
                {
                    color = input[2];
                }
            }

            cars.Add(new Car(model, engine, weight, color));
        }

        foreach (var car in cars)
        {
            Console.WriteLine(car.ToString());
        }
    }
}