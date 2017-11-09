public class HoneyCake : Food
{
    private string name;
    private int pointOfHappiness;

    public HoneyCake(string name)
    {
        this.name = name;
        this.pointOfHappiness = 5;
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