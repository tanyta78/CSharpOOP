using System.Collections.Generic;

public class NationsBuilder
{
    private AirNation airNation;
    private WaterNation waterNation;
    private FireNation fireNation;
    private EarthNation earthNation;

    public void AssignBender(List<string> benderArgs)
    {
        //Parameters – type (string), name (string), power (int), secondaryParameter (floating-point number
        var type = benderArgs[0];
        var name = benderArgs[1];
        var power = int.Parse(benderArgs[2]);
        var secParam = double.Parse(benderArgs[3]);

        Bender bender = null;

        switch (type)
        {
            case "Air":
                bender = new AirBender(name, power, secParam);
               this.airNation.Benders.Add(bender);
                break;

            case "Fire":
                bender = new FireBender(name, power, secParam);
                fireNation.Benders.Add(bender);
                break;

            case "Water":
                bender = new WaterBender(name, power, secParam);
                waterNation.Benders.Add(bender);
                break;

            case "Earth":
                bender = new EarthBender(name, power, secParam);
                earthNation.Benders.Add(bender);
                break;
        }
    }

    public void AssignMonument(List<string> monumentArgs)
    {
        //	Monument {type} {name} {affinity}
        var type = monumentArgs[0];
        var name = monumentArgs[1];
        var affinity = int.Parse(monumentArgs[2]);

        Monument monument = null;

        switch (type)
        {
            case "Air":
                monument = new AirMonument(name, affinity);
                airNation.Monuments.Add(monument);
                break;

            case "Fire":
                monument = new FireMonument(name, affinity);
                fireNation.Monuments.Add(monument);
                break;

            case "Water":
                monument = new WaterMonument(name, affinity);
                waterNation.Monuments.Add(monument);
                break;

            case "Earth":
                monument = new EarthMonument(name, affinity);
                earthNation.Monuments.Add(monument);
                break;
        }
    }

    public string GetStatus(string nationsType)
    {
        var result = "";
        switch (nationsType)
        {
            case "Air":
                result = airNation.ToString();
                break;

            case "Water":
                result = waterNation.ToString();
                break;

            case "Fire":
                result = fireNation.ToString();
                break;

            case "Earth":
                result = earthNation.ToString();
                break;
        }
        return result;
    }

    public void IssueWar(string nationsType)
    {
        //TODO: Add some logic here …
    }

    public string GetWarsRecord()
    {
        return "";
    }
}