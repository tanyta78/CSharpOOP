using System.Collections.Generic;

namespace PawInc.Models
{
    public abstract class Center
    {
        private string name;
        private List<Animal> storedAnimals;

        public Center(string name)
        {
            this.Name = name;
            this.StoredAnimals = new List<Animal>();
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public List<Animal> StoredAnimals
        {
            get
            {
                return storedAnimals;
            }

            set
            {
                storedAnimals = value;
            }
        }
    }
}