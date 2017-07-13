using System.Collections.Generic;
using System.Text;

public class WaterNation : Nation
{
    private List<WaterBender> benders;
    private List<WaterMonument> monuments;

    public WaterNation() : base()
    {
        this.benders = new List<WaterBender>();
        this.monuments = new List<WaterMonument>();
    }
}