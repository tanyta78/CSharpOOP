﻿public class FireBender : Bender
{
    private double heatAggression;

    public FireBender(string name, int power, double heatAggression) : base(name, power)
    {
        this.HeatAggression = heatAggression;
    }

    public double HeatAggression
    {
        get { return heatAggression; }
        set { heatAggression = value; }
    }

    public override string ToString()
    {
        return $"Fire Bender: {this.Name}, Power: {this.Power}, Heat Aggression: {this.HeatAggression:f2}";
    }

    public override double GetBenderTotalPower()
    {
        return this.Power * this.HeatAggression;
    }
}