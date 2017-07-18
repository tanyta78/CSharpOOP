﻿using System;
using System.Linq;
using System.Text;

public abstract class Provider
{
    private string id;
    private double energyOutput;

    public Provider(string id, double energyOutput)
    {
        this.Id = id;
        this.EnergyOutput = energyOutput;
    }

    public double EnergyOutput
    {
        get { return energyOutput; }
        protected set
        {
            if (value < 0 || value >= 10000)
            {
                throw new ArgumentException("Provider is not registered, because of it's EnergyOutput");
            }

            energyOutput = value;
        }
    }

    public string Id
    {
        get { return id; }
        protected set { id = value; }
    }

    public override string ToString()

    {
        var sb = new StringBuilder();
        string type = this.GetType().Name;
        var result = type.Take(type.Length - type.IndexOf("Provider"));
        sb.AppendLine($"{result} Provider – {this.Id}");
        sb.AppendLine($"Energy Output: {this.EnergyOutput}");
        return sb.ToString().Trim();
    }
}