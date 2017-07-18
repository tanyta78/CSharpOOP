using System;
using System.Collections.Generic;

public class HarvesterFactory
{
    private static string except;

    public static string Except
    {
        get { return except; }
        set { except = value; }
    }

    public static Harvester CreateHarvester(List<string> arguments)
    {
        string type = arguments[0];
        string id = arguments[1];
        double oreOutput = double.Parse(arguments[2]);
        double energyReqirment = double.Parse(arguments[3]);
        int sonicFactor = 0;
        string result;
        Harvester harvester = null;
        if (type == "Sonic")
        {
            sonicFactor = int.Parse(arguments[4]);
        }

        try
        {
            switch (type)
            {
                case "Sonic":
                    harvester = new SonicHarvester(id, oreOutput, energyReqirment, sonicFactor);
                    break;

                case "Hammer":
                    harvester = new HammerHarvester(id, oreOutput, energyReqirment);
                    break;
            }
        }
        catch (ArgumentException e)
        {
            Except = e.Message;
        }

        return harvester;
    }
}