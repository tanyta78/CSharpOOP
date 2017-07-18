﻿using System.Text;

public class PressureProvider : Provider
{
    public PressureProvider(string id, double energyOutput) : base(id, energyOutput)
    {
        this.EnergyOutput = energyOutput * 150 / 100;
    }

    public override string ToString()

    {
        var sb = new StringBuilder();
        sb.AppendLine($"Pressure Provider - {this.Id}");
        sb.AppendLine($"Energy Output: {this.EnergyOutput}");
        return sb.ToString().Trim();
    }
}