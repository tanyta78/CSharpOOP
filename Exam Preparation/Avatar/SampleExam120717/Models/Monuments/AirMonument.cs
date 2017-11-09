public class AirMonument : Monument
{
    private int airAffinity;

    public AirMonument(string name, int airAffinity) : base(name)
    {
        this.AirAffinity = airAffinity;
    }

    public int AirAffinity
    {
        get { return airAffinity; }
        set { airAffinity = value; }
    }

    public override string ToString()
    {
        return $"Air Monument: {this.Name}, Air Affinity: {this.AirAffinity}";
    }

    public override int GetMonumentPoints()
    {
        return this.AirAffinity;
    }
}