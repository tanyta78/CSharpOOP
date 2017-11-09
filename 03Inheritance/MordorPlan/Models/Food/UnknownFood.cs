public class UnknownFood : Food
{
    private string name;
    private int pointOfHappiness;

    public UnknownFood(string name)
    {
        this.name = name;
        this.pointOfHappiness = -1;
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