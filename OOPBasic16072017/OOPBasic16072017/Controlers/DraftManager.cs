using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DraftManager
{
    private Dictionary<string, Harvester> harvesters;
    private Dictionary<string, Provider> providers;
    private string actualMode;
    private double storedEnergy;
    private double oreGattered;

    public DraftManager()
    {
        this.harvesters = new Dictionary<string, Harvester>();
        this.providers = new Dictionary<string, Provider>();
        this.ActualMode = "Full";
        this.StoredEnergy = 0;
        this.OreGattered = 0;
    }

    public string ActualMode
    {
        get { return actualMode; }
        set { actualMode = value; }
    }

    public double StoredEnergy
    {
        get { return storedEnergy; }
        set { storedEnergy = value; }
    }

    public double OreGattered
    {
        get { return oreGattered; }
        set { oreGattered = value; }
    }

    public string RegisterHarvester(List<string> arguments)
    {
        string type = arguments[0];
        string id = arguments[1];
        double oreOutput = double.Parse(arguments[2]);
        double energyReqirment = double.Parse(arguments[3]);
        int sonicFactor = 0;
        string result;

        if (type == "Sonic")
        {
            sonicFactor = int.Parse(arguments[4]);
        }
        Harvester harvester = HarvesterFactory.CreateHarvester(arguments);
        if (harvester != null)
        {
            harvesters.Add(id, harvester);
            result = $"Successfully registered {type} Harvester - {id}";
        }
        else
        {
            result = HarvesterFactory.Except;
        }
        return result;
    }

    public string RegisterProvider(List<string> arguments)
    {
        string type = arguments[0];
        string id = arguments[1];
        double energyOutput = double.Parse(arguments[2]);

        string result = null;
        Provider provider;

        try
        {
            switch (type)
            {
                case "Solar":
                    provider = new SolarProvider(id, energyOutput);
                    providers.Add(id, provider);
                    break;

                case "Pressure":
                    provider = new PressureProvider(id, energyOutput);
                    providers.Add(id, provider);
                    break;
            }
            result = $"Successfully registered {type} Provider - {id}";
        }
        catch (ArgumentException e)
        {
            result = ProviderFactory.Except;
        }
        return result;
    }

    public string Day()
    {
        var energyProvided = providers.Values.Select(p => p.EnergyOutput).Sum();
        StoredEnergy += energyProvided;
        var neededEnergyPerDay = harvesters.Values.Select(h => h.EnergyRequirement).Sum();
        var summedOreOutput = harvesters.Values.Select(h => h.OreOutput).Sum();

        switch (this.ActualMode)
        {
            case "Half":
                neededEnergyPerDay = neededEnergyPerDay * 60 / 100;
                summedOreOutput = summedOreOutput / 2;
                break;

            case "Energy":
                neededEnergyPerDay = 0;
                summedOreOutput = 0;
                break;
        }

        if (neededEnergyPerDay <= StoredEnergy)
        {
            this.StoredEnergy -= neededEnergyPerDay;
            this.OreGattered += summedOreOutput;
        }
        else
        {
            summedOreOutput = 0;
        }

        var sb = new StringBuilder();
        sb.AppendLine("A day has passed.");
        sb.AppendLine($"Energy Provided: {energyProvided}");
        sb.AppendLine($"Plumbus Ore Mined: {summedOreOutput}");

        return sb.ToString().Trim();
    }

    public string Mode(List<string> arguments)
    {
        this.ActualMode = arguments[0];
        return $"Successfully changed working mode to {ActualMode} Mode";
    }

    public string Check(List<string> arguments)
    {
        string id = arguments[0];
        string result;
        if (this.providers.ContainsKey(id))
        {
            result = providers[id].ToString();
        }
        else if (this.harvesters.ContainsKey(id))
        {
            result = harvesters[id].ToString();
        }
        else
        {
            result = $"No element found with id - {id}";
        }
        return result;
    }

    public string ShutDown()
    {
        var sb = new StringBuilder();
        sb.AppendLine("System Shutdown");
        sb.AppendLine($"Total Energy Stored: {this.StoredEnergy}");
        sb.AppendLine($"Total Mined Plumbus Ore: {this.OreGattered}");

        return sb.ToString().Trim();
    }
}