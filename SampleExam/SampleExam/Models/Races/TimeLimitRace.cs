using System.Text;

public class TimeLimitRace : Race
{
    private int goldTime;

    public int GoldTime
    {
        get { return goldTime; }
        set { goldTime = value; }
    }

    public TimeLimitRace(int length, string route, int prizePool, int goldTime) : base(length, route, prizePool)
    {
        this.GoldTime = goldTime;
    }

    public override string StartRace()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"{this.Route} - {this.Length}");
        if (this.Participants.Count == 0)
        {
            return "Cannot start the race with zero participants.";
        }
        foreach (Car participantsValue in Participants.Values)
        {
            var performance = (participantsValue.Horsepower / 100) * participantsValue.Acceleration * this.Length;

            sb.AppendLine($"{participantsValue.Brand} {participantsValue.Model} - {performance} s.");

            if (performance <= this.GoldTime)
            {
                sb.Append($"Gold Time, ${this.PrizePool}.");
            }
            else if (performance > this.GoldTime && performance <= this.GoldTime + 15)
            {
                sb.Append($"Silver Time, ${this.PrizePool * 0.5}.");
            }
            else if (performance > this.GoldTime + 15)
            {
                sb.Append($"Bronze Time, ${this.PrizePool * 0.3}.");
            }
        }
        this.Participants.Clear();
        return sb.ToString();
    }
}