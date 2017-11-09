using System.Collections.Generic;
using System.Text;

public class Gandalf
{
    private int happiness_point = 0;

    private int happinessPoint;
    private List<Food> foods;
    private Mood mood;

    public Gandalf()
    {
        this.happinessPoint = happiness_point;
        this.foods = new List<Food>();
        this.setMood();
    }

    public int getHappinessPoint()
    {
        return happinessPoint;
    }

    private void setHappinessPoint()
    {
        foreach (var food in foods)
        {
            this.happinessPoint += food.getPointOfHappiness();
        }
    }

    public void setMood()
    {
        mood = MoodFactory.GetMood(this.happinessPoint);
    }

    public void setFoods(string[] foods)
    {
        foreach (var food in foods)
        {
            this.foods.Add(FoodFactory.GetFood(food));
        }

        if (foods.Length >= 1)
        {
            setHappinessPoint();
        }
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"{this.happinessPoint}").Append($"{this.mood}");
        return sb.ToString();
    }
}