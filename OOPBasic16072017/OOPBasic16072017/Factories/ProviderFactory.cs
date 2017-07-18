using System;
using System.Collections.Generic;

public class ProviderFactory
{
    private static string except;

    public static string Except
    {
        get { return except; }
        set { except = value; }
    }

    public static Provider CreateProvider(List<string> arguments)
    {
        string type = arguments[0];
        string id = arguments[1];
        double energyOutput = double.Parse(arguments[2]);

        Provider provider = null;

        try
        {
            switch (type)
            {
                case "Solar":
                    provider = new SolarProvider(id, energyOutput);

                    break;

                case "Pressure":
                    provider = new PressureProvider(id, energyOutput);

                    break;
            }
        }
        catch (ArgumentException e)
        {
            Except = e.Message;
        }
        return provider;
    }
}