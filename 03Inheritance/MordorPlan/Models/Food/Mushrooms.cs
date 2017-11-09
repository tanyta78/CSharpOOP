public class Mushrooms : Food
{
    private string name;
    private int pointOfHappiness;

    public Mushrooms(string name)
    {
        this.name = name;
        this.pointOfHappiness = -10;
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