   public class FoodFactory
    {
        public static Food GetFood(int quantity,string food)
        {
            
            switch (food)
            {
                case "Meat": return new Meat(quantity);
                case "Vegetable": return new Vegetable(quantity);
               
                default: return new UnknownFood(quantity);
            }
        }
}

public class UnknownFood : Food
{
    public UnknownFood(int quantity)
    {
       
    }
}

