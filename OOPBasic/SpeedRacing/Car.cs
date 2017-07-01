using System;

public class Car
{
    private string model;
    private double fuelAmount;
    private double fuelCostPerKm;
    private double distanceTraveled;

    public Car(string model, double fuelAmount, double fuelCostPerKm)
    {
        this.model = model;
        this.fuelAmount = fuelAmount;
        this.fuelCostPerKm = fuelCostPerKm;
        this.distanceTraveled = 0;
    }

    public void CanCarMoveKm(double amountOfKm)
    {
        var currentFuel = this.FuelAmount;
        var posibleKmToTravel = currentFuel / this.FuelCostPerKm;
        if (posibleKmToTravel >= amountOfKm)
        {
            this.fuelAmount -= amountOfKm * this.FuelCostPerKm;
            this.distanceTraveled += amountOfKm;
        }
        else
        {
            Console.WriteLine("Insufficient fuel for the drive");
        }
    }

    public string Model => model;
    public double FuelAmount => fuelAmount;
    public double FuelCostPerKm => fuelCostPerKm;
    public double DistanceTraveled => distanceTraveled;
}
