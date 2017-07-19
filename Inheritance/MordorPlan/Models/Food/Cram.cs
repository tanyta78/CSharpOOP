public class Cram : Food
{
    private string name;
    private int pointOfHappiness;

    public Cram(string name)
    {
        this.name = name;
        this.pointOfHappiness = 2;
    }

    public override string getName()
    {
        return this.name;
    }

    public override int getPointOfHappiness()
    {
        return this.pointOfHappiness;
    }
}