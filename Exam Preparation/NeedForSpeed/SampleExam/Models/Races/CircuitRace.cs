using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CircuitRace : Race
{
    private int laps;

    public CircuitRace(int length, string route, int prizePool, int laps) : base(length, route, prizePool)
    {
        this.Laps = laps;
    }

    public int Laps
    {
        get { return this.laps; }
        private set { this.laps = value; }
    }

    public override string StartRace()
    {
        var sb = new StringBuilder();
        int moneyWon = 0;
        int end = Math.Min(this.Participants.Count, 4);
        int durabilityLost = this.Laps * 100;

        sb.AppendLine($"{this.Route} - {this.Length * this.Laps}");
        if (this.Participants.Count == 0)
        {
            return "Cannot start the race with zero Participants.";
        }

        List<Car> winners = this.Participants.Values.OrderByDescending(x => x.GetOverallPerformance()).ToList();

        for (int i = 1; i <= end; i++)
        {
            if (i == 1)
            {
                moneyWon = (int)(this.PrizePool * 0.4);
            }
            else if (i == 2)
            {
                moneyWon = (int)(this.PrizePool * 0.3);
            }
            else if (i == 3)
            {
                moneyWon = (int)(this.PrizePool * 0.2);
            }
            else if (i == 4)
            {
                moneyWon = (int)(this.PrizePool * 0.1);
            }
            var performancePoints = winners[i - 1].GetOverallPerformance() - durabilityLost;

            sb.Append($"{i}. {winners[i - 1].Brand} {winners[i - 1].Model} " +
                      $"{performancePoints}PP - ${moneyWon}");

            if (i < end)
            {
                sb.AppendLine();
            }
        }
        foreach (var car in this.Participants.Values)
        {
            car.Durability -= durabilityLost;
        }

        this.Participants.Clear();
        return sb.ToString();
    }
}