using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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