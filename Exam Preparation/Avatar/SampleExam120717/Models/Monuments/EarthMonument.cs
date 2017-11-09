public class EarthMonument : Monument
{
    private int earthAffinity;

    public EarthMonument(string name, int earthAffinity) : base(name)
    {
        this.EarthAffinity = earthAffinity;
    }

    public int EarthAffinity
    {
        get { return earthAffinity; }
        set { earthAffinity = value; }
    }

    public override string ToString()
    {
        return $"Earth Monument: {this.Name}, Earth Affinity: {this.EarthAffinity}";
    }

    public override int GetMonumentPoints()
    {
        return this.EarthAffinity;
    }
}