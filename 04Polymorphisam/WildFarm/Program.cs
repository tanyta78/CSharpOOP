using System;

public class Program
{
    public static void Main()
    {
        var input = Console.ReadLine();
        while (input != "End")
        {
            //read animal info
            var animalInfo = input.Split();
            var animalType = animalInfo[0];
            var animalName = animalInfo[1];
            var animalWeight = double.Parse(animalInfo[2]);
            var animalLivingRegion = animalInfo[3];
            var animalBreed = string.Empty;
            Animal currentAnimal = null;
            if (animalInfo.Length > 4 && animalType == "Cat")
            {
                animalBreed = animalInfo[4];
            }
            try
            {
                switch (animalType)
                {
                    case "Cat": currentAnimal = new Cat(animalName, animalType, animalWeight, animalLivingRegion, animalBreed); break;
                    case "Mouse": currentAnimal = new Mouse(animalName, animalType, animalWeight, animalLivingRegion); break;
                    case "Zebra": currentAnimal = new Zebra(animalName, animalType, animalWeight, animalLivingRegion); break;
                    case "Tiger": currentAnimal = new Tiger(animalName, animalType, animalWeight, animalLivingRegion); break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            //animal make sound
            currentAnimal.MakeSound();

            //read food info
            var foodInfo = Console.ReadLine().Split();

            try
            {
                var quantity = int.Parse(foodInfo[1]);
                switch (foodInfo[0])
                {
                    case "Meat": currentAnimal.Eat(new Meat(quantity)); break;
                    case "Vegetable": currentAnimal.Eat(new Vegetable(quantity)); break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine(currentAnimal);

            input = Console.ReadLine();
        }
    }
}