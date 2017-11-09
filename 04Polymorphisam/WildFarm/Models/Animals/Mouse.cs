using System;

public class Mouse : Mammal
{
    public Mouse(string animalName, string animalType, double animalWeight, string livingRegion) : base(animalName, animalType, animalWeight, livingRegion)
    {
    }

    public override void MakeSound()
    {
        Console.WriteLine("SQUEEEAAAK!");
    }

    public override void Eat(Food food)
    {
        if (food is Vegetable)
        {
            this.FoodEaten += food.Quantity;
        }
        else
        {
            throw new ArgumentException("Mouses are not eating that type of food!");
        }
    }
}