
  public class MoodFactory
    {
        public static Mood GetMood(int happinessPoint)
        {
            if (happinessPoint<-5)
            {
                return new Angry();
            }
            else if(happinessPoint>=-5 && happinessPoint<0)
            {
                return new Sad();
            }
            else if (happinessPoint >= 0 && happinessPoint <= 15)
            {
                return new Happy();
            }
            else
            {
                return new JavaScript();
            }
        }

    }

