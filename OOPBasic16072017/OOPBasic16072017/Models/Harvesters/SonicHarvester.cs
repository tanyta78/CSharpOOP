using System;
using System.Linq;
using System.Text;

public class SonicHarvester : Harvester
{
    private int sonicFactor;

    public SonicHarvester(string id, double oreOutput, double energyRequirement, int sonicFactor) : base(id, oreOutput, energyRequirement)
    {
        this.SonicFactor = sonicFactor;
        this.EnergyRequirement = energyRequirement / this.SonicFactor;
    }

    public int SonicFactor
    {
        get { return sonicFactor; }
        protected set
        {
            if (value <= 0)
            {
                throw new ArgumentException($"Harvester is not registered, because of it's SonicFactor");
            }
            sonicFactor = value;
        }
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine($"Sonic Harvester - {this.Id}");
        sb.AppendLine($"Ore Output: {this.OreOutput}");
        sb.AppendLine($"Energy Requirement: {this.EnergyRequirement}");
        return sb.ToString().Trim();
    }
}