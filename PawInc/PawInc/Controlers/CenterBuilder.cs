using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PawInc.Models;
using PawInc.Models.Animals;
using PawInc.Models.Centers;

namespace PawInc.Controlers
{
    public class CenterBuilder
    {
        private List<Center> centers;
        private List<Animal> adoptedAnimals;
        private List<Animal> cleanedAnimals;
        private List<Animal> castratedAnimals;

        public CenterBuilder()
        {
            this.centers = new List<Center>();
            this.adoptedAnimals = new List<Animal>();
            this.cleanedAnimals = new List<Animal>();
            this.castratedAnimals = new List<Animal>();
        }

        public void RegisterCleansingCenter(string name)
        {
            var clener = new CleansingCenter(name);
            centers.Add(clener);
        }

        public void RegisterAdoptionCenter(string name)
        {
            var adopter = new AdoptionCenter(name);
            centers.Add(adopter);
        }

        public void RegisterCastrationCenter(string name)
        {
            var castrator = new CastrationCenter(name);
            centers.Add(castrator);
        }

        public void RegisterDog(string name, int age, int learnedCommands, string adoptionCenterName)
        {
            AdoptionCenter center = (AdoptionCenter)centers.Find(c => c.Name == adoptionCenterName);
            var dog = new Dog(name, age, center, learnedCommands);
            center.StoredAnimals.Add(dog);
        }

        public void RegisterCat(string name, int age, int intelligenceCoefficient, string adoptionCenterName)
        {
            AdoptionCenter center = (AdoptionCenter)centers.Find(c => c.Name == adoptionCenterName);
            var cat = new Cat(name, age, center, intelligenceCoefficient);
            center.StoredAnimals.Add(cat);
        }

        public void SendForCleansing(string adoptionCenterName, string cleansingCenterName)
        {
            AdoptionCenter adopter = (AdoptionCenter)centers.Find(c => c.Name == adoptionCenterName);

            CleansingCenter clener = (CleansingCenter)centers.Find(c => c.Name == cleansingCenterName);

            adopter.SendForCleaning(clener);
        }

        public void SendForCastration(string adoptionCenterName, string castrationCenterName)
        {
            AdoptionCenter adopter = (AdoptionCenter)centers.Find(c => c.Name == adoptionCenterName);

            CastrationCenter castrator = (CastrationCenter)centers.Find(c => c.Name == castrationCenterName);

            adopter.SendForCastration(castrator);
        }

        public void Cleanse(string cleansingCenterName)
        {
            CleansingCenter clener = (CleansingCenter)centers.Find(c => c.Name == cleansingCenterName);
            var animalsToClean = clener.StoredAnimals;
            foreach (var storedAnimal in animalsToClean)
            {
                storedAnimal.CleansingStatus = true;
                var centerToReturn = storedAnimal.Center;
                centerToReturn.StoredAnimals.Add(storedAnimal);
                this.cleanedAnimals.Add(storedAnimal);
            }
            clener.StoredAnimals.Clear();
        }

        public void Adopt(string adoptionCenterName)
        {
            AdoptionCenter adopter = (AdoptionCenter)centers.Find(c => c.Name == adoptionCenterName);
            var animalsToAdopt = adopter.StoredAnimals.Where(a => a.CleansingStatus == true).ToList();
            foreach (var animal in animalsToAdopt)
            {
                adopter.StoredAnimals.Remove(animal);
                this.adoptedAnimals.Add(animal);
            }
        }

        public void Castrate(string castrationCenterName)
        {
            CastrationCenter castrator = (CastrationCenter)centers.Find(c => c.Name == castrationCenterName);
            var animalsToCastrate = castrator.StoredAnimals;
            foreach (var storedAnimal in animalsToCastrate)
            {
                storedAnimal.IsCastrated = true;
                var centerToReturn = storedAnimal.Center;
                centerToReturn.StoredAnimals.Add(storedAnimal);
                this.castratedAnimals.Add(storedAnimal);
            }
            castrator.StoredAnimals.Clear();
        }

        public string CastrationStatistic()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Paw Incorporative Castration Statistics");
            var castrationCenters = centers.Where(c => c.GetType().Name == "CastrationCenter");
            sb.AppendLine($"Castration Centers: {castrationCenters.Count()}");
            sb.Append("Adopted Animals: ");
            sb.AppendLine(this.castratedAnimals.Count >= 0 ? string.Join(", ", this.castratedAnimals.OrderBy(a => a.Name, System.StringComparer.Ordinal).Select(a => a.Name)) : "None");
            return sb.ToString().Trim();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Paw Incorporative Regular Statistics");
            var adoptionsCenters = centers.Where(c => c.GetType().Name == "AdoptionCenter");
            var cleanesingCenters = centers.Where(c => c.GetType().Name == "CleansingCenter");
            sb.AppendLine($"Adoption Centers: {adoptionsCenters.Count()}");
            sb.AppendLine($"Cleansing Centers: {cleanesingCenters.Count()}");

            sb.Append("Adopted Animals: ");
            sb.AppendLine(this.adoptedAnimals.Count > 0 ? string.Join(", ", this.adoptedAnimals.OrderBy(a => a.Name, System.StringComparer.Ordinal).Select(a => a.Name)) : "None");

            sb.Append("Cleansed Animals: ");
            sb.AppendLine(this.cleanedAnimals.Count > 0 ? string.Join(", ", this.cleanedAnimals.OrderBy(a => a.Name, System.StringComparer.Ordinal).Select(a => a.Name)) : "None");

            var animalsForAdopt = adoptionsCenters.Select(c => c.StoredAnimals.Where(a => a.CleansingStatus == true).ToList().Count).Sum();
            sb.Append($"Animals Awaiting Adoption: ");
            sb.AppendLine(animalsForAdopt >= 0 ? $"{animalsForAdopt}" : "None");

            var animalsForCleaning = cleanesingCenters.Select(c => c.StoredAnimals.Where(a => a.CleansingStatus == false).ToList().Count).Sum();
            sb.Append($"Animals Awaiting Cleansing: ");
            sb.AppendLine(animalsForCleaning >= 0 ? $"{animalsForCleaning}" : "None");
            return sb.ToString().Trim();
        }
    }
}