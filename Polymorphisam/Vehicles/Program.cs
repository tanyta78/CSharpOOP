using System;

public class Program
{
    public static void Main()
    {
        try
        {

            var carInfo = Console.ReadLine().Split();
            var truckInfo = Console.ReadLine().Split();
            var busInfo = Console.ReadLine().Split();

            Car car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]), double.Parse(carInfo[3]));
            Truck truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]), double.Parse(truckInfo[3]));
            Bus bus = new Bus(double.Parse(busInfo[1]), double.Parse(busInfo[2]), double.Parse(busInfo[3]));

            var numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                try
                {


                    var commandInput = Console.ReadLine().Split();
                    double quantity;
                    if (double.TryParse(commandInput[2], out quantity))
                    {
                        switch (commandInput[0])
                        {
                            case "Drive":

                                if (commandInput[1] == "Car")
                                {
                                    car.Drive(quantity);
                                }
                                else if (commandInput[1] == "Truck")
                                {
                                    truck.Drive(quantity);
                                }
                                else
                                {
                                    bus.Drive(quantity);
                                }
                                break;

                            case "Refuel":
                                if (commandInput[1] == "Car")
                                {
                                    car.Refuel(quantity);
                                }
                                else if (commandInput[1] == "Truck")
                                {
                                    truck.Refuel(quantity);
                                }
                                else
                                {
                                    bus.Refuel(quantity);
                                }
                                break;

                            case "DriveEmpty":
                                bus.DriveEmpty(quantity);
                                break;

                            default: throw new ArgumentException("Invalid input!");
                        }
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);

                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:f2}");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);

        }
    }
}