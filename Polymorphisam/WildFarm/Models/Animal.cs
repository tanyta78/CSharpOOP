public abstract class Animal
{
    private string animalName;
    private string animalType;
    private double animalWeight;
    private int foodEaten;

    public Animal(string animalName, string animalType, double animalWeight)
    {
        this.AnimalName = animalName;
        this.AnimalType = animalType;
        this.AnimalWeight = animalWeight;
        this.FoodEaten = 0;
    }

    public string AnimalName
    {
        get { return animalName; }
        set { animalName = value; }
    }

    public string AnimalType
    {
        get { return animalType; }
        set { animalType = value; }
    }

    public double AnimalWeight
    {
        get { return animalWeight; }
        set { animalWeight = value; }
    }

    public int FoodEaten
    {
        get { return foodEaten; }
        set { foodEaten = value; }
    }

    public abstract void MakeSound();

    public abstract void Eat(Food food);
}