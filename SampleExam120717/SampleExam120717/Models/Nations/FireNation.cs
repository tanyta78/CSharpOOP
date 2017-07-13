using System.Collections.Generic;
using System.Text;

public class FireNation : Nation
{
    private List<FireBender> benders;
    private List<FireMonument> monuments;

    public FireNation() : base()
    {
        this.benders = new List<FireBender>();
        this.monuments = new List<FireMonument>();
    }
}