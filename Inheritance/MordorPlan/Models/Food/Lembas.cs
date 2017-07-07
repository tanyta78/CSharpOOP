
   public class Lembas:Food
    {
        private string name;
        private int pointOfHappiness;

        public Lembas(string name)
        {
            this.name = name;
            this.pointOfHappiness = 3;
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

