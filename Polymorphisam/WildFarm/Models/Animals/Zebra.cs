using System;

public class Zebra : Mammal
{
    public Zebra(string animalName, string animalType, double animalWeight, string livingRegion) : base(animalName, animalType, animalWeight, livingRegion)
    {
    }

    public override void MakeSound()
    {
        Console.WriteLine("Zs");
    }

    public override void Eat(Food food)
    {

        if (food is Vegetable)
        {
            this.FoodEaten += food.Quantity;
        }
        else
        {
            throw new ArgumentException("Zebras are not eating that type of food!");
        }
    }
}