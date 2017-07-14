using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawInc.Models.Centers
{
    public class AdoptionCenter : Center
    {
        public AdoptionCenter(string name) : base(name)
        {
        }

        public void SendForCleaning(CleansingCenter clener)
        {
            var animalsForCleaning = StoredAnimals.Where(a => a.CleansingStatus == false).ToList();
            foreach (var animal in animalsForCleaning)
            {
                clener.StoredAnimals.Add(animal);
                this.StoredAnimals.Remove(animal);
            }
        }

        public void SendForCastration(CastrationCenter castrator)
        {
            var animalsForCastration = StoredAnimals.Where(a => a.IsCastrated == false).ToList();
            foreach (var animal in animalsForCastration)
            {
                castrator.StoredAnimals.Add(animal);
                this.StoredAnimals.Remove(animal);
            }
        }
    }
}