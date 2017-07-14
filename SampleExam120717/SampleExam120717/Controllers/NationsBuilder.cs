using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class NationsBuilder
{
    private List<Nation> nations;

    private Queue<string> warsIssued;

    public NationsBuilder()
    {
        var airNation = new AirNation();
        var waterNation = new WaterNation();
        var fireNation = new FireNation();
        var earthNation = new EarthNation();
        this.nations = new List<Nation>();
        nations.Add(airNation);
        nations.Add(waterNation);
        nations.Add(fireNation);
        nations.Add(earthNation);
        this.warsIssued = new Queue<string>();
    }

    public void AssignBender(List<string> benderArgs)
    {
        //Parameters – type (string), name (string), power (int), secondaryParameter (floating-point number
        var type = benderArgs[1];
        var name = benderArgs[2];
        var power = int.Parse(benderArgs[3]);
        var secParam = double.Parse(benderArgs[4]);

        Bender bender = null;

        switch (type)
        {
            case "Air":
                bender = new AirBender(name, power, secParam);
                this.nations.FirstOrDefault(n => n.GetType().Name == "AirNation").Benders.Add(bender);
                break;

            case "Fire":
                bender = new FireBender(name, power, secParam);
                this.nations.FirstOrDefault(n => n.GetType().Name == "FireNation").Benders.Add(bender);
                break;

            case "Water":
                bender = new WaterBender(name, power, secParam);
                this.nations.FirstOrDefault(n => n.GetType().Name == "WaterNation").Benders.Add(bender);
                break;

            case "Earth":
                bender = new EarthBender(name, power, secParam);
                this.nations.FirstOrDefault(n => n.GetType().Name == "EarthNation").Benders.Add(bender);
                break;
        }
    }

    public void AssignMonument(List<string> monumentArgs)
    {
        //	Monument {type} {name} {affinity}
        var type = monumentArgs[1];
        var name = monumentArgs[2];
        var affinity = int.Parse(monumentArgs[3]);

        Monument monument = null;

        switch (type)
        {
            case "Air":
                monument = new AirMonument(name, affinity);
                this.nations.FirstOrDefault(n => n.GetType().Name == "AirNation").Monuments.Add(monument);
                break;

            case "Fire":
                monument = new FireMonument(name, affinity);
                this.nations.FirstOrDefault(n => n.GetType().Name == "FireNation").Monuments.Add(monument);
                break;

            case "Water":
                monument = new WaterMonument(name, affinity);
                this.nations.FirstOrDefault(n => n.GetType().Name == "WaterNation").Monuments.Add(monument);
                break;

            case "Earth":
                monument = new EarthMonument(name, affinity);
                this.nations.FirstOrDefault(n => n.GetType().Name == "EarthNation").Monuments.Add(monument);
                break;
        }
    }

    public string GetStatus(string nationsType)
    {
        var nameToCheck = nationsType + "Nation";
        var result = this.nations.Where(n => n.GetType().Name == nameToCheck).FirstOrDefault();

        return result.ToString().Trim();
    }

    public void IssueWar(string nationsType)
    {
        warsIssued.Enqueue(nationsType);

        foreach (var nation in nations)
        {
            nation.GetTotalPowerPoints();
        }

        var winner = nations.OrderByDescending(n => n.TotalPower).First();

        foreach (var nation in nations.Where(n => n.GetType().Name != winner.GetType().Name))
        {
            nation.Benders.Clear();
            nation.Monuments.Clear();
        }
    }

    public string GetWarsRecord()
    {
        var sb = new StringBuilder();
        var count = 1;
        while (warsIssued.Count != 0)
        {
            sb.AppendLine($"War {count} issued by {warsIssued.Dequeue()}");
            count++;
        }
        return sb.ToString().Trim();
    }
}