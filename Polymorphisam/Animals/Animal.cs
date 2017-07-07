
  public class Animal
  {
      private string name;
      private string favoriteFood;

      public string Name
      {
          get { return this.name; }
          set { this.name = value; }
      }

      public string FavoriteFood
      {
          get { return this.favoriteFood; }
          set { this.favoriteFood = value; }
      }

      public virtual string ExplainMyself()
      {
          return $"I am {this.name} and my favourite food is {this.favoriteFood}";
      }
  }

