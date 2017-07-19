using System.Collections.Generic;

public class EarthNation : Nation
{
    private List<EarthBender> benders;
    private List<EarthMonument> monuments;

    public EarthNation() : base()
    {
        this.benders = new List<EarthBender>();
        this.monuments = new List<EarthMonument>();
    }
}