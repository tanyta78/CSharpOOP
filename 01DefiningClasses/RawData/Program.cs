using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        int numberOfCars = int.Parse(Console.ReadLine());
        var carsList = new List<Car>();

        for (int i = 0; i < numberOfCars; i++)
        {
            var carsInfo = Console.ReadLine().Split();
            var carModel = carsInfo[0];
            /*“<Model> <EngineSpeed> <EnginePower> <CargoWeight> <CargoType> <Tire1Pressure> <Tire1Age> <Tire2Pressure> <Tire2Age> <Tire3Pressure> <Tire3Age> <Tire4Pressure> <Tire4Age>*/
            var carEngineSpeed = int.Parse(carsInfo[1]);
            var carEnginePower = int.Parse(carsInfo[2]);
            var carCargoWeight = int.Parse(carsInfo[3]);
            var carCargoType = carsInfo[4];
            var Tire1Pressure = double.Parse(carsInfo[5]);
            var Tire1Age = int.Parse(carsInfo[6]);
            var Tire2Pressure = double.Parse(carsInfo[7]);
            var Tire2Age = int.Parse(carsInfo[8]);
            var Tire3Pressure = double.Parse(carsInfo[9]);
            var Tire3Age = int.Parse(carsInfo[10]);
            var Tire4Pressure = double.Parse(carsInfo[11]);
            var Tire4Age = int.Parse(carsInfo[12]);

            carsList.Add(new Car(carModel, new Engine(carEngineSpeed, carEnginePower), new Cargo(carCargoWeight, carCargoType), new Tire(Tire1Pressure, Tire1Age), new Tire(Tire2Pressure, Tire2Age), new Tire(Tire3Pressure, Tire3Age), new Tire(Tire4Pressure, Tire4Age)));
        }

        var commandLine = Console.ReadLine();
        switch (commandLine)
        {
            case "flamable":
                foreach (var car in carsList.Where(c => c.Cargo.Type == "flamable" && c.Engine.Power > 250))
                {
                    Console.WriteLine($"{car.Model}");
                }
                break;

            case "fragile":
                foreach (var car in carsList.Where(c => c.Cargo.Type == "fragile" && (c.Tire1.Pressure < 1 || c.Tire2.Pressure < 1 || c.Tire3.Pressure < 1 || c.Tire4.Pressure < 1)))
                {
                    Console.WriteLine($"{car.Model}");
                }
                break;
        }
    }
}