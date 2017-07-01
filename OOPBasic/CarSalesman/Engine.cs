
   public class Engine
   {
    
       private string model;
       private string power;
       private string displacement;
       private string efficiency;

    public Engine(string model, string power)
    {
        this.Model = model;
        this.Power = power;
        this.Displacement = "n/a";
        this.Efficiency = "n/a";
    }

    public Engine(string model, string power, string displacement, string efficiency) : this(model, power)
    {
        this.Displacement = displacement;
        this.Efficiency = efficiency;
    }

    public string Model
       {
           get { return model; }
           set { model = value; }
       }

       public string Power
       {
           get { return power; }
           set { power = value; }
       }

       public string Displacement
       {
           get { return displacement; }
           set { displacement = value; }
       }

       public string Efficiency
       {
           get { return efficiency; }
           set { efficiency = value; }
       }
   }

