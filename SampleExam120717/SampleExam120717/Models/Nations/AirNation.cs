using System.Collections.Generic;
using System.Text;

public class AirNation : Nation
{
    private List<AirBender> benders;
    private List<AirMonument> monuments;

    public AirNation() : base()
    {
        this.monuments = new List<AirMonument>();
        this.benders = new List<AirBender>();
    }
}