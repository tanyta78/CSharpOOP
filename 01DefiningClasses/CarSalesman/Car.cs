public class Car
{
    private string model;
    private Engine engine;
    private string color;
    private string weight;

    public Car(string model, Engine engine)
    {
        this.Model = model;
        this.Engine = engine;
        this.Weight = "n/a";
        this.Color = "n/a";
    }

    public Car(string model, Engine engine, string weight, string color) : this(model, engine)
    {
        this.Weight = weight;
        this.Color = color;
    }

    public string Model
    {
        get { return model; }
        set { model = value; }
    }

    public Engine Engine
    {
        get { return engine; }
        set { engine = value; }
    }

    public string Weight
    {
        get { return weight; }
        set { weight = value; }
    }

    public string Color
    {
        get { return color; }
        set { color = value; }
    }

    public override string ToString()
    {
        return $"{this.Model}:\n  {this.Engine.Model}:\n    Power: {this.Engine.Power}\n    Displacement: {this.Engine.Displacement}\n    Efficiency: { this.Engine.Efficiency}\n  Weight: {this.Weight}\n  Color: {this.Color}";
    }
}