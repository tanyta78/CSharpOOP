using PawInc.Models.Centers;

namespace PawInc.Models.Animals
{
    public class Cat : Animal
    {
        private int intelligenceCoefficient;

        public Cat(string name, int age, AdoptionCenter center, int intelligenceCoefficient) : base(name, age, center)
        {
            this.IntelligenceCoefficient = intelligenceCoefficient;
        }

        public int IntelligenceCoefficient
        {
            get { return intelligenceCoefficient; }
            set { intelligenceCoefficient = value; }
        }
    }
}