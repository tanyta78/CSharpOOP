using System;
using System.Linq;
using System.Text;

public abstract class Harvester
{
    private string id;
    private double oreOutput;
    private double energyRequirement;

    public Harvester(string id, double oreOutput, double energyRequirement)
    {
        this.Id = id;
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;
    }

    public double OreOutput
    {
        get { return oreOutput; }
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException($"Harvester is not registered, because of it's OreOutput");
            }

            oreOutput = value;
        }
    }

    public double EnergyRequirement
    {
        get { return energyRequirement; }
        protected set
        {
            if (value > 20000 || value < 0)
            {
                throw new ArgumentException($"Harvester is not registered, because of it's EnergyRequirment");
            }

            energyRequirement = value;
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
        var result = type.Take(type.Length - type.IndexOf("Harvester"));
        sb.AppendLine($"{result} Harvester - {this.Id}");
        sb.AppendLine($"Ore Output: {this.OreOutput}");
        sb.AppendLine($"Energy Requirement: {this.EnergyRequirement}");
        return sb.ToString().Trim();
    }
}