using System;

public class Car : Vehicle
{
    public override void Drive(double distance)
    {
        var consumtionPerDistance = distance * (base.FuelConsumptionPerKm + 0.9);

        if (consumtionPerDistance > this.FuelQuantity)
        {
            Console.WriteLine("Car needs refueling");
        }
        else
        {
            Console.WriteLine($"Car travelled {distance} km");
            base.FuelQuantity -= consumtionPerDistance;
        }
    }

    public override void Refuel(double quantity)
    {
        if (quantity <= 0)
        {
            throw new ArgumentException("Fuel must be a positive number");
        }

        if (base.FuelQuantity + quantity > base.TankCapacity)
        {
            throw new ArgumentException("Cannot fit fuel in tank");
        }
        base.FuelQuantity += quantity;
    }

    public Car(double fuel, double consumption, double tank)
    {
        base.FuelQuantity = fuel;
        base.FuelConsumptionPerKm = consumption;
        base.TankCapacity = tank;
    }
}