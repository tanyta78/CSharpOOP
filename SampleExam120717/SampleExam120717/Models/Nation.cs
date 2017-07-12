using System.Collections.Generic;

public abstract class Nation
{
    private List<Bender> benders;
    private List<Monument> monuments;
    private double power;

    public Nation()
    {
        this.Power = 0;
        this.Monuments = new List<Monument>();
        this.Benders = new List<Bender>();
    }

    public List<Bender> Benders
    {
        get { return benders; }
        set { benders = value; }
    }

    public List<Monument> Monuments
    {
        get { return monuments; }
        set { monuments = value; }
    }

    public double Power
    {
        get { return power; }
        set { power = value; }
    }
}

