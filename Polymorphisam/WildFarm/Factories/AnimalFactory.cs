
using System;

public class AnimalFactory
{
    public static Animal GetAnimal(string[] animalInfo)
    {
        var animalType = animalInfo[0];
        var animalName = animalInfo[1];
        var animalWeight = double.Parse(animalInfo[2]);
        var animalLivingRegion = animalInfo[3];
        var animalBreed = string.Empty;
        if (animalInfo.Length > 4 && animalType == "Cat")
        {
            animalBreed = animalInfo[4];
        }
        try
        {
            switch (animalType)
            {
                case "Cat": return new Cat(animalName,animalType,animalWeight,animalLivingRegion,animalBreed);
                case "Mouse": return new Mouse(animalName,animalType,animalWeight,animalLivingRegion);
                case "Zebra": return new Zebra(animalName,animalType,animalWeight,animalLivingRegion);
               
                default: return new Tiger(animalName,animalType,animalWeight,animalLivingRegion);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }
}

