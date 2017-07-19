public class Melon : Food
{
    private string name;
    private int pointOfHappiness;

    public Melon(string name)
    {
        this.name = name;
        this.pointOfHappiness = 1;
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