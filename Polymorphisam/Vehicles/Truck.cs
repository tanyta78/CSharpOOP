
using System;

public class Truck : Vehicle
{
    public override void Drive(double distance)
    {
        var consumtionPerDistance = distance * (base.FuelConsumptionPerKm + 1.6);

        if (consumtionPerDistance > base.FuelQuantity)
        {
            Console.WriteLine("Truck needs refueling");
        }
        else
        {
            Console.WriteLine($"Truck travelled {distance} km");
            base.FuelQuantity -= consumtionPerDistance;
        }
    }

    public override void Refuel(double quantity)
    {
        if (quantity <= 0)
        {
            throw new ArgumentException("Fuel must be a positive number");
        }
        base.FuelQuantity += 0.95 * quantity;
    }

    public Truck(double fuel, double consumption,double tank)
    {
        base.FuelQuantity = fuel;
        base.FuelConsumptionPerKm = consumption;
        base.TankCapacity = tank;
    }
}

