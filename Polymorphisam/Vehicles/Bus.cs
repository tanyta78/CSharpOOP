using System;

public class Bus : Vehicle
{
    public override void Drive(double distance)
    {
        var consumtionPerDistance = distance * (base.FuelConsumptionPerKm + 1.4);

        if (consumtionPerDistance > base.FuelQuantity)
        {
            Console.WriteLine("Bus needs refueling");
        }
        else
        {
            Console.WriteLine($"Bus travelled {distance} km");
            base.FuelQuantity -= consumtionPerDistance;
        }
    }

    public void DriveEmpty(double distance)
    {
        var consumtionPerDistance = distance * base.FuelConsumptionPerKm;

        if (consumtionPerDistance > base.FuelQuantity)
        {
            Console.WriteLine("Bus needs refueling");
        }
        else
        {
            Console.WriteLine($"Bus travelled {distance} km");
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

    public Bus(double fuel, double consumption, double tank)
    {
        base.FuelQuantity = fuel;
        base.FuelConsumptionPerKm = consumption;
        base.TankCapacity = tank;
    }
}