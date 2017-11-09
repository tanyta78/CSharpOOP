using System;

public abstract class Vehicle
{
    private double fuelQuantity;
    private double fuelConsumptionPerKm;
    private double tankCapacity;

    public double FuelQuantity
    {
        get { return this.fuelQuantity; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
            this.fuelQuantity = value;
        }
    }

    public double FuelConsumptionPerKm
    {
        get { return this.fuelConsumptionPerKm; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Consumption must be positive");
            }
            this.fuelConsumptionPerKm = value;
        }
    }

    public double TankCapacity
    {
        get { return this.tankCapacity; }
        set { this.tankCapacity = value; }
    }

    public abstract void Drive(double distance);

    public abstract void Refuel(double quantity);
}