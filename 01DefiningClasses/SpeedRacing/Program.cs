using System;
using System.Collections.Generic;

public class Program
{
    private static void Main(string[] args)
    {
        int numberOfCars = int.Parse(Console.ReadLine());
        var cars = new List<Car>();

        for (int i = 0; i < numberOfCars; i++)
        {
            var infoLine = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var model = infoLine[0];
            var fuelAmount = double.Parse(infoLine[1]);
            var fuelCostForKm = double.Parse(infoLine[2]);
            cars.Add(new Car(model, fuelAmount, fuelCostForKm));
        }
        var commandLine = Console.ReadLine();
        while (!commandLine.Equals("End"))
        {
            var commands = commandLine.Split();
            var carName = commands[1];
            var kmToDrive = double.Parse(commands[2]);

            var currentCar = cars.Find(c => c.Model == carName);
            currentCar.CanCarMoveKm(kmToDrive);

            commandLine = Console.ReadLine();
        }

        foreach (var car in cars)
        {
            Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.DistanceTraveled}");
        }
    }
}